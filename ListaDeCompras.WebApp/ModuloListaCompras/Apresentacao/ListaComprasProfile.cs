using AutoMapper;
using ListaDeCompras.WebApp.ModuloListaCompras.Aplicacao;
using ListaDeCompras.WebApp.ModuloListaCompras.Dominio;
using ListaDeCompras.WebApp.ModuloProduto.Aplicacao;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Apresentacao;

public class ListaComprasProfile : Profile
{
    public ListaComprasProfile()
    {
        CreateMap<DetalhesListaComprasDto, ListarListaComprasViewModel>();
        CreateMap<DetalhesListaComprasDto, EditarListaComprasViewModel>();
        CreateMap<DetalhesListaComprasDto, ExcluirListaComprasViewModel>();
        CreateMap<DetalhesListaComprasDto, ListarItensViewModel>();

        CreateMap<CadastrarListaComprasViewModel, CadastrarListaComprasDto>();
        CreateMap<EditarListaComprasViewModel, EditarListaComprasDto>();

        CreateMap<ItemDaListaDto, ItemDaListaViewModel>();
        CreateMap<GerenciarItemViewModel, GerenciarItemDto>();
        CreateMap<ListarProdutoDto, SelectListItem>()
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
    }
}
