namespace Slack_for_WP.Slack
{
    internal enum Endpoints
    {
        //General listings
        ListUsers,
        ListChannels,
        ListIMChannels,
        ListGroups,
        ListFiles,
        ListStars,
        ListEmoji,

        //Channel endpoints
        ChannelJoin,
        ChannelLeave,
        ChannelInfo,
        ChannelHistory,
        ChannelMarkRead,
        ChannelInvite,

        //File endpoints
        FileUpload,
        FileInfo,
        FileSearch,

        //Chat history endpoints
        HistoryIMChannel,
        HistoryGroup,

        //Chat endpoints
        ChatUpdateMessage,
        ChatDeleteMessage,
        ChatPostMessage,
        ChatSearchMessages,

        //Searches
        SearchAll,

        //General OAuth
        Authorize,
        TestAuth,
        OAuthAccess,
    }

    class EndpointHelper
    {
        private static readonly string[,] literalEndpoints =
        {
            {"ListUsers",           "users.list"},
            {"ListChannels",        "channels.list"},
            {"ListIMChannels",      "im.list"},
            {"ListGroups",          "groups.list"},
            {"ListFiles",           "files.list"},
            {"ListStars",           "stars.list"},
            {"ListEmoji",           "emoji.list"},
            {"ChannelJoin",         "channels.join"},
            {"ChannelLeave",        "channels.leave"},
            {"ChannelInfo",         "channels.info"},
            {"ChannelHistory",      "channels.history"},
            {"ChannelMarkRead",     "channels.mark"},
            {"ChannelInvite",       "channels.invite"},
            {"FileUpload",          "files.upload"},
            {"FileInfo",            "files.info"},
            {"FileSearch",          "search.files"},
            {"HistoryIMChannel",    "im.history"},
            {"HistoryGroup",        "groups.history"},
            {"ChatUpdateMessage",   "chat.update"},
            {"ChatDeleteMessage",   "chat.delete"},
            {"ChatPostMessage",     "chat.postMessage"},
            {"ChatSearchMessages",  "search.messages"},
            {"SearchAll",           "search.all"},
            {"Authorize",           "authorize"},
            {"TestAuth",            "auth.test"},
            {"OAuthAccess",         "oauth.access"}
        };

        internal static string Parse(Endpoints endpoint)
        {
            for (int i = 0; i < literalEndpoints.GetLength(0); i++)
            {
                if (literalEndpoints[i, 0] == endpoint.ToString())
                    return literalEndpoints[i, 1];
            }
            return string.Empty;
        }
    }
}
