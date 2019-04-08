using App31;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Cekilis_PhoneApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Hakkinda2 : Page
    {
        public Hakkinda2()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void kapatButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void LaunchSite(string siteAddress)
        {
            try
            {
                Uri uri = new Uri(siteAddress);
                var launched = await Windows.System.Launcher.LaunchUriAsync(uri);
            }
            catch (Exception ex)
            {
                //handle the exception
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            if (main.dilayarlari.Values["dil"].ToString() == "Türkçe")
            {
                hakkindaBaslik.Text = "Çekiliş Hakkında";
                body.Text = "Çekiliş 2.1.0.0\n\nKodlama: Ready\n\nYazılım & Programlama & Webmaster Forumu ve Örnek Projeler için:\n\nhttp://www.kodevreni.com";
                kapatButton.Content = "Çıkış";
            }
            else if (main.dilayarlari.Values["dil"].ToString() == "English")
            {
                hakkindaBaslik.Text = "About Çekiliş";
                body.Text = "Çekiliş 2.1.0.0\n\nCoding: Ready\n\nEnglish Translation: Ready\n\nSoftware & Programming & Webmaster Forum and Example for projects:\n\nhttp://www.kodevreni.com";
                kapatButton.Content = "Close";
            }
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            LaunchSite("http://www.kodevreni.com");
        }

        private void anasayfaButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void hakkindaButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Hakkinda2));
        }
        private void kayitlarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(KayitYoneticisi2));
        }

        private void dilButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DilAyarlari2));
        }
    }
}
