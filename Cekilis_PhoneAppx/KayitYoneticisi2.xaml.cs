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
    public sealed partial class KayitYoneticisi2 : Page
    {
        public KayitYoneticisi2()
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

        private void yukleButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            if (kayitlar.SelectedIndex != -1)
            {
                string nVeriler = kayitlar.Items[kayitlar.SelectedIndex].ToString();
                string veriler = main.value.Values[nVeriler.Trim()].ToString();
                MainPageVeriler mVeriler = new MainPageVeriler();
                mVeriler.Ogeler = veriler;
                this.Frame.Navigate(typeof(MainPage), mVeriler);
            }

        }

        private void silButton_Click(object sender, RoutedEventArgs e)
        {
            if (kayitlar.SelectedIndex != -1)
            {
                MainPage main = new MainPage();
                string secilen = kayitlar.Items[kayitlar.SelectedIndex].ToString();
                main.value.Values.Remove(secilen);
                kayitlar.Items.Clear();
                foreach (string veri in main.value.Values.Keys)
                {
                    if (veri != "dil")
                    {
                        kayitlar.Items.Add(veri);
                    }
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            if (main.dilayarlari.Values["dil"].ToString() == "Türkçe")
            {
                kayitYoneticisiBaslik.Text = "Kayıt Yöneticisi";
                kayitlarBaslik.Text = "Kayıtlar:";
                silButton.Content = "Sil";
                yukleButton.Content = "Yükle";
                kapatButton.Content = "Kapat";
            }
            else if (main.dilayarlari.Values["dil"].ToString() == "English")
            {
                kayitYoneticisiBaslik.Text = "Record Manager";
                kayitlarBaslik.Text = "Records:";
                silButton.Content = "Delete";
                yukleButton.Content = "Load";
                kapatButton.Content = "Close";
            }

            kayitlar.Items.Clear();
            foreach (string veri in main.value.Values.Keys)
            {
                if (veri != "dil")
                {
                    kayitlar.Items.Add(veri);
                }
            }
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
