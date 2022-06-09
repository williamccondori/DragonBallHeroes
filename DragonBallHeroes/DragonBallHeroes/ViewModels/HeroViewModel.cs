using DragonBallHeroes.Models;
using DragonBallHeroes.Services;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DragonBallHeroes.ViewModels
{
    public class HeroViewModel : BaseViewModel
    {
        private List<Hero> _heroes;

        private int _indexSelected;

        private string _selectedColorOne;
        private string _selectedColorTwo;

        #region CONSTRUCTOR 
        public HeroViewModel(INavigation navigation)
        {
            Navigation = navigation;
            DependencyService.Get<IStatusBarViewModel>().SetStatusBarTransparent();
            Task.Run(ShowHeroes);
        }
        #endregion

        #region OBJECTS
        public List<Hero> Heroes
        {
            get { return _heroes; }
            set
            {
                SetValue(ref _heroes, value);
            }
        }
        public string SelectedColorOne
        {
            get { return _selectedColorOne; }
            set
            {
                SetValue(ref _selectedColorOne, value);
            }
        }

        public string SelectedColorTwo
        {
            get { return _selectedColorTwo; }
            set
            {
                SetValue(ref _selectedColorTwo, value);
            }
        }
        #endregion

        public async Task DisplaceCardView(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SelectedIndex"))
            {
                var index = ((PanCardView.CoverFlowView)sender).SelectedIndex;
                if (index != _indexSelected)
                {
                    _indexSelected = index;
                    await AssignColorsToBackgroundFromList(_indexSelected);
                }
            }
        }

        public async Task ShowHeroes()
        {
            var heroService = new HeroService();
            Heroes = await heroService.GetAll();
            await AssignColorsToBackgroundFromList(0);
        }

        private async Task AssignColorsToBackgroundFromList(int heroesListIndex)
        {
            try
            {
                string selectedImageUrl = Heroes[heroesListIndex].Icon;
                var (colorOne, colorTwo) = await GetColors(selectedImageUrl);
                SelectedColorOne = colorOne;
                SelectedColorTwo = colorTwo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task<(string, string)> GetColors(string imageUrl)
        {
            var httpClient = new HttpClient();
            using (Stream stream = await httpClient.GetStreamAsync(imageUrl))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    var bitmap = SKBitmap.Decode(memoryStream);
                    return GetPredominantColor(bitmap);
                }
            }
        }
    }
}
