using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services;

namespace PsikiyatristKlinikRandevuProgram.web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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


            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
