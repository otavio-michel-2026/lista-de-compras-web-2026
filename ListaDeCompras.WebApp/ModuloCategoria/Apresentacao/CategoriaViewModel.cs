using System.ComponentModel.DataAnnotations;

namespace ListaDeCompras.WebApp.ModuloCategoria;
//Apresentação

public record CadastrarCategoriaViewModel
(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido")]
    [StringLength(50, ErrorMessage = "O campo \"Nome\" deve conter no maximo 50 caracteres")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Cor\" deve ser preenchido")]
    string Cor,

    int QtdProduto
);
public record EditarCategoriaViewModel
(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido")]
    [StringLength(50, ErrorMessage = "O campo \"Nome\" deve conter no maximo 50 caracteres")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Cor\" deve ser preenchido")]
    string Cor,

    int QtdProduto,

    Guid Id
);
public record ListarCategoriaViewModel
(
    string Nome,

    string Cor,

    int QtdProduto,

    Guid Id
);
public record ExcluirCategoriaViewModel
(
    string Nome,

    string Cor,

    int QtdProduto,

    Guid Id
);
