using DragonBallHeroes.Views;
using Xamarin.Forms;

namespace DragonBallHeroes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new HeroView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
