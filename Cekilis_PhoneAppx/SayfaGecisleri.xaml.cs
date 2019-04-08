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
    public sealed partial class SayfaGecisleri : Page
    {
        public SayfaGecisleri()
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

        private void gitButton_Click(object sender, RoutedEventArgs e)
        {
            if (hakkindaItem.IsSelected == true)
            {
                this.Frame.Navigate(typeof(Hakkinda2));
            }
            else if (dilAyarlariItem.IsSelected == true)
            {
                this.Frame.Navigate(typeof(DilAyarlari2));
            }
            else if (anasayfaItem.IsSelected == true)
            {
                this.Frame.Navigate(typeof(MainPage));
            }
            else if (kayitYoneticisiItem.IsSelected == true)
            {
                this.Frame.Navigate(typeof(KayitYoneticisi2));
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            if (main.dilayarlari.Values["dil"].ToString() == "Türkçe")
            {
                hakkindaItem.Content = "Hakkında";
                dilAyarlariItem.Content = "Dil Ayarları";
                anasayfaItem.Content = "Anasayfa";
                kayitYoneticisiItem.Content = "Kayıt Yöneticisi";
                gitButton.Content = "Git";
                kapatButton.Content = "Kapat";
            }
            else if (main.dilayarlari.Values["dil"].ToString() == "English")
            {
                hakkindaItem.Content = "About";
                dilAyarlariItem.Content = "Language Settings";
                anasayfaItem.Content = "Home";
                kayitYoneticisiItem.Content = "Records Manager";
                gitButton.Content = "Go";
                kapatButton.Content = "Close";
            }
        }
    }
}
