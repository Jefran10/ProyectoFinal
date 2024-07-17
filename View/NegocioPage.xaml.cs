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
        ObservableCollection<Models.Business> usu;
        HttpClient cliente = new HttpClient();
        String url = "http://192.168.200.7/proyecto/usuarios.php";
        var content = await cliente.GetStringAsync(url);
        List<Models.Business> mostrar = JsonConvert.DeserializeObject<List<Models.Business>>(content);
        usu = new ObservableCollection<Models.Business>(mostrar);
        listaNegocios.ItemsSource = usu;
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