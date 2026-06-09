using ListaDeCompras.WebApp.Compartilhado.ModuloBase;
using ListaDeCompras.WebApp.ModuloCategoria;

namespace ListaDeCompras.WebApp.ModuloProduto.Dominio;
//Dominio

public class Produto : EntidadeBase<Produto>
{
    public string Nome { get; set; } = string.Empty;
    public Categoria Categoria { get; set; } = null!;
    public UnidadeDeMedida UnidadeDeMedida { get; set; }
    public decimal Preco { get; set; }

    public Produto() { }
    public Produto(string nome, Categoria categoria, UnidadeDeMedida unidadeDeMedida, decimal preco)
    {
        Nome = nome;
        Categoria = categoria;
        UnidadeDeMedida = unidadeDeMedida;
        Preco = preco;
    }
    public override void Atualizar(Produto entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Categoria = entidadeAtualizada.Categoria;
        UnidadeDeMedida = entidadeAtualizada.UnidadeDeMedida;
        Preco = entidadeAtualizada.Preco;
    }
}
