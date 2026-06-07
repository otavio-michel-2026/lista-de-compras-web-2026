using FluentResults;
using ListaDeCompras.WebApp.ModuloListaCompras.Dominio;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Aplicacao;

public class ServicoListaCompras
{
    private readonly IRepositorioListaCompras repositorioLista;

    public ServicoListaCompras(IRepositorioListaCompras repositorioLista)
    {
        this.repositorioLista = repositorioLista;
    }

    public Result Cadastrar(CadastrarListaComprasDto dto)
    {
        var lista = new ListaCompras(dto.Nome);

        repositorioLista.Cadastrar(lista);

        return Result.Ok();
    }

    public Result Editar(EditarListaComprasDto dto)
    {
        var listaEditada = new ListaCompras(dto.Nome);

        bool sucesso = repositorioLista.Editar(dto.Id, listaEditada);

        if (!sucesso)
            return Result.Fail("Lista de compras não encontrada.");

        return Result.Ok();
    }

    public List<DetalhesListaComprasDto> Selecionar()
    {
        return repositorioLista.Registros.Select(lc => new DetalhesListaComprasDto(lc.Id, lc.Nome, lc.DataCriacao, lc.TotalItens, lc.StatusLista)).ToList();
    }

    public Result<DetalhesListaComprasDto> Selecionar(Guid id)
    {
        var lista = repositorioLista.Selecionar(id);
        
        if (lista is null)
            return Result.Fail("Lista de compras não encontrada.");

        return Result.Ok(new DetalhesListaComprasDto(lista.Id, lista.Nome, lista.DataCriacao, lista.TotalItens, lista.StatusLista));
    }

}
