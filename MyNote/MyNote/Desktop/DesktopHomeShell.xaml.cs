using MyNote.Desktop;
namespace MyNote.Desktop;

public partial class DesktopHomeShell : Shell
{
	public DesktopHomeShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("NoteDetail", typeof(DesktopNoteDetailPage));
    }
}