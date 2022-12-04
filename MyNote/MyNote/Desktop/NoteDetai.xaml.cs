using MyNote.ViewModels;
namespace MyNote.Desktop;

public partial class NoteDetai : ContentPage
{
	public NoteDetai()
	{
		InitializeComponent();
		this.BindingContext = new NoteViewModel();

    }
}