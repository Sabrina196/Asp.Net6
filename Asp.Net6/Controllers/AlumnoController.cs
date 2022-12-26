using Asp.Net6.Data;
using Asp.Net6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netCore6.Controllers
{
    public class AlumnoController : Controller
    {
        //variable privada 
        private readonly ApplicationDbContext _db;

        //Constructor
        public AlumnoController(ApplicationDbContext db)
        {
            _db = db;     
        }

        public IActionResult Index()
        {
            //Extraer lista de datos de Alumnos 
            IEnumerable<Alumno> lista = _db.Alumno;
            return View(lista);
        }
        
        //Get Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Alumno alumno)
        {
            //Validación
            /*Si el modelo es válido, se graban los datos y retorna la vista*/
            if (ModelState.IsValid)
            {
                _db.Alumno.Add(alumno);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            /*Sino se retorna a la misma vista crear pero se le envia los datos ingresados en alumno*/
            return View(alumno);

        }

        //Get Editar
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            //Se captura al Alumno por el Id
            var editarobj = _db.Alumno.Find(Id);
            //Si el obj es null, que tambien retorne NotFound
            if (editarobj == null)
            {
                return NotFound();
            }
            //Si no es Null, retornamos obj a la vista
            return View(editarobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _db.Alumno.Update(alumno);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            /*Sino se retorna a la misma vista crear pero se le envia los datos ingresados en alumno*/
            return View(alumno);

        }

        //Get Elminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            //Se captura al Alumno por el Id
            var eliminarobj = _db.Alumno.Find(Id);
            //Si el obj es null, que tambien retorne NotFound
            if (eliminarobj == null)
            {
                return NotFound();
            }
            //Si no es Null, retornamos obj a la vista
            return View(eliminarobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Alumno alumno)
        {
            if (alumno == null)
            {
                return NotFound();
            }
            _db.Alumno.Remove(alumno);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
