using FluentResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ListaDeCompras.WebApp.Compartilhado.Extensions;
// Apresentação
public static class ModelStateExtensions
{
    public static void AddModelError(this ModelStateDictionary modelState, ResultBase result)
    {
        foreach (var e in result.Errors)
        {
            string c = e.Metadata["Campo"] as string ?? string.Empty;
            modelState.AddModelError(c, e.Message);
        }
    }
}
