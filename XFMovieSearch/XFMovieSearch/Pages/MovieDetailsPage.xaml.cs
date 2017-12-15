using MovieSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFMovieSearch.ViewModels;

namespace XFMovieSearch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailsPage : ContentPage
    {
        private MovieDetailsViewModel _viewModel;

        public MovieDetailsPage(Movie movie, IMovieApi api)
        {
            this._viewModel = new MovieDetailsViewModel(this.Navigation, movie, api);
            this.BindingContext = this._viewModel;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadInfo();
        }
    }
}