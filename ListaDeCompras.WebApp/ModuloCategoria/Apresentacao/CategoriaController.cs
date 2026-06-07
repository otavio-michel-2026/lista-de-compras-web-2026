using AutoMapper;
using FluentResults;
using ListaDeCompras.WebApp.Compartilhado.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompras.WebApp.ModuloCategoria;
//Apresentação

public class CategoriaController(ServicoCategoria servicoCategoria, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        var dtos = servicoCategoria.SelecionarTodos();

        var listarVms = mapeador.Map<List<CategoriaViewModel>>(dtos);

        return View(listarVms);
    }
    [HttpGet]
    public ActionResult Cadastrar()
    {
        CategoriaViewModel cadastrarVm = new(
            string.Empty,
            string.Empty,
            0
        );

        return View(cadastrarVm);
    }
    [HttpPost]
    public ActionResult Cadastrar(CategoriaViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var dto = mapeador.Map<CategoriaDto>(vm);

        Result resultado = servicoCategoria.Cadastrar(dto);

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
        var resultado = servicoCategoria.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        var dto = resultado.Value;

        var vm = mapeador.Map<CategoriaViewModel>(dto);

        return View(vm);
    }
    [HttpPost]
    public ActionResult Editar(CategoriaViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var dto = mapeador.Map<CategoriaDto>(vm);

        Result resultado = servicoCategoria.Editar(dto);

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
        var resultado = servicoCategoria.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        var dto = resultado.Value;

        var vm = mapeador.Map<CategoriaViewModel>(dto);

        return View(vm);
    }
    [HttpPost]
    public ActionResult Excluir(CategoriaViewModel vm)
    {
        Result resultado = servicoCategoria.Excluir(vm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }
}
