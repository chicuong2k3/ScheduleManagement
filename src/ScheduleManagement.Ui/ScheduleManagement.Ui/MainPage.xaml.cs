using ScheduleManagement.Ui.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ScheduleManagement.Ui
{
    public partial class MainPage : Page
    {
        public MainPage(MainPageViewModel viewModel)
        {
            this.InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
