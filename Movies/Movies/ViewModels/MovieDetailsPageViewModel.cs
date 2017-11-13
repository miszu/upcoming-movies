using Movies.Utilities;
using Prism.Mvvm;
using Prism.Navigation;

namespace Movies.ViewModels
{
    public class MovieDetailsPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;

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
            var selectedMovie = parameters[NavigationParametersKeys.SelectedMovie.ToString()] as string;
            if (selectedMovie != null)
            {
                Title = selectedMovie;
            }
        }
    }
}
