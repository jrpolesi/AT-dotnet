using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Services;

namespace TravelApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<TravelAppContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("TravelAppConnection")));

        builder.Services.AddScoped<IClienteService, ClienteService>();
        builder.Services.AddScoped<ICidadeDestinoService, CidadeDestinoService>();
        builder.Services.AddScoped<IPaisDestinoService, PaisDestinoService>();
        builder.Services.AddScoped<IPacoteTuristicoService, PacoteTuristicoService>();
        builder.Services.AddScoped<IReservaService, ReservaService>();

        builder.Services.AddRazorPages();

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

        app.MapGet("/", context => {
            context.Response.Redirect("/Reservas/Index");
            return Task.CompletedTask;
        });

        app.MapRazorPages();

        app.Run();
    }
}