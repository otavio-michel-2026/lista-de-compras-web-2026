using AutoMapper;
using ListaDeCompras.WebApp.ModuloCategoria;

namespace ListaDeCompras.WebApp.ModuloProduto;
//apresentação

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<ListarProdutoDto, ProdutoMostrarViewModel>();

        CreateMap<ProdutoViewModel, CadastrarProdutoDto>();

        CreateMap<DetalhesProdutoDto, ProdutoViewModel>()
            .ForCtorParam("Categorias", opt => opt.MapFrom(_ => new List<OpcaoCategoriaViewModel>()));

        CreateMap<ProdutoViewModel, EditarProdutoDto>();

        CreateMap<DetalhesProdutoDto, ProdutoMostrarViewModel>();

        CreateMap<ListarCategoriaDto, OpcaoCategoriaViewModel>();
    }
}

