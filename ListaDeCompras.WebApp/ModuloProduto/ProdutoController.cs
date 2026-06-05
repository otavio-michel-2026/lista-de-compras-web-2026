using AutoMapper;
using FluentResults;
using ListaDeCompras.WebApp.Compartilhado.Extensions;
using ListaDeCompras.WebApp.ModuloCategoria;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompras.WebApp.ModuloProduto
//Apresentação

{
    public class ProdutoController(ServicoProduto servicoProduto, IMapper mapeador, ServicoCategoria servicoCategoria) : Controller
    {
        [HttpGet]
        public ActionResult Listar()
        {
            var dtos = servicoProduto.SelecionarTodos();

            var listarVms = mapeador.Map<List<ListarProdutoViewModel>>(dtos);

            return View(listarVms);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            var cadastrarVm = new CadastrarProdutoViewModel(
                string.Empty,
                SelecionarCategorias(),
                Guid.Empty,
                0,
                0
            );

            return View(cadastrarVm);
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastrarProdutoViewModel vm)
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

            var vm = mapeador.Map<EditarProdutoViewModel>(resultado.Value) with { Categorias = SelecionarCategorias() };

            return View(vm);
        }

        [HttpPost]
        // public ActionResult Editar(EditarProdutoViewModel vm)
        // {
        //     if (!ModelState.IsValid)
        //         return View(vm with { Categorias = SelecionarCategorias() });

        //     var dto = mapeador.Map<DetalhesProdutoDto>(vm);

        //     Result resultado = servicoProduto.Editar(dto);

        //     if (resultado.IsFailed)
        //     {
        //         ModelState.AddModelError(resultado);
        //         return View(vm with { Categorias = SelecionarCategorias() });
        //     }

        //     return RedirectToAction(nameof(Listar));
        // }

        [HttpGet]
        public ActionResult Excluir(Guid id)
        {
            var resultado = servicoProduto.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                TempData.AddErrorMessage(resultado);

                return RedirectToAction(nameof(Listar));
            }

            ExcluirProdutoViewModel vm =
                mapeador.Map<ExcluirProdutoViewModel>(resultado.Value);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Excluir(ExcluirProdutoViewModel vm)
        {
            Result resultado = servicoProduto.Excluir(vm.Id);

            if (resultado.IsFailed)
                TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        private List<OpcaoCategoriaViewModel> SelecionarCategorias()
        {
            List<ListarCategoriaDto> dtos = servicoCategoria.SelecionarTodos();

            return dtos.Select(dto => mapeador.Map<OpcaoCategoriaViewModel>(dto)).ToList();
        }
    }
}
