using System;
using Xamarin.Forms;

namespace Movies.Views
{
    public partial class MovieDetailsPage : ContentPage
    {
        private const int PosterAnimationTime = 400;
        private const double BackdropTargetOpacity = 0.7;

        public MovieDetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BeginOpacityAnimations();
            BeginTranslationAnimations();
        }

        private void BeginOpacityAnimations()
        {
            PosterImage.FadeTo(1, PosterAnimationTime);
            DetailsContainer.FadeTo(1, (uint) (2 * PosterAnimationTime));
            BackdropMask.FadeTo(BackdropTargetOpacity, 5 * PosterAnimationTime);
        }

        private void BeginTranslationAnimations()
        {
            // TODO
        }
    }
}

