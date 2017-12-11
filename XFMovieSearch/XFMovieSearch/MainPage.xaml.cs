using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MovieSearch;

namespace XFMovieSearch
{
    public partial class MainPage : ContentPage
    {
        IMovieApi api;
        public MainPage()
        {
            InitializeComponent();
            api = new MovieApi();
        }

        private async Task SearchButton_OnClickedAsync(object sender, EventArgs e)
        {
            var title = this.TitleEntry.Text;
            var movie = await api.GetMovieByTitle(title);
            this.MovieLable.Text = movie.Title;
        }
    }
}
