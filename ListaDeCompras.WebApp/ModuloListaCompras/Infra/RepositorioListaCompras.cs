using ListaDeCompras.WebApp.Compartilhado;
using ListaDeCompras.WebApp.Compartilhado.ModuloBase;
using ListaDeCompras.WebApp.ModuloListaCompras.Dominio;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Infra;

public class RepositorioListaCompras : RepositorioBase<ListaCompras>, IRepositorioListaCompras
{
    public RepositorioListaCompras(ContextoJson contexto) : base(contexto) { }

    protected override List<ListaCompras> CarregarRegistros()
    {
        return contexto.Listas;
    }

    public bool AdicionarItem(Guid id, ItemDaLista item)
    {
        var lista = Selecionar(id);

        if (lista is null)
            return false;

        lista.AdicionarItem(item);
        contexto.Salvar();

        return true;
    }

    public bool RemoverItem(Guid id, Guid produtoId, decimal quantidade)
    {
        var lista = Selecionar(id);

        if (lista is null)
            return false;

        if (lista.RemoverItem(produtoId, quantidade))
        {
            contexto.Salvar();
            return true;
        }
        else
            return false;
    }
}
