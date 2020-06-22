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
    public sealed partial class MovieListPage : Page
    {
        public MovieListPage()
        {
            this.InitializeComponent();
        }
        //Navigate to Movie by clicking on item
        private void DiscoveredMovieClick(object sender, ItemClickEventArgs e)
        {
            var item = (Movie)e.ClickedItem;
            ViewModel.NavigateToDetails();
        }
        //Navigate to Movie by clicking on the button after write movie name in TextBox
        private void Movie_Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToDetails();
        }
        //Navigate to Movie by clicking on movie name
        private void Movie_Click(object sender, RoutedEventArgs e)
        {
            //Set sender to a button
            Button button = sender as Button;
            if (button != null)
            {
                //Get the content of the button and open that.
                string movieName = (string)button.Content;
                ViewModel.NavigateToDetailsWithClick(movieName);
            }
        }
        //Return to Menu by clicking on this button
        private void Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToMainPage();
        }
    }
}
