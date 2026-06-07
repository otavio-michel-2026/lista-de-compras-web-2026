using AutoMapper;
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

}
