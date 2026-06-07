using System.ComponentModel.DataAnnotations;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ListaDeCompras.WebApp.ModuloProduto;
//Apresentação

public record OpcaoCategoriaViewModel(
    Guid Id,
    string Nome
);
public record ProdutoViewModel
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
    decimal Preco,

    Guid Id = new Guid()
);

public record ProdutoMostrarViewModel
(
    string Nome,

    string CategoriaNome,

    UnidadeDeMedida UnidadeDeMedida,

    decimal Preco,

    Guid Id
);
