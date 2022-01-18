
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Plugin.CurrentActivity;
using Plugin.FacebookClient;
using SocialMediaAuthentication.ViewModels;
using System;
using Xamarin.Auth;



namespace MedGame.UI.Mobile.Droid
{
    [Activity(Label = "MediGotchi", Icon = "@mipmap/buddaicon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {



            //    try
            //    {
            //        PackageInfo info = Android.App.Application.Context.PackageManager.GetPackageInfo(Android.App.Application.Context.PackageName, PackageInfoFlags.Signatures);
            //        foreach (var signature in info.Signatures)
            //        {
            //            MessageDigest md = MessageDigest.GetInstance("SHA");
            //            md.Update(signature.ToByteArray());

            //            System.Diagnostics.Debug.WriteLine(Convert.ToBase64String(md.Digest()));
            //        }
            //    }
            //    catch (NoSuchAlgorithmException e)
            //    {
            //        System.Diagnostics.Debug.WriteLine(e);
            //    }
            //    catch (Exception e)
            //    {
            //        System.Diagnostics.Debug.WriteLine(e);
            //    }



            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            RequestWindowFeature(WindowFeatures.ActionBar);

            base.OnCreate(savedInstanceState);
            FacebookClientManager.Initialize(this);



            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(new OAuth2Service()));

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);
            FacebookClientManager.OnActivityResult(requestCode, resultCode, intent);
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }



    public class DroidOAuth2Authenticator : OAuth2Authenticator
    {
        public DroidOAuth2Authenticator(string clientId, string scope, Uri authorizeUrl, Uri redirectUrl) : base(clientId, scope, authorizeUrl, redirectUrl)
        {

        }

        protected override void OnPageEncountered(Uri url, System.Collections.Generic.IDictionary<string, string> query, System.Collections.Generic.IDictionary<string, string> fragment)
        {
            // Remove state from dictionaries. 
            // We are ignoring request state forgery status 
            // as we're hitting an ASP.NET service which forwards 
            // to a third-party OAuth service itself
            if (query.ContainsKey("state"))
            {
                query.Remove("state");
            }

            if (fragment.ContainsKey("state"))
            {
                fragment.Remove("state");
            }

            base.OnPageEncountered(url, query, fragment);
        }
    }

    public class OAuth2Service : IOAuth2Service
    {
        public event EventHandler<string> OnSuccess = delegate { };
        public event EventHandler OnCancel = delegate { };
        public event EventHandler<string> OnError = delegate { };

        public void Authenticate(string clientId, string scope, Uri authorizeUrl, Uri redirectUrl)
        {
            var activity = CrossCurrentActivity.Current.Activity;

            var auth = new DroidOAuth2Authenticator(
                clientId: clientId, // your OAuth2 client id
                scope: scope, // the scopes for the particular API you're accessing, delimited by "+" symbols
                authorizeUrl: authorizeUrl, // the auth URL for the service
                redirectUrl: redirectUrl); // the redirect URL for the service

            //auth.Error = true;
            auth.ShowErrors = false;

            EventHandler<AuthenticatorErrorEventArgs> errorDelegate = null;
            EventHandler<AuthenticatorCompletedEventArgs> completedDelegate = null;

            errorDelegate = (sender, eventArgs) =>
            {
                OnError?.Invoke(this, eventArgs.Message);

                auth.Error -= errorDelegate;
                auth.Completed -= completedDelegate;
            };

            completedDelegate = (sender, eventArgs) =>
            {

                // UI presented, so it's up to us to dimiss it on Android
                // dismiss Activity with WebView or CustomTabs
                CrossCurrentActivity.Current.Activity.Finish();

                if (eventArgs.IsAuthenticated)
                {

                    OnSuccess?.Invoke(this, eventArgs.Account.Properties["access_token"]);

                }
                else
                {
                    // The user cancelled

                    OnCancel?.Invoke(this, EventArgs.Empty);
                }
                auth.Error -= errorDelegate;
                auth.Completed -= completedDelegate;

            };

            auth.Error += errorDelegate;
            auth.Completed += completedDelegate;

            activity.StartActivity(auth.GetUI(activity));
        }

    }
}