using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieSearch
{
    public interface IMovieApi
    {
        Task<List<Movie>> GetMoviesByTitle(string title);
        Task<Movie> GetMovieByTitle(string title);
        Task<List<Movie>> GetTopRatedMovies();
        Task<List<Movie>> GetMostPopularMovies();
        Task<List<string>> GetActors(int id);
        Task<MovieExtraInfo> GetExtraInfo(int id);
    }
}
