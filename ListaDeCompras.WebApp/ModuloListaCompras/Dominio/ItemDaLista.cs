using ListaDeCompras.WebApp.ModuloProduto;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Dominio;

public class ItemDaLista
{
    public bool Concluido { get; set; }
    public Produto Produto { get; set; } = null!;
    public decimal Quantidade { get; set; }

    public ItemDaLista() { }

    public ItemDaLista(Produto produto, decimal quantidade)
    {
        Produto = produto;
        Quantidade = quantidade;
    }

    public void AlterarQuantidade(decimal quantidade)
    {
        Quantidade += quantidade;
    }

    public void DefinirQuantidade(decimal quantidade)
    {
        Quantidade = quantidade;
    }

    public decimal CalcularPreco()
    {
        return Produto.Preco * Quantidade;
    }

    public void Concluir()
    {
        Concluido = true;
    }

    public void Reabrir()
    {
        Concluido = false;
    }
}
