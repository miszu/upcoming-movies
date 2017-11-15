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
using System.Collections.Generic;

namespace Movies.ViewModels
{
    public class UpcomingMoviesPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        IMovieRepository _movieRepository;
        ObservableCollection<Movie> _upcomingMovies;
        int _nextPageOfMoviesToLoad = 1;
        public Action AnimateToast;
        public Action<bool> SwitchRefreshVisibility;

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

        string _toastText;
        public string ToastText
        {
            get
            {
                return _toastText;
            }
            set
            {
                SetProperty(ref _toastText, value);
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
                UpcomingMovies = new ObservableCollection<Movie>();
                await LoadMoreMovies();
            }
        }

        public async Task LoadMoreMovies()
        {
            IEnumerable<Movie> movies;
            try
            {
                movies = await _movieRepository.GetMovies(_nextPageOfMoviesToLoad);
            }
            catch (Exception)
            {
                movies = null;
            }

            SwitchRefreshVisibility?.Invoke(movies == null);

            if (movies == null)
            {
                ToastText = "No internet = no movies. Please turn it on.";
                AnimateToast?.Invoke();
                return;
            }

            _nextPageOfMoviesToLoad++;
            foreach (var newMovie in movies)
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