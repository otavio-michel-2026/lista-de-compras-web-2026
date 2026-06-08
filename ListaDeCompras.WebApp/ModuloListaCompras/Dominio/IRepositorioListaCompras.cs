using ListaDeCompras.WebApp.Compartilhado.ModuloBase;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Dominio;

public interface IRepositorioListaCompras : IRepositorio<ListaCompras>
{
    bool AdicionarItem(Guid id, ItemDaLista item);
    bool RemoverItem(Guid id, Guid produtoId, decimal quantidade);
    bool ConcluirItem(Guid id, Guid produtoId);
}
