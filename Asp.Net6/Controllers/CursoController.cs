using Asp.Net6.Data;
using Asp.Net6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net6.Controllers
{
    public class CursoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CursoController( ApplicationDbContext db)
        {
            _db= db;
        }

        public IActionResult Index()
        {
            IEnumerable<Curso> lista = _db.Curso;
            return View(lista);
        }

        //Get Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Curso curso)
        {
            //Validación
            if (ModelState.IsValid)
            {
                _db.Curso.Add(curso);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(curso);

        }

        //Get Editar
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var editarobj = _db.Curso.Find(Id);
            if (editarobj == null) 
            {
                return NotFound();
            }
            return View(editarobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Curso curso)
        {

            if (ModelState.IsValid)
            {
                _db.Curso.Update(curso);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(curso);

        }

        //Get Eliminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var eliminarobj = _db.Curso.Find(Id);
            if (eliminarobj == null)
            {
                return NotFound();
            }
            return View(eliminarobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Curso curso)
        {

            if (curso == null)
            {
                return NotFound();
            }
            _db.Curso.Remove(curso);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
