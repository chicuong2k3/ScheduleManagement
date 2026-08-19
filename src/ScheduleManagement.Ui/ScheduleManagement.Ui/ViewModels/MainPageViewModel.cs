using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;

namespace ScheduleManagement.Ui.ViewModels
{
    public class MainPageViewModel : NotificationObject
    {
        private string _welcomeText;

        public MainPageViewModel()
        {
            _welcomeText = "Hello from Prism!";
            SomeCommand = new DelegateCommand(OnSomeCommand);
        }

        public string WelcomeText
        {
            get { return _welcomeText; }
            set
            {
                if (_welcomeText != value)
                {
                    _welcomeText = value;
                    RaisePropertyChanged(nameof(WelcomeText));
                }
            }
        }

        public DelegateCommand SomeCommand { get; }

        private void OnSomeCommand()
        {
            WelcomeText = "Button was clicked!";
        }
    }
}
