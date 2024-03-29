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
    public sealed partial class MoviePage : Page
    {
        public MoviePage()
        {
            this.InitializeComponent();
        }
        //Click on Actor
        private void Person_Click(object sender, RoutedEventArgs e)
        {
            //Set sender information to button
            Button actorButton = sender as Button;
            if (actorButton != null)
            {
                string actorName = (string)actorButton.Content;
                ViewModel.NavigateToPerson(actorName);
            }
        }
    }
   
}
