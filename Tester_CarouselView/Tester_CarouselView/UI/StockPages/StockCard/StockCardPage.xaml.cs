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

        Tester_CarouselView.UI.StockViewModels.StockCard.StockCardViewModel _StockCardViewModel = null;

        private Tester_CarouselView.AppEngine.AppEngine _AppEngine = null;

        #endregion

        public StockCardPage(Tester_CarouselView.AppEngine.AppEngine u_AppEngine)
        {
            InitializeComponent();

            _AppEngine = u_AppEngine;

            _StockCardViewModel = new StockViewModels.StockCard.StockCardViewModel(this,_AppEngine);

            this.BindingContext = _StockCardViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {

                // Set selected category
                Device.BeginInvokeOnMainThread(async () =>
                {
                    int tmp_CategoryIndex = _AppEngine.CategoryFeatures.Items.IndexOf(_AppEngine.CategoryFeatures.SelectedCategory);
                    if (tmp_CategoryIndex >= 0)
                    {
                        fro_CarouselView_Categories.IsScrollAnimated = false;
                        if (Device.RuntimePlatform == Device.Android)
                        {
                            fro_CarouselView_Categories.CurrentItem = _AppEngine.CategoryFeatures.Items[tmp_CategoryIndex];
                        }
                        else if (Device.RuntimePlatform == Device.iOS)
                        {
                            fro_CarouselView_Categories.Position = tmp_CategoryIndex;
                        }

                        _StockCardViewModel.OnPropertyChanged("ActiveCategoryName");
                    }

                    await Task.Delay(0);
                });

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void fro_CarouselView_Categories_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            try
            {

                if (fro_CarouselView_Categories.ItemsSource == null)
                {
                    return;
                }

                if (e.PreviousItem == null)
                {
                    return;
                }

                if (e.CurrentItem is Tester_CarouselView.AppEngine.AppEngineClasses.cls_Category)
                {
                    // Set new category
                    if (_AppEngine.CategoryFeatures.SelectedCategory != (Tester_CarouselView.AppEngine.AppEngineClasses.cls_Category)e.CurrentItem)
                    {
                        _AppEngine.CategoryFeatures.SetCategory((Tester_CarouselView.AppEngine.AppEngineClasses.cls_Category)e.CurrentItem);
                    }
                }

                _StockCardViewModel.OnPropertyChanged("ActiveCategoryName");

                
            }
            catch (Exception ex)
            {

            }
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