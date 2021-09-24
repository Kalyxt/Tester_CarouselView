using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tester_CarouselView.AppEngine.AppEngineClasses
{
    /// <summary>
    /// Category of items in stock.
    /// </summary>
    public class cls_Category : IDisposable, INotifyPropertyChanged
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="u_AppEngine"></param>
        public cls_Category(AppEngine u_AppEngine)
        {
            prp_AppEngine = u_AppEngine;
        }

        #region PROPERTIES

        private AppEngine prp_AppEngine;

        public AppEngine AppEngine
        {
            get
            {
                return prp_AppEngine;
            }
        }

        /// <summary>Name of the category.</summary>
        public string Name { get; set; }

        private System.Collections.ObjectModel.ObservableCollection<cls_StockCard> prp_Items;
        ///// <summary>
        ///// List of the items of category.
        ///// </summary>
        public System.Collections.ObjectModel.ObservableCollection<cls_StockCard> Items
        {
            get
            {
                return prp_Items;
            }
            set
            {
                prp_Items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        #endregion

        #region EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            try
            {
                var changed = PropertyChanged;
                if (changed == null)
                    return;

                changed(this, new PropertyChangedEventArgs(name));
            }
            catch
            {

            }
        }

        #endregion

        #region IDisposable

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                try
                {
                    if (prp_Items != null)
                    {
                        prp_Items.Clear();
                        prp_Items = null;
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
