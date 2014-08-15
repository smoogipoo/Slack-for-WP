using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Slack_for_WP.Slack
{
    class EndpointObjects
    {
        #region Types

        [DataContract]
        internal class BasicResponse
        {
            [DataMember(Name = "ok")]
            public bool Success { get; set; }
        }

        [DataContract]
        internal class Paging
        {
            [DataMember(Name = "count")]
            public int Count { get; set; }

            [DataMember(Name = "total")]
            public int Total { get; set; }

            [DataMember(Name = "page")]
            public int CurrentPage { get; set; }

            [DataMember(Name = "pages")]
            public int TotalPages { get; set; }
        }

        [DataContract]
        internal class Icon
        {
            [DataMember(Name = "image_24")]
            public string Image24 { get; set; }

            [DataMember(Name = "image_32")]
            public string Image32 { get; set; }

            [DataMember(Name = "image_48")]
            public string Image48 { get; set; }

            [DataMember(Name = "image_72")]
            public string Image72 { get; set; }

            [DataMember(Name = "image_192")]
            public string Image192 { get; set; }
        }

        [DataContract]
        internal class File
        {
            [DataMember(Name = "id")]
            public string ID { get; set; }

            [DataMember(Name = "timestamp")]
            public string Timestamp { get; set; }

            [DataMember(Name = "name")]
            public string Name { get; set; }

            [DataMember(Name = "title")]
            public string Title { get; set; }

            [DataMember(Name = "mimetype")]
            public string MimeType { get; set; }

            [DataMember(Name = "filetype")]
            public string FileType { get; set; }

            [DataMember(Name = "pretty_type")]
            public string PrettyType { get; set; }

            [DataMember(Name = "user")]
            public string User { get; set; }

            [DataMember(Name = "mode")]
            public string Mode { get; set; }

            [DataMember(Name = "editable")]
            public bool Editable { get; set; }

            [DataMember(Name = "is_external")]
            public bool IsExternal { get; set; }

            [DataMember(Name = "external_type")]
            public string ExternalType { get; set; }

            [DataMember(Name = "size")]
            public int Size { get; set; }

            [DataMember(Name = "url")]
            public string URL { get; set; }

            [DataMember(Name = "url_download")]
            public string DownloadURL { get; set; }

            [DataMember(Name = "url_private")]
            public string PrivateURL { get; set; }

            [DataMember(Name = "url_private_download")]
            public string PrivateDownloadURL { get; set; }

            [DataMember(Name = "thumb_64")]
            public string Thumb64 { get; set; }

            [DataMember(Name = "thumb_80")]
            public string Thumb80 { get; set; }

            [DataMember(Name = "thumb_360")]
            public string Thumb360 { get; set; }

            [DataMember(Name = "thumb_360_gif")]
            public string Thumb360Gif { get; set; }

            [DataMember(Name = "thumb_360_w")]
            public string Thumb360Width { get; set; }

            [DataMember(Name = "thumb_360_h")]
            public string Thumb360Height { get; set; }

            [DataMember(Name = "permalink")]
            public string Permalink { get; set; }

            [DataMember(Name = "edit_link")]
            public string EditLink { get; set; }

            [DataMember(Name = "preview")]
            public string Preview { get; set; }

            [DataMember(Name = "preview_highlight")]
            public string PreviewHighlight { get; set; }

            [DataMember(Name = "lines")]
            public int Lines { get; set; }

            [DataMember(Name = "lines_more")]
            public int MoreLines { get; set; }

            [DataMember(Name = "is_public")]
            public bool IsPublic { get; set; }

            [DataMember(Name = "public_url_shared")]
            public bool IsPublicURLShared { get; set; }

            [DataMember(Name = "channels")]
            public string[] Channels { get; set; }

            [DataMember(Name = "groups")]
            public string[] Groups { get; set; }

            [DataMember(Name = "initial_comment")]
            public string InitialComment { get; set; }

            [DataMember(Name = "num_stars")]
            public int StarsCount { get; set; }

            [DataMember(Name = "is_starred")]
            public bool IsStarred { get; set; }
        }

        [DataContract]
        internal class MemberProfile
        {
            [DataMember(Name = "first_name")]
            public string FirstName { get; set; }

            [DataMember(Name = "last_name")]
            public string LastName { get; set; }

            [DataMember(Name = "real_name")]
            public string RealName { get; set;}

            [DataMember(Name = "email")]
            public string Email { get; set; }

            [DataMember(Name = "skype")]
            public string Skype { get; set; }
            
            [DataMember(Name = "phone")]
            public string Phone { get; set; }

            [DataMember(Name = "image_24")]
            public string Image24 { get; set; }

            [DataMember(Name = "image_32")]
            public string Image32 { get; set; }

            [DataMember(Name = "image_48")]
            public string Image48 { get; set; }

            [DataMember(Name = "image_72")]
            public string Image72 { get; set; }

            [DataMember(Name = "image_192")]
            public string Image192 { get; set; }
        }

        [DataContract]
        internal class Member
        {
            [DataMember(Name = "id")]
            public string ID { get; set; }

            [DataMember(Name = "name")]
            public string Name { get; set; }

            [DataMember(Name = "deleted")]
            public bool Deleted { get; set; }

            [DataMember(Name = "profile")]
            public MemberProfile Profile { get; set; }

            [DataMember(Name = "is_admin")]
            public bool IsAdmin { get; set; }

            [DataMember(Name = "is_owner")]
            public bool IsOwner { get; set; }

            [DataMember(Name = "has_files")]
            public bool HasFiles { get; set; }
        }

        [DataContract]
        internal class Message
        {
            [DataMember(Name = "type")]
            public string Type { get; set; }

            [DataMember(Name = "subtype")]
            public string SubType { get; set; }

            [DataMember(Name = "ts")]
            public string Timestamp { get; set; }

            [DataMember(Name = "user")]
            public string User { get; set; }

            [DataMember(Name = "text")]
            public string Text { get; set; }

            /// <summary>
            /// The underlying message when a message was changed.
            /// </summary>
            [DataMember(Name = "message")]
            public Message UnderlyingMessage { get; set; }

            /// <summary>
            /// The bot ID.
            /// </summary>
            [DataMember(Name = "bot_id")]
            public string BotID { get; set; }

            /// <summary>
            /// The bot username.
            /// </summary>
            [DataMember(Name = "username")]
            public string BotUsername { get; set; }

            /// <summary>
            /// Hash of icons to display the bot.
            /// </summary>
            [DataMember(Name = "icons")]
            public Icon Icons { get; set; }

            /// <summary>
            /// The members of the channel when archived.
            /// </summary>
            [DataMember(Name = "members")]
            public Member[] Members { get; set; }

            /// <summary>
            /// Is set in a file message.
            /// </summary>
            [DataMember(Name = "file")]
            public File File { get; set; }

            /// <summary>
            /// Is set if file is shared with channel.
            /// </summary>
            [DataMember(Name = "upload")]
            public bool Upload { get; set; }
        }

        [DataContract]
        internal class ChannelDescription
        {
            [DataMember(Name = "value")]
            public string Value { get; set; }

            [DataMember(Name = "creator")]
            public string Creator { get; set; }

            [DataMember(Name = "last_set")]
            public string LastSet { get; set; }
        }

        [DataContract]
        internal class Channel
        {
            [DataMember(Name = "id")]
            public string ID { get; set; }

            [DataMember(Name = "name")]
            public string Name { get; set; }

            [DataMember(Name = "created")]
            public string Created { get; set; }

            [DataMember(Name = "creator")]
            public string Creator { get; set; }

            [DataMember(Name = "is_archived")]
            public bool IsArchived { get; set; }

            [DataMember(Name = "is_general")]
            public bool IsGeneral { get; set; }

            [DataMember(Name = "is_member")]
            public bool IsMember { get; set; }

            [DataMember(Name = "members")]
            public string[] Members { get; set; }

            [DataMember(Name = "topic")]
            public ChannelDescription Topic { get; set; }

            [DataMember(Name = "purpose")]
            public ChannelDescription Purpose { get; set; }

            [DataMember(Name = "last_read")]
            public string LastRead { get; set; }

            [DataMember(Name = "latest")]
            public Message[] LatestMessage { get; set; }

            [DataMember(Name = "unread_count")]
            public int UnreadCount { get; set; }
        }

        [DataContract]
        internal class IMChannel
        {
            [DataMember(Name = "id")]
            public string ID { get; set; }

            [DataMember(Name = "user")]
            public string User { get; set; }

            [DataMember(Name = "created")]
            public string Created { get; set; }

            [DataMember(Name = "is_user_deleted")]
            public bool IsUserDeleted { get; set; }
        }

        #endregion

        #region ChannelInfos

        [DataContract]
        internal class BasicChannelInfo : BasicResponse
        {
            [DataMember(Name = "channel")]
            public Channel Channel { get; set; }
        }

        [DataContract]
        internal class ChannelJoinInfo : BasicChannelInfo
        {
            [DataMember(Name = "already_in_channel")]
            public bool AlreadyInChannel { get; set; }
        }

        [DataContract]
        internal class ChannelLeaveInfo : BasicResponse
        {
            [DataMember(Name = "not_in_channel")]
            public bool NotInChannel { get; set; }
        }

        [DataContract]
        internal class ChannelHistoryInfo : BasicResponse
        {
            [DataMember(Name = "latest")]
            public string Latest { get; set; }

            [DataMember(Name = "messages")]
            public Message[] Messages { get; set; }
        }

        [DataContract]
        internal class ChannelListInfo : BasicResponse
        {
            [DataMember(Name = "channels")]
            public Channel[] Channels { get; set; }
        }

        [DataContract]
        internal class IMListInfo : BasicResponse
        {
            [DataMember(Name = "ims")]
            public IMChannel[] IMChannels { get; set; }
        }

        #endregion

        #region FileInfos

        [DataContract]
        internal class FileInfo : BasicResponse
        {
            [DataMember]
            public File File { get; set; }
        }

        [DataContract]
        internal class FileListInfo : BasicResponse
        {
            [DataMember]
            public File[] Files { get; set; }

            [DataMember(Name = "paging")]
            public Paging Paging { get; set; }
        }

        #endregion

        #region GroupInfos

        [DataContract]
        internal class GroupHistoryInfo : ChannelHistoryInfo
        {
            [DataMember(Name = "has_more")]
            public bool HasMoreMessages { get; set; }
        }

        [DataContract]
        internal class GroupListInfo : BasicResponse
        {
            [DataMember(Name = "groups")]
            public Channel[] Groups { get; set; }
        }

        #endregion

        //Todo: Searches

        #region ChatInfos

        [DataContract]
        internal class BasicChatInfo : BasicResponse
        {
            [DataMember(Name = "ts")]
            public string Timestamp { get; set; }

            [DataMember(Name = "channel")]
            public string Channel { get; set; }
        }

        [DataContract]
        internal class ChatUpdateInfo : BasicChatInfo
        {
            [DataMember(Name = "text")]
            public string Text { get; set; }
        }

        #endregion

        #region AuthInfos

        [DataContract]
        internal class AuthTestInfo : BasicResponse
        {
            [DataMember(Name = "url")]
            public string URL { get; set; }

            [DataMember(Name = "team")]
            public string Team { get; set; }

            [DataMember(Name = "user")]
            public string User { get; set; }

            [DataMember(Name = "team_id")]
            public string TeamID { get; set; }

            [DataMember(Name = "user_id")]
            public string UserID { get; set; }
        }

        [DataContract]
        internal class OAuthAccessInfo
        {
            [DataMember(Name = "access_token")]
            public string AccessToken { get; set; }

            [DataMember(Name = "scope")]
            public string Scope { get; set; }
        }

        #endregion

        #region UserInfos

        [DataContract]
        internal class UserListInfo : BasicResponse
        {
            [DataMember(Name = "members")]
            public Member[] Members { get; set; }
        }

        #endregion

        #region EmojiInfos

        [DataContract]
        internal class EmojiListInfo : BasicResponse
        {
            [DataMember(Name = "emoji")]
            public Dictionary<string, string> Emojis { get; set; }
        }

        #endregion
    }
}
