using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using MovieWorld.Services;
using MovieWorld.Views;

namespace MovieWorld.ViewModels
{
    class SeriesSeasonPageViewModel:ViewModelBase
    {
        //Contains information on Series
        private Series _series; public Series Series
        {
            get { return _series; }
            set { Set(ref _series, value); }
        }
        //Contains information on Seasons of Series
        private Season _season; public Season Season
        {
            get { return _season; }
            set { Set(ref _season, value); }
        }
        //The chosen episode in the textbox
        private int _episode; public int Episode
        {
            get { return _episode; }
            set { Set(ref _episode, value); }
        }
        //Stores information that needed to navigate to other seasons or episode (contains series id, season number and probably contains episode id)
        public ObservableCollection<int> SeasonToCheckOut
        {
            get;
            set;
        } = new ObservableCollection<int>();
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            //Create a new service and fill the Series, Season properties with the help of the parameters
            var service = new MovieService();
            ObservableCollection<int> Ids = (ObservableCollection<int>)parameter;
            int seriesID = Ids.First();
            int seasonID = Ids.Last();
            Season = await service.GetSeriesSeasonAsync(seriesID, seasonID);
            Series = await service.GetSeriesAsync(seriesID);
            
            await base.OnNavigatedToAsync(parameter, mode, state);
        }
        public void NavigateToNextSeason()
        {
            //Navigate to the next season. Increase season number and refresh the page
            int season = Season.season_number+1;
            SeasonToCheckOut.Clear();
            SeasonToCheckOut.Add(Series.id);
            SeasonToCheckOut.Add(season);
            NavigationService.Navigate(typeof(SeriesSeasonPage), SeasonToCheckOut);
        }
        public void NavigateToPreviousSeason()
        {
            int season= Season.season_number;
            //Navigate to the previous season. Decrease the season number and refresh the page
            if (Season.season_number != 1)
            {
                season -= 1;
            }
            SeasonToCheckOut.Clear();
            SeasonToCheckOut.Add(Series.id);
            SeasonToCheckOut.Add(season);
            NavigationService.Navigate(typeof(SeriesSeasonPage), SeasonToCheckOut);
        }
        public void NavigateToSeries()
        {
            //Navigate back to the series
            NavigationService.Navigate(typeof(SeriesPage), Series.id);
        }
        public void NavigateToEpisode()
        {
            //Navigate to episode - fill SeasonToCheckOut with series id, season number, episode number
            SeasonToCheckOut.Clear();
            SeasonToCheckOut.Add(Series.id);
            SeasonToCheckOut.Add(Season.season_number);
            SeasonToCheckOut.Add(Episode);
            NavigationService.Navigate(typeof(EpisodePage), SeasonToCheckOut);
        }
    }
}
