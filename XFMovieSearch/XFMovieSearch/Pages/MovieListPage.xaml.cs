using MovieSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFMovieSearch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieListPage : ContentPage
    {
        private MovieListViewModel _viewModel;

        public MovieListPage(MovieListViewModel viewModel)
        {
            this._viewModel = viewModel;
            this._viewModel.SetNavigation(this.Navigation);
            this.BindingContext = this._viewModel;
            InitializeComponent();
        }

        public MovieListViewModel ViewModel
        {
            get => this._viewModel;
        }
    }
}