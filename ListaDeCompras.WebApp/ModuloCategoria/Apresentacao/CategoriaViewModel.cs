using System.ComponentModel.DataAnnotations;

namespace ListaDeCompras.WebApp.ModuloCategoria.Apresentacao;
//Apresentação

public record CategoriaViewModel
(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido")]
    [StringLength(50, ErrorMessage = "O campo \"Nome\" deve conter no maximo 50 caracteres")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Cor\" deve ser preenchido")]
    string Cor,

    int QtdProduto,

    Guid Id = new Guid()
);

