using System.Threading.Tasks;
using Movies.ViewModels;
using Xamarin.Forms;

namespace Movies.Views
{
    public partial class UpcomingMoviesPage : ContentPage
    {
        UpcomingMoviesPageViewModel _viewModel;
        uint _toastTime = 2 * 1000;

        public UpcomingMoviesPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as UpcomingMoviesPageViewModel;
            MoviesList.ItemSelected += (sender, e) => MoviesList.SelectedItem = null;
            MoviesList.ItemAppearing += MoviesList_ItemAppearing;
            _viewModel.AnimateToast = AnimateToast;
            _viewModel.SwitchRefreshVisibility = SwitchRefreshVisibility;
        }

        async void MoviesList_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (e.Item == _viewModel.UpcomingMovies[_viewModel.UpcomingMovies.Count - 1])
            {
                await _viewModel.LoadMoreMovies();
            }
        }

        private void AnimateToast()
        {
            Toast.FadeTo(1, _toastTime).ContinueWith(async (_) => await Task.Delay((int) _toastTime)).ContinueWith((arg) => Toast.FadeTo(0, _toastTime));
        }

        private void SwitchRefreshVisibility(bool shouldRefreshBeVisible)
        {
            if (shouldRefreshBeVisible)
            {
                if (ToolbarItems.Count == 1)
                {
                    return;
                }

                ToolbarItems.Add(new ToolbarItem("Search", "ic_refresh_white", async () =>
                {
                    await _viewModel.LoadMoreMovies();
                }));
            }
            else
            {
                ToolbarItems.Clear();
            }
        }
    }
}

