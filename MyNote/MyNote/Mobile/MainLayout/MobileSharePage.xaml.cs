using MyNote.ViewModels;

namespace MyNote.Mobile.MainLayout;

public partial class MobileSharePage : ContentPage
{
	public MobileSharePage()
	{
		InitializeComponent();
        this.BindingContext = new NoteViewModel();
    }

    private async void back1_click(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}