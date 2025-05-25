using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using AndroidX.Navigation;
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
}