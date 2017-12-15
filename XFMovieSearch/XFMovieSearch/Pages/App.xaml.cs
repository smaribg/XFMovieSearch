using MovieSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XFMovieSearch.Pages;
using XFMovieSearch.ViewModels;

namespace XFMovieSearch
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var searchPage = new SearchPage(new SearchViewModel(new MovieApi()));
            var searchNavigationPage = new NavigationPage(searchPage);
            searchNavigationPage.Title = "Search";

            var topRated = new MovieListPage(new TopRatedViewModel(new MovieApi()));
            var topRatedNavigationPage = new NavigationPage(topRated);
            topRatedNavigationPage.Title = "Top rated";

            var popularPage = new MovieListPage(new PopularViewModel(new MovieApi()));
            var popularNavigationPage = new NavigationPage(popularPage);
            popularNavigationPage.Title = "Popular";

            var tabbedPage = new TabbedPage();
            tabbedPage.Appearing += (object sender, EventArgs e) =>
            {
                ((TopRatedViewModel)topRated.ViewModel).GetTopRated();
                ((PopularViewModel)popularPage.ViewModel).GetPopular();

            };
            tabbedPage.Children.Add(searchNavigationPage);
            tabbedPage.Children.Add(topRatedNavigationPage);
            tabbedPage.Children.Add(popularNavigationPage);

            MainPage = tabbedPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
