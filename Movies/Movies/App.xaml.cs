using Prism.Unity;
using Microsoft.Practices.Unity;
using Movies.Views;
using Movies.Interfaces;
using Movies.Services;

namespace Movies
{
    public partial class App : PrismApplication
    {
        public App() : base(null) { }
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"{nameof(MoviesNavigationPage)}/{nameof(UpcomingMoviesPage)}"); 
        }

        protected override void RegisterTypes()
        {
            // TODO: move to class with registrations
            Container.RegisterType<IMovieRepository, MovieRepository>();

            Container.RegisterTypeForNavigation<MoviesNavigationPage>();
            Container.RegisterTypeForNavigation<UpcomingMoviesPage>();
            Container.RegisterTypeForNavigation<MovieDetailsPage>();
        }
    }
}