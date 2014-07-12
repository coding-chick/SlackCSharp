using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using CodingChick.SlackAPI;
using CodingChick.SlackAPI.Base;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CodingChick.SlackWP8.Resources;
using WebSocket4Net;

namespace CodingChick.SlackWP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

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
        private async void RecievedMessagesButton_OnClick(object sender, RoutedEventArgs e)
        {
            var client = new SlackClient("");
            await client.Connect("codingchick");
            client.SlackSocket.OnMessageRecieved += SlackSocketOnOnMessageRecieved;
        }

        private void SlackSocketOnOnMessageRecieved(object source, ChatMessageEventArgs chatMessageEventArgs)
        {
            MessageBox.Show(chatMessageEventArgs.Message);
        }
    }
}