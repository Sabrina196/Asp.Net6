using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Asp.Net6.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Comision es obligatorio.")]
        public string Comision { get; set; }

        [Required(ErrorMessage = "El campo materia es obligatorio.")]
        public string Materia { get; set; }

        [Required(ErrorMessage = "El campo horario es obligatorio.")]
        public string horario{ get; set; }

        [DisplayName("Año Lectivo")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(2022,2023, ErrorMessage ="El campo debe tener el año actual")]
        public int anioLectivo { get; set; }
    }
}
