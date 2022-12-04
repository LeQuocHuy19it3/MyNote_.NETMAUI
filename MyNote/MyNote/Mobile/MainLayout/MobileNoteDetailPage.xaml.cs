using MyNote.ViewModels;
namespace MyNote.Mobile.MainLayout;

public partial class MobileNoteDetailPage : ContentPage
{
	public MobileNoteDetailPage()
	{
		InitializeComponent();
		this.BindingContext = new NoteViewModel();
	}

    private async void back1_click(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}