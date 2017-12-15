using System.Collections.Generic;
using MovieSearch;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;

namespace XFMovieSearch
{
    public class MovieListViewModel : INotifyPropertyChanged
    {
        protected INavigation _navigation;
        protected IMovieApi _api;
        protected List<Movie> _movies;
        protected Movie _selectedMovie;

        internal void SetNavigation(INavigation navigation)
        {
            this._navigation = navigation;
        }

        public List<Movie> Movies
        {
            get => this._movies;

            set
            {
                this._movies = value;
                OnPropertyChanged();
            }
        }

        public Movie SelectedMovie
        {
            get => this._selectedMovie;
            set
            {
                if(value != null)
                {
                    this._selectedMovie = value;
                    this._navigation.PushAsync(new MovieDetailsPage(this._selectedMovie, this._api), true);
                    this._selectedMovie = null;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LoadMoreInfo()
        {
            foreach(Movie m in this._movies)
            {
                if(m.Actors.Count == 0)
                    this.LoadCastAsync(m);
            }
        }

        private async void LoadCastAsync(Movie movie)
        {
            movie.Actors = await _api.GetActors(movie.Id);
        }
    }
}