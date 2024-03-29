﻿using System;
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
    
    public sealed partial class EpisodePage : Page
    {
        public EpisodePage()
        {
            this.InitializeComponent();
        }
        //Open up the previous episode
        private void PreviousEpisodeClick(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToPreviousEpisode();
        }
        //Open up the next episode
        private void NextEpisodeClick(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToNextEpisode();
        }
        //Return to series
        private void ReturnToSeriesClick(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToSeries();
        }
    }
}
