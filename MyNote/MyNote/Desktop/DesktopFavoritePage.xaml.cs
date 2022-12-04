using MyNote.ViewModels;

namespace MyNote.Desktop;

public partial class DesktopFavoritePage : ContentPage
{
	public DesktopFavoritePage()
	{
		InitializeComponent();
        this.BindingContext = new NoteViewModel();
    }

    private void Detai_Click(object sender, EventArgs e)
    {

    }
}