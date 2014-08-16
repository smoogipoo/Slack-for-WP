using System.Net;
using System.Windows;
using Microsoft.Phone.Controls;
using Slack_for_WP.Slack;
using Slack_for_WP.Slack.SerializationObjects;

namespace Slack_for_WP.Pages
{
    public partial class MainLogin
    {
        public MainLogin()
        {
            InitializeComponent();
        }

        private void checkLogin()
        {
            HttpWebRequest req;
            if (App.Auth == null || App.Auth.AccessToken == null)
            {
                req = RequestBuilder.BuildRequest(Endpoints.TestAuth, null, RequestBuilder.RequestMethods.GET);
            }
            else
            {
                req = RequestBuilder.BuildRequest(Endpoints.TestAuth, new[,]
                {
                    { "token", App.Auth.AccessToken }
                }, RequestBuilder.RequestMethods.GET);
            }

            RequestBuilder.PeformRequest(checkLoginCallback, req);
        }

        private void checkLoginCallback(string result)
        {
            AuthTestInfo info = Serializer.Deserialize<AuthTestInfo>(result);

            if (info.Success)
                App.ChangeMode(App.Modes.SlackMain);
            else
            {
                ProgressBar.Visibility = Visibility.Collapsed;
                LoginButton.Visibility = Visibility.Visible;
            }
        }

        private void loginClick(object sender, RoutedEventArgs e)
        {
            App.ChangeMode(App.Modes.OAuthLogin);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            checkLogin();
        }
    }
}