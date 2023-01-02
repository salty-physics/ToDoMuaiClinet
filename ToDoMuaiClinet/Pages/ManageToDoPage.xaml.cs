using ToDoMuaiClinet.DataServices;
using ToDoMuaiClinet.Models;

namespace ToDoMuaiClinet.Pages;

[QueryProperty(nameof(ToDo), "ToDo")] //wymagane do przekazywania parametrów
public partial class ManageToDoPage : ContentPage
{
    private readonly IRestDataService _dataService;

	private ToDo _toDo;
	private bool _isNew;
	
	public ToDo ToDo
	{
		get => _toDo;
		set
		{
			_isNew = IsNew(value);
			_toDo = value;
			OnPropertyChanged();
		}
	}


    public ManageToDoPage(IRestDataService dataService)
	{
		InitializeComponent();

		_dataService = dataService;
		BindingContext = this;
	}

	private bool IsNew(ToDo item)
	{
		if (item.Id == 0) return true;

		return false;
	}

	async void OnCancelButtonClick(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

    async void OnDeleteButtonClick(object sender, EventArgs e)
    {
		//await _dataService.DeleteTaskAsync(_toDo.Id); //nie wiem czemu nie to
        await _dataService.DeleteTaskAsync(ToDo.Id);
        await Shell.Current.GoToAsync("..");
    }

    async void OnSaveButtonClick(object sender, EventArgs e)
    {
		if (_isNew)
		{
			await _dataService.AddTaskAsync(ToDo);
		}
		else
		{
			await _dataService.UpdateTaskAsync(ToDo);
		}

        await Shell.Current.GoToAsync("..");
    }
}