using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Matricula.AppMovil.Models.Dtos;
using Matricula.AppMovil.Servicios.Iservicios;
using System.Collections.ObjectModel;

namespace Matricula.AppMovil.ViewModels
{
    partial class EstudiantesViewModel : ObservableObject
    {
        public ObservableCollection<EstudianteModel> Estudiantes { get; set; } = new();

        private readonly IServicioDeEstudiantes _servicioDeEstudiantes;
        
        public EstudiantesViewModel()
        {
            _servicioDeEstudiantes = App.Current.Servicios.GetRequiredService<IServicioDeEstudiantes>();
        }

        [RelayCommand]
        public async void VerEstudiantesRegistrados()
        {
            Estudiantes.Clear();

            var estudiantes = await _servicioDeEstudiantes.ListaDeEstudiantesRegistrados();
            if (estudiantes != null)
            {
                // mapeo
                estudiantes.ForEach(e =>
                {
                    Estudiantes.Add(new EstudianteModel()
                    {
                        Cedula = e.Cedula,
                        NombreCompleto = $"{e.Nombre} {e.PrimerApellido} {e.SegundoApellido}",
                        Sexo = e.Sexo,
                        Edad = DateTime.Now.Year - e.FechaDeNacimiento.Year,
                        CedulaMadre = e.CedulaMadre,
                        CedulaPadre = e.CedulaPadre

                    });
                });
            }

            await Task.Delay(1000);

            await Shell.Current.GoToAsync($"{nameof(Views.EstudiantesPage)}");
        }


        [RelayCommand]
        public async void VerHombresRegistrados()
        {
            Estudiantes.Clear();

            var estudiantes = await _servicioDeEstudiantes.ObtenerHombresRegistrados();
            if (estudiantes != null)
            {
                // mapeo
                estudiantes.ForEach(e =>
                {
                    Estudiantes.Add(new EstudianteModel()
                    {
                        Cedula = e.Cedula,
                        NombreCompleto = $"{e.Nombre} {e.PrimerApellido} {e.SegundoApellido}",
                        Sexo = e.Sexo,
                        Edad = DateTime.Now.Year - e.FechaDeNacimiento.Year,
                        CedulaMadre = e.CedulaMadre,
                        CedulaPadre = e.CedulaPadre

                    });
                });
            }


            await Task.Delay(1000);

            await Shell.Current.GoToAsync($"{nameof(Views.HombresPage)}");
        }


        [RelayCommand]
        public async void VerMujeresRegistrados()
        {

            Estudiantes.Clear();

            var estudiantes = await _servicioDeEstudiantes.ObtenerMujeresRegistrados();
            if (estudiantes != null)
            {
                // mapeo
                estudiantes.ForEach(e =>
                {
                    Estudiantes.Add(new EstudianteModel()
                    {
                        Cedula = e.Cedula,
                        NombreCompleto = $"{e.Nombre} {e.PrimerApellido} {e.SegundoApellido}",
                        Sexo = e.Sexo,
                        Edad = DateTime.Now.Year - e.FechaDeNacimiento.Year,
                        CedulaMadre = e.CedulaMadre,
                        CedulaPadre = e.CedulaPadre

                    });
                });

                await Task.Delay(1000);

                await Shell.Current.GoToAsync($"{nameof(Views.MujeresPage)}");


            }
        }
    }


}
        

