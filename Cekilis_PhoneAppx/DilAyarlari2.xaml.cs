using App31;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class DilAyarlari2 : Page
    {
        public DilAyarlari2()
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

        private void kaydetButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            if (turkceItem.IsSelected == true)
            {
                main.dilayarlari.Values["dil"] = "Türkçe";
                dilAyarlariBaslik.Text = "Dil Seçenekleri";
                kaydetButton.Content = "Kaydet";
                cikisButton.Content = "Kapat";
                dilBaslikTextBlock.Text = "Dil Seçiniz:";
                MessageDialog mesaj = new MessageDialog("Dil seçiminiz değiştirilmiştir.", "Bilgi");
                mesaj.Commands.Add(new UICommand("Tamam", new UICommandInvokedHandler(tamamButton)));
                mesaj.ShowAsync();
            }
            else if (ingilizceItem.IsSelected == true)
            {
                main.dilayarlari.Values["dil"] = "English";
                dilAyarlariBaslik.Text = "Language Settings";
                kaydetButton.Content = "Save";
                cikisButton.Content = "Close";
                dilBaslikTextBlock.Text = "Language Choice:";
                MessageDialog mesaj = new MessageDialog("Your choice of language has been changed.", "Information");
                mesaj.Commands.Add(new UICommand("OK", new UICommandInvokedHandler(tamamButton)));
                mesaj.ShowAsync();
            }
        }

        private void tamamButton(IUICommand command)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            if (main.dilayarlari.Values["dil"].ToString() == "Türkçe")
            {
                turkceItem.IsSelected = true;
                dilAyarlariBaslik.Text = "Dil Ayarları";
                dilBaslikTextBlock.Text = "Dil Seçiminiz:";
                kaydetButton.Content = "Kaydet";
                cikisButton.Content = "Çıkış";
            }
            else if (main.dilayarlari.Values["dil"].ToString() == "English")
            {
                ingilizceItem.IsSelected = true;
                dilAyarlariBaslik.Text = "Language Settings";
                dilBaslikTextBlock.Text = "Language Choice:";
                kaydetButton.Content = "Save";
                cikisButton.Content = "Close";
            }
        }

        private void cikisButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
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
