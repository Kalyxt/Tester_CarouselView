using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Tester_CarouselView.AppEngine.AppEngineClasses
{
    /// <summary>
    /// Contains list of categories and functions to work and edit categories.
    /// </summary>
    public class CategoryFeatures : IDisposable, INotifyPropertyChanged
    {

        public CategoryFeatures(AppEngine u_AppEngine)
        {
            prp_AppEngine = u_AppEngine;
        }


        #region PROPERTIES

        private AppEngine prp_AppEngine;
        /// <summary>
        /// Hlavný objekt programu LUKUL - predstavuje bežiacu inštanciu programu.
        /// </summary>
        public AppEngine AppEngine
        {
            get
            {
                return prp_AppEngine;
            }
        }


        private ObservableCollection<cls_Category> prp_Items;
        /// <summary>
        /// Category list.
        /// </summary>
        public ObservableCollection<cls_Category> Items
        {
            get
            {
                return prp_Items;
            }
            set
            {
                prp_Items = value;
                OnPropertyChanged("Items");
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
