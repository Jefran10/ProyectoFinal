using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ProyectoFinal.View;

public partial class NegocioPage : ContentPage
{
    String usuario;
    public NegocioPage(String user)
    {
        InitializeComponent();

        lblUsuario.Text = user;
        usuario = user;
        listar();
    }
    public async void listar()
    {

    }

    private async void btnDetalle_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn.BindingContext is Models.Business negocio)
            {
                await Navigation.PushAsync(new DetallePage(usuario));
            }
        }
    }
}