using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using CodingChick.SlackAPI;
using CodingChick.SlackAPI.Base;
using CodingChick.SlackAPI.Data;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CodingChick.SlackWP8.Resources;
using Telerik.Windows.Controls;
using WebSocket4Net;

namespace CodingChick.SlackWP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        ObservableCollection<CustomConversationViewMessage> _messages = new ObservableCollection<CustomConversationViewMessage>();

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.conversationView.ItemsSource = _messages;
            this.conversationView.CreateMessage = (string text) => new CustomConversationViewMessage(text, DateTime.Now, ConversationViewMessageType.Outgoing, _sender);

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        SlackClient _client;
        private string _sender;

        private async void RecievedMessagesButton_OnClick(object sender, RoutedEventArgs e)
        {
            _client = new SlackClient("xoxp-2448634628-2448634632-2451162356-c493b2");
            await _client.Connect("testAgent");
            _client.SlackSocket.OnChatMessageRecieved += SlackSocketOnChatOnChatMessageRecieved;
            _sender = "codingchick";
        }

        private void SlackSocketOnChatOnChatMessageRecieved(object source, ChatMessageEventArgs chatMessageEventArgs)
        {
            if (!string.IsNullOrEmpty(chatMessageEventArgs.SlackMessage.User) && chatMessageEventArgs.SlackMessage.UserName != _sender)
            {
                var dispatcher = Deployment.Current.Dispatcher;
                var displayChatMessage = new CustomConversationViewMessage(chatMessageEventArgs.SlackMessage.Text, DateTime.Now,
                    ConversationViewMessageType.Incoming, chatMessageEventArgs.SlackMessage.User);

                if (!dispatcher.CheckAccess())
                {
                    dispatcher.BeginInvoke(() => { _messages.Add(displayChatMessage); });
                }
            }
        }



        private async void OnSendingMessage(object sender, ConversationViewMessageEventArgs e)
        {
            var viewMessage = e.Message as CustomConversationViewMessage;

            if (viewMessage != null)
            {
                _messages.Add(viewMessage);

                var message = new SlackMessage()
                {
                    Type = "message",
                    Channel = "C02D6JNKG",
                    Hidden = false,
                    Text = viewMessage.Text,
                    User = viewMessage.Sender
                };

                var result = await _client.PostMessageThroughWebhook(message);
            }
        }
    }

    public class CustomConversationViewMessage : ConversationViewMessage
    {
        public CustomConversationViewMessage(string text, DateTime timeStamp, ConversationViewMessageType type,
            string sender)
            : base(text, timeStamp, type)
        {
            Sender = sender;
        }

        public string Sender { get; set; }
    }
}