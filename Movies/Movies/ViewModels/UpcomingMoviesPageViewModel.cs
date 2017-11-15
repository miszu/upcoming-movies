using Prism.Mvvm;
using System.Collections.ObjectModel;
using Prism.Navigation;
using Xamarin.Forms;
using Movies.Utilities;
using Movies.Interfaces;
using Movies.Models;
using Movies.Views;
using System;
using System.Threading.Tasks;

namespace Movies.ViewModels
{
    public class UpcomingMoviesPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        IMovieRepository _movieRepository;
        ObservableCollection<Movie> _upcomingMovies;
        int _nextPageOfMoviesToLoad = 1;

        public ObservableCollection<Movie> UpcomingMovies
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

        public Command<Movie> MovieSelectedCommand { get; set; }

        public UpcomingMoviesPageViewModel(INavigationService navigationService, IMovieRepository movieRepository)
        {
            _navigationService = navigationService;
            _movieRepository = movieRepository;

            SetUpMovieDetailsNavigation();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            if (UpcomingMovies == null)
            {
                var sampleMovies = await _movieRepository.GetMovies(_nextPageOfMoviesToLoad++);
                UpcomingMovies = new ObservableCollection<Movie>(sampleMovies);
            }
        }

        public async Task LoadMoreMovies()
        {
            var newMovies = await _movieRepository.GetMovies(_nextPageOfMoviesToLoad++);
            foreach (var newMovie in newMovies)
            {
                _upcomingMovies.Add(newMovie);
            }
        }

        private void SetUpMovieDetailsNavigation()
        {
            MovieSelectedCommand = new Command<Movie>(async (movie) =>
            {
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add(NavigationParametersKeys.SelectedMovie.ToString(), movie);

                await _navigationService.NavigateAsync(nameof(MovieDetailsPage), navigationParameters); 
            });
        }
    }
}