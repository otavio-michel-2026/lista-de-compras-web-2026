using ListaDeCompras.WebApp.ModuloListaCompras.Dominio;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Aplicacao;

public record DetalhesListaComprasDto(
    Guid Id,
    string Nome,
    DateTime DataCriacao,
    int Quantidade,
    StatusLista StatusLista
);
