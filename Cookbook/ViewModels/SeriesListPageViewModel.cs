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
    public class SeriesListPageViewModel : ViewModelBase
    {
        //List of the series that met the requirements of user
        public ObservableCollection<Series> DiscoveredSeries
        {
            get;
            set;
        } = new ObservableCollection<Series>();
        //The user can write the title of the requested series above the list in Textbox. That text will be stored here
        private string _seriesName; public string SeriesName
        {
            get { return _seriesName; }
            set { Set(ref _seriesName, value); }
        }
        //The Series that was chosen is defined here
        private Series _series;public Series ChosenSeries
        {
            get { return _series; }
            set { Set(ref _series, value); }
        }
        // TODO get data from webservice
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            //Create a new service and fill DiscoveredSeries with the elements of the parameter. 
            //It is a SeriesWithGenreIDs, program needs to convert that to Series, it was needed only for tematical search
            var service = new MovieService();
            foreach (Series item in (ObservableCollection<Series>)parameter)
            {
                DiscoveredSeries.Add(item);
            }
            await base.OnNavigatedToAsync(parameter, mode, state);
        }
        public void NavigateToDetails()
        {
            //Open up the Series that's title was written in the Textbox above the list
          //  if(DiscoveredSeries.Where(x => x.name == SeriesName).E
            int seriesId = DiscoveredSeries.Where(x => x.name == SeriesName).First().id;
            NavigationService.Navigate(typeof(SeriesPage), seriesId);
        }
        //Navigate to main page
        public void NavigateToMainPage()
        { NavigationService.Navigate(typeof(MainPage)); }
        //Open the Series on which the user clicked
        public void NavigateToDetailsWithClick(string seriesName)
        {
            int seriesId = DiscoveredSeries.Where(x => x.name == seriesName).Single().id;
            NavigationService.Navigate(typeof(SeriesPage), seriesId);
        }
    }
}

