using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MyNote.IService;
using MyNote.Mobile.MainLayout;
using MyNote.Models;
using MyNote.ViewModels;

namespace MyNote.Mobile.LoginRegister;

public partial class LoginPage : ContentPage
{
    private readonly IUserService _userService = new UserViewModel();
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    ToastDuration duration = ToastDuration.Short;
    double fontSize = 14;
    public LoginPage()
	{
		InitializeComponent();
    }

    public async void Login_Click(object sender, EventArgs e)
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
            await Navigation.PushAsync(new MobileShell());
        } else
        { 
            string text = "Username or Password incorrect!";
            //await DisplayAlert("Warning", "Please input Username & Password", "OK");
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }
 
    private async void Forgot_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ForgotPassword());
    }

    private async void Register2_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }

    private async void back1_click(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}