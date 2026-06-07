using AutoMapper;
using ListaDeCompras.WebApp.ModuloListaCompras.Aplicacao;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Apresentacao;

public class ListaComprasProfile : Profile
{
    public ListaComprasProfile()
    {
        CreateMap<DetalhesListaComprasDto, ListarListaComprasViewModel>();
        CreateMap<DetalhesListaComprasDto, EditarListaComprasViewModel>();
        CreateMap<DetalhesListaComprasDto, ExcluirListaComprasViewModel>();

        CreateMap<CadastrarListaComprasViewModel, CadastrarListaComprasDto>();
        CreateMap<EditarListaComprasViewModel, EditarListaComprasDto>();
        CreateMap<ExcluirListaComprasViewModel, DetalhesListaComprasDto>();
    }
}
