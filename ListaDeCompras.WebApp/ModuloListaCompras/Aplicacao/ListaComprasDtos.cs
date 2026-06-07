using ListaDeCompras.WebApp.ModuloListaCompras.Dominio;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Aplicacao;

public record DetalhesListaComprasDto(
    Guid Id,
    string Nome,
    DateTime DataCriacao,
    int Quantidade,
    StatusLista StatusLista
);
public record CadastrarListaComprasDto(
    string Nome
);

public record EditarListaComprasDto(
    Guid Id,
    string Nome
);
