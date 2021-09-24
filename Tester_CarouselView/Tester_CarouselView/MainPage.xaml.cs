using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tester_CarouselView
{
    public partial class MainPage : ContentPage
    {
        private Tester_CarouselView.AppEngine.AppEngine _AppEngine;

        public MainPage(Tester_CarouselView.AppEngine.AppEngine u_AppEngine)
        {
            InitializeComponent();

            _AppEngine = u_AppEngine;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // Open TabbedPage

            this._AppEngine.AppNavigation.GoPage(Tester_CarouselView.AppEngine.AppNavigation.enm_Tester_PageNumbers.Stock_Categories);
        }
    }
}
