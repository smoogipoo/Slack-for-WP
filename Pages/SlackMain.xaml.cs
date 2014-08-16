using Microsoft.Phone.Controls;

namespace Slack_for_WP.Pages
{
    public partial class SlackMain : PhoneApplicationPage
    {
        public SlackMain()
        {
            InitializeComponent();

            ChannelName.Text = App.AuthInfo.Team;
        }
    }
}