using Matricula.AppMovil.ViewModels;

namespace Matricula.AppMovil.Views;

public partial class EstudiantesPage : ContentPage
{
	public EstudiantesPage()
	{
		BindingContext = App.Current.Servicios.GetRequiredService<EstudiantesViewModel>();	
		InitializeComponent();
	}
}