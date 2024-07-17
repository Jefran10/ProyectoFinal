namespace ProyectoFinal.View;

public partial class MapaPage : ContentPage
{
    String usuario;
    public MapaPage(String user)
	{
		InitializeComponent();
        lblUsuario.Text = user;
        usuario = user;
    }

    private void btnBuscar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NegocioPage(usuario));

    }
}