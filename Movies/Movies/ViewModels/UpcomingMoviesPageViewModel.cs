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
using System.Linq;

namespace Movies.ViewModels
{
    public class UpcomingMoviesPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        IMovieRepository _movieRepository;
        int _nextPageOfMoviesToLoad = 1;
        public Action AnimateToast;
        public Action<bool> SwitchRefreshVisibility;

        string _previousSearchQuery = "";
        IEnumerable<Movie> _copyOfPreSearchMovies;
        ObservableCollection<Movie> _movieList;

        public ObservableCollection<Movie> MovieList
        {
            get
            {
                return _movieList;
            }
            set
            {
                SetProperty(ref _movieList, value);
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

        string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                SetProperty(ref _searchText, value);
            }
        }

        bool _isSearchingMode;
        public bool IsSearchingMode
        {
            get
            {
                return _isSearchingMode;
            }
            set
            {
                SetProperty(ref _isSearchingMode, value);
            }
        }

        public Command<Movie> MovieSelectedCommand { get; set; }
        public Command<string> SearchTextChangedCommand { get; set; }

        public UpcomingMoviesPageViewModel(INavigationService navigationService, IMovieRepository movieRepository)
        {
            _navigationService = navigationService;
            _movieRepository = movieRepository;

            SetUpCommands();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            if (MovieList == null)
            {
                MovieList = new ObservableCollection<Movie>();
                await LoadMoreMovies();
            }
        }

        public async Task LoadMoreMovies()
        {
            IEnumerable<Movie> movies;
            try
            {
                if (IsSearchingMode)
                {
                    movies = await _movieRepository.FindMovies(SearchText);
                }
                else
                {
                    movies = await _movieRepository.GetMovies(_nextPageOfMoviesToLoad);
                }
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

            if (IsSearchingMode)
            {
                MovieList.Clear();
            }
            else
            {
                _nextPageOfMoviesToLoad++;
            }

            foreach (var newMovie in movies)
            {
                MovieList.Add(newMovie);
            }
        }

        private void SetUpCommands()
        {
            MovieSelectedCommand = new Command<Movie>(async (movie) =>
            {
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add(NavigationParametersKeys.SelectedMovie.ToString(), movie);

                await _navigationService.NavigateAsync(nameof(MovieDetailsPage), navigationParameters); 
            });

            SearchTextChangedCommand = new Command<string>(async (newText) =>
            {
                if (string.IsNullOrWhiteSpace(newText) || _previousSearchQuery.Trim() == newText.Trim())
                {
                    return;
                }

                await LoadMoreMovies();
            });
        }

        public void SearchSelected()
        {
            SearchText = "";
            IsSearchingMode = !IsSearchingMode;

            if (IsSearchingMode)
            {
                _previousSearchQuery = "";
                _copyOfPreSearchMovies = MovieList.ToList();
                MovieList.Clear();
            }
            else
            {
                MovieList.Clear();
                foreach (var movieCopy in _copyOfPreSearchMovies)
                {
                    MovieList.Add(movieCopy);
                }
            }
        }
    }
}