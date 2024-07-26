using Matricula.BL.Repositorios;
using Matricula.DA.DataBase;
using Matricula.Model.Entidades;
using Matricula.UI.Models.Estudiantes;
using Matricula.UI.Servicios.Iservicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Matricula.UI.Controllers.Estudiantes
{
    public class EstudiantesController : Controller
    {

        private readonly IservicioDeEstudiantes _servicioDeEstudiantes;
        public EstudiantesController(IservicioDeEstudiantes sevicioDeEstudiantes)
        {
           _servicioDeEstudiantes = sevicioDeEstudiantes;   

        }
        // GET: HomeController
        public async Task<ActionResult> Index(string busqueda)
        {
            List<EstudianteParaMostrar> Estudiantes = new();
            if (busqueda == null)
            {

                 var  estudiantes = await _servicioDeEstudiantes.ListaDeEstudiantesRegistrados();  
               if(estudiantes!= null)
                {
                    estudiantes.ForEach(e =>
                    {
                        Estudiantes.Add(MapearEstudiante(e));
                    });

                }

            }
            else
            {
                var estudiantes = new List<Estudiante>();   
                
                
                    estudiantes.AddRange(await _servicioDeEstudiantes.ObtenerEstudiantePorCedula(busqueda));
                    estudiantes.AddRange(await _servicioDeEstudiantes.ObtenerEstudiantePorNombre(busqueda));
                    estudiantes.AddRange(await _servicioDeEstudiantes.ObtenerEstudiantePorApellidos(busqueda));

                    estudiantes.ForEach(e =>
                    {
                        Estudiantes.Add(MapearEstudiante(e));
                    });

                


            }
                
            return View(Estudiantes);
        }

        // GET: HomeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Estudiante estudiante = await _servicioDeEstudiantes.ObtenerUnEstudiantePorId(id);
            return View(estudiante);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();

            
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EstudianteParaAgregar estudianteParaAgregar)
        {
            try
            {
                Estudiante estudiante = new Estudiante
                {
                    Cedula = estudianteParaAgregar.Cedula,
                    Nombre = estudianteParaAgregar.Nombre,
                    PrimerApellido = estudianteParaAgregar.PrimerApellido,
                    SegundoApellido = estudianteParaAgregar.SegundoApellido,
                    Sexo = (Model.Entidades.Sexo)estudianteParaAgregar.Sexo,
                    FechaDeNacimiento = estudianteParaAgregar.FechaDeNacimiento,
                    CedulaMadre = estudianteParaAgregar.CedulaMadre,
                    CedulaPadre = estudianteParaAgregar.CedulaPadre

                };

                await _servicioDeEstudiantes.RegistrarUnEstudiante(estudiante);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Estudiante estudiante = await _servicioDeEstudiantes.ObtenerUnEstudiantePorId(id);
            EstudianteParaAgregar estudianteAEditar = new EstudianteParaAgregar
            {
                Id = estudiante.Id,
                Cedula = estudiante.Cedula,
                Nombre = estudiante.Nombre,
                PrimerApellido = estudiante.PrimerApellido,
                SegundoApellido = estudiante.SegundoApellido,
                Sexo = (UI.Models.Estudiantes.Sexo)estudiante.Sexo,
                FechaDeNacimiento = estudiante.FechaDeNacimiento,
                CedulaMadre = estudiante.CedulaMadre,
                CedulaPadre = estudiante.CedulaPadre
            };
            return View(estudianteAEditar);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EstudianteParaAgregar estudianteParaAgregar)
        {
            try
            {
                int Id = estudianteParaAgregar.Id;
                Estudiante estudiante = await _servicioDeEstudiantes.ObtenerUnEstudiantePorId(Id);

                estudiante.Id = estudianteParaAgregar.Id;
                estudiante.Cedula = estudianteParaAgregar.Cedula;
                estudiante.Nombre = estudianteParaAgregar.Nombre;
                estudiante.PrimerApellido = estudianteParaAgregar.PrimerApellido;
                estudiante.SegundoApellido = estudianteParaAgregar.SegundoApellido;
                estudiante.Sexo = (Model.Entidades.Sexo)(Models.Estudiantes.Sexo)estudianteParaAgregar.Sexo;
                estudiante.FechaDeNacimiento = estudianteParaAgregar.FechaDeNacimiento;
                estudiante.CedulaMadre = estudianteParaAgregar.CedulaMadre;
                estudiante.CedulaPadre = estudianteParaAgregar.CedulaPadre;


                await _servicioDeEstudiantes.EditarUnEstudiante(estudiante);


                return RedirectToAction(nameof(Index));
            }
            catch { 
            
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Estudiante estudiante = await _servicioDeEstudiantes.ObtenerUnEstudiantePorId(id);
            return View(estudiante);
        }

        // POST: HomeController/Delete/5
        [HttpPost ]
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
                Id =estudiante.Id,  
                Cedula = estudiante.Cedula,
                Edad =  DateTime.Today.Year - estudiante.FechaDeNacimiento.Year,
                Sexo= (Models.Estudiantes.Sexo)estudiante.Sexo,
                NombreCompleto = $"{estudiante.Nombre} {estudiante.PrimerApellido} {estudiante.SegundoApellido}"

            };

        }
    }

}
