using DragonBallHeroes.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DragonBallHeroes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeroView : ContentPage
    {
        public HeroView()
        {
            InitializeComponent();
            BindingContext = new HeroViewModel(Navigation);
        }
    }
}