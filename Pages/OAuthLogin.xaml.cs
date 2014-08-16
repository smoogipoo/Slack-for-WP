using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Phone.Controls;
using Slack_for_WP.Config;
using Slack_for_WP.OAuth;
using Slack_for_WP.Slack;

namespace Slack_for_WP.OAuthLogin
{
    public partial class OAuthBrowserWindow
    {
        public OAuthBrowserWindow()
        {
            InitializeComponent();

            Browser.Navigate(new Uri("https://slack.com/oauth/authorize?client_id=" + Client.ID));
        }

        private void Browser_Navigating(object sender, NavigatingEventArgs e)
        {
            string query = e.Uri.Query;

            string[] p = query.TrimStart('?').Split('&');

            if (p.Length == 1)
                return;

            Dictionary<string, string> parameters = p.Select(param => param.Split('=')).ToDictionary(split => split[0], split => split[1]);

            if (parameters.ContainsKey("code"))
            {
                e.Cancel = true;

                HttpWebRequest req = RequestBuilder.BuildRequest(Endpoints.OAuthAccess, new[,]
                {
                    { "client_id", Client.ID },
                    { "client_secret", Client.Secret },
                    { "code" , parameters["code"] }
                }).Result;

                RequestBuilder.PeformRequest(OAuthTokenReceived, req);
            }
        }

        private void OAuthTokenReceived(string result)
        {
            App.OAuthInfo = Serializer.Deserialize<SerializationObjects.OAuthAccessInfo>(result);
            App.ChangeMode(App.Modes.SlackMain);
        }
    }
}