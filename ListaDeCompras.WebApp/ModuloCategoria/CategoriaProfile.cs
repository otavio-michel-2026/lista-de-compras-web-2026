using AutoMapper;
using ListaDeCompras.WebApp.ModuloProduto;

namespace ListaDeCompras.WebApp.ModuloCategoria;
//apresentação

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<ListarCategoriaDto, ListarCategoriaViewModel>();
        CreateMap<CadastrarCategoriaViewModel, CadastrarCategoriaDto>();
        CreateMap<EditarCategoriaViewModel, EditarCategoriaDto>();
        CreateMap<ListarCategoriaDto, OpcaoCategoriaViewModel>();

        CreateMap<DetalhesCategoriaDto, EditarCategoriaViewModel>();
        CreateMap<DetalhesCategoriaDto, ExcluirCategoriaViewModel>();
    }
}
