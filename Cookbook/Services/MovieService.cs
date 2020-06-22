using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.Services
{
    class MovieService
    {
        //Send request and turn JSON to requested format.
        private async Task<T> GetAsync<T>(Uri uri)
        { using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }
        
        private readonly Uri movieServerUrl = new Uri("https://api.themoviedb.org");
       
        //Request for a movie using its id
        public async Task<Movie> GetMovieAsync(int id)
        {
            return await GetAsync<Movie>(new Uri(movieServerUrl, $"3/movie/{id}?api_key=b535fb9162267b5f833139385c3a2131&language=en-US"));
        }
        //Request for a series using its id
        public async Task<Series> GetSeriesAsync(int id)
        {
            return await GetAsync<Series>(new Uri(movieServerUrl, $"3/tv/{id}?api_key=b535fb9162267b5f833139385c3a2131&language=en-US")); }
        //Request for a list of series which meet the requirements
        public async Task<SeriesGroup> GetDiscoverSeriesAsync(string media, string language, string sort, float vote, string keywords)
        {
            return await GetAsync<SeriesGroup>(new Uri(movieServerUrl, $"3/discover/{media}?api_key=b535fb9162267b5f833139385c3a2131&language={language}&sort_by={sort}&page=1&vote_average.gte={vote}&with_keywords={keywords}"));
        }
        //Request for a list of movies which meet the requirements
        public async Task<MovieGroup> GetDiscoverMovieAsync(string media, string language, string sort, bool adult,float vote, string keywords)
        {
            return await GetAsync<MovieGroup>(new Uri(movieServerUrl, $"3/discover/{media}?api_key=b535fb9162267b5f833139385c3a2131&language={language}&sort_by={sort}&include_adult={adult}&page=1&vote_average.gte={vote}&with_keywords={keywords}"));
        }
        //Request for the episodes of a series using the series id, the number of the season and the number of requested episode
        public async Task<Episode> GetSeriesEpisodeAsync(int id,int season_number, int episode_number)
        {
            return await GetAsync<Episode>(new Uri(movieServerUrl, $"3/tv/{id}/season/{season_number}/episode/{episode_number}?api_key=b535fb9162267b5f833139385c3a2131&language=en-US"));
        }
        //Request for a person using its id
        public async Task<Person> GetPersonAsync(int id)
        {
            return await GetAsync<Person>(new Uri(movieServerUrl, $"3/person/{id}?api_key=b535fb9162267b5f833139385c3a2131&language=en-US"));
        }
        //Request for a season of a series using the series id and the number of the requested season
        public async Task<Season> GetSeriesSeasonAsync(int id, int season_number)
        {
            return await GetAsync<Season>(new Uri(movieServerUrl, $"3/tv/{id}/season/{season_number}?api_key=b535fb9162267b5f833139385c3a2131&language=en-US"));
        }
        //Request for the cast of the movie
        public async Task<Credits> GetMovieCreditsAsync(int id)
        {
            return await GetAsync<Credits>(new Uri(movieServerUrl, $"3/movie/{id}/credits?api_key=b535fb9162267b5f833139385c3a2131&language=en-US"));
        }
        //Request for the cast of the series
        public async Task<Credits> GetSeriesCreditsAsync(int id)
        {
            return await GetAsync<Credits>(new Uri(movieServerUrl, $"3/series/{id}/credits?api_key=b535fb9162267b5f833139385c3a2131&language=en-US"));
        }
        //Request for the trending movies in the given time-period day-or week
        public async Task<MovieGroup> GetTrendingMovie(string time)
        {
            return await GetAsync<MovieGroup>(new Uri(movieServerUrl, $"3/trending/movie/{time}?api_key=b535fb9162267b5f833139385c3a2131&language=en-US"));
        }
        //Request for trending series in the given time period day-or week
        public async Task<SeriesGroup> GetTrendingSeries(string time)
        {
            return await GetAsync<SeriesGroup>(new Uri(movieServerUrl, $"3/trending/tv/{time}?api_key=b535fb9162267b5f833139385c3a2131&language=en-US"));
        }
        //Request for the series in which the given person participated
        public async Task<Credits> GetSeriesCredits(int personId)
        {
            return await GetAsync<Credits>(new Uri(movieServerUrl, $"3/person/{personId}/tv_credits?api_key=b535fb9162267b5f833139385c3a2131&language=en-US"));
        }
        //Request for movies in which the given person participated
        public async Task<Credits> GetMovieCredits(int personId)
        {
            return await GetAsync<Credits>(new Uri(movieServerUrl, $"3/person/{personId}/movie_credits?api_key=b535fb9162267b5f833139385c3a2131&language=en-US"));
        }
        //Get available genres 
        public async Task<Genres> GetGenres(string media){
            return await GetAsync<Genres>(new Uri(movieServerUrl, $"3/genre/{media}/list?api_key=b535fb9162267b5f833139385c3a2131&language=en-US"));
        }
      
    }   
}
