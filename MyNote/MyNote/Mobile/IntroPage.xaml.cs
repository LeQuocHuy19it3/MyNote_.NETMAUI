using MyNote.Mobile.LoginRegister;
namespace MyNote.Mobile;

public partial class IntroPage : ContentPage
{
	public IntroPage()
	{
		InitializeComponent();
	}

    private async void Register_Click(object sender, EventArgs e)
    {
        (sender as Button).Opacity = 0.8;
        await Navigation.PushAsync(new RegisterPage());
        (sender as Button).Opacity = 1;
    }

    private async void Login1_Click(object sender, EventArgs e)
    {
        (sender as Button).Opacity = 0.8;
        await Navigation.PushAsync(new LoginPage());
        (sender as Button).Opacity = 1;
    }

}