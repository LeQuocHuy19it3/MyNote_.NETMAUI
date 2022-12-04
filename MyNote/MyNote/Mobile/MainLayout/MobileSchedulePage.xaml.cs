using MyNote.ViewModels;
using System.Transactions;
namespace MyNote.Mobile.MainLayout;

public partial class MobileSchedulePage : ContentPage
{
    private bool _isPanelTranslated;
	public MobileSchedulePage()
	{
		InitializeComponent();
		this.BindingContext = new ScheduleListViewModel();
        panelLeft.TranslateTo(-80, 0, 150);
    }
    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        var viewModel = (ScheduleListViewModel)BindingContext;
        viewModel.BindDataToScheduleList();
    }


    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        if (_isPanelTranslated)
        {
            panelLeft.TranslateTo(-80, 0, 150);
        }
        else
        {
            panelLeft.TranslateTo(0, 0, 150);
        }

        _isPanelTranslated = !_isPanelTranslated;
    }
}