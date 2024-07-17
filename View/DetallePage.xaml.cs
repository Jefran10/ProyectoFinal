namespace ProyectoFinal.View;

public partial class DetallePage : ContentPage
{
	public DetallePage(String user)
	{
		InitializeComponent();
        lblUsuario.Text = user;
       // lblUbicacion.Text = negocio.address;
        //lblNegocio.Text = negocio.name;
        //lblCategoria.Text = negocio.category;
       // lblDescripcion.Text = negocio.description;
    }
}