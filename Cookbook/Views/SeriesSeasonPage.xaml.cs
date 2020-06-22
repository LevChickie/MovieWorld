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

namespace MovieWorld.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SeriesSeasonPage : Page
    {
        public SeriesSeasonPage()
        {
            this.InitializeComponent();
        }
        //Navigate to previous season
        private void Previous_Season_Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToPreviousSeason();
        }
        //Navigate to next season
        private void Next_Season_Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToNextSeason();
        }
        //Return to the series page
        private void ReturnToSeriesClick(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToSeries();
        }
        //Navigate to the Episode page using the textBox
        private void GoToEpisode(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToEpisode();
        }
    }
}
