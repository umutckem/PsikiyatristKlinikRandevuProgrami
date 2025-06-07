using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Bildirim;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.GeriBildirim;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.KlinikRapor;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Kullanici;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Odeme;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Randevu;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Recete;
using PsikiyatristKlinikRandevuProgrami.Application.Randevu.Handlers; // CQRS handler'larýn olduðu namespace
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SignalR; // Add for SignalR
using PsikiyatristKlinikRandevuProgrami.Web.Hubs; // Add for AppointmentHub

namespace PsikiyatristKlinikRandevuProgram.web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Application Services
            builder.Services.AddScoped<ICommandFacade, CommandFacade>();

            builder.Services.AddScoped<IKullaniciCommandService, KullaniciCommandService>();
            builder.Services.AddScoped<IKullaniciQueryService, KullaniciQueryService>();

            builder.Services.AddScoped<IRandevuCommandService, RandevuCommandService>();
            builder.Services.AddScoped<IRandevuQueryService, RandevuQueryService>();

            builder.Services.AddScoped<IKlinikRaporCommandService, KlinikRaporCommandService>();
            builder.Services.AddScoped<IKlinikRaporQueryService, KlinikRaporQueryService>();

            builder.Services.AddScoped<IOdemeCommandService, OdemeCommandService>();
            builder.Services.AddScoped<IOdemeQueryService, OdemeQueryService>();

            builder.Services.AddScoped<IReceteCommandService, ReceteCommandService>();
            builder.Services.AddScoped<IReceteQueryService, ReceteQueryService>();

            builder.Services.AddScoped<IGeriBildirimCommandService, GeriBildirimCommandService>();
            builder.Services.AddScoped<IGeriBildirimQueryService, GeriBildirimQueryService>();

            builder.Services.AddScoped<IBildirimCommandService, BildirimCommandService>();
            builder.Services.AddScoped<IBildirimQueryService, BildirimQueryService>();

            builder.Services.AddScoped<ICommandFacade, CommandFacade>();
            builder.Services.AddHostedService<RandevuIptalConsumerService>();

            builder.Services.AddScoped<ISubject, Subject>();
            builder.Services.AddScoped<IObserver, BildirimObserver>();

            builder.Services.AddScoped<CommandInvoker>(); // Buraya eklendi


            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetRandevularByPsikiyatristIdQueryHandler).Assembly);
            });

            // Database
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Identity
            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddRoles<IdentityRole>() // Rol desteði
            .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddSignalR();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
                endpoints.MapHub<AppointmentHub>("/appointmentHub"); // Map SignalR hub
            });

            app.Run();
        }
    }
}
