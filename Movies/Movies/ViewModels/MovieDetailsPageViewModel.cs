using Movies.Models;
using Movies.Utilities;
using Prism.Mvvm;
using Prism.Navigation;

namespace Movies.ViewModels
{
    public class MovieDetailsPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;

        Movie _movie;
        public Movie Movie
        {
            get
            {
                return _movie;
            }
            set
            {
                SetProperty(ref _movie, value);
            }
        }

        string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        public MovieDetailsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            var selectedMovie = parameters[NavigationParametersKeys.SelectedMovie.ToString()] as Movie;

            if (selectedMovie != null)
            {
                Movie = selectedMovie;
                Title = Movie.Name;

                if (Movie.ReleaseDate.HasValue)
                {
                    Title += $" ({Movie.ReleaseDate.Value.Year})";
                }
            }
        }
    }
}
