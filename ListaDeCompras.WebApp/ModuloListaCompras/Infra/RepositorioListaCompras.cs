using ListaDeCompras.WebApp.Compartilhado;
using ListaDeCompras.WebApp.Compartilhado.ModuloBase;
using ListaDeCompras.WebApp.ModuloListaCompras.Dominio;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Infra;

public class RepositorioListaCompras : RepositorioBase<Dominio.ListaCompras>, IRepositorioListaCompras
{
    public RepositorioListaCompras(ContextoJson contexto) : base(contexto) { }

    protected override List<Dominio.ListaCompras> CarregarRegistros()
    {
        return contexto.Listas;
    }
}
