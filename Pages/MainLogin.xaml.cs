using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace Slack_for_WP.MainLogin
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.ChangeMode(App.Modes.OAuthLogin);
        }
    }
}