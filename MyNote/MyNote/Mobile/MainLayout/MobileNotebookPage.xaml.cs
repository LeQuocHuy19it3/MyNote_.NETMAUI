using MyNote.ViewModels;
namespace MyNote.Mobile.MainLayout;

public partial class MobileNotebookPage : ContentPage
{
	public MobileNotebookPage()
	{
		InitializeComponent();
		this.BindingContext = new NotebookViewModel();
	}

    private void Add_Click(object sender, EventArgs e)
    {

    }
}