namespace ProyectoFinal.View;

public partial class DetallePage : ContentPage
{
	public DetallePage(String user)
	{
		InitializeComponent();
        lblUsuario.Text = user;
        lblUbicacion.Text = "Marieta de Veintimilla";
        lblNegocio.Text = "Comida r�pida";
        lblCategoria.Text = "Comida";
        lblDescripcion.Text = "Venta de comida r�pida como: papas fritas, hamburguesas";
    }
}