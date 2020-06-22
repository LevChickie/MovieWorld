using System;
using Windows.UI.Xaml.Controls;

namespace MovieWorld.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //Manipulate CheckBox - and set Sort-property to desc. or asc.
        private void CheckBoxCheckDecreasing(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.CheckSortCheckbox("popularity.desc");
        }

        private void CheckBoxCheckIncreasing(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.CheckSortCheckbox("popularity.asc");
        }
        //Start search for movies/series
        private void Discover_Button_Click(object sender,  Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (MediaInput.Text=="tv")
            {
                ViewModel.DiscoverSeries();
            }
            else if(MediaInput.Text=="movie")
            {
                ViewModel.DiscoverMovie();
            }
        }
        //Manipulate CheckBox - and set IsAdult-property to true or false
        private void CheckBoxCheckAdult(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.CheckAdultCheckbox(true);
        }
        private void CheckBoxCheckChildren(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.CheckAdultCheckbox(false);
        }
        //Start discover by trend
        private void Item_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (MediaTV.IsChecked == true)
            {
                ViewModel.DiscoverTrendingSeries();
            }
            else if(MediaMovie.IsChecked==true)
            {
                ViewModel.DiscoverTrendingMovie();
            }
        }
        //Manipulate Timing - set Timer week or day
        private void SetTiming(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //Set data of sender in a button
            RadioButton setTimer = sender as RadioButton;
            if (setTimer != null)
            {
                //Get the tag of the button
                String tag = setTimer.Tag.ToString();
                switch (tag)
                {
                    case "week": ViewModel.SetTimer(tag); break;
                    case "day": ViewModel.SetTimer(tag); break;
                      
                }
            }
        }
        //Manipulate Media - set Media tv or movie
        private void SetMedia(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            RadioButton setMedia = sender as RadioButton;
            if (setMedia != null)
            {
                String tag = setMedia.Tag.ToString();
                switch (tag)
                {
                    case "tv": ViewModel.SetMedia(tag);break;
                    case "movie": ViewModel.SetMedia(tag);break;

                }
            }
        }
    }
}
