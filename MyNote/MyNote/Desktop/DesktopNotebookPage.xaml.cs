using MyNote.ViewModels;

namespace MyNote.Desktop;

public partial class DesktopNotebookPage : ContentPage
{
	public DesktopNotebookPage()
	{
		InitializeComponent();
        this.BindingContext = new NotebookViewModel();
    }

    private void Add_Click(object sender, EventArgs e)
    {

    }
}