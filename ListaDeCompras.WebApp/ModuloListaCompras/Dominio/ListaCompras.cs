using System.Text.Json.Serialization;
using ListaDeCompras.WebApp.Compartilhado.ModuloBase;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Dominio;

public class ListaCompras : EntidadeBase<ListaCompras>
{
    public string Nome { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public List<ItemDaLista> Itens { get; set; } = [];

    [JsonIgnore]
    public int TotalItens => Itens.Count;

    [JsonIgnore]
    public bool TemItens => Itens.Count != 0;

    [JsonIgnore]
    public StatusLista StatusLista
    {
        get
        {
            if (Itens.Count == 0)
                return StatusLista.Aberta;

            return Itens.All(i => i.Concluido) ? StatusLista.Concluida : StatusLista.Aberta;
        }
    }

    public ListaCompras() { }

    public ListaCompras(string nome)
    {
        Nome = nome;
    }

    public void AdicionarItem(ItemDaLista item)
    {
        ItemDaLista? itemExistente = Itens.FirstOrDefault(i => i.Produto.Id == item.Produto.Id);

        if (itemExistente is null)
            Itens.Add(item);
        else
            itemExistente.AlterarQuantidade(item.Quantidade);
    }

    public bool RemoverItem(Guid produtoId, decimal quantidade)
    {
        ItemDaLista? itemExistente = Itens.FirstOrDefault(i => i.Produto.Id == produtoId);
        
        if (itemExistente is null)
            return false;
        else if (itemExistente.Quantidade > quantidade)
            itemExistente.AlterarQuantidade(-quantidade);
        else if (itemExistente.Quantidade == quantidade)
            return Itens.Remove(itemExistente);
        else
            return false;

        return true;
    }

    public void ConcluirItem(Guid produtoId)
    {
        ItemDaLista? item = Itens.FirstOrDefault(i => i.Produto.Id == produtoId);

        if (item is null)
            return;

        item.Concluir();
    }

    public void ReabrirItem(Guid produtoId)
    {
        ItemDaLista? item = Itens.FirstOrDefault(i => i.Produto.Id == produtoId);

        if (item is null)
            return;

        item.Reabrir();
    }

    public decimal CalcularTotal()
    {
        return Itens.Sum(i => i.CalcularPreco());
    }

    public override void Atualizar(ListaCompras listaEditada)
    {
        Nome = listaEditada.Nome;
    }
}
