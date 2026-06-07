using System.ComponentModel.DataAnnotations;
using ListaDeCompras.WebApp.ModuloListaCompras.Dominio;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Apresentacao;

public record ListarListaComprasViewModel(
    Guid Id,
    string Nome,
    DateTime DataCriacao,
    int Quantidade,
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
