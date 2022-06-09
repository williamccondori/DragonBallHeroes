using DragonBallHeroes.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DragonBallHeroes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeroView : ContentPage
    {
        private readonly HeroViewModel _viewModel;

        public HeroView()
        {
            _viewModel = new HeroViewModel(Navigation);
            BindingContext = _viewModel;
            InitializeComponent();
        }

        private async void CoverFlowView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            await _viewModel.DisplaceCardView(sender, e);
        }
    }
}