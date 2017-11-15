using Movies.ViewModels;
using Xamarin.Forms;

namespace Movies.Views
{
    public partial class UpcomingMoviesPage : ContentPage
    {
        UpcomingMoviesPageViewModel _viewModel;

        // TODO: rethink background, maybe change it to next backdrops while scrolling?
        // TODO: remove white selection on iOS
        public UpcomingMoviesPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as UpcomingMoviesPageViewModel;
            MoviesList.ItemSelected += (sender, e) => MoviesList.SelectedItem = null;
            MoviesList.ItemAppearing += MoviesList_ItemAppearing;
        }

        async void MoviesList_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (e.Item == _viewModel.UpcomingMovies[_viewModel.UpcomingMovies.Count - 1])
            {
                await _viewModel.LoadMoreMovies();
            }
        }
    }
}

