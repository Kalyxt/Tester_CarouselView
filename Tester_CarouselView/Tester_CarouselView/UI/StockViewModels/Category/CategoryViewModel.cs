using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Tester_CarouselView.UI.StockViewModels.Category
{
    class CategoryViewModel : Tester_CarouselView.UI.StockViewModels.BaseViewModel, IDisposable
    {

        #region COMMANDS
        public ICommand BackCommand { get; private set; }

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Const
        /// </summary>
        /// <param name="u_Page"></param>
        /// <param name="u_AppEngine"></param>
        public CategoryViewModel(Xamarin.Forms.ContentPage u_Page, Tester_CarouselView.AppEngine.AppEngine u_AppEngine) : base(u_AppEngine)
        {
            try
            {
                _Page = u_Page;

                // MenuCategory items
                prp_MenuCategory_Items = this.AppEngine.CategoryFeatures.Items;

                // prepare commands
                InitializeCommands();

                this.AppEngine.CategoryFeatures.PropertyChanged += eh_MenuCategory_PropertyChanged;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region FIELDS

        Xamarin.Forms.ContentPage _Page;

        #endregion

        #region PROPERTIES

        private ObservableCollection<Tester_CarouselView.AppEngine.AppEngineClasses.cls_Category> prp_MenuCategory_Items;
        /// <summary>
        /// Category list.
        /// </summary>
        public ObservableCollection<Tester_CarouselView.AppEngine.AppEngineClasses.cls_Category> MenuCategory_Items
        {
            get
            {
                return prp_MenuCategory_Items;
            }
            set
            {
                prp_MenuCategory_Items = value;
                OnPropertyChanged("MenuCategory_Items");
            }
        }


        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Pop current page.
        /// </summary>
        public async Task GoBack()
        {
            try
            {
                this.IsRunning = true;
                await this._Page.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.IsRunning = false;
            }
        }

        #endregion

        #region PRIVATE METHODS
        void InitializeCommands()
        {

            BackCommand = new Command(async () => await GoBack());
        }

        #endregion

        #region EVENTS
        /// <summary>
        /// Event handler for updating category items from main object in AppEngine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eh_MenuCategory_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {

                prp_MenuCategory_Items = this.AppEngine.CategoryFeatures.Items;

                OnPropertyChanged("MenuCategory_Items");

                await Task.Delay(0);
            });
        }

        #endregion

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

                    }

                    // Remove event handlers
                    this.AppEngine.CategoryFeatures.PropertyChanged -= eh_MenuCategory_PropertyChanged;
                }
                catch (Exception)
                {
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
