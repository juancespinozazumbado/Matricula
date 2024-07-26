using Matricula.BL.Repositorios;
using Matricula.DA.DataBase;
using Matricula.Model.Entidades;
using Matricula.UI.Models.Estudiantes;
using Matricula.UI.Servicios.Iservicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Matricula.UI.Controllers.Estudiantes
{
    public class MujeresRegistradasController : Controller
    {

        IservicioDeEstudiantes _servicioDeEstudiantes;
        public MujeresRegistradasController(IservicioDeEstudiantes servicioDeEstudiantes)
        {
            _servicioDeEstudiantes = servicioDeEstudiantes;

        }
        // GET: MujeresRegistradasController
        public async Task<ActionResult> Index()
        {



            List<EstudianteParaMostrar> Estudiantes = new();

            var estudiantes = await _servicioDeEstudiantes.ObtenerMujeresRegistrados();
            if (estudiantes != null)
            {
                estudiantes.ForEach(e =>
                {
                    Estudiantes.Add(MapearEstudiante(e));
                });

            }

            return View(Estudiantes);


        }

        // GET: MujeresRegistradasController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Estudiante estudiante = await _servicioDeEstudiantes.ObtenerUnEstudiantePorId(id);
            return View(estudiante);
        }



        //////////////////////////////////////////////////////////////////
        ///
         // GET: HomeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Estudiante estudiante = await _servicioDeEstudiantes.ObtenerUnEstudiantePorId(id);
            return View(estudiante);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Estudiante estudiante)
        {
            try
            {
                await _servicioDeEstudiantes.EliminarUnEstudiante(estudiante.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: HomeController/Delete/5
        public async Task<ActionResult> Historial(int id)
        {
            Estudiante estudiante = await _servicioDeEstudiantes.ObtenerUnEstudiantePorId(id);
            List<List<Estudiante>> historial = await _servicioDeEstudiantes.ObtenerHistorialFamiliar(id);       
            ModeloHistorial modelo = new ModeloHistorial
            {
                Estudiante = estudiante,
                Historial = historial

            };

            return View(modelo);
        }

        private EstudianteParaMostrar MapearEstudiante(Estudiante estudiante)
        {
            return new EstudianteParaMostrar()
            {
                Id = estudiante.Id,
                Cedula = estudiante.Cedula,
                Edad = DateTime.Today.Year - estudiante.FechaDeNacimiento.Year,
                Sexo = (Models.Estudiantes.Sexo)estudiante.Sexo,
                NombreCompleto = $"{estudiante.Nombre} {estudiante.PrimerApellido} {estudiante.SegundoApellido}"

            };

        }

    }
}
