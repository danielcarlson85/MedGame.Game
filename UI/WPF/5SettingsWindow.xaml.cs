using MedGame.GameLogic;
using MedGame.Models;
using MedGame.Services;
using System.Windows;
using System.Windows.Input;

namespace MedGame.UI.WPF
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        RESTClient RestClient = new RESTClient();
        LoadingWindow LoadingWindow = new LoadingWindow();

        public SettingsWindow()
        {
            InitializeComponent();

            TextBoxFacebookFullName.Text = GameModels.Player.Name;
            TextBoxFacebookEmail.Text = GameModels.Player.Email;
            TextBoxFacebookGender.Text = GameModels.Player.Gender;
            TextBoxAddress.Text = GameModels.Player.Address;
            TextBoxFacebookDateOfBirth.Text = GameModels.Player.Birthday;
        }
        private void IconPlay_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PlayWindow playWindow = new PlayWindow();
            playWindow.Show();
            this.Close();
        }

        private void IconMunk_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MunkWindow MunkWindow = new MunkWindow();
            MunkWindow.Show();
            this.Close();
        }

        private void IconStatistics_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StatisticsWindow StatisticsWindow = new StatisticsWindow();
            StatisticsWindow.Show();
            this.Close();
        }

        private void IconShare_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ShareWindow ShareWindow = new ShareWindow();
            ShareWindow.Show();
            this.Close();
        }

        private void IconSettings_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SettingsWindow SettingsWindow = new SettingsWindow();
            SettingsWindow.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            GameModels.Player.Name = TextBoxFacebookFullName.Text;
            GameModels.Player.Email = TextBoxFacebookEmail.Text;
            GameModels.Player.Gender = TextBoxFacebookGender.Text;
            GameModels.Player.Address = TextBoxAddress.Text;
            GameModels.Player.Birthday = TextBoxFacebookDateOfBirth.Text;

            await FileHandler.SavePlayerToFile(GameModels.Player, GameModels.Player.Email);

            MunkWindow munkWindow = new MunkWindow();
            munkWindow.Show();
            this.Close();
        }
    }
}
