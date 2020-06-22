using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using MovieWorld.Services;
using MovieWorld.Views;

namespace MovieWorld.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //List containing the results for a request for Serieses
        public ObservableCollection<Series> DiscoveredSeries
        {
            get;
            set;
        } = new ObservableCollection<Series>();
        //List containing the results for the request for movies
        public ObservableCollection<Movie> DiscoveredMovie
        {
            get;
            set;
        } = new ObservableCollection<Movie>();
        //Property if the given movie is for adults or not
        private bool isAdult; public bool IsAdult
        {
            get { return isAdult; }
            set { Set(ref isAdult, value); }
        }
        //Property that tells the API in which order should it return data
        private string sortDecreasing; public string SortDecreasing
        {
            get { return sortDecreasing; }
            set { Set(ref sortDecreasing, value); }
        }
        //Property that tells the API that the user looks for a movie or a tv-series
        private string media; public string Media
        {
            get { return media; }
            set { Set(ref media, value); }
        }
        //Property containing the keywords for searching for movies
        private string keyword; public string Keyword
        {
            get { return keyword; }
            set { Set(ref keyword, value); }
        }
        //Property that tells the API that the requested movies/serieses should be on this language
        private string language; public string Language
        {
            get { return language; }
            set { Set(ref language, value); }
        }
        //The returning movies/series should have higher popularity vote than the given value
        private int vote; public int Vote
        {
            get { return vote; }
            set { Set(ref vote, value); }
        }
        //A property used for the trending search, tells the API if it should return daily or weekly data
        private string timer; public string Timer
        {
            get { return timer; }
            set { Set(ref timer, value); }
        }
        //Property containing the chosen genre in which the user look for movie/series
        private string genreName; public string Genre
        {
            get { return genreName; }
            set { Set(ref genreName, value); }
        }
        //Property containing the chosen genre in which the user look for movie/series - both needed for the search
        private Genre genre; public Genre ChosenGenre
        {
            get { return genre; }
            set { Set(ref genre, value); }
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
          await base.OnNavigatedToAsync(parameter, mode, state);
        }
        //Navigate to series using its id
        public void NavigateToDetails(int seriesID)
        { NavigationService.Navigate(typeof(SeriesPage), seriesID); }
        //Adult checkbox event handler
        public void CheckAdultCheckbox(bool value)
        {
            IsAdult = value;   
        }
        //Sort Checkbox event handler
        public void CheckSortCheckbox(string value)
        {
            SortDecreasing = value;
        }
        //Timer radiobutton event handler
        public void SetTimer(string timer)
        {
            this.timer = timer;
        }
        //Media radiobutton event handler
        public void SetMedia(string media)
        {
            this.media = media;
        }
        //Search for Series
        public async Task DiscoverSeries()
        {
            //API needs %2C between keywords
            Keyword.Replace(",", "%2C");
            //Create new service and get series informations in a SeriesGroup
            var service = new MovieService();
                var discovered = await service.GetDiscoverSeriesAsync(Media, Language, SortDecreasing, Vote, Keyword);
            //Get the list of genres and choose the one out that user was looking for
            var genreList = await service.GetGenres(Media);
            foreach (var item in genreList.genres)
            {

                if (Genre == item.name)
                {
                    ChosenGenre = item;
                }
            }
            //Clear up the DiscoverSerieses so it would not contain old data
            DiscoveredSeries.Clear();
            //Fill up DiscoveredSeries if the items meet requirements
            foreach (var item in discovered.results)
            {
                if (item.genre_ids.Contains(ChosenGenre.id))
                {
                    DiscoveredSeries.Add((Series)item);
                }
            }
            NavigationService.Navigate(typeof(SeriesListPage), DiscoveredSeries);
        }
        //Discover a movie
        public async Task DiscoverMovie()
        {
            //API needs %2C for each , between keywords
            Keyword.Replace(",", "%2C");
            //Create service and get series and genre data
            var service = new MovieService();
            var discovered = await service.GetDiscoverMovieAsync(Media, Language, SortDecreasing, IsAdult, Vote, Keyword);
            var genreList = await service.GetGenres(Media);
                //Search for the chosen genre;
            foreach(var item in genreList.genres)
            {
                if(Genre == item.name)
                {
                    ChosenGenre = item;
                }
            }
            //Clear the list DiscoveredMovies so it wont contain old data
            DiscoveredMovie.Clear();
            //Fill up DiscoveredMovies with elements that meet the requirements
           foreach (var item in discovered.results)
            {
                if (item.genre_ids.Contains(ChosenGenre.id))
                {
                             DiscoveredMovie.Add((Movie)item);
                }
            }
            NavigationService.Navigate(typeof(MovieListPage), DiscoveredMovie);
        }
        public async Task DiscoverTrendingMovie()
        {
            //Create service and get data from API
            var service = new MovieService();
            var discovered = await service.GetTrendingMovie(Timer);
            DiscoveredMovie.Clear();
            //Fill up the emptied DiscoveredMovie with elements that meet requirements
            foreach (var item in discovered.results)
            {
                DiscoveredMovie.Add(item);
            }
            NavigationService.Navigate(typeof(MovieListPage), DiscoveredMovie);
        }
        public async Task DiscoverTrendingSeries()
        {
            //Create service and get data from API
            var service = new MovieService();
            var discovered = await service.GetTrendingSeries(Timer);
            DiscoveredSeries.Clear();
            //Fill up the emptied DiscoveredSeries with elements that meet requirements
            foreach (var item in discovered.results)
            {
                DiscoveredSeries.Add(item);
            }
            NavigationService.Navigate(typeof(SeriesListPage), DiscoveredSeries);
        }
    }
}

