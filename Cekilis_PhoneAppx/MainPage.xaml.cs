using Cekilis_PhoneApp;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App31
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainPageVeriler cVeriler;
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            cVeriler = e.Parameter as MainPageVeriler;
            if (cVeriler != null)
            {
                if (cVeriler.Ogeler != null)
                {
                    string[] items = cVeriler.Ogeler.Split('|');
                    katilimcilar.Items.Clear();
                    foreach (string item in items)
                    {
                        katilimcilar.Items.Add(item);
                    }
                }
                else if (cVeriler.Ekle != null)
                {
                    katilimcilar.Items.Add(cVeriler.Ekle);
                }
                else if (cVeriler.Duzenle != null && cVeriler.Index != null)
                {
                    katilimcilar.Items[cVeriler.Index] = cVeriler.Duzenle;
                }
            }
        }

        bool yuklendi = false;
        public string gIslem = "";
        public string gVeri = "";
        public int gIndex = 0;
        public Windows.Storage.ApplicationDataContainer value = Windows.Storage.ApplicationData.Current.LocalSettings;
        public Windows.Storage.ApplicationDataContainer dilayarlari = Windows.Storage.ApplicationData.Current.LocalSettings;

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            yuklendi = true;
            if (dilayarlari.Values["dil"] != null)
            {
                if (dilayarlari.Values["dil"].ToString() == "Türkçe")
                {
                    hizliDuzenlemeToggleSwitchButton.Header = "Hızlı düzenleme modu";
                    katilimciSayisiTextBlock.Text = "Şuanda 0 adet katılımcı bulunmaktadır.";
                    cikmaIhtimaliTextBlock.Text = "Seçili verinin çıkma ihtimali: %0";
                    tekliRadioButton.Content = "Tekli";
                    takimliRadioButton.Content = "Takımlı";
                    kazanacakSayisiBaslikTextBlock.Text = "Kazanacak sayısı:";
                    cekilisYapButton.Content = "Çekiliş Yap";
                    kazananlarBaslikTextBlock.Text = "Kazananlar:";
                    hizliDuzenlemeToggleSwitchButton.OnContent = "Açık";
                    hizliDuzenlemeToggleSwitchButton.OffContent = "Kapalı";
                    kaydetButton.Content = "Kaydet";
                    kayitYoneticisiButton.Content = "Kayıt Yöneticisi";
                    kapatAppBar.Label = "Çıkış";
                    anasayfaButton.Label = "Anasayfa";
                    hakkindaButton.Label = "Hakkında";
                    kayitlarButton.Label = "Kayıtlar";
                    dilButton.Label = "Dil";
                }
                else if (dilayarlari.Values["dil"].ToString() == "English")
                {
                    hizliDuzenlemeToggleSwitchButton.Header = "Quick edit mode";
                    katilimciSayisiTextBlock.Text = "We have 0's are participants.";
                    cikmaIhtimaliTextBlock.Text = "The probability of a selected data: 0%";
                    tekliRadioButton.Content = "Single";
                    takimliRadioButton.Content = "Dual";
                    kazanacakSayisiBaslikTextBlock.Text = "Winner count:";
                    cekilisYapButton.Content = "Do The Raffle";
                    kazananlarBaslikTextBlock.Text = "Winners:";
                    hizliDuzenlemeToggleSwitchButton.OnContent = "On";
                    hizliDuzenlemeToggleSwitchButton.OffContent = "Off";
                    kaydetButton.Content = "Save";
                    kayitYoneticisiButton.Content = "Record Manager";
                    kapatAppBar.Label = "Exit";
                    anasayfaButton.Label = "Home";
                    hakkindaButton.Label = "About";
                    kayitlarButton.Label = "Records";
                    dilButton.Label = "Language";
                }
            }
            else
            {
                dilayarlari.Values["dil"] = "Türkçe";
            }
        }

        int enfazla = 0, enaz = 0;

        private void kazanacakSayisiTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void sayiKlavyesi_PointerExited(object sender, PointerRoutedEventArgs e)
        {

        }

        private void kazanacakSayisiTextBox_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void katilimcilar_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {

        }

        private void kazanacakSayisiTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {

        }

        private void hizliDuzenlemeToggleSwitchButton_Toggled(object sender, RoutedEventArgs e)
        {
            string deger = String.Empty;
            string anki = String.Empty;
            if (hizliDuzenlemeToggleSwitchButton.IsOn == true)
            {
                katilimcilar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                hizliDuzenlemeModuRichTextBox.Visibility = Windows.UI.Xaml.Visibility.Visible;
                for (int i = 0; i < katilimcilar.Items.Count; i++)
                {
                    if (deger == String.Empty)
                    {
                        deger = katilimcilar.Items[i].ToString();
                    }
                    else
                    {
                        deger += "\n" + katilimcilar.Items[i].ToString();
                    }
                    hizliDuzenlemeModuRichTextBox.Document.SetText(Windows.UI.Text.TextSetOptions.None, deger);
                }
            }
            else
            {
                katilimcilar.Visibility = Windows.UI.Xaml.Visibility.Visible;
                hizliDuzenlemeModuRichTextBox.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private void hizliDuzenlemeModuRichTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            string satir = String.Empty;
            hizliDuzenlemeModuRichTextBox.Document.GetText(Windows.UI.Text.TextGetOptions.AdjustCrlf, out satir);
            katilimcilar.Items.Clear();
            string[] satirlar = satir.Split('\r');
            foreach (string veri in satirlar)
            {
                if (veri != "")
                {
                    katilimcilar.Items.Add(veri);
                }
            }
            if (dilayarlari.Values["dil"].ToString() == "Türkçe")
            {
                katilimciSayisiTextBlock.Text = "Şuanda " + katilimcilar.Items.Count + " adet veri bulunmaktadır.";
            }
            else if (dilayarlari.Values["dil"].ToString() == "English")
            {
                katilimciSayisiTextBlock.Text = "We have " + katilimcilar.Items.Count + "'s are participants.";
            }
        }

        private void cekilisYapButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int kazanacakSayisi = int.Parse(kazanacakSayisiTextBox.Text.Trim());
                string lines = String.Empty;
                List<string> kayitlar = new List<string>();
                int ilkKazanan = 0;
                int ikinciKazanan = 0;
                Random rastgele = new Random();
                int son = 0;
                int uretilensayi = 0;
                int count = katilimcilar.Items.Count;
                List<string> veriler = new List<string>(katilimcilar.Items.Count);
                List<string> veriler2 = new List<string>(katilimcilar.Items.Count);
                List<string> uretilenler = new List<string>(Convert.ToInt32(kazanacakSayisi));
                if (tekliRadioButton.IsChecked == true)
                {
                    if (kazanacakSayisi < katilimcilar.Items.Count)
                    {
                        lines = "";
                        for (int i = 0; i < count; i++)
                        {
                            veriler.Add(Convert.ToString(katilimcilar.Items[i]));
                        }

                        for (int i = 0; i < Convert.ToInt32(kazanacakSayisi); i++)
                        {
                            uretilensayi = rastgele.Next(0, veriler.Count);
                            uretilenler.Add(veriler[uretilensayi]);
                            veriler.RemoveAt(uretilensayi);
                        }
                        foreach (string kazananveri in uretilenler)
                        {
                            if (lines == "")
                            {
                                lines = kazananveri;
                            }
                            else
                            {
                                lines += "\n" + kazananveri;
                            }
                        }
                    }
                    else
                    {

                    }
                }
                else if (takimliRadioButton.IsChecked == true)
                {
                    lines = "";
                    int uretilen = rastgele.Next(0, veriler2.Count);

                    for (int i = 0; i < katilimcilar.Items.Count; i++)
                    {
                        veriler2.Add(Convert.ToString(katilimcilar.Items[i]));
                    }
                    for (int i = 0; i < Convert.ToInt32(kazanacakSayisi); i++)
                    {
                        if (lines != "")
                        {
                            lines += "\n" + veriler2[uretilen];
                            veriler2.RemoveAt(uretilen);
                        }
                        else
                        {
                            lines += veriler2[uretilen];
                            veriler2.RemoveAt(uretilen);
                        }

                        if (veriler2.Count > 0)
                        {
                            int uretilen2 = rastgele.Next(0, veriler2.Count);
                            if (lines != "")
                            {
                                lines += "   -   " + veriler2[uretilen2];
                                veriler2.RemoveAt(uretilen2);
                            }
                            else
                            {
                                lines += "   -   " + veriler2[uretilen2];
                                veriler2.RemoveAt(uretilen2);
                            }
                        }
                        else
                        {
                            lines = lines + "  (BAY)";
                        }
                    }
                }

                if (lines != "")
                {
                    kazananlarRichTextBox.Document.SetText(Windows.UI.Text.TextSetOptions.None, lines);
                }
            }
            catch (Exception hata)
            {
                if (dilayarlari.Values["dil"].ToString() == "Türkçe")
                {
                    MessageDialog mesaj = new MessageDialog(hata.Message, "Hata");
                    mesaj.Commands.Add(new UICommand("Tamam", new UICommandInvokedHandler(handler)));
                    mesaj.ShowAsync();
                }
                else if (dilayarlari.Values["dil"].ToString() == "English")
                {
                    MessageDialog mesaj = new MessageDialog(hata.Message, "Error");
                    mesaj.Commands.Add(new UICommand("OK", new UICommandInvokedHandler(handler)));
                    mesaj.ShowAsync();
                }
            }
        }

        private void handler(IUICommand command)
        {

        }

        public double YuzdeHesaplaMetin(string metin)
        {
            int sayisi = 0;
            List<string> tum = new List<string>();
            List<string> hesap = new List<string>(); ;
            string seciliveri = metin;
            for (int i = 0; i < katilimcilar.Items.Count; i++)
            {
                tum.Add(Convert.ToString(katilimcilar.Items[i]));
            }

            foreach (string ileti in tum)
            {
                if (ileti == metin)
                {
                    sayisi++;
                }
            }
            double yuzde = ((double)sayisi / katilimcilar.Items.Count) * 100;
            return yuzde;
        }

        private void katilimcilar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                List<double> items = new List<double>();
                int sayi = 0;
                double yuzde = YuzdeHesapla(katilimcilar.SelectedIndex);
                for (int i = 0; i < katilimcilar.Items.Count; i++)
                {
                    items.Add(YuzdeHesapla(i));
                }

                foreach (double oran in items)
                {
                    if (yuzde == oran)
                    {
                        sayi++;
                    }
                }
                int tam = Convert.ToInt32(yuzde);
                int virgul = -1;
                string bYuzde = yuzde.ToString();
                for (int b = 0; b < bYuzde.Length; b++)
                {
                    char karakter = Convert.ToChar(bYuzde.Substring(b, 1));
                    if (karakter == ',')
                    {
                        virgul = b;
                    }
                }

                if (virgul == -1)
                {
                    if (katilimcilar.Items.Count == sayi)
                    {
                        if (dilayarlari.Values["dil"].ToString() == "Türkçe")
                        {
                            cikmaIhtimaliTextBlock.Text = "Seçilen verinin çıkma ihtimali: %" + yuzde + " (Tüm katılımcı çıkma ihtimalleri aynı)";
                        }
                        else if (dilayarlari.Values["dil"].ToString() == "English")
                        {
                            cikmaIhtimaliTextBlock.Text = "The probability of a selected data: " + yuzde + "% (All participants have the same case)";
                        }
                    }
                    else
                    {
                        if (dilayarlari.Values["dil"].ToString() == "Türkçe")
                        {
                            cikmaIhtimaliTextBlock.Text = "Seçilen verinin çıkma ihtimali: %" + yuzde;
                        }
                        else if (dilayarlari.Values["dil"].ToString() == "English")
                        {
                            cikmaIhtimaliTextBlock.Text = "The probability of a selected data: " + yuzde + "%";
                        }
                    }
                }

                string ilkveri = bYuzde.Substring(0, virgul);
                string ikinciveri = bYuzde.Substring(virgul + 1, 1);
                string birles = ilkveri + "," + ikinciveri;

                if (katilimcilar.Items.Count == sayi)
                {
                    if (dilayarlari.Values["dil"].ToString() == "Türkçe")
                    {
                        cikmaIhtimaliTextBlock.Text = "Seçilen verinin çıkma ihtimali: %" + birles + "(Tüm katılımcı çıkma ihtimalleri aynı)";
                    }
                    else if (dilayarlari.Values["dil"].ToString() == "English")
                    {
                        cikmaIhtimaliTextBlock.Text = "The probability of a selected data: %" + birles + "(All participants have the same case)";
                    }
                }
                else
                {
                    if (dilayarlari.Values["dil"].ToString() == "Türkçe")
                    {
                        cikmaIhtimaliTextBlock.Text = "Seçilen verinin çıkma ihtimali: %" + birles;
                    }
                    else if (dilayarlari.Values["dil"].ToString() == "English")
                    {
                        cikmaIhtimaliTextBlock.Text = "The probability of a selected data: " + birles + "%";
                    }
                }
            }
            catch (Exception hata)
            {

            }
        }

        public double YuzdeHesapla(int index)
        {
            int sayisi = 0;
            List<string> tum = new List<string>();
            List<string> hesap = new List<string>();
            int seciliindex = index;
            string seciliveri = Convert.ToString(katilimcilar.Items[seciliindex]);
            for (int i = 0; i < katilimcilar.Items.Count; i++)
            {
                tum.Add(Convert.ToString(katilimcilar.Items[i]));
            }

            foreach (string ileti in tum)
            {
                if (ileti == seciliveri)
                {
                    sayisi++;
                }
            }
            double yuzde = ((double)sayisi / katilimcilar.Items.Count) * 100;
            return yuzde;
        }

        private void hizliDuzenlemeModuRichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (hizliDuzenlemeModuRichTextBox.Document.Selection.Text != "")
                {
                    List<double> items = new List<double>();
                    int sayi = 0;
                    double yuzde = YuzdeHesaplaMetin(hizliDuzenlemeModuRichTextBox.Document.Selection.Text);
                    for (int i = 0; i < katilimcilar.Items.Count; i++)
                    {
                        items.Add(YuzdeHesapla(i));
                    }

                    foreach (double oran in items)
                    {
                        if (yuzde == oran)
                        {
                            sayi++;
                        }
                    }
                    int tam = Convert.ToInt32(yuzde);
                    int virgul = -1;
                    string bYuzde = yuzde.ToString();
                    for (int b = 0; b < bYuzde.Length; b++)
                    {
                        char karakter = Convert.ToChar(bYuzde.Substring(b, 1));
                        if (karakter == ',')
                        {
                            virgul = b;
                        }
                    }

                    if (virgul == -1)
                    {
                        if (katilimcilar.Items.Count == sayi)
                        {
                            if (dilayarlari.Values["dil"].ToString() == "Türkçe")
                            {
                                cikmaIhtimaliTextBlock.Text = "Seçilen verinin çıkma ihtimali: %" + yuzde + "(Tüm katılımcı çıkma ihtimalleri aynı)";
                            }
                            else if (dilayarlari.Values["dil"].ToString() == "English")
                            {
                                cikmaIhtimaliTextBlock.Text = "The probability of a selected data: " + yuzde + "% (All participants have the same case)";
                            }
                        }
                        else
                        {
                            if (dilayarlari.Values["dil"].ToString() == "Türkçe")
                            {
                                cikmaIhtimaliTextBlock.Text = "Seçilen verinin çıkma ihtimali: %" + yuzde;
                            }
                            else if (dilayarlari.Values["dil"].ToString() == "English")
                            {
                                cikmaIhtimaliTextBlock.Text = "The probability of a selected data: " + yuzde + "%";
                            }
                        }
                    }

                    string ilkveri = bYuzde.Substring(0, virgul);
                    string ikinciveri = bYuzde.Substring(virgul + 1, 1);
                    string birles = ilkveri + "," + ikinciveri;

                    if (katilimcilar.Items.Count == sayi)
                    {
                        if (dilayarlari.Values["dil"].ToString() == "Türkçe")
                        {
                            cikmaIhtimaliTextBlock.Text = "Seçilen verinin çıkma ihtimali: %" + birles + "(Tüm katılımcı çıkma ihtimalleri aynı)";
                        }
                        else if (dilayarlari.Values["dil"].ToString() == "English")
                        {
                            cikmaIhtimaliTextBlock.Text = "The probability of a selected data: " + birles + "% (All participants have the same case)";
                        }
                    }
                    else
                    {
                        if (dilayarlari.Values["dil"].ToString() == "Türkçe")
                        {
                            cikmaIhtimaliTextBlock.Text = "Seçilen verinin çıkma ihtimali: %" + birles;
                        }
                        else if (dilayarlari.Values["dil"].ToString() == "English")
                        {
                            cikmaIhtimaliTextBlock.Text = "The probability of a selected data: " + birles + "%";
                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception hata)
            {

            }
        }

        private async void programAdiTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private async void menuComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void cekilisBaslikButton_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private async void kayitYoneticisiButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(KayitYoneticisi2));
        }

        public string gVeriler = "";

        private async void kaydetButton_Click(object sender, RoutedEventArgs e)
        {
            if (katilimcilar.Items.Count > 0)
            {
                gVeriler = "";
                for (int i = 0; i < katilimcilar.Items.Count; i++)
                {
                    if (katilimcilar.Items[i].ToString() != "")
                    {
                        if (gVeriler == "")
                        {
                            gVeriler = katilimcilar.Items[i].ToString();
                        }
                        else
                        {
                            gVeriler += "|" + katilimcilar.Items[i].ToString();
                        }
                    }
                }
                MessageDialog mesaj = new MessageDialog(gVeriler, "");
                await mesaj.ShowAsync();
                GirisKutusu giris = new GirisKutusu(gVeriler);
                await giris.ShowAsync();
            }
        }

        private void sayfaGecisleriButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SayfaGecisleri));
        }

        private void kapaUygulamaButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void katilimciSilButton_Click(object sender, RoutedEventArgs e)
        {
            if (katilimcilar.SelectedItems.Count > 0)
            {
                List<int> indises = new List<int>();
                for (int i = 0; i < katilimcilar.SelectedItems.Count; i++)
                {
                    indises.Add(katilimcilar.Items.IndexOf(katilimcilar.SelectedItems[i]));
                }

                indises.Sort();
                indises.Reverse();

                for (int x = 0; x < indises.Count; x++)
                {
                    katilimcilar.Items.RemoveAt(indises[x]);
                }

                if (dilayarlari.Values["dil"].ToString() == "Türkçe")
                {
                    katilimciSayisiTextBlock.Text = "Şuanda " + katilimcilar.Items.Count + " adet veri bulunmaktadır.";
                }
                else if (dilayarlari.Values["dil"].ToString() == "English")
                {
                    katilimciSayisiTextBlock.Text = "Now there are " + katilimcilar.Items.Count + " pieces of data.";
                }
            }
        }

        private void katilimciEkleButton_Click(object sender, RoutedEventArgs e)
        {
            gIslem = "Ekleme";
            this.Frame.Navigate(typeof(KatilimciIslemKutusu));
        }

        private async void katilimciDuzenleButton_Click(object sender, RoutedEventArgs e)
        {
            if (katilimcilar.SelectedItems.Count == 1)
            {
                gIslem = "Düzenleme";
                gVeri = katilimcilar.SelectedItems[0].ToString();
                gIndex = katilimcilar.Items.IndexOf(katilimcilar.SelectedItems[0]);
                MessageDialog mesaj = new MessageDialog("gVeri = " + katilimcilar.SelectedItems[0].ToString() + "\ngIndex = " + katilimcilar.Items.IndexOf(katilimcilar.SelectedItems[0]), "Bilgi");
                await mesaj.ShowAsync();
                this.Frame.Navigate(typeof(KatilimciIslemKutusu));
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
