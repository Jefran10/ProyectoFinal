using ProyectoFinal.Services;

namespace ProyectoFinal.View;

public partial class RegisterPage : ContentPage
{
    private readonly ApiService _apiService;

    public RegisterPage()
	{
		InitializeComponent();
        _apiService = new ApiService();

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        bool success = await _apiService.RegisterAsync(username, email, password);

        if (success)
        {
            await DisplayAlert("Success", "Registration successful. Please login.", "OK");
            await Navigation.PopAsync(); // Volver a la página de login
        }
        else
        {
            await DisplayAlert("Error", "Registration failed. Please try again.", "OK");
        }

    }
}