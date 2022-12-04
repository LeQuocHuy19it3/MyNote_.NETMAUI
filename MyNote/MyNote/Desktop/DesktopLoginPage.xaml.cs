using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MyNote.IService;
using MyNote.Models;
using MyNote.ViewModels;
using MyNote.Mobile.MainLayout;

namespace MyNote.Desktop;

public partial class DesktopLoginPage : ContentPage
{
    private readonly IUserService _userService = new UserViewModel();
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    ToastDuration duration = ToastDuration.Short;
    double fontSize = 14;
    public DesktopLoginPage()
	{
		InitializeComponent();
	}

    private void Forgot_Click(object sender, EventArgs e)
    {
        
    }

    private async void Login_Click(object sender, EventArgs e)
    {
        string userName = txtUserName.Text;
        string password = txtPassword.Text;
        if (userName == null || password == null)
        {
            string text = "Please input Username & Password";
            //await DisplayAlert("Warning", "Please input Username & Password", "OK");
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
            return;
        }
        UserModel userModel = await _userService.Login(userName, password);
        if (userModel != null)
        {
            await Navigation.PushAsync(new DesktopHomeShell());
        }
        else
        {
            string text = "Username or Password incorrect!";
            //await DisplayAlert("Warning", "Please input Username & Password", "OK");
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }

    private async void Register_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DesktopRegisterPage());
    }
}