using Prism.Unity;
using Movies.Views;

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
            Container.RegisterTypeForNavigation<MoviesNavigationPage>();
            Container.RegisterTypeForNavigation<UpcomingMoviesPage>();
            Container.RegisterTypeForNavigation<MovieDetailsPage>();
        }
    }
}