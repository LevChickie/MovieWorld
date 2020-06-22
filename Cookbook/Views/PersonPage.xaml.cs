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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PersonPage : Page
    {
        public PersonPage()
        {
            this.InitializeComponent();
        }
        //Click on the Movies featured by the actor
        private void Movie_Click(object sender, RoutedEventArgs e)
        {
            //Set sender information to button
            Button actorButton = sender as Button;
            if (actorButton != null)
            {
                string movieName = (string)actorButton.Content;
                ViewModel.NavigateToMovie(movieName);
            }
        }
        //Click on the Series featured by the actor
        private void Series_Click(object sender, RoutedEventArgs e)
        {
            //Set sender information to button
            Button actorButton = sender as Button;
            if (actorButton != null)
            {
                string seriesName = (string)actorButton.Content;
                ViewModel.NavigateToSeries(seriesName);
            }
        }
    }
}
