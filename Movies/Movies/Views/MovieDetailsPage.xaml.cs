using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Movies.Views
{
    public partial class MovieDetailsPage : ContentPage
    {
        const uint PosterAnimationTime = 600;
        const double BackdropTargetOpacity = 0.7;
        double _width;
        double _height;

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
            BackdropMask.FadeTo(BackdropTargetOpacity, 5 * PosterAnimationTime);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != _width || height != _height)
            {
                _width = width;
                _height = height;

                if (width > height)
                {
                    MainContainer.RowDefinitions.Clear();
                    MainContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
                    MainContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });

                    MainContainer.Children.Remove(DetailsContainer);
                    MainContainer.Children.Add(DetailsContainer, 1, 0);

                    DetailsContainer.Margin = new Thickness(0, 0, 25, 25);
                    Grid.SetRowSpan(BackdropImage, 1);
                    Grid.SetRowSpan(BackdropMask, 1);
                    Grid.SetColumnSpan(BackdropImage, 2);
                    Grid.SetColumnSpan(BackdropMask, 2);
                }
                else
                {
                    if (MainContainer.RowDefinitions.Count > 0)
                    {
                        return;
                    }

                    MainContainer.ColumnDefinitions.Clear();
                    MainContainer.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });
                    MainContainer.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });

                    MainContainer.Children.Remove(DetailsContainer);
                    MainContainer.Children.Add(DetailsContainer, 0, 1);

                    DetailsContainer.Margin = new Thickness(10, 30, 10, 10);
                    Grid.SetRowSpan(BackdropImage, 2);
                    Grid.SetRowSpan(BackdropMask, 2);
                    Grid.SetColumnSpan(BackdropImage, 1);
                    Grid.SetColumnSpan(BackdropMask, 1);
                }
            }
        }
    }
}

