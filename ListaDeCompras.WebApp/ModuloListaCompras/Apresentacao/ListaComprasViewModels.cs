using System.ComponentModel.DataAnnotations;
using ListaDeCompras.WebApp.ModuloListaCompras.Dominio;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Apresentacao;

public record ListarListaComprasViewModel(
    Guid Id,
    string Nome,
    DateTime DataCriacao,
    int Quantidade,
    decimal PrecoTotal,
    StatusLista StatusLista
);
public record CadastrarListaComprasViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome
);

public record EditarListaComprasViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome
);

public record ExcluirListaComprasViewModel(
    Guid Id,
    string Nome,
    DateTime DataCriacao,
    int Quantidade,
    StatusLista StatusLista
);

public record ListarItensViewModel(
    Guid Id,
    string Nome,
    DateTime DataCriacao,
    int Quantidade,
    decimal PrecoTotal,
    StatusLista StatusLista,
    List<ItemDaListaViewModel> Itens
);

public record ItemDaListaViewModel(
    bool Concluido,
    Guid ProdutoId,
    string Produto,
    string Categoria,
    decimal Quantidade,
    decimal Preco
);

public record GerenciarItemViewModel(
    Guid Id,

    Guid ProdutoId,

    [Required(ErrorMessage = "O campo \"Quantidade\" deve ser preenchido.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O campo \"Quantidade\" deve conter um valor válido maior que zero.")]
    decimal Quantidade,

    [ValidateNever]
    List<SelectListItem> Produtos
) : IValidatableObject
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (ProdutoId == Guid.Empty)
            yield return new ValidationResult("O campo \"Produto\" deve ser preenchido.", [nameof(ProdutoId)]);
    }
}

public record AtualizarItemViewModel(
    bool Concluido,
    string Produto,
    string Categoria,
    decimal Quantidade,
    decimal Preco
);
