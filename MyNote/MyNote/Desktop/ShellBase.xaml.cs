namespace MyNote.Desktop;

public partial class ShellBase : Shell
{
	public ShellBase()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(DesktopNoteDetailPage), typeof(DesktopNoteDetailPage));
    }
}