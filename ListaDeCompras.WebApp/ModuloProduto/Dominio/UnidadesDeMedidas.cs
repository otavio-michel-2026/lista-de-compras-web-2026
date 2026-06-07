using System.ComponentModel.DataAnnotations;

namespace ListaDeCompras.WebApp.ModuloProduto;
//Dominio

public enum UnidadeDeMedida
{
    [Display(Name = "unidade")]
    Unidade,

    [Display(Name = "kg")]
    KGs,

    [Display(Name = "g")]
    Gramas,

    [Display(Name = "L")]
    Litros,

    [Display(Name = "mL")]
    Mls,
}

