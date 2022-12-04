using MyNote.ViewModels;
namespace MyNote.Desktop;

public partial class DesktopAllNotePage : ContentPage
{
	public DesktopAllNotePage()
	{
		InitializeComponent();
        this.BindingContext = new NoteViewModel();
	}

    private void Add_Click(object sender, EventArgs e)
    {

    }

    private async void Detai_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NoteDetai());
    }
}