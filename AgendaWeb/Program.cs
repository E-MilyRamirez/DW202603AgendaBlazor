using AgendaWeb.Components;
using AgendaWeb.Data;
using AgendaWeb.Data.Commands;
using AgendaWeb.Services;

namespace AgendaWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            //Builder es un patron de diseño
            //connectionString va después del CreateBuilder y antes del build, porque es parte de la configuración que se va a usar en la aplicación, y se obtiene de la configuración del builder.

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            //Inyección de dependencias
            builder.Services.AddScoped<SQLServer>(_ => new SQLServer(connectionString));
            builder.Services.AddScoped<ContactoCommand>();
            builder.Services.AddScoped<ContactoServices>();
            builder.Services.AddScoped<TipoContactoCommand>();
            builder.Services.AddScoped<TipoContactoServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
