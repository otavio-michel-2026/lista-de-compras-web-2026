using ListaDeCompras.WebApp.Compartilhado;
using ListaDeCompras.WebApp.Compartilhado.ModuloBase;
using ListaDeCompras.WebApp.ModuloProduto.Dominio;

namespace ListaDeCompras.WebApp.ModuloProduto.Infra;
//Infra

public class RepositorioProduto : RepositorioBase<Produto>, IRepositorioProduto
{
    public RepositorioProduto(ContextoJson contexto) : base(contexto) { }

    protected override List<Produto> CarregarRegistros()
    {
        return contexto.Produtos;
    }
}
