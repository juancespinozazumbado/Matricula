using Matricula.AppMovil.ViewModels;

namespace Matricula.AppMovil.Views;

public partial class HombresPage : ContentPage
{
	public HombresPage()
	{
        BindingContext = App.Current.Servicios.GetRequiredService<EstudiantesViewModel>();
        InitializeComponent();
	}
}