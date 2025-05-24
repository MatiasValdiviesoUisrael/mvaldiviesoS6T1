using System.Collections.Specialized;
using System.Net;
using mvaldiviesoS6T1.Models;

namespace mvaldiviesoS6T1.Views;

public partial class vActualizarEliminarEstudiante : ContentPage
{
    public vActualizarEliminarEstudiante(Estudiante estudiante)
    {
        InitializeComponent();
        txtCodigo.Text = estudiante.codigo.ToString();
        txtCedula.Text = estudiante.cedula;
        txtNombre.Text = estudiante.nombre;
        txtApellido.Text = estudiante.apellido;
        txtEdad.Text = estudiante.edad.ToString();
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        // Validaci�n b�sica
        if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtEdad.Text))
        {
            DisplayAlert("Error", "Todos los campos son obligatorios para actualizar.", "OK");
            return;
        }

        try
        {
            WebClient client = new WebClient();
            var parametros = new NameValueCollection();

            string url = $"http://localhost/moviles/post.php?codigo={txtCodigo.Text}&cedula={txtCedula.Text}&nombre={txtNombre.Text}&apellido={txtApellido.Text}&edad={txtEdad.Text}";

            client.UploadData(url, "PUT", new byte[0]);

            DisplayAlert("�xito", "Estudiante actualizado correctamente.", "OK");
            Navigation.PushAsync(new vEstudiante());
        }
        catch (WebException webEx)
        {
            string errorMessage = "Error desconocido.";
            if (webEx.Status == WebExceptionStatus.ProtocolError)
            {
                HttpWebResponse response = (HttpWebResponse)webEx.Response;
                errorMessage = $"Error HTTP: {response.StatusCode} - {new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd()}";
            }
            else
            {
                errorMessage = webEx.Message;
            }
            DisplayAlert("Error de Actualizaci�n", "No se pudo actualizar el estudiante: " + errorMessage, "OK");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient client = new WebClient();

            string url = $"http://localhost/moviles/post.php?codigo={txtCodigo.Text}";

            client.UploadData(url, "DELETE", new byte[0]);

            DisplayAlert("�xito", "Estudiante eliminado correctamente.", "OK");
            Navigation.PushAsync(new vEstudiante());
        }
        catch (WebException webEx)
        {
            string errorMessage = "Error desconocido.";
            if (webEx.Status == WebExceptionStatus.ProtocolError)
            {
                HttpWebResponse response = (HttpWebResponse)webEx.Response;
                errorMessage = $"Error HTTP: {response.StatusCode} - {new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd()}";
            }
            else
            {
                errorMessage = webEx.Message;
            }
            DisplayAlert("Error de Eliminaci�n", "No se pudo eliminar el estudiante: " + errorMessage, "OK");
        }
    }
}