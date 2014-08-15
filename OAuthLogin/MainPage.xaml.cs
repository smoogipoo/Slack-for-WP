using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Slack_for_WP.Config;
using Slack_for_WP.Slack;

namespace Slack_for_WP.OAuth
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
                return;
        }
    }
}