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
    public class MovieListPageViewModel : ViewModelBase
    {
        //List containing Movies that should be listed on the page
        public ObservableCollection<Movie> DiscoveredMovie
        {
            get;
            set;
        } = new ObservableCollection<Movie>();
        //When the user writes the title of the searched movie, it will be saved in this property
        private string _moviesName; public string MovieName
        {
            get { return _moviesName; }
            set { Set(ref _moviesName, value); }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            //Create new service and get movies from a the list of MovieWithGenreIDs- that was needed for tematical search
            var service = new MovieService();
            foreach(Movie item in (ObservableCollection<Movie>)parameter)
            {
                DiscoveredMovie.Add(item);
            }
            
            await base.OnNavigatedToAsync(parameter, mode, state);
        }
        public void NavigateToDetails()
        {
            //Get the movie which name is written in the Textbox above the list
            int movieId = DiscoveredMovie.Where(x => x.title == MovieName).Single().id;
            NavigationService.Navigate(typeof(MoviePage), movieId);
        }
        public void NavigateToDetailsWithClick(string movieName)
        {
            //Get the movie on which the user clicked
            int movieId = DiscoveredMovie.Where(x => x.title == movieName).Single().id;
            NavigationService.Navigate(typeof(MoviePage), movieId);
        }
        //Navigate back to main page
        public void NavigateToMainPage()
        { NavigationService.Navigate(typeof(MainPage)); }

    }
}

