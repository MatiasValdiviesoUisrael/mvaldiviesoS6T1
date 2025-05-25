using mvaldiviesoS6T1.Models;
using System.Net;

namespace mvaldiviesoS6T1.Views;

public partial class agregarEstudiante : ContentPage
{
	public agregarEstudiante(Estudiante datos)
	{
		InitializeComponent();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtCedula.Text = datos.cedula;
        txtEdad.Text = datos.edad.ToString();
    }

	private void btnAgregar_Clicked(object sender, EventArgs e)
    {

        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
            cliente.UploadValues("http://localhost:3000/post.php", "POST", parametros);
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex) 
        {
            DisplayAlert("Error", "No se pudo agregar el estudiante: " + ex.Message, "OK");
        }



    }
}