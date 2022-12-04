using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MyNote.IService;
using MyNote.Models;
using MyNote.ViewModels;

namespace MyNote.Desktop;

public partial class DesktopRegisterPage : ContentPage
{
    private readonly IUserService _userService = new UserViewModel();
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    ToastDuration duration = ToastDuration.Short;
    double fontSize = 14;
    public DesktopRegisterPage()
	{
		InitializeComponent();
	}

    private async void Register_Click(object sender, EventArgs e)
    {
        string userName = txtUserName.Text;
        string password = txtPassword.Text;
        string rePassword = txtRePassword.Text;
        if (userName == null || password == null || rePassword == null)
        {
            string text = "Please input Username & Password";
            //await DisplayAlert("Warning", "Please input Username & Password", "OK");
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
            return;
        }
        if (password != rePassword)
        {
            string text = "Password does not match!";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
            return;
        }
        UserModel user = new UserModel(userName, password);
        bool check = await _userService.Register(user);
        if (check == true)
        {
            await Navigation.PushAsync(new DesktopLoginPage());
            string text = "Register Successfully!";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
        else
        {
            string text = "Something went wrong!";
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }

    private async void Signin_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DesktopLoginPage());
    }
}