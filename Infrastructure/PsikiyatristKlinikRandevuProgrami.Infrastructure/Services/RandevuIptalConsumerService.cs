using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System;

public class RandevuIptalConsumerService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<RandevuIptalConsumerService> _logger;
    private IConnection _connection;
    private IModel _channel;

    public RandevuIptalConsumerService(IServiceProvider serviceProvider, ILogger<RandevuIptalConsumerService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;

        var factory = new ConnectionFactory() { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(queue: "randevu_iptal_queue",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            _logger.LogInformation($"Randevu iptal mesajı alındı: {message}");

            if (int.TryParse(message, out int randevuId))
            {
                try
                {
                    // Scoped servis kullanımı (DBContext) için scope açıyoruz
                    using var scope = _serviceProvider.CreateScope();
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var randevu = await dbContext.randevus.FindAsync(randevuId);
                    if (randevu != null)
                    {
                        dbContext.randevus.Remove(randevu);
                        await dbContext.SaveChangesAsync();
                        _logger.LogInformation($"Randevu (Id={randevuId}) başarıyla silindi.");
                    }
                    else
                    {
                        _logger.LogWarning($"Randevu (Id={randevuId}) bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Randevu silinirken hata oluştu.");
                }
            }
            else
            {
                _logger.LogWarning($"Geçersiz randevuId mesajı: {message}");
            }

            // Mesaj işlendi olarak işaretle
            _channel.BasicAck(ea.DeliveryTag, false);
        };

        _channel.BasicConsume(queue: "randevu_iptal_queue",
                             autoAck: false,
                             consumer: consumer);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
        base.Dispose();
    }
}
