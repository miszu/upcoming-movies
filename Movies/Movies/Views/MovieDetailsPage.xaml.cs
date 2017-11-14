using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Movies.Views
{
    public partial class MovieDetailsPage : ContentPage
    {
        private const uint PosterAnimationTime = 600;
        private const double BackdropTargetOpacity = 0.7;

        public MovieDetailsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await BeginOpacityAnimations();
        }

        private async Task BeginOpacityAnimations()
        {
            await PosterImage.FadeTo(1, PosterAnimationTime);
            DetailsContainer.FadeTo(1, 2 * PosterAnimationTime);
            IconDetailsContainer.FadeTo(1, 2 * PosterAnimationTime);
            BackdropMask.FadeTo(BackdropTargetOpacity, 5 * PosterAnimationTime);
        }

        private void BeginTranslationAnimations()
        {
            // TODO
        }
    }
}

