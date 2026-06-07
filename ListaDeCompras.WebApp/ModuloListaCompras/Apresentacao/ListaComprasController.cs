using AutoMapper;
using ListaDeCompras.WebApp.Compartilhado.Extensions;
using ListaDeCompras.WebApp.ModuloListaCompras.Aplicacao;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Apresentacao;

public class ListaComprasController(ServicoListaCompras servicoLista, IMapper mapeador) : Controller
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
}
