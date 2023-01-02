using ToDoMuaiClinet.Pages;

namespace ToDoMuaiClinet;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ManageToDoPage), typeof(ManageToDoPage));
		
	}
}
