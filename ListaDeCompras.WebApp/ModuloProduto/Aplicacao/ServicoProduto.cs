using FluentResults;
using ListaDeCompras.WebApp.ModuloCategoria.Dominio;
using ListaDeCompras.WebApp.ModuloProduto.Dominio;

namespace ListaDeCompras.WebApp.ModuloProduto.Aplicacao;

public class ServicoProduto
{
    private readonly IRepositorioProduto repositorioProduto;
    private readonly IRepositorioCategoria repositorioCategoria;

    public ServicoProduto(
        IRepositorioProduto repositorioProduto,
        IRepositorioCategoria repositorioCategoria
    )
    {
        this.repositorioProduto = repositorioProduto;
        this.repositorioCategoria = repositorioCategoria;
    }

    public Result Cadastrar(CadastrarProdutoDto dto)
    {
        if (repositorioProduto.Registros.Any(c => string.Equals(c.Nome, dto.Nome, StringComparison.OrdinalIgnoreCase) && c.Categoria.Id == dto.CategoriaId))
            return Falha(dto.Nome, "Já existe um produto com esse nome nessa categoria.");

        Categoria? categoria = repositorioCategoria.Selecionar(dto.CategoriaId);

        if (categoria is null)
            return Falha(nameof(dto.CategoriaId), "Categoria nao Encontrada");

        Produto novoProduto = new(
            dto.Nome,
            categoria,
            dto.UnidadeDeMedida,
            dto.Preco
        );

        categoria.AdicionarProduto(novoProduto);

        repositorioProduto.Cadastrar(novoProduto);

        return Result.Ok();
    }

    public Result Editar(EditarProdutoDto dto)
    {
        if (repositorioProduto.Selecionar(c => c.Id != dto.Id).Any(c => string.Equals(c.Nome, dto.Nome, StringComparison.OrdinalIgnoreCase) && c.Categoria.Id == dto.CategoriaId))
            return Falha("Nome", "Já existe um produto com esse nome nessa categoria.");

        Categoria? categoria = repositorioCategoria.Selecionar(dto.CategoriaId);

        if (categoria is null)
            return Falha("CategoriaId", "Categoria não Encontrada");

        Produto produtoAtualizado = new(dto.Nome, categoria, dto.UnidadeDeMedida, dto.Preco);

        bool conseguiuEditar = repositorioProduto.Editar(dto.Id, produtoAtualizado);

        if (!conseguiuEditar)
            return Result.Fail("Ocorreu um erro ao produto ao ser editado.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Produto? produto = repositorioProduto.Selecionar(id);

        if (produto == null)
            return Result.Fail("Produto não encontrado.");

        produto.Categoria.RetirarProduto(produto);
        bool conseguiuExcluir = repositorioProduto.Excluir(id);

        if (!conseguiuExcluir)
            return Result.Fail("Produto não encontrado.");

        return Result.Ok();
    }

    public List<ListarProdutoDto> SelecionarTodos()
    {
        List<Produto> produtos = repositorioProduto.Selecionar();

        return produtos
            .Select(c => new ListarProdutoDto(c.Nome, c.Categoria.Nome, c.UnidadeDeMedida, c.Preco, c.Id))
            .ToList();
    }

    public Result<DetalhesProdutoDto> SelecionarPorId(Guid id)
    {
        Produto? produto = repositorioProduto.Selecionar(id);

        if (produto == null)
            return Result.Fail("produto não encontrado.");

        return Result.Ok(new DetalhesProdutoDto(produto.Nome, produto.Categoria.Nome, produto.Categoria.Id, produto.UnidadeDeMedida, produto.Preco, produto.Id));
    }
    private static Result Falha(string campo, string mensagem)
    {
        IError erro = new Error(mensagem).WithMetadata("Campo", campo);

        return Result.Fail(erro);
    }
}
