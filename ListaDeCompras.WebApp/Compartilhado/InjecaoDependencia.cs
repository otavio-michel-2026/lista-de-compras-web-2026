using ListaDeCompras.WebApp.Compartilhado.ModuloBase;
using ListaDeCompras.WebApp.ModuloCategoria;
using ListaDeCompras.WebApp.ModuloProduto;

namespace ListaDeCompras.WebApp.Compartilhado;

public static class InjecaoDependencia
{
    // Camada de Apresentação
    public static void AddPresentation(this IServiceCollection services)
    {
        services.AddControllersWithViews().AddRazorOptions(options =>
        {
            // Resetar a configuração padrão do MVC
            options.ViewLocationFormats.Clear();

            // Views dos módulos: /ModuloCaixa/Apresentacao/Views/Listar.cshtml
            options.ViewLocationFormats.Add("/Modulo{1}/Views/{0}.cshtml");

            // Views compartilhadas: /Compartilhado/Apresentacao/Views/_Layout.cshtml
            options.ViewLocationFormats.Add("/Compartilhado/Views/{0}.cshtml");
        });

        services.AddAutoMapper(config =>
        {
            //config.AddProfile<(*)Profile>();
            config.AddProfile<ProdutoProfile>();
            config.AddProfile<CategoriaProfile>();
        });
    }

    // Camada de Infraestrutura
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(provider =>
        {
            ContextoJson contextoJson = new();

            contextoJson.Carregar();

            return contextoJson;
        });
        //services.AddScoped<IRepositorio(*), Repositorio(*)>();
        services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
        services.AddScoped<IRepositorioProduto, RepositorioProduto>();
    }

    // Camada de Aplicação
    public static void AddServices(this IServiceCollection services)
    {
        //services.AddScoped<Servico(*)>();
        services.AddScoped<ServicoProduto>();
        services.AddScoped<ServicoCategoria>();
    }
}
