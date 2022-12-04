namespace MyNote.Mobile.MainLayout;

public partial class MobileAllSettingPage : ContentPage
{
	public MobileAllSettingPage()
	{
		InitializeComponent();
	}

    private async void Notes_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MobileAllNotePage());
    }

    private async void Favoritr_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MobileFavoriteNotePage());
    }

    private async void Shared_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MobileSharePage());
    }


    private async void About_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MobileAboutMePage());

    }

    private void SignOut_Click(object sender, EventArgs e)
    {

    }
}