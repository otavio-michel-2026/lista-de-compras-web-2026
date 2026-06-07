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

    public List<DetalhesListaComprasDto> Selecionar()
    {
        return repositorioLista.Registros.Select(lc => new DetalhesListaComprasDto(lc.Id, lc.Nome, lc.DataCriacao, lc.TotalItens, lc.StatusLista)).ToList();
    }

}
