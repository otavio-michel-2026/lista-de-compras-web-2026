using FluentResults;
using ListaDeCompras.WebApp.ModuloListaCompras.Dominio;
using ListaDeCompras.WebApp.ModuloProduto;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Aplicacao;

public class ServicoListaCompras(IRepositorioListaCompras repositorioLista, IRepositorioProduto repositorioProduto)
{
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

    public Result Excluir(Guid id)
    {
        var lista = repositorioLista.Selecionar(id);

        if (lista is null)
            return Result.Fail("Lista de compras não encontrada.");
        if (lista.TemItens)
            return Result.Fail("Não é possível remover uma lista quem tem itens.");

        repositorioLista.Excluir(id);

        return Result.Ok();
    }

    public Result AdicionarItem(GerenciarItemDto dto)
    {
        var lista = repositorioLista.Selecionar(dto.Id);

        if (lista is null)
            return Result.Fail("Lista de compras não encontrada.");

        var produto = repositorioProduto.Selecionar(dto.ProdutoId);

        if (produto is null)
            return Falha(nameof(dto.ProdutoId), "Produto não encontrado.");

        if (produto.UnidadeDeMedida == UnidadeDeMedida.Unidade && dto.Quantidade != decimal.Truncate(dto.Quantidade))
            return Falha(nameof(dto.Quantidade), "A quantidade deve ser um número inteiro para produtos vendidos por unidade.");

        repositorioLista.AdicionarItem(dto.Id, new ItemDaLista(produto, dto.Quantidade));

        return Result.Ok();
    }

    public Result RemoverItem(GerenciarItemDto dto)
    {
        var lista = repositorioLista.Selecionar(dto.Id);

        if (lista is null)
            return Result.Fail("Lista de compras não encontrada.");

        var produto = repositorioProduto.Selecionar(dto.ProdutoId);

        if (produto is null)
            return Falha(nameof(dto.ProdutoId), "Produto não encontrado.");

        if (produto.UnidadeDeMedida == UnidadeDeMedida.Unidade && dto.Quantidade != decimal.Truncate(dto.Quantidade))
            return Falha(nameof(dto.Quantidade), "A quantidade deve ser um número inteiro para produtos vendidos por unidade.");

        bool sucesso = repositorioLista.RemoverItem(dto.Id, produto.Id, dto.Quantidade);

        if (!sucesso)
            return Falha(nameof(dto.Quantidade), "A quantidade não pode ser maior que a quantidade do produto na lista.");

        return Result.Ok();
    }

    public List<DetalhesListaComprasDto> Selecionar()
    {
        return repositorioLista.Registros.Select(lc => new DetalhesListaComprasDto(lc.Id, lc.Nome, lc.DataCriacao, lc.TotalItens, lc.CalcularTotal(), lc.StatusLista)).ToList();
    }

    public List<Guid> SelecionarProdutosNaLista(Guid id)
    {
        var idsProduto = repositorioLista.Selecionar(id)?.Itens.Select(il => il.Produto.Id);

        if (idsProduto is null)
            return [];

        return repositorioProduto.Registros.Where(p => idsProduto.Contains(p.Id)).Select(p => p.Id).ToList();
    }

    public Result<DetalhesListaComprasDto> Selecionar(Guid id, bool incluirItens = false)
    {
        var lista = repositorioLista.Selecionar(id);

        if (lista is null)
            return Result.Fail("Lista de compras não encontrada.");

        List<ItemDaListaDto>? itens = null;

        if (incluirItens)
            itens = lista.Itens.Select(il => new ItemDaListaDto(il.Concluido, il.Produto.Nome, il.Produto.Categoria.Nome, il.Quantidade, il.CalcularPreco())).ToList();

        return Result.Ok(new DetalhesListaComprasDto(lista.Id, lista.Nome, lista.DataCriacao, lista.TotalItens, lista.CalcularTotal(), lista.StatusLista, itens));
    }

    private static Result Falha(string campo, string mensagem)
    {
        IError erro = new Error(mensagem).WithMetadata("Campo", campo);

        return Result.Fail(erro);
    }
}
