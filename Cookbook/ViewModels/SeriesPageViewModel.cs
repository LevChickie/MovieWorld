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
    public class SeriesPageViewModel : ViewModelBase
    {
      //Contains information on the chosen series
        private Series _series; public Series Series
        {
            get { return _series; }
            set { Set(ref _series, value); }
        }
        //Stores the number of the chosen season - from the TextBox
        private int _seasonNumberChosen; public int SeasonNumberChosen
        {
            get { return _seasonNumberChosen; }
            set { Set(ref _seasonNumberChosen, value); }
        }
        //Contains all information needed to open a Season (contains series id and season number)
        public ObservableCollection<int> SeasonToCheckOut
        {
            get;
            set;
        } = new ObservableCollection<int>();
        //Contains information on the Cast of the Series - for most of the series it returns no value
        public ObservableCollection<Cast> Cast
        {
            get;
            set;
        } = new ObservableCollection<Cast>();
      
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            //Create new service and fill Series with information
            var seriesId = (int)parameter;
            var service = new MovieService();
            //Delete old data from SeasonToCheckOut
            SeasonToCheckOut.Clear();
            Series = await service.GetSeriesAsync(seriesId);
            var credits = await service.GetSeriesCreditsAsync(seriesId);
            //Get the list of actors from the Credits variable
            if (credits.cast != null)
            {
                foreach (var item in credits.cast)
                { 
                    Cast.Add(item);
                }
            }
            await base.OnNavigatedToAsync(parameter, mode, state);
        }
        //Navigate to the 
        public void NavigateToPerson(int personId)
        { NavigationService.Navigate(typeof(PersonPage), personId); }
        //Navigate to the chosen Episode
        public void NavigateToEpisode()
        {
            //Fill Season to checkout with seriesId, season number and also with episodeID
            SeasonToCheckOut.Add(Series.id);
            SeasonToCheckOut.Add(SeasonNumberChosen);
            SeasonToCheckOut.Add(1);
            NavigationService.Navigate(typeof(EpisodePage),SeasonToCheckOut );
        }
        public void NavigateToSeason()
        {
            //Fill Season to checkout with seriesId, season number
            SeasonToCheckOut.Add(Series.id);
            SeasonToCheckOut.Add(SeasonNumberChosen);
            NavigationService.Navigate(typeof(SeriesSeasonPage),SeasonToCheckOut );
        }
        //Return to Menu
        public void NavigateToMenu()
        {
            NavigationService.Navigate(typeof(MainPage));
        }
        //Navigate to the chosen person
        public void NavigateToPerson(string actorName)
        {
            //Find the actor from the cast with the chosen name
            int actorID = Cast.Where(x => x.name == actorName).Single().id;
            NavigationService.Navigate(typeof(PersonPage), actorID);
        }
    }
}
