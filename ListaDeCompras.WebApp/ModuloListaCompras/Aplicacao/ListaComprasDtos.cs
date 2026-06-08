using ListaDeCompras.WebApp.ModuloListaCompras.Dominio;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Aplicacao;

public record DetalhesListaComprasDto(
    Guid Id,
    string Nome,
    DateTime DataCriacao,
    int Quantidade,
    decimal PrecoTotal,
    StatusLista StatusLista,
    List<ItemDaListaDto>? Itens = null
);

public record CadastrarListaComprasDto(
    string Nome
);

public record EditarListaComprasDto(
    Guid Id,
    string Nome
);

public record ItemDaListaDto(
    bool Concluido,
    Guid ProdutoId,
    string Produto,
    string Categoria,
    decimal Quantidade,
    decimal Preco
);

public record GerenciarItemDto(
    Guid Id,
    Guid ProdutoId,
    decimal Quantidade
);
