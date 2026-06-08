using AutoMapper;
using FluentResults;
using ListaDeCompras.WebApp.Compartilhado.Extensions;
using ListaDeCompras.WebApp.ModuloCategoria;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompras.WebApp.ModuloProduto;
//Apresentação


public class ProdutoController(ServicoProduto servicoProduto, IMapper mapeador, ServicoCategoria servicoCategoria) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        var dtos = servicoProduto.SelecionarTodos();

            var listarVms = mapeador.Map<List<ProdutoMostrarViewModel>>(dtos);

        return View(listarVms);
    }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            var cadastrarVm = new ProdutoViewModel(
                string.Empty,
                SelecionarCategorias(),
                Guid.Empty,
                0,
                0
            );

        return View(cadastrarVm);
    }

        [HttpPost]
        public ActionResult Cadastrar(ProdutoViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm with { Categorias = SelecionarCategorias() });

        var dto = mapeador.Map<CadastrarProdutoDto>(vm);

        Result resultado = servicoProduto.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(vm with { Categorias = SelecionarCategorias() });
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        var resultado = servicoProduto.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

            var vm = mapeador.Map<ProdutoViewModel>(resultado.Value);

            return View(vm with { Categorias = SelecionarCategorias() });
        }
        [HttpPost]
        public ActionResult Editar(ProdutoViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm with { Categorias = SelecionarCategorias() });

            var dto = mapeador.Map<EditarProdutoDto>(vm);

            Result resultado = servicoProduto.Editar(dto);

            if (resultado.IsFailed)
            {
                ModelState.AddModelError(resultado);
                return View(vm with { Categorias = SelecionarCategorias() });
            }

            return RedirectToAction(nameof(Listar));
        }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        var resultado = servicoProduto.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

            var vm = mapeador.Map<ProdutoMostrarViewModel>(resultado.Value);

        return View(vm);
    }

        [HttpPost]
        public ActionResult Excluir(ProdutoMostrarViewModel vm)
        {
            Result resultado = servicoProduto.Excluir(vm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }

        private List<OpcaoCategoriaViewModel> SelecionarCategorias()
        {
            List<CategoriaDto> dtos = servicoCategoria.SelecionarTodos();

        return dtos.Select(dto => mapeador.Map<OpcaoCategoriaViewModel>(dto)).ToList();
    }
}
