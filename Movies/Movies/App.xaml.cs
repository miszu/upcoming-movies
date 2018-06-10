using Prism.Unity;
using Movies.Views;

using Movies.Interfaces;
using Movies.Services;
using Prism;
using Prism.Ioc;

namespace Movies
{
    public partial class App : PrismApplication
    {
        public App() : base(null) { }

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"{nameof(MoviesNavigationPage)}/{nameof(UpcomingMoviesPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IMovieRepository, MovieRepository>();
            containerRegistry.RegisterForNavigation<MoviesNavigationPage>();
            containerRegistry.RegisterForNavigation<UpcomingMoviesPage>();
            containerRegistry.RegisterForNavigation<MovieDetailsPage>();
        }
    }
}