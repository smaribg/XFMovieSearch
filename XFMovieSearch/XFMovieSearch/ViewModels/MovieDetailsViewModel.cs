using MovieSearch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFMovieSearch.ViewModels
{
    class MovieDetailsViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;
        private Movie _movie;
        private IMovieApi _api;
        private string _infoString;

        public MovieDetailsViewModel(INavigation navigation, Movie movie, IMovieApi api)
        {
            this._navigation = navigation;
            this._movie = movie;
            this._api = api;
        }

        public Movie Movie
        {
            get => this._movie;
            set
            {
                _movie = value;
                OnPropertyChanged();
            }
        }

        public string InfoString
        {
            get => this._infoString;
            set
            {
                _infoString = value;
                OnPropertyChanged();
            }
        }

        private void UpdateInfoString()
        {
            this.InfoString = _movie.Runtime + " min | " + String.Join(",", this._movie.Genres);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void LoadInfo()
        {
            var extra = await _api.GetExtraInfo(this._movie.Id);
            this._movie.Runtime = extra.Runtime;
            this._movie.Tagline = extra.Tagline;
            UpdateInfoString();
        }
    }
}
