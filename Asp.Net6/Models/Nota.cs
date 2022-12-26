using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Net6.Models
{
    public class Nota
    {
        [Key]
        public int Id { get; set; }

        [MaxLength (3)]
        public string Informe_1 { get; set; }

        [Required(ErrorMessage ="Escriba un Número o el Cero en su defecto")]
        [Range(0,10, ErrorMessage ="El rango del valor de la nota es de 0 a 10")]
        public int nota1 { get; set; }

        [MaxLength(3)]
        public string Informe_2 { get; set; }

        [Required(ErrorMessage = "Escriba un Número o el Cero en su defecto")]
        [Range(0, 10, ErrorMessage = "El rango del valor de la nota es de 0 a 10")]
        public int nota2 { get; set; }

        [MaxLength(3)]
        public string Informe_3 { get; set; }

        [Required(ErrorMessage = "Escriba un Número o el Cero en su defecto")]
        [Range(0, 10, ErrorMessage = "El rango del valor de la nota es de 0 a 10")]
        public int nota3 { get; set; }

        public int notaFinal { get; set; }

        //Foreign Key
        public int AlumnoId { get; set; }

        [ForeignKey("AlumnoId")]
        public virtual Alumno? Alumno { get; set; }

        public int CursoId { get; set; }

        [ForeignKey("CursoId")]
        public virtual Curso?Curso { get; set; }
    }
}
