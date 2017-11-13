using Prism.Mvvm;
using System.Collections.ObjectModel;
using Prism.Navigation;
using Xamarin.Forms;
using Movies.Utilities;

namespace Movies.ViewModels
{
    public class UpcomingMoviesPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        ObservableCollection<string> _upcomingMovies;
        public ObservableCollection<string> UpcomingMovies
        {
            get
            {
                return _upcomingMovies;
            }
            set
            {
                SetProperty(ref _upcomingMovies, value);
            }
        }

        public Command<string> MovieSelectedCommand { get; set; }

        public UpcomingMoviesPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SetUpMovieDetailsNavigation();
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (UpcomingMovies == null)
            {
                // TODO: move to service
                var sampleMovies = new[] { "Pulp Fiction", "Inspector Gadget", "Downsizing" };
                UpcomingMovies = new ObservableCollection<string>(sampleMovies);
            }
        }

        private void SetUpMovieDetailsNavigation()
        {
            MovieSelectedCommand = new Command<string>(async (movie) =>
            {
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add(NavigationParametersKeys.SelectedMovie.ToString(), movie);

                await _navigationService.NavigateAsync("MovieDetailsPage", navigationParameters); 
            });
        }
    }
}
