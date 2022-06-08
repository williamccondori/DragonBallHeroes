using DragonBallHeroes.Models;
using DragonBallHeroes.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DragonBallHeroes.ViewModels
{
    public class HeroViewModel : BaseViewModel
    {
        private List<Hero> _heroes;

        #region CONSTRUCTOR 
        public HeroViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Task.Run(Show);
        }
        #endregion

        #region OBJECTS
        public List<Hero> Heroes
        {
            get { return _heroes; }
            set { SetValue(ref _heroes, value); }
        }
        #endregion



        public async Task Show()
        {
            var heroService = new HeroService();
            Heroes = await heroService.GetAll();
        }
    }
}
