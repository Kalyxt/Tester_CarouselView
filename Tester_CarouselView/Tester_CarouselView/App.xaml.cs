using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tester_CarouselView
{
    public partial class App : Application
    {

        Tester_CarouselView.AppEngine.AppEngine _AppEngine;

        public App()
        {
            InitializeComponent();

            _AppEngine = new AppEngine.AppEngine();

            Application.Current.MainPage = new NavigationPage(new Tester_CarouselView.MainPage(_AppEngine));

            this._AppEngine.AppNavigation.Navigation = this.MainPage.Navigation;

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
