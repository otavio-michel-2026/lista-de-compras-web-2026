using ListaDeCompras.WebApp.ModuloProduto.Dominio;

namespace ListaDeCompras.WebApp.ModuloProduto.Aplicacao;
//Aplicação

public record CadastrarProdutoDto(
    string Nome,
    Guid CategoriaId,
    UnidadeDeMedida UnidadeDeMedida,
    decimal Preco
);
public record EditarProdutoDto(
    string Nome,
    Guid CategoriaId,
    UnidadeDeMedida UnidadeDeMedida,
    decimal Preco,
    Guid Id
);
public record DetalhesProdutoDto(
    string Nome,
    string CategoriaNome,
    Guid CategoriaId,
    UnidadeDeMedida UnidadeDeMedida,
    decimal Preco,
    Guid Id
);
public record ListarProdutoDto(
    string Nome,
    string CategoriaNome,
    UnidadeDeMedida UnidadeDeMedida,
    decimal Preco,
    Guid Id
);
