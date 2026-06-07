using System.ComponentModel.DataAnnotations;

namespace ListaDeCompras.WebApp.ModuloListaCompras.Dominio;

public enum StatusLista
{
    [Display(Name = "Aberta")]
    Aberta,
    [Display(Name = "Cocnluída")]
    Concluida
}
