using MovieSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFMovieSearch.ViewModels
{
    class SearchViewModel : MovieListViewModel
    {
        public ICommand SearchCommand { protected set; get; }
        private string _searchText;
        private bool _isLoading;
        private bool _loadingIsEnabled;
        public SearchViewModel(IMovieApi api)
        {
            this._api = api;
            this.Movies = new List<Movie>();
            SearchCommand = new Command(async () =>
            {
                IsLoading = true;
                LoadingIsEnabled = true;
                this.Movies = await _api.GetMoviesByTitle(SearchText);
                LoadMoreInfo();
                IsLoading = false;
                LoadingIsEnabled = false;
            });
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if(value != null)
                    _searchText = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get => this._isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public bool LoadingIsEnabled
        {
            get => this._loadingIsEnabled;
            set
            {
                _loadingIsEnabled = value;
                OnPropertyChanged();
            }
        }
    }
}
