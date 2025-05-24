using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using mvaldiviesoS6T1.Models;
using Newtonsoft.Json;

namespace mvaldiviesoS6T1.Views;

public partial class vEstudiante : ContentPage
{

	private const string URL = "http://localhost:3000/post.php";
	private readonly HttpClient estudiante = new HttpClient();
	private ObservableCollection<Estudiante> estudiantes;

    public vEstudiante()
	{
		InitializeComponent();
		Obtener();
	}

	public async void Obtener()
	{
		var content = await estudiante.GetStringAsync(URL);
		List<Estudiante> lista = JsonConvert.DeserializeObject<List<Estudiante>>(content);
        estudiantes = new ObservableCollection<Estudiante>(lista);
        listaEstudiantes.ItemsSource = estudiantes;
    }

    private void btnNuevo_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new vAñadirEstudiante());
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objEstudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new vActualizarEliminarEstudiante(objEstudiante));
    }
}