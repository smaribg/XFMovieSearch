using MovieSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFMovieSearch.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
        private MovieListViewModel _viewModel;

        public SearchPage(MovieListViewModel viewModel)
        {
            this._viewModel = viewModel;
            this._viewModel.SetNavigation(this.Navigation);
            this.BindingContext = this._viewModel;
            InitializeComponent();
        }
    }
}