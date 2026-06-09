namespace ListaDeCompras.WebApp.ModuloCategoria.Aplicacao;
//Aplicação

public record CategoriaDto(
    string Nome,
    string Cor,
    int QtdProduto,
    Guid Id = new Guid()
);
