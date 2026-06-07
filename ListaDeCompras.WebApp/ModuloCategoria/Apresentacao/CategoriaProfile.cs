using AutoMapper;

namespace ListaDeCompras.WebApp.ModuloCategoria;
//apresentação

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<ListarCategoriaDto, ListarCategoriaViewModel>();
        CreateMap<CadastrarCategoriaViewModel, CadastrarCategoriaDto>();
        CreateMap<EditarCategoriaViewModel, EditarCategoriaDto>();
        // CreateMap<CadastrarCategoriaDto, CadastrarCategoriaViewModel>();
        // CreateMap<EditarCategoriaDto, EditarCategoriaViewModel>();

        CreateMap<DetalhesCategoriaDto, EditarCategoriaViewModel>();
        CreateMap<DetalhesCategoriaDto, ExcluirCategoriaViewModel>();
    }
}
