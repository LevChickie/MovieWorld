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
    public sealed partial class SeriesListPage : Page
    {
        public SeriesListPage()
        {
            this.InitializeComponent();
        }
      //Click on button after typing series name in Textbox
        private void Series_Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToDetails();
        }
        //Return to menu 
        private void Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToMainPage();

        }
        //Click on series-name
        private void Series_Click(object sender, RoutedEventArgs e)
        {
            //Set sender information to button
            Button button = sender as Button;
            if (button != null)
            {
                string seriesName = (string)button.Content;
                ViewModel.NavigateToDetailsWithClick(seriesName);
            }
        }
    }
    
}
