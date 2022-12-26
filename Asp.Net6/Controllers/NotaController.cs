using Asp.Net6.Data;
using Asp.Net6.Models;
using Asp.Net6.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Asp.Net6.Controllers
{
    public class NotaController : Controller
    {
        //atributo 
        private readonly ApplicationDbContext _db;
        //Constructor
        public NotaController( ApplicationDbContext db)
        {
            _db= db;
        }


        public IActionResult Index()
        {
            //Incluimos las Listas de Alumno y Curso enlazados a la Nota con el Include
            IEnumerable<Nota> lista = _db.Nota.Include(a => a.Alumno)
                                              .Include(c => c.Curso);
            return View(lista);
        }

        public IActionResult Filtrar(int Id)
        {
            IQueryable<Nota> listaFiltrada = _db.Nota.Include(a => a.Alumno)
                                                     .Include(c => c.Curso).Where(c => c.Curso.Id == Id);

            return View(listaFiltrada);
        }


        //Get Crear/Editar
        public IActionResult Upsert(int? Id)
        {
            //Crear las Listas de Alumno - Curso 
            NotaVM notaVM = new NotaVM()
            {
                Nota = new Nota(),
                AlumnoLista = _db.Alumno.Select(a => new SelectListItem
                {
                    Text = a.NombreApellido,
                    Value = a.Id.ToString()
                }),
                CursoLista = _db.Curso.Select(c => new SelectListItem
                {
                    Text = $"{c.Comision} - {c.Materia}",
                    Value = c.Id.ToString()
                })

            };


            if (Id == null)
            {
                //Crear nueva Nota
                return View(notaVM);
            }
            else
            {
                //Editar Nota
                notaVM.Nota =  _db.Nota.Find(Id);
                if (notaVM.Nota == null)
                {
                    return NotFound();
                }
                return View(notaVM);
            }
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(NotaVM notaVM)
        {
            if (ModelState.IsValid)
            {
                if (notaVM.Nota.Id == 0)
                {
                    //Crear
                    _db.Nota.Add(notaVM.Nota);
                }
                else
                {
                    //Actualizar       
                    _db.Nota.Update(notaVM.Nota);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            //Si no es Valido
            /*Se llenan nuevamente las listas si algo falla*/
            notaVM.AlumnoLista = _db.Alumno.Select(a => new SelectListItem
            {
                Text = a.NombreApellido,
                Value = a.Id.ToString()
            });
            notaVM.CursoLista = _db.Curso.Select(c => new SelectListItem
            {
                Text = $"{c.Comision} - {c.Materia}",
                Value = c.Id.ToString()
            });

            return View(notaVM);
 
        }

        //Get Eliminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            Nota nota = _db.Nota.Include(a => a.Alumno)
                                 .Include(c => c.Curso)
                                 .FirstOrDefault(n=>n.Id == Id);

            if (nota == null)
            {
                return NotFound();
            }
            return View(nota);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Nota nota)
        {
            if (nota == null)
            {
                return NotFound();
            }
            _db.Nota.Remove(nota);
            _db.SaveChanges();
            return RedirectToAction("Index");
        
        }
    }
}




