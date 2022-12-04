using MyNote.ViewModels;

namespace MyNote.Desktop;

public partial class DesktopNoteDetailPage : ContentPage
{
	public DesktopNoteDetailPage()
	{
		InitializeComponent();
        this.BindingContext = new NoteViewModel();
    }
}