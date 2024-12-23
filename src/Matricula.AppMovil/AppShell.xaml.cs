using Matricula.AppMovil.Views;

namespace Matricula.AppMovil
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(EstudiantesPage), typeof(EstudiantesPage));
            Routing.RegisterRoute(nameof(HombresPage), typeof(HombresPage));
            Routing.RegisterRoute(nameof(MujeresPage), typeof(MujeresPage));
        }
    }
}