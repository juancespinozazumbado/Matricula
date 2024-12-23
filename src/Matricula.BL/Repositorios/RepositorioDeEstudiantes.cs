using Matricula.DA.DataBase;
using Matricula.Model.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Matricula.BL.Repositorios
{
    public class RepositorioDeEstudiantes : IrepositorioDeEstudiantes
    {
        private DBContexto _Contexto;
        public RepositorioDeEstudiantes(DBContexto contexto)
        {
            _Contexto = contexto;
        }


        public async Task<List<Estudiante>> ListaDeEstudiantesRegistrados()
        {
            return await _Contexto.Estudiantes.ToListAsync();
        }

        public async Task<bool> RegistrarUnEstudiante(Estudiante estudiante)
        {
             await _Contexto.Estudiantes.AddAsync(estudiante);
             await  _Contexto.SaveChangesAsync();
            return true;    

        }

        public async Task<Estudiante?> ObtenerUnEstudiantePorId(int id)
        {
            var estudiante = await _Contexto.Estudiantes.ToListAsync();
                return estudiante.Find(e => e.Id == id);
        }


        public async Task<bool> EditarUnEstudiante(Estudiante estudiante)
        {
            var estudianteAeditar = await ObtenerUnEstudiantePorId(estudiante.Id);

            if (estudianteAeditar != null)
            {
                estudianteAeditar.Nombre = estudiante.Nombre;
                estudianteAeditar.FechaDeNacimiento = estudiante.FechaDeNacimiento;
                _Contexto.Estudiantes.Update(estudianteAeditar);
                await _Contexto.SaveChangesAsync();
                return true;
            }
            else return false;

        }

        public async Task<List<List<Estudiante>>>  ObtenerHistorialFamiliar(int id)
        {
            var estudiante = await ObtenerUnEstudiantePorId(id);

            Dictionary<int, List<Estudiante>> HistorialFamiliar = new()
            {
                { 1, Hijos(estudiante) },
                { 2, Padres(estudiante) },
                { 3, Hermanos(estudiante) },
                { 4, Abuelos(estudiante) }
            };
            List<Estudiante> tiosPaternos = Tios(estudiante)[0];
            List<Estudiante> tiosMaternos = Tios(estudiante)[1];
            HistorialFamiliar.Add(5, tiosPaternos);
            HistorialFamiliar.Add(6, tiosMaternos);
          
            HistorialFamiliar.Add(7, Primos(estudiante));

            return HistorialFamiliar.Values.ToList();

        }

        public async Task<List<Estudiante>> ObtenerHombresRegistrados()
        {
            var estudiantes = await _Contexto.Estudiantes.ToListAsync();
            var hombresRegistrados = from estudiante in estudiantes
                                     where estudiante.Sexo == Sexo.Hombre
                                     select estudiante;

            return (List<Estudiante>)hombresRegistrados.ToList();


        }

        public async Task<List<Estudiante>> ObtenerMujeresRegistrados()
        {
            var estudiantes = await _Contexto.Estudiantes.ToListAsync();
            var hombresRegistrados = from estudiante in estudiantes
                                     where estudiante.Sexo == Sexo.Mujer
                                     select estudiante;

            return (List<Estudiante>)hombresRegistrados.ToList();
        }

        public async Task<bool> EliminarUnEstudiante(int id)
        {
            var estuddiante = await ObtenerUnEstudiantePorId(id);

            if(estuddiante != null)
            {
               _Contexto.Estudiantes.Remove(estuddiante);
                await _Contexto.SaveChangesAsync();
                return true;

            } else return false;
           
        }



        //// Metodos para historial familiar 
        ///

        private List<Estudiante> Padres(Estudiante estudiante)
        {
            var estudiantes = _Contexto.Estudiantes.ToList();

            var padres = from padre in estudiantes
                         where padre.Cedula == estudiante.CedulaPadre
                          || padre.Cedula == estudiante.CedulaMadre
                         select padre;

            List<Estudiante> Padres = padres.ToList();
            return Padres;
        }



        private List<Estudiante> Hijos(Estudiante estudiante)
        {
            var estudiantes = _Contexto.Estudiantes.ToList();

            var hijos = from hijo in estudiantes
                         where hijo.CedulaPadre == estudiante.Cedula
                          || hijo.CedulaMadre == estudiante.Cedula
                         select hijo;

            List<Estudiante> Hijos = hijos.ToList();
            return Hijos;
        }

        private List<Estudiante> Hermanos (Estudiante estudiante)
        {
            var estudiantes = _Contexto.Estudiantes.ToList();
            var hermanos = from hermano in estudiantes
                           where 
                           hermano.CedulaPadre == estudiante.CedulaPadre
                            || hermano.CedulaMadre == estudiante.CedulaMadre
                           select hermano;
            List<Estudiante> Hermanos = hermanos.ToList();

                Hermanos.Remove(estudiante);
            return Hermanos;
        }


        private List<Estudiante>? Abuelos(Estudiante estudiante)
        {
            var estudiantes = _Contexto.Estudiantes.ToList();
            var padres = Padres(estudiante).ToList();
            List<Estudiante> Abuelos = new();
            if (padres.Count == 2)
            {
                Estudiante Padre = padres[0];
                Estudiante Madre = padres[1];

                var abuelos = from abuelo in estudiantes
                              where abuelo.Cedula == Padre.CedulaPadre
                               || abuelo.Cedula == Padre.CedulaMadre
                               || abuelo.Cedula == Madre.CedulaPadre
                               || abuelo.Cedula == Madre.CedulaMadre
                              select abuelo;
                Abuelos.AddRange(abuelos);

            }
            else if(padres.Count > 0)
            {
                Estudiante Padre = padres[0];
                

                var abuelos = from abuelo in estudiantes
                              where abuelo.Cedula == Padre.CedulaPadre
                               || abuelo.Cedula == Padre.CedulaMadre
                              
                              select abuelo;
                Abuelos.AddRange(abuelos);  
            }
            
            return Abuelos;

        }

        private List<List<Estudiante>>? Tios(Estudiante estudiante)
        {
            
            List<List<Estudiante>> Tios = new();
            Tios.Add(new List<Estudiante> { });
                 Tios.Add(new List<Estudiante> { });

            var padres = Padres(estudiante).ToList();
            if (padres.Count == 2)
            {
                List<Estudiante> TiosPaternos = Hermanos(padres[0]).ToList();
                List<Estudiante> TiosMaternos = Hermanos(padres[1]).ToList();
                
                Tios[0].AddRange(TiosPaternos);
                Tios[1].AddRange(TiosMaternos);
            } else if(padres.Count >0) 
            {
                List<Estudiante> TiosPaternos = Hermanos(padres[0]).ToList();
                
                Tios[0].AddRange(TiosPaternos);
             
            }
               
            return Tios;

        }


        private List<Estudiante> Primos(Estudiante estudiante)
        {
            var estudiantes = _Contexto.Estudiantes.ToList();
         
            List<Estudiante> Primos = new(); 
            var tios = Tios(estudiante);
            List<Estudiante> TiosDelEstudiante = new();
            TiosDelEstudiante.AddRange(tios[0]);
            TiosDelEstudiante.AddRange(tios[1]);




            foreach (var tio in TiosDelEstudiante)
            {       
                 var primos = from est in estudiantes
                             where est.CedulaPadre == tio.Cedula
                             || est.CedulaMadre == tio.Cedula
                             select est;

                Primos.AddRange(primos);
                

            }
            Primos = Primos.Distinct().ToList();

            if (Primos.Count > 0 && Primos.Contains(estudiante))
            {
                Primos.Remove(estudiante);
                
            }

            return Primos;

        }

        public async Task<List<Estudiante>> ObtenerEstudiantePorNombre(string nombre)
        {
             var estudiantes = await _Contexto.Estudiantes.ToListAsync();
                
                return estudiantes.Where(e => e.Nombre.Contains(nombre)).ToList();
        }

        public async Task<List<Estudiante>> ObtenerEstudiantePorApellidos(string apellidos)
        {
            var estudiantes = await _Contexto.Estudiantes.ToListAsync();
               return estudiantes.Where(e =>
                                   e.PrimerApellido.Contains(apellidos) 
                                   || e.SegundoApellido.Contains(apellidos)).ToList();
        }

        public async Task<List<Estudiante>> ObtenerEstudiantePorCedula(string cedula)
        {
            var estudiantes = await _Contexto.Estudiantes.ToListAsync();
                return estudiantes.Where(e=> e.Cedula == cedula).ToList();
        }
    }
}