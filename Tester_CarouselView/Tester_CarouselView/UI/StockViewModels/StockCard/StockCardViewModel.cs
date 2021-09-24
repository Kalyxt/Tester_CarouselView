using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Tester_CarouselView.UI.StockViewModels.StockCard
{
    public class StockCardViewModel : Tester_CarouselView.UI.StockViewModels.BaseViewModel, IDisposable
    {
        #region COMMANDS
        public ICommand BackCommand { get; private set; }

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Const.
        /// </summary>
        /// <param name="u_Page"></param>
        /// <param name="u_AppEngine"></param>
        public StockCardViewModel(Xamarin.Forms.ContentPage u_Page, Tester_CarouselView.AppEngine.AppEngine u_AppEngine) : base(u_AppEngine)
        {
            try
            {
                _Page = u_Page;


                // Prepare commands
                InitializeCommands();


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

        private ObservableCollection<Tester_CarouselView.AppEngine.AppEngineClasses.cls_StockCard> prp_StockCard_Items;
        /// <summary>
        /// Stockcard list.
        /// </summary>
        public ObservableCollection<Tester_CarouselView.AppEngine.AppEngineClasses.cls_StockCard> StockCard_Items
        {
            get
            {
                return prp_StockCard_Items;
            }
            set
            {
                prp_StockCard_Items = value;
                OnPropertyChanged("StockCard_Items");
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
