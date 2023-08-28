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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace stacjaPogody
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Admin : Page
    {
        System.Threading.Timer _timer;
        public Admin()
        {
            this.InitializeComponent();
            _timer = new System.Threading.Timer(new System.Threading.TimerCallback((obj) => Refresh()), null, 0, 1000);
        }

        private async void Refresh()
        {
            //call your database here...
            Dane.Losowanko();
            //and update the UI afterwards:
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
            () =>
            {
                // Your UI update code goes here!
                dane.Text = $"Temperatura: {Dane.temp} ℃\nWilgotność: {Dane.hum} %\nSiła wiatru: " +
                $"{Dane.wind} km/h\nKierunek wiatru: {Dane.wind_dir}";
            });
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            dane.Text = $"Temperatura: {Dane.temp} ℃\nWilgotność: {Dane.hum} %\nSiła wiatru: " +
                $"{Dane.wind} km/h\nKierunek wiatru: {Dane.wind_dir}";
            wartosc.Text ="Wartość korekty w tej chwili: " + Dane.korekta.ToString();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

      

        private void korektowaniko_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Dane.korekta = Convert.ToDouble(korektowaniko.Text);
                wartosc.Text = "Wartość korekty w tej chwili: " + Dane.korekta.ToString();
            }
            catch (Exception ex)
            {
                korektowaniko.Text = "";
            }
        }
    }
}
