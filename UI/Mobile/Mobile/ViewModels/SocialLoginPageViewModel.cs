using MedGame.UI.Mobile.Views;

using Acr.UserDialogs;
using MedGame.UI.Mobile;
using Newtonsoft.Json;
using Plugin.FacebookClient;
//using Plugin.GoogleClient;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SocialMediaAuthentication.ViewModels
{
    public class SocialLoginPageViewModel
    {
        const string InstagramApiUrl = "https://api.instagram.com";
        const string InstagramScope = "basic";
        const string InstagramAuthorizationUrl = "https://api.instagram.com/oauth/authorize/";
        const string InstagramRedirectUrl = "https://xamboy.com/default.html";
        const string InstagramClientId = "77567512de424a528ba61715d389a644";

        public ICommand OnLoginCommand { get; set; }

        IFacebookClient _facebookService = CrossFacebookClient.Current;
        //IGoogleClientManager _googleService = CrossGoogleClient.Current;
        IOAuth2Service _oAuth2Service;


        public ObservableCollection<AuthNetwork> AuthenticationNetworks { get; set; } = new ObservableCollection<AuthNetwork>()
        {
            new AuthNetwork()
            {
                Name = "Facebook",
                Icon = "ic_fb",
                Foreground = "#FFFFFF",
                Background = "#4768AD"
            },
             new AuthNetwork()
            {
                Name = "Instagram",
                Icon = "ic_ig",
                Foreground = "#FFFFFF",
                Background = "#DD2A7B"
            },
              new AuthNetwork()
            {
                Name = "Google",
                Icon = "ic_google",
                Foreground = "#000000",
                Background ="#F8F8F8"
            }
        };


        public SocialLoginPageViewModel(IOAuth2Service oAuth2Service)
        {
            _oAuth2Service = oAuth2Service;

            OnLoginCommand = new Command<AuthNetwork>(async (data) => await LoginAsync(data));
        }
        async Task LoginAsync(AuthNetwork authNetwork)
        {
            switch (authNetwork.Name)
            {
                case "Facebook":
                    await LoginFacebookAsync(authNetwork);
                    break;
                case "Instagram":
                    await LoginInstagramAsync(authNetwork);
                    break;
                case "Google":
                    //await LoginGoogleAsync(authNetwork);
                    break;
            }
        }
        async Task LoginInstagramAsync(AuthNetwork authNetwork)
        {
            EventHandler<string> onSuccessDelegate = null;
            EventHandler<string> onErrorDelegate = null;
            EventHandler onCancelDelegate = null;

            onSuccessDelegate = async (s, a) =>
            {

                UserDialogs.Instance.ShowLoading("Loading");

                var userResponse = await RestService.For<IInstagramApi>(InstagramApiUrl).GetUser(a);

                if (userResponse.IsSuccessStatusCode)
                {
                    var userDataString = await userResponse.Content.ReadAsStringAsync();
                        //Handling Encoding
                        var userDataStringFixed = System.Text.RegularExpressions.Regex.Unescape(userDataString);

                    var instagramUser = JsonConvert.DeserializeObject<InstagramUser>(userDataStringFixed);
                    var socialLoginData = new NetworkAuthData
                    {
                        Logo = authNetwork.Icon,
                        Picture = instagramUser.Data.ProfilePicture,
                        Foreground = authNetwork.Foreground,
                        Background = authNetwork.Background,
                        Name = instagramUser.Data.FullName,
                        Id = instagramUser.Data.Id
                    };

                    UserDialogs.Instance.HideLoading();
                        //await App.Current.MainPage.Navigation.PushModalAsync(new SignInPage(socialLoginData));
                        await App.Current.MainPage.Navigation.PushModalAsync(new SignInPage());
                }
                else
                {
                        //TODO: Handle instagram user info error
                        UserDialogs.Instance.HideLoading();

                    await UserDialogs.Instance.AlertAsync("Error", "Houston we have a problem", "Ok");
                }

                _oAuth2Service.OnSuccess -= onSuccessDelegate;
                _oAuth2Service.OnCancel -= onCancelDelegate;
                _oAuth2Service.OnError -= onErrorDelegate;
            };
            onErrorDelegate = (s, a) =>
            {
                _oAuth2Service.OnSuccess -= onSuccessDelegate;
                _oAuth2Service.OnCancel -= onCancelDelegate;
                _oAuth2Service.OnError -= onErrorDelegate;
                Debug.WriteLine($"ERROR: Instagram, MESSAGE: {a}");
            };
            onCancelDelegate = (s, a) =>
            {
                _oAuth2Service.OnSuccess -= onSuccessDelegate;
                _oAuth2Service.OnCancel -= onCancelDelegate;
                _oAuth2Service.OnError -= onErrorDelegate;
            };

            _oAuth2Service.OnSuccess += onSuccessDelegate;
            _oAuth2Service.OnCancel += onCancelDelegate;
            _oAuth2Service.OnError += onErrorDelegate;
            _oAuth2Service.Authenticate(InstagramClientId, InstagramScope, new Uri(InstagramAuthorizationUrl), new Uri(InstagramRedirectUrl));


        }

        async Task LoginFacebookAsync(AuthNetwork authNetwork)
        {
            try
            {

                if (_facebookService.IsLoggedIn)
                {
                    _facebookService.Logout();
                }

                EventHandler<FBEventArgs<string>> userDataDelegate = null;

                userDataDelegate = async (object sender, FBEventArgs<string> e) =>
                {
                    switch (e.Status)
                    {
                        case FacebookActionStatus.Completed:
                            var facebookProfile = await Task.Run(() => JsonConvert.DeserializeObject<FacebookProfile>(e.Data));
                            var socialLoginData = new NetworkAuthData
                            {
                                Id = facebookProfile.Id,
                                Logo = authNetwork.Icon,
                                Foreground = authNetwork.Foreground,
                                Background = authNetwork.Background,
                                Picture = facebookProfile.Picture.Data.Url,
                                Name = $"{facebookProfile.FirstName} {facebookProfile.LastName}",
                            };
                            await App.Current.MainPage.Navigation.PushModalAsync(new SignInPage());
                                //await App.Current.MainPage.Navigation.PushModalAsync(new SignInPage(socialLoginData));
                                break;
                        case FacebookActionStatus.Canceled:
                            await App.Current.MainPage.DisplayAlert("Facebook Auth", "Canceled", "Ok");
                            break;
                        case FacebookActionStatus.Error:
                            await App.Current.MainPage.DisplayAlert("Facebook Auth", "Error", "Ok");
                            break;
                        case FacebookActionStatus.Unauthorized:
                            await App.Current.MainPage.DisplayAlert("Facebook Auth", "Unauthorized", "Ok");
                            break;
                    }

                    _facebookService.OnUserData -= userDataDelegate;
                };

                _facebookService.OnUserData += userDataDelegate;

                string[] fbRequestFields = { "email", "first_name", "picture", "gender", "last_name" };
                string[] fbPermisions = { "email" };
                await _facebookService.RequestUserDataAsync(fbRequestFields, fbPermisions);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        //            async Task LoginGoogleAsync(AuthNetwork authNetwork)
        //            {
        //                try
        //                {
        //                    if (!string.IsNullOrEmpty(_googleService.ActiveToken))
        //                    {
        //                        //Always require user authentication
        //                        _googleService.Logout();
        //                    }

        //                    EventHandler<GoogleClientResultEventArgs<GoogleUser>> userLoginDelegate = null;
        //                    userLoginDelegate = async (object sender, GoogleClientResultEventArgs<GoogleUser> e) =>
        //                    {
        //                        switch (e.Status)
        //                        {
        //                            case GoogleActionStatus.Completed:
        //#if DEBUG
        //                                var googleUserString = JsonConvert.SerializeObject(e.Data);
        //                                Debug.WriteLine($"Google Logged in succesfully: {googleUserString}");
        //#endif

        //                                var socialLoginData = new NetworkAuthData
        //                                {
        //                                    Id = e.Data.Id,
        //                                    Logo = authNetwork.Icon,
        //                                    Foreground = authNetwork.Foreground,
        //                                    Background = authNetwork.Background,
        //                                    Picture = e.Data.Picture.AbsoluteUri,
        //                                    Name = e.Data.Name,
        //                                };

        //                                await App.Current.MainPage.Navigation.PushModalAsync(new HomePage(socialLoginData));
        //                                break;
        //                            case GoogleActionStatus.Canceled:
        //                                await App.Current.MainPage.DisplayAlert("Google Auth", "Canceled", "Ok");
        //                                break;
        //                            case GoogleActionStatus.Error:
        //                                await App.Current.MainPage.DisplayAlert("Google Auth", "Error", "Ok");
        //                                break;
        //                            case GoogleActionStatus.Unauthorized:
        //                                await App.Current.MainPage.DisplayAlert("Google Auth", "Unauthorized", "Ok");
        //                                break;
        //                        }

        //                        _googleService.OnLogin -= userLoginDelegate;
        //                    };

        //                    _googleService.OnLogin += userLoginDelegate;

        //                    await _googleService.LoginAsync();
        //                }
        //                catch (Exception ex)
        //                {
        //                    Debug.WriteLine(ex.ToString());
        //                }
        //            }

    }
}

public class Data
{
    [JsonProperty("is_silhouette")]
    public bool IsSilhouette { get; set; }
    public int Height { get; set; }
    public string Url { get; set; }
    public int Width { get; set; }
}



public class Picture
{
    public Data Data { get; set; }
}

public class FacebookProfile
{
    public string Email { get; set; }
    public string Id { get; set; }
    public Picture Picture { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }
    [JsonProperty("first_name")]
    public string FirstName { get; set; }
}













//AuthNetwork

public class AuthNetwork
{
    public string Name { get; set; }

    public string Icon { get; set; }

    public string Background { get; set; }

    public string Foreground { get; set; }
}










//Instagram:


public class InstagramCounts
{
    public int Media { get; set; }
    public int Follows { get; set; }
    [JsonProperty("followed_by")]
    public int FollowedBy { get; set; }
}

public class InstagramData
{
    public string Id { get; set; }
    public string Username { get; set; }
    [JsonProperty("profile_picture")]
    public string ProfilePicture { get; set; }
    [JsonProperty("full_name")]
    public string FullName { get; set; }
    public string Bio { get; set; }
    public string Website { get; set; }
    [JsonProperty("is_business")]
    public bool IsBusiness { get; set; }
    public InstagramCounts Counts { get; set; }
}

public class InstagramMeta
{
    public int Code { get; set; }
}

public class InstagramUser
{
    public InstagramData Data { get; set; }
    public InstagramMeta Meta { get; set; }
}







public interface IOAuth2Service
{
    event EventHandler<string> OnSuccess;
    event EventHandler<string> OnError;
    event EventHandler OnCancel;

    void Authenticate(string clientId, string scope, Uri authorizeUrl, Uri redirectUrl);
}









[Headers("Content-Type: application/json")]
public interface IInstagramApi
{
    [Get("/v1/users/self/?access_token={accessToken}")]
    Task<HttpResponseMessage> GetUser(string accessToken);
}



