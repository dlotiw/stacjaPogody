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
using static System.Net.Mime.MediaTypeNames;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace stacjaPogody
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        System.Threading.Timer _timer;
        public MainPage()
        {
            this.InitializeComponent();
            _timer = new System.Threading.Timer(new System.Threading.TimerCallback((obj) => Refresh()), null, 0, 1000);
        }


        private void admin_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Admin));
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            
            dane.Text = $"Temperatura: {Dane.temp}\nWilgotność: {Dane.hum}\nSiła wiatru: {Dane.wind}\nKierunek wiatru: {Dane.wind_dir}";


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
                dane.Text = $"Temperatura: {Dane.temp+Dane.korekta} ℃\nWilgotność: {Dane.hum+Dane.korekta} %\nSiła wiatru: " +
                $"{Dane.wind + Dane.korekta} km/h\nKierunek wiatru: {Dane.wind_dir}";
            });
        }
    }
}