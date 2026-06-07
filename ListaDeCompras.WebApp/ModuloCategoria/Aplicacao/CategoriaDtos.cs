namespace ListaDeCompras.WebApp.ModuloCategoria;
//Aplicação

public record CadastrarCategoriaDto(
    string Nome,
    string Cor,
    int QtdProduto
);
public record EditarCategoriaDto(
    Guid Id,
    string Nome,
    string Cor,
    int QtdProduto
);
public record DetalhesCategoriaDto(
    Guid Id,
    string Nome,
    string Cor,
    int QtdProduto
);
public record ListarCategoriaDto(
    Guid Id,
    string Nome,
    string Cor,
    int QtdProduto
);
