using AutoMapper;
using FluentResults;
using ListaDeCompras.WebApp.Compartilhado.Extensions;
using ListaDeCompras.WebApp.ModuloListaCompras.Aplicacao;
using ListaDeCompras.WebApp.ModuloProduto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Apresentacao;

public class ListaComprasController(ServicoListaCompras servicoLista, ServicoProduto servicoProduto, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        var dtos = servicoLista.Selecionar();
        var vms = mapeador.Map<List<ListarListaComprasViewModel>>(dtos);
        return View(vms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        var vm = new CadastrarListaComprasViewModel(string.Empty);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarListaComprasViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var dto = mapeador.Map<CadastrarListaComprasDto>(vm);

        var resultado = servicoLista.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);
            return View(vm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        var resultado = servicoLista.Selecionar(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        var dto = resultado.Value;

        var vm = mapeador.Map<EditarListaComprasViewModel>(dto);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Editar(EditarListaComprasViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var dto = mapeador.Map<EditarListaComprasDto>(vm);

        var resultado = servicoLista.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);
            return View(vm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        var resultado = servicoLista.Selecionar(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        var dto = resultado.Value;

        var vm = mapeador.Map<ExcluirListaComprasViewModel>(dto);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirListaComprasViewModel vm)
    {
        var resultado = servicoLista.Excluir(vm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult VisualizarItens(Guid id)
    {
        var resultado = servicoLista.Selecionar(id, true);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        var dto = resultado.Value;

        var vm = mapeador.Map<ListarItensViewModel>(dto);

        return View(vm);
    }

    [HttpGet("{id:guid}/AdicionarItem")]
    public ActionResult AdicionarItem(Guid id)
    {
        var vm = new GerenciarItemViewModel(id, Guid.Empty, 0, SelecionarProdutos());

        return View(vm);
    }

    [HttpPost("{id:guid}/AdicionarItem")]
    public ActionResult AdicionarItem(Guid id, GerenciarItemViewModel vm)
    {
        vm = vm with { Id = id };

        if (!ModelState.IsValid)
            return View(vm with { Produtos = SelecionarProdutos() });

        var dto = mapeador.Map<GerenciarItemDto>(vm);

        var resultado = servicoLista.AdicionarItem(dto);

        if (resultado.IsFailed)
        {
            if (resultado.TemErroDeCampo())
            {
                ModelState.AddModelError(resultado);
                return View(vm with { Produtos = SelecionarProdutos() });
            }

            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(VisualizarItens), new { id });
        }

        return RedirectToAction(nameof(VisualizarItens), new { id });
    }

    [HttpGet("{id:guid}/RemoverItem")]
    public ActionResult RemoverItem(Guid id)
    {
        var vm = new GerenciarItemViewModel(id, Guid.Empty, 0, SelecionarProdutosNaLista(id));

        return View(vm);
    }

    [HttpPost("{id:guid}/RemoverItem")]
    public ActionResult RemoverItem(Guid id, GerenciarItemViewModel vm)
    {
        vm = vm with { Id = id };

        if (!ModelState.IsValid)
            return View(vm with { Produtos = SelecionarProdutosNaLista(id) });

        var dto = mapeador.Map<GerenciarItemDto>(vm);

        var resultado = servicoLista.RemoverItem(dto);

        if (resultado.IsFailed)
        {
            if (resultado.TemErroDeCampo())
            {
                ModelState.AddModelError(resultado);
                return View(vm with { Produtos = SelecionarProdutosNaLista(id) });
            }

            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(VisualizarItens), new { id });
        }

        return RedirectToAction(nameof(VisualizarItens), new { id });
    }

    private List<SelectListItem> SelecionarProdutos()
    {
        var dtos = servicoProduto.SelecionarTodos();

        return mapeador.Map<List<SelectListItem>>(dtos);
    }

    private List<SelectListItem> SelecionarProdutosNaLista(Guid id)
    {
        var ids = servicoLista.SelecionarProdutosNaLista(id);

        var dtos = servicoProduto.SelecionarTodos().Where(dto => ids.Contains(dto.Id));

        return mapeador.Map<List<SelectListItem>>(dtos);
    }
}
