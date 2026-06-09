using AutoMapper;
using ListaDeCompras.WebApp.ModuloCategoria.Aplicacao;

namespace ListaDeCompras.WebApp.ModuloCategoria.Apresentacao;
//apresentação

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<CategoriaDto, CategoriaViewModel>();
        CreateMap<CategoriaViewModel, CategoriaDto>();
    }
}
