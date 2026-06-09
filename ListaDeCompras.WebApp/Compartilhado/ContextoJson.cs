using System.Text.Json;
using System.Text.Json.Serialization;
using ListaDeCompras.WebApp.ModuloCategoria.Dominio;
using ListaDeCompras.WebApp.ModuloListaCompras.Dominio;
using ListaDeCompras.WebApp.ModuloProduto.Dominio;

namespace ListaDeCompras.WebApp.Compartilhado;
// Infraestrutura
public class ContextoJson
{
    //List<T> (*) (*)s;
    public List<Categoria> Categorias { get; set; } = [];
    public List<Produto> Produtos { get; set; } = [];
    public List<ListaCompras> Listas { get; set; } = [];
    private readonly string caminhoArquivo;
    private readonly JsonSerializerOptions opcoesJson = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        ReferenceHandler = ReferenceHandler.Preserve
    };

    public ContextoJson()
    {
        string caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        string caminhoDiretorio = Path.Combine(caminhoAppData, "ListaDeCompras");

        Directory.CreateDirectory(caminhoDiretorio);

        caminhoArquivo = Path.Combine(caminhoDiretorio, "dados.json");
    }

    public void Salvar()
    {
        string jsonString = JsonSerializer.Serialize(this, opcoesJson);

        File.WriteAllText(caminhoArquivo, jsonString);
    }

    public void Carregar()
    {
        if (!File.Exists(caminhoArquivo))
            return;

        string jsonString = File.ReadAllText(caminhoArquivo);

        ContextoJson? contextoSalvo = JsonSerializer
            .Deserialize<ContextoJson>(jsonString, opcoesJson);

        if (contextoSalvo is null)
            return;

        //*s = contextoSalvo.(*)s
        Categorias = contextoSalvo.Categorias;
        Produtos = contextoSalvo.Produtos;
        Listas = contextoSalvo.Listas;
    }
}
