namespace MedGame.UI.Mobile.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        string id = string.Empty;
        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        public SettingsPageViewModel()
        {
            Title = "test";
            Id = "Detta är idt";

            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        //public ICommand OpenWebCommand { get; }
    }
}