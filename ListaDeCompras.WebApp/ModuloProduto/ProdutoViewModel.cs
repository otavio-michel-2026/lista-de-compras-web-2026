using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ListaDeCompras.WebApp.ModuloProduto;
//Apresentação

public record OpcaoCategoriaViewModel(
    Guid Id,
    string Nome
);
public record CadastrarProdutoViewModel
(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido")]
    [StringLength(100, MinimumLength =2, ErrorMessage = "O campo \"Nome\" deve conter no maximo 100 caracteres e no minimo 2")]
    string Nome,

    [ValidateNever]
    List<OpcaoCategoriaViewModel> Categorias,

    [Required(ErrorMessage = "O campo \"Categoria\" deve ser preenchido")]
    Guid CategoriaId,

    [Required(ErrorMessage = "O campo \"Unidade de medida\" deve ser preenchido")]
    UnidadeDeMedida UnidadeDeMedida,

    [Required(ErrorMessage = "O campo \"Preco\" deve ser preenchido")]
    decimal Preco
);
public record EditarProdutoViewModel
(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido")]
    [StringLength(100, MinimumLength =2, ErrorMessage = "O campo \"Nome\" deve conter no maximo 100 caracteres e no minimo 2")]
    string Nome,

    [ValidateNever]
    List<OpcaoCategoriaViewModel> Categorias,

    [Required(ErrorMessage = "O campo \"Unidade de medida\" deve ser preenchido")]
    UnidadeDeMedida UnidadeDeMedida,

    [Required(ErrorMessage = "O campo \"Preco\" deve ser preenchido")]
    decimal Preco,

    Guid Id
);
public record ListarProdutoViewModel
(
    string Nome,

    string CategoriaNome,

    UnidadeDeMedida UnidadeDeMedida,

    decimal Preco,

    Guid Id
);
public record ExcluirProdutoViewModel
(
    string Nome,

    string CategoriaNome,

    UnidadeDeMedida UnidadeDeMedida,

    decimal Preco,

    Guid Id
);
