using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tester_CarouselView.UI.StockPages.StockCard
{
    /// <summary>
    /// Page with the items (StockCards) in selected category.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockCardPage : ContentPage, IDisposable
    {

        #region FIELDS

        Tester_CarouselView.UI.StockViewModels.StockCard.StockCardViewModel _StockCardViewModel;

        private Tester_CarouselView.AppEngine.AppEngine _AppEngine;

        #endregion

        public StockCardPage(Tester_CarouselView.AppEngine.AppEngine u_AppEngine)
        {
            InitializeComponent();
        }






        #region IDisposable

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                try
                {
                    if (disposing)
                    {
                        this._StockCardViewModel.Dispose();

                    }

                    // Odmapovať eventy
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}