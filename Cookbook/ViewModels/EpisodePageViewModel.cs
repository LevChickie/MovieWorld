using MovieWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using Template10.Services.NavigationService;
using MovieWorld.Views;
using System.Collections.ObjectModel;

namespace MovieWorld.ViewModels
{
    public class EpisodePageViewModel : ViewModelBase
    {
        //Contains all information needed for opening up a new episode. It contains series id, season number and episode number.
        public ObservableCollection<int> EpisodeToCheckOut
        {
            get;
            set;
        } = new ObservableCollection<int>();
        //Contains all information about this particular episode
        private Episode _episode; public Episode Episode
        {
            get { return _episode; }
            set { Set(ref _episode, value); }
        }
        //Contains all information about this particular series
        private Series _series; public Series Series
        {
            get { return _series; }
            set { Set(ref _series, value); }
        }
        //Contains all information about this particular season
        private Season _season; public Season Season
        {
            get { return _season; }
            set { Set(ref _season, value); }
        }
        //Run this function when navigated to this page
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
           //Get all the required Ids for the request
            ObservableCollection<int> Ids = (ObservableCollection<int>)parameter;
            int seriesID = Ids.ElementAt(0);
            int seasonID = Ids.ElementAt(1);
            int episodeID = Ids.ElementAt(2);
            //Create new service
            var service = new MovieService();
            //Request the series, season and episode to fill up properties
            Series = await service.GetSeriesAsync(seriesID);
            Season = await service.GetSeriesSeasonAsync(seriesID,seasonID);
            Episode = await service.GetSeriesEpisodeAsync(seriesID,seasonID,episodeID);
            await base.OnNavigatedToAsync(parameter, mode, state);
        }
        public void NavigateToNextEpisode()
        {
            //Increase episode number and load the series id, season number and the new episode to the parameter
            //Cannot make upper boundary while the API should send the number of episodes per season, but it returns 0.
            int episode = Episode.episode_number+1;
            EpisodeToCheckOut.Add(Series.id);
            EpisodeToCheckOut.Add(Season.season_number);
            EpisodeToCheckOut.Add(episode);
            NavigationService.Navigate(typeof(EpisodePage),EpisodeToCheckOut );
        }
        public void NavigateToPreviousEpisode()
        {
            //Decrease episode number and load the series id, season number and the new episode to the parameter
            int episode = Episode.episode_number;
            if (Episode.episode_number > 1)
            {
                episode-= 1;
            }
            EpisodeToCheckOut.Add(Series.id);
            EpisodeToCheckOut.Add(Season.season_number);
            EpisodeToCheckOut.Add(episode);
            NavigationService.Navigate(typeof(EpisodePage), EpisodeToCheckOut);
        }
        public void NavigateToSeries()
        {
            //Returns to series
            NavigationService.Navigate(typeof(SeriesPage), Series.id);
        }
    }
}
