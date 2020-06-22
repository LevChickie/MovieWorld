using MovieWorld.Services;
using MovieWorld.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace MovieWorld.ViewModels
{
    public class PersonPageViewModel : ViewModelBase
    {
       //Property contains information about the specific person
        private Person _person; public Person Person
        {
            get { return _person; }
            set { Set(ref _person, value); }
        }
        //String contains the alias names of the actor
        private string alias; public string Alias
        {
            get { return alias; }
            set { Set(ref alias, value); }
        }
        //List of all the movies the actor was participated
        public ObservableCollection<Cast> MovieCast
        {
            get;
            set;
        } = new ObservableCollection<Cast>();
        //List of all the series the actor was participated
        public ObservableCollection<Cast> SeriesCast
        {
            get;
            set;
        } = new ObservableCollection<Cast>();
      
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            //Create service and ask information from the API
            var personID = (int)parameter;
            var service = new MovieService();
            Person = await service.GetPersonAsync(personID);
            var seriesCast = await service.GetSeriesCredits(personID);
            var movieCast = await service.GetMovieCredits(personID);
            //Forge the string Alias with the help of the also_known_as array of Person
            Alias = "Aliases: ";
            for(int i=0; i < Person.also_known_as.Length; i++)
            {
                Alias = Alias + ", " + Person.also_known_as[i];
            }
            //Add movies and series to the Lists
            foreach(var item in movieCast.cast)
            {
                MovieCast.Add(item);
            }
            foreach(var item in seriesCast.cast)
            {
                SeriesCast.Add(item);
            }
            await base.OnNavigatedToAsync(parameter, mode, state);
        }
        public void NavigateToMovie(string movieName)
        {
            //Navigate to the chosen Movie where the name is equal to the Movie-title the user clicked on
            int movieId = MovieCast.Where(x => x.name == movieName).Single().id;
            NavigationService.Navigate(typeof(MoviePage), movieId);
        }
        public void NavigateToSeries(string seriesName)
        {
            //Navigate to the chosen Series where the name is equal to the Series-title the user clicked on
            int seriesId = SeriesCast.Where(x => x.name == seriesName).First().id;
             NavigationService.Navigate(typeof(SeriesPage), seriesId);
        }
    }
}
