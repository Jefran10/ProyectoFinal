namespace ProyectoFinal.View;

public partial class DetallePage : ContentPage
{
	public DetallePage(String user)
	{
		InitializeComponent();
        lblUsuario.Text = user;
        lblUbicacion.Text = "Marieta de Veintimilla";
        lblNegocio.Text = "Comida rápida";
        lblCategoria.Text = "Comida";
        lblDescripcion.Text = "Venta de comida rápida como: papas fritas, hamburguesas";
    }
}