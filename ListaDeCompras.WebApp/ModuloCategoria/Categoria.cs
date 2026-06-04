using ListaDeCompras.WebApp.Compartilhado.ModuloBase;
using ListaDeCompras.WebApp.ModuloProduto;

namespace ListaDeCompras.WebApp.ModuloCategoria;
//Dominio

public class Categoria : EntidadeBase<Categoria>
{
    public string Nome { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    List<Produto> Produtos { get; set; } = [];
    public Categoria() { }
    public Categoria(string nome, string cor)
    {
        Nome = nome;
        Cor = cor;
    }
    public override void Atualizar(Categoria entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Cor = entidadeAtualizada.Cor;
    }
    public void AdicionarProduto(Produto produto)
    {
        Produtos.Add(produto);
    }
    public void RetirarProduto(Produto produto)
    {
        Produtos.Remove(produto);
    }
}
