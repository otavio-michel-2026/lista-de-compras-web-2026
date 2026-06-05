using AutoMapper;
using ListaDeCompras.WebApp.ModuloCategoria;

namespace ListaDeCompras.WebApp.ModuloProduto;
//apresentação

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<ListarProdutoDto, ListarProdutoViewModel>();
        CreateMap<ListarCategoriaDto, OpcaoCategoriaViewModel>();

        CreateMap<CadastrarProdutoViewModel, CadastrarProdutoDto>();
        CreateMap<EditarProdutoViewModel, EditarProdutoDto>();

        CreateMap<DetalhesProdutoDto, EditarProdutoViewModel>()
            .ForCtorParam("Categorias", opt => opt.MapFrom(_ => new List<OpcaoCategoriaViewModel>()));

        CreateMap<DetalhesProdutoDto, ExcluirProdutoViewModel>();
    }
}

