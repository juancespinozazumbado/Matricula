using Matricula.AppMovil.ViewModels;

namespace Matricula.AppMovil
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            BindingContext = App.Current.Servicios.GetRequiredService<EstudiantesViewModel>();  
            InitializeComponent();
        }

 
    }
}