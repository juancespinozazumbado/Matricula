using Matricula.AppMovil.ViewModels;

namespace Matricula.AppMovil.Views;

public partial class MujeresPage : ContentPage
{
	public MujeresPage()
	{
        BindingContext = App.Current.Servicios.GetRequiredService<EstudiantesViewModel>();
        InitializeComponent();
	}
}