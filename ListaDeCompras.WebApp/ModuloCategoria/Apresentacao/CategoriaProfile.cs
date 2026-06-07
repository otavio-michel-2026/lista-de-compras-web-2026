using AutoMapper;

namespace ListaDeCompras.WebApp.ModuloCategoria;
//apresentação

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<CategoriaDto, CategoriaViewModel>();
        CreateMap<CategoriaViewModel, CategoriaDto>();
    }
}
