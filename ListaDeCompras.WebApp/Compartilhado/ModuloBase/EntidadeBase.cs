namespace ListaDeCompras.WebApp.Compartilhado.ModuloBase;
// Domínio
public abstract class EntidadeBase<T> where T : EntidadeBase<T>
{
    public Guid Id {get; set;}
    public abstract void Atualizar(EntidadeBase<T> entidadeAtualizada);
}
