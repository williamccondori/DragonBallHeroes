using SkiaSharp;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace DragonBallHeroes.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation;
        public event PropertyChangedEventHandler PropertyChanged;


        private ImageSource image;
        public ImageSource Image
        {
            get { return image; }
            set { image = value; }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;

            OnPropertyChanged(propertyName);

            return true;
        }

        protected void SetValue<T>(ref T backingFieled, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingFieled, value))
            {
                return;
            }

            backingFieled = value;

            OnPropertyChanged(propertyName);
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetProperty(ref _isBusy, value);
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        public static (string, string) GetPredominantColor(SKBitmap bitmap)
        {
            int redOne = 0;
            int greenOne = 0;
            int blueOne = 0;

            int totalOne = 0;
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height / 2; y++)
                {
                    SKColor color = bitmap.GetPixel(x, y);
                    redOne += color.Red;
                    greenOne += color.Green;
                    blueOne += color.Blue;
                    totalOne++;
                }
            }
            redOne /= totalOne;
            greenOne /= totalOne;
            blueOne /= totalOne;

            int redTwo = 0;
            int greenTwo = 0;
            int blueTwo = 0;

            int totalTwo = 0;
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width / 2; j++)
                {
                    SKColor color = bitmap.GetPixel(j, i);
                    redTwo += color.Red;
                    greenTwo += color.Green;
                    blueTwo += color.Blue;
                    totalTwo++;
                }
            }
            redTwo /= totalTwo;
            greenTwo /= totalTwo;
            blueTwo /= totalTwo;

            string colorOne = $"#{redOne:X2}{greenOne:X2}{blueOne:X2}";
            string colorTwo = $"#{redTwo:X2}{greenTwo:X2}{blueTwo:X2}";

            return (colorOne, colorTwo);
        }
    }
}
