using MyNote.Mobile;
using MyNote.Desktop;

namespace MyNote;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

#if ANDROID || IOS
        MainPage = new NavigationPage(new IntroPage());
#else
	MainPage = new NavigationPage(new DesktopLoginPage());
#endif
    }
}
