using Vaskebjørnen.Models;
using Vaskebjørnen.Repositories;

namespace Vaskebjørnen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //string connectionString = "Server=localhost;Database=Vaskebjørnen;Integrated Security=True;;Encrypt=False";

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSingleton<IRepo<Resident>,ResidentRepo>();
            builder.Services.AddTransient<ResidentRepo>();
            builder.Services.AddSingleton<IRepo<Machine>,MachineRepo>();
            builder.Services.AddTransient<MachineRepo>();
            builder.Services.AddSingleton<IRepo<Booking>,BookingRepo>();
            builder.Services.AddTransient<BookingRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
