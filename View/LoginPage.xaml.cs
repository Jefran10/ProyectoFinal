using ProyectoFinal.Services;
using ProyectoFinal.Models;

namespace ProyectoFinal.View;

public partial class LoginPage : ContentPage
         
{
    private readonly ApiService _apiService;

    public LoginPage()
	{
		InitializeComponent();
    _apiService = new ApiService();
        


    }

    private async  void Button_Clicked(object sender, EventArgs e)
    {

        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        // Llamar al m�todo de login en ApiService
        bool success = await _apiService.LoginAsync(username, password);


        if (success)
        {
            // Navegar a la siguiente p�gina despu�s del login (por ejemplo, MainPage)
             await Navigation.PushAsync(new MenuPage());
        }
        else
        {
             await DisplayAlert("Error", "Usuario o contrase�a incorrectos", "Aceptar");

        }

    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
         await Navigation.PushAsync(new RegisterPage());

    }
}