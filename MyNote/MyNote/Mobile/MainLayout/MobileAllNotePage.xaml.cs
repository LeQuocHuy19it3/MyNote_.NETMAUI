using MyNote.ViewModels;
namespace MyNote.Mobile.MainLayout;

public partial class MobileAllNotePage : ContentPage
{
	public MobileAllNotePage()
	{
		InitializeComponent();
        this.BindingContext = new NoteViewModel();
    }

    private void Add_Click(object sender, EventArgs e)
    {
       
    }

    private async void back1_click(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void Detai_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MobileNoteDetailPage());
    }
}