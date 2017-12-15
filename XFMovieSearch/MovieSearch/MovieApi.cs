using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;

namespace MovieSearch
{
    public class MovieApi : IMovieApi
    {
        private IApiMovieRequest _api;
        public MovieApi()
        {
            MovieDbFactory.RegisterSettings(new MovieDbSettings());
            _api = MovieDbFactory.Create<IApiMovieRequest>().Value;
        }

        public async Task<List<Movie>> GetTopRatedMovies()
        {
            ApiSearchResponse<MovieInfo> response = await _api.GetTopRatedAsync();
            return GetMoviesFromResponse(response);
        }

        public async Task<List<Movie>> GetMostPopularMovies()
        {
            ApiSearchResponse<MovieInfo> response = await _api.GetPopularAsync();
            return GetMoviesFromResponse(response);
        }

        public async Task<List<Movie>> GetMoviesByTitle(string title)
        {
            ApiSearchResponse<MovieInfo> response = await _api.SearchByTitleAsync(title);
            return GetMoviesFromResponse(response);
        }

        public async Task<Movie> GetMovieByTitle(string title)
        {
            ApiSearchResponse<MovieInfo> response = await _api.SearchByTitleAsync(title);
            return GetMovieFromResponse(response);
        }

        private List<Movie> GetMoviesFromResponse(ApiSearchResponse<MovieInfo> response)
        {
            List<Movie> movies;


            if (response.Results != null)
            {
                movies = response.Results.Select(x => new Movie
                {
                    Title = x.Title,
                    Year = x.ReleaseDate.Year,
                    ImageRemote = x.PosterPath,
                    BackdropRemote = x.BackdropPath,
                    Description = x.Overview,
                    Id = x.Id,
                    Genres = x.Genres.Select(y => y.Name).ToList(),
                    AverageVote = x.VoteAverage

                }).ToList();
                foreach (Movie m in movies)
                {
                    m.Actors = new List<string>(); ;
                    m.Runtime = 0;
                }

                return movies;
            }
            else
                return new List<Movie>();
        }

        private Movie GetMovieFromResponse(ApiSearchResponse<MovieInfo> response)
        {
            Movie movie;


            if (response.Results != null)
            {
                movie = response.Results.Select(x => new Movie
                {
                    Title = x.Title,
                    Year = x.ReleaseDate.Year,
                    ImageRemote = x.PosterPath,
                    BackdropRemote = x.BackdropPath,
                    Description = x.Overview,
                    Id = x.Id,
                    Genres = x.Genres.Select(y => y.Name).ToList(),
                    AverageVote = x.VoteAverage

                }).FirstOrDefault();
                movie.Actors = new List<string>();
                movie.Runtime = 0;

                return movie;
            }
            else
                return new Movie();
        }

        public async Task<List<string>> GetActors(int id)
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiQueryResponse<MovieCredit> response = await movieApi.GetCreditsAsync(id);
            if (response.Item == null)
            {
                return new List<string>();
            }
            return response.Item.CastMembers.Select(x => x.Name).Take(3).ToList();
        }

        public async Task<MovieExtraInfo> GetExtraInfo(int id)
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiQueryResponse<DM.MovieApi.MovieDb.Movies.Movie> response = await movieApi.FindByIdAsync(id);
            if (response.Item != null)
            {
                return new MovieExtraInfo
                {
                    Runtime = response.Item.Runtime,
                    Tagline = response.Item.Tagline
                };
            }
            return new MovieExtraInfo();

        }
    }
}
