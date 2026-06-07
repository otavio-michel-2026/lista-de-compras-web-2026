using ListaDeCompras.WebApp.Compartilhado;
using ListaDeCompras.WebApp.Compartilhado.ModuloBase;
using ListaDeCompras.WebApp.ModuloProduto;

namespace ListaDeCompras.WebApp.ModuloCategoria;
//Infra

public class RepositorioCategoria : RepositorioBase<Categoria>, IRepositorioCategoria
{
    public RepositorioCategoria(ContextoJson contexto) : base(contexto) { }

    protected override List<Categoria> CarregarRegistros()
    {
        return contexto.Categorias;
    }

    public void AdicionarProdutoNaCategoria(Produto produto, Categoria categoria)
    {
        categoria.AdicionarProduto(produto);
    }

    public void RetirarProdutoDaCategoria(Produto produto, Categoria categoria)
    {
        categoria.RetirarProduto(produto);
    }

}
