using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.Net6.Models.ViewModels
{
    public class NotaVM
    {
        public Nota Nota { get; set; }

        public IEnumerable<SelectListItem>? AlumnoLista { get; set; }
        public IEnumerable<SelectListItem>? CursoLista { get; set; }


    }
}
