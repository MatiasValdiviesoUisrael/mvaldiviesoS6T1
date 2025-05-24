using System.Net;

namespace mvaldiviesoS6T1.Views;

public partial class vAñadirEstudiante : ContentPage
{
	public vAñadirEstudiante()
	{
		InitializeComponent();
	}

    private void btnAñadir_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient client = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("cedula", txtcedula.Text);
            parametros.Add("nombre", txtnombre.Text);
            parametros.Add("apellido", txtapellido.Text);
            parametros.Add("edad", txtedad.Text);

			client.UploadValues("http://localhost:3000/post.php", "POST", parametros);
			Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
		{
			DisplayAlert("Error", "No se pudo añadir el estudiante: " + ex.Message, "OK");
        }
    }
}