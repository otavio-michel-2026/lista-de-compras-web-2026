using ListaDeCompras.WebApp.Compartilhado;

namespace ListaDeCompras.WebApp;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddPresentation();

        var app = builder.Build();

        app.UseStaticFiles();
        app.UseRouting();
        app.MapDefaultControllerRoute();

        app.Run();
    }
}
