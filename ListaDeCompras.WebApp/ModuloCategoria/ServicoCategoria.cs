using AutoMapper;
using FluentResults;

namespace ListaDeCompras.WebApp.ModuloCategoria;
//Aplicação

public class ServicoCategoria
{
    private readonly IRepositorioCategoria repositorioCategoria;
    private readonly IMapper mapeador;

    public ServicoCategoria(
        IRepositorioCategoria repositorioCategoria,
        IMapper mapeador
    )
    {
        this.repositorioCategoria = repositorioCategoria;
        this.mapeador = mapeador;
    }

    public Result Cadastrar(CadastrarCategoriaDto dto)
    {
        if (repositorioCategoria.Registros.Any(c => string.Equals(c.Nome, dto.Nome, StringComparison.OrdinalIgnoreCase)))
            return Falha("Nome", "Já existe uma categoria com esse nome.");

        Categoria novaCategoria = new(
            dto.Nome,
            dto.Cor
        );

        repositorioCategoria.Cadastrar(novaCategoria);

        return Result.Ok();
    }

    public Result Editar(EditarCategoriaDto dto)
    {
        if (repositorioCategoria.Selecionar(c => c.Id != dto.Id).Any(c => string.Equals(c.Nome, dto.Nome, StringComparison.OrdinalIgnoreCase)))
            return Falha("Nome", "Já existe uma categoria com esse nome.");

        Categoria categoriaAtualizada = new(dto.Nome, dto.Cor);

        bool conseguiuEditar = repositorioCategoria.Editar(dto.Id, categoriaAtualizada);

        if (!conseguiuEditar)
            return Result.Fail("Categoria não encontrada.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Categoria? categoria = repositorioCategoria.Selecionar(id);

        if (categoria == null)
            return Result.Fail("Caixa não encontrada.");

        if (categoria.Produtos.Count != 0)
            return Result.Fail("Esta categoria não pode ser excluída pois está relacionada a um produto.");

        repositorioCategoria.Excluir(id);

        return Result.Ok();
    }

    public List<ListarCategoriaDto> SelecionarTodos()
    {
        List<Categoria> categorias = repositorioCategoria.Selecionar();

        return categorias
            .Select(c => new ListarCategoriaDto(c.Id, c.Nome, c.Cor, c.Produtos.Count))
            .ToList();
    }

    public Result<DetalhesCategoriaDto> SelecionarPorId(Guid id)
    {
        Categoria? categoria = repositorioCategoria.Selecionar(id);

        if (categoria == null)
            return Result.Fail("Categoria não encontrada.");

        return Result.Ok(new DetalhesCategoriaDto(categoria.Id, categoria.Nome, categoria.Cor, categoria.Produtos.Count));
    }
    private static Result Falha(string campo, string mensagem)
    {
        IError erro = new Error(mensagem).WithMetadata("Campo", campo);

        return Result.Fail(erro);
    }
}
