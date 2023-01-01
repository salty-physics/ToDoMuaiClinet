using System.Diagnostics;
using ToDoMuaiClinet.DataServices;

namespace ToDoMuaiClinet;

public partial class MainPage : ContentPage
{
    private readonly IRestDataService _dataService;

    public MainPage(IRestDataService dataService)
	{
		InitializeComponent();

        _dataService = dataService;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        
        collectionView.ItemsSource = await _dataService.GetAllToDoAsync();
    }

    async void OnAddToDoClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Add clicked");
    }

    async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine("Selection changed");
    }

}

