using ListaDeCompras.WebApp.ModuloListaCompras.Dominio;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Apresentacao;

public record ListarListaComprasViewModel(
    Guid Id,
    string Nome,
    DateTime DataCriacao,
    int Quantidade,
    StatusLista StatusLista
);
