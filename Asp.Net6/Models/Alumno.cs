using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Asp.Net6.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nombre y Apellido")]
        [Required(ErrorMessage ="El campo Nombre es obligatorio.")]
        public string NombreApellido { get; set; }

        public string correo { get; set; }
    }
}
