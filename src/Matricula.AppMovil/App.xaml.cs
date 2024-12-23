using Matricula.AppMovil.Servicios;
using Matricula.AppMovil.Servicios.Iservicios;
using Matricula.AppMovil.ViewModels;
using Matricula.AppMovil.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Matricula.AppMovil
{
    public partial class App : Application
    {
        public static new App Current => (App)Application.Current;
        public IServiceProvider Servicios { get; }


        public App()
        {
            ServiceCollection servicios = new ServiceCollection();
            Servicios = ConfigurarServicios(servicios);


            InitializeComponent();

            MainPage = new AppShell();
        }

        private static IServiceProvider ConfigurarServicios(ServiceCollection servicios)
        {

            servicios.AddSingleton<IServicioRest, ServicioRest>();
            servicios.AddSingleton<IServicioDeEstudiantes, ServicioDeEstudiantes>();


            servicios.AddHttpClient();
      

            servicios.AddScoped<EstudiantesViewModel>();

            servicios.AddSingleton<EstudiantesPage>();
            servicios.AddSingleton<MujeresPage>();
            servicios.AddSingleton<HombresPage>();



            return servicios.BuildServiceProvider();

        }
    }
}