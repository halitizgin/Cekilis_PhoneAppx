using App31;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers.Provider;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Cekilis_PhoneApp
{
    public sealed partial class GirisKutusu : ContentDialog
    {
        public GirisKutusu(string Veriler)
        {
            this.InitializeComponent();
            gVeriler = Veriler;
        }

        string gVeriler;

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            MainPage main = new MainPage();
            if (main.value.Values[veri.Text.Trim()] == null)
            {
                main.value.Values[veri.Text.Trim()] = gVeriler;
                gVeriler = "";
            }
            else
            {
                if (main.dilayarlari.Values["dil"].ToString() == "Türkçe")
                {
                    MessageDialog mesaj = new MessageDialog("\"" + veri.Text.Trim() + "\" adlı kayıt zaten mevcuttur. Üzerine yazmak istediğinize emin misiniz?", "Soru");
                    mesaj.Commands.Add(new UICommand("Evet", new UICommandInvokedHandler(evethandler)));
                    mesaj.Commands.Add(new UICommand("Hayır", new UICommandInvokedHandler(hayirhandler)));
                    await mesaj.ShowAsync();
                }
                else if (main.dilayarlari.Values["dil"].ToString() == "English")
                {
                    MessageDialog mesaj = new MessageDialog("\"" + veri.Text.Trim() + "\" are already available at records. Are you sure you want to overwrite?", "Question");
                    mesaj.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(evethandler)));
                    mesaj.Commands.Add(new UICommand("No", new UICommandInvokedHandler(hayirhandler)));
                    await mesaj.ShowAsync();
                }
            }
        }

        private void hayirhandler(IUICommand command)
        {
            
        }

        private void evethandler(IUICommand command)
        {
            MainPage main = new MainPage();
            main.value.Values[veri.Text.Trim()] = gVeriler;
            gVeriler = "";
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private async void girisKutusu_Loaded(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            if (main.dilayarlari.Values["dil"].ToString() == "Türkçe")
            {
                this.Title = "Kayıt ismini giriniz:";
                this.PrimaryButtonText = "Onayla";
                this.SecondaryButtonText = "İptal";
            }
            else if (main.dilayarlari.Values["dil"].ToString() == "English")
            {
                this.Title = "Enter the name of the record:";
                this.PrimaryButtonText = "Confirm";
                this.SecondaryButtonText = "Cancel";
            }
        }
    }
}
