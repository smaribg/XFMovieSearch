using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MovieSearch
{
    public class Movie : INotifyPropertyChanged
    {
        private readonly string Url = "http://image.tmdb.org/t/p/original";
        private List<string> _actors;
        private string _actorString;
        private int _runTime;
        private string _tagLine;

        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public List<String> Genres  { get; set; }
        public double AverageVote { get; set; }
        public string ImageUrl { get => Url + ImageRemote; }
        public string BackdropUrl  { get => Url + BackdropRemote; }
        public string ImageRemote { get; set;  }
        public string BackdropRemote { get;  set; }
        public string Description { get; set; }

        public string TitleAndYearString
        {
            get => Title + " (" + Year + ")";
        }

        public List<string> Actors
        {
            get => _actors;
            set
            {
                _actors = value;
                ActorsString = String.Join(",", Actors);
            }
        }
        public string ActorsString
        {
            get => this._actorString;
            set
            {
                this._actorString = value;
                OnPropertyChanged();
            }
        }
        public int Runtime
        {
            get => this._runTime;
            set
            {
                this._runTime = value;
                OnPropertyChanged();
            }
        }

        public string Tagline
        {
            get => this._tagLine;
            set
            {
                this._tagLine = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
