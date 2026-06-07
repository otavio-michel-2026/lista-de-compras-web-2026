using ListaDeCompras.WebApp.Compartilhado.ModuloBase;
using ListaDeCompras.WebApp.ModuloProduto;

namespace ListaDeCompras.WebApp.ModuloCategoria;
//Infra

public interface IRepositorioCategoria : IRepositorio<Categoria>
{
    void AdicionarProdutoNaCategoria(Produto produto, Categoria categoria);
    void RetirarProdutoDaCategoria(Produto produto, Categoria categoria);
}
