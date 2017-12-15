using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSearch;
using Xamarin.Forms;
using System.Windows.Input;

namespace XFMovieSearch.ViewModels
{
    class TopRatedViewModel : MovieListViewModel
    {
        private bool _isRefreshing = false;

        public TopRatedViewModel(IMovieApi api)
        {
            this._movies = new List<Movie>();
            this._api = api;
        }

        public async Task GetTopRated()
        {
            this.Movies = await _api.GetTopRatedMovies();
            LoadMoreInfo();
        }

        public string Title
        {
            get => "Top Rated";
        }

        public bool IsRefreshing
        {
            get => this._isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }


        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    await GetTopRated();
                    IsRefreshing = false;
                });
            }
        }
    }
}
