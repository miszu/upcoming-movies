using Xamarin.Forms;

namespace Movies.Views
{
    public partial class UpcomingMoviesPage : ContentPage
    {
        // TODO: rethink background, maybe change it to next backdrops while scrolling?
        // TODO: remove white selection on iOS
        public UpcomingMoviesPage()
        {
            InitializeComponent();
            MoviesList.ItemSelected += (sender, e) => MoviesList.SelectedItem = null;
        }
    }
}

