using Android.Views; 
using DragonBallHeroes.Droid.Themes.StatusBar;
using DragonBallHeroes.ViewModels;
using Plugin.CurrentActivity;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(StatusBarActivity))]
namespace DragonBallHeroes.Droid.Themes.StatusBar
{
    public class StatusBarActivity : IStatusBarViewModel
    {
        [Obsolete]
        public void SetStatusBarTransparent()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var currentWindow = GetCurrentWindow();
                currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility) SystemUiFlags.LayoutFullscreen;
                currentWindow.SetStatusBarColor(Android.Graphics.Color.Transparent);
            });
        }

        private Window GetCurrentWindow()
        {
            var window = CrossCurrentActivity.Current.Activity.Window;
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            return window;
        }
    }
}