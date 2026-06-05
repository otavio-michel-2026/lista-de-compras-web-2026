namespace ListaDeCompras.WebApp.ModuloProduto;
//Aplicação

public record CadastrarProdutoDto(
    string Nome,
    Guid CategoriaId,
    string UnidadeDeMedida,
    decimal Preco
);
public record EditarProdutoDto(
    string Nome,
    Guid CategoriaId,
    string UnidadeDeMedida,
    decimal Preco,
    Guid Id
);
public record DetalhesProdutoDto(
    string Nome,
    string CategoriaNome,
    Guid CategoriaId,
    string UnidadeDeMedida,
    decimal Preco,
    Guid Id
);
public record ListarProdutoDto(
    string Nome,
    string CategoriaNome,
    string UnidadeDeMedida,
    decimal Preco,
    Guid Id
);
