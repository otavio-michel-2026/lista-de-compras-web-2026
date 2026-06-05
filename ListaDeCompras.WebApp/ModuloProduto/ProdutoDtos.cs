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
    string Categoria,
    string UnidadeDeMedida,
    decimal Preco,
    Guid Id
);
public record ListarProdutoDto(
    string Nome,
    string Categoria,
    string UnidadeDeMedida,
    decimal Preco,
    Guid Id
);
