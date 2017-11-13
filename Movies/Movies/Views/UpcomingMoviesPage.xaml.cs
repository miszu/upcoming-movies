using Xamarin.Forms;

namespace Movies.Views
{
    public partial class UpcomingMoviesPage : ContentPage
    {
        public UpcomingMoviesPage()
        {
            InitializeComponent();
            MoviesList.ItemSelected += (sender, e) => MoviesList.SelectedItem = null;
        }
    }
}

