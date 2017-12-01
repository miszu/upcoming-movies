using System.Threading.Tasks;
using Movies.ViewModels;
using Xamarin.Forms;

namespace Movies.Views
{
    public partial class UpcomingMoviesPage : ContentPage
    {
        UpcomingMoviesPageViewModel _viewModel;
        uint _toastTime = 3 * 1000;

        public UpcomingMoviesPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as UpcomingMoviesPageViewModel;
            MoviesList.ItemSelected += (sender, e) => MoviesList.SelectedItem = null;
            MoviesList.ItemAppearing += MoviesList_ItemAppearing;
            _viewModel.AnimateToast = AnimateToast;
            _viewModel.SwitchRefreshVisibility = SwitchRefreshVisibility;

            ToolbarItems.Add(new ToolbarItem("Search", "ic_search_white", async () =>
            {
                _viewModel.SearchSelected();
            }));
        }

        async void MoviesList_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (_viewModel.IsSearchingMode == false && e.Item == _viewModel.MovieList[_viewModel.MovieList.Count - 1])
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
                if (ToolbarItems.Count == 2)
                {
                    return;
                }

                ToolbarItems.Add(new ToolbarItem("Refresh", "ic_refresh_white", async () =>
                {
                    await _viewModel.LoadMoreMovies();
                }));
            }
            else
            {
                if (ToolbarItems.Count == 1)
                {
                    return;
                }

                ToolbarItems.RemoveAt(1);
            }
        }
    }
}

