using MedGame.UI.Interfaces;
using MedGame.UI.Mobile.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MedGame.UI.Mobile.Views
{
    public partial class NotificationPage : ContentPage
    {
        private readonly StepCounterViewModel vm;
        readonly ICustomNotification notification;

        public NotificationPage()
        {
            InitializeComponent();

            BindingContext = vm = new StepCounterViewModel();

            notification = DependencyService.Get<ICustomNotification>();
        }


        private void NavButtonMunkPage_ClickedAsync(object sender, EventArgs e)
        {
            vm.StopMeditation();
            App.Current.MainPage = new MunkPage();
        }

        private void NavButtonPlayPage_ClickedAsync(object sender, EventArgs e)
        {
            vm.StopMeditation();
            App.Current.MainPage = new PlayPage();
        }

        private void NavButtonStatisticPage_ClickedAsync(object sender, EventArgs e)
        {
            //vm.StopMeditation();
            App.Current.MainPage = new StatisticPage();
        }

        private void NavButtonSharePage_ClickedAsync(object sender, EventArgs e)
        {
            vm.StopMeditation();
            App.Current.MainPage = new SharePage();
        }

        private void NavButtonSettingsPage_ClickedAsync(object sender, EventArgs e)
        {
            vm.StopMeditation();
            App.Current.MainPage = new SettingsPage();
        }

        private void ButtonNotification_Clicked(object sender, EventArgs e)
        {

            var t = Task.Run(async delegate
            {
                await Task.Delay(2000);
                notification.Send("hej", "joho");
            });

            t.Wait();
        }
    }
}