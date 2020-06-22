using MovieWorld.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using Template10.Services.NavigationService;
using MovieWorld.Views;

namespace MovieWorld.ViewModels
{
    public class MoviePageViewModel : ViewModelBase
    {
        //Property that stores the information that is needed about the movie
        private Movie _movie; public Movie Movie
        {
            get { return _movie; }
            set { Set(ref _movie, value); }
        }
        //Property stores information about the cast of the movie
        private Credits _credits; public Credits Credits
        {
            get { return _credits; }
            set { Set(ref _credits, value); }
        }
       
        //List containing the all the actors for the movie
        public ObservableCollection<Cast> Cast
        {
            get;
            set;
        } = new ObservableCollection<Cast>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            //Create new service and fill the Movie property with the return value for the API request
            var movieId = (int)parameter;
            var service = new MovieService();
            Movie = await service.GetMovieAsync(movieId);
            //Get credits for the movie
            var credits = await service.GetMovieCreditsAsync(movieId);
            //Add actors to the Cast list
            foreach (Cast item in credits.cast)
            {
                Cast.Add(item);
            }
            await base.OnNavigatedToAsync(parameter, mode, state);
        }
       
        public void NavigateToPerson(string actorName)
        {
            //Navigate to the chosen actor of the movie
            int actorID= Cast.Where(x => x.name == actorName).Single().id;
            NavigationService.Navigate(typeof(PersonPage), actorID);
        }
        public void NavigateToEpisode(int recipeId, int season, int episode)
        {
            //Navigate to the main page
            NavigationService.Navigate(typeof(EpisodePage), episode);
        }
    }
}
