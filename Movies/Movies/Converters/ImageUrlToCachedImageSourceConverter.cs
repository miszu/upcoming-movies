using System;
using Xamarin.Forms;

namespace Movies.Converters
{
    public class ImageUrlToCachedImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var imagePath = value.ToString();
            return new UriImageSource { CachingEnabled = true, Uri = new Uri(imagePath) };
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
