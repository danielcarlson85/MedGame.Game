using MedGame.GameLogic;
using MedGame.Models;
using MedGame.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Windows;

namespace MedGame.UI.WPF
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        RESTClient RestClient = new RESTClient();
        LoadingWindow LoadingWindow = new LoadingWindow();

        public SignInWindow()
        {
            InitializeComponent();

            //if (!RestClient.CheckForInternetConnection())
            //{
            //    MessageBox.Show("Check your internet connection", "No connection found", MessageBoxButton.OK, MessageBoxImage.Information);
            //    Environment.Exit(0);
            //}
            //else
            //{
            //}
        }

        private async void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            //Player result = await RestClient.SignIn(TextBoxEmail.Text, TextBoxPassword.Password);

            if (!File.Exists(TextBoxEmail.Text.MakeFullFileName()))
            {
                MessageBox.Show("User does not exist, pleas register a new user");
            }
            else
            {
                LoadingWindow.Show();
                GamePlay.Player = await FileHandler.LoadPlayerFromFile(TextBoxEmail.Text.MakeFullFileName());
                CheckLogin(GamePlay.Player);
            }
        }

        private async void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            //Player result = await RestClient.SignUp(TextBoxEmail.Text, TextBoxPassword.Password);

            var newPlayer = Player.CreateNewPlayer(TextBoxEmail.Text);

            await FileHandler.SavePlayerToFile(newPlayer, TextBoxEmail.Text.MakeFullFileName());
            GamePlay.Player = await FileHandler.LoadPlayerFromFile(TextBoxEmail.Text.MakeFullFileName());
            CheckLogin(GamePlay.Player);
        }

        public void CheckLogin(Player playerResult)
        {
            if (playerResult.Email != null)
            {
                GamePlay.Player = playerResult;

                if (GamePlay.Player.Email != null)
                {
                    MunkWindow MunkWindow = new MunkWindow();
                    MunkWindow.Show();

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();

                    LoadingWindow.Close();

                    Close();
                }
                else
                {
                    MessageBox.Show(GamePlay.Player.PlayerMessage);
                }
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void LabelLoginWithFacebook_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }
    }
}
