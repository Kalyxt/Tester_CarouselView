﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tester_CarouselView.UI.StockPages.Category
{
    /// <summary>
    /// Page with the list of categories to choose from.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage, IDisposable
    {

        #region FIELDS

        Tester_CarouselView.UI.StockViewModels.Category.CategoryViewModel _CategoryViewModel;

        private Tester_CarouselView.AppEngine.AppEngine _AppEngine;

        #endregion

        public CategoryPage(Tester_CarouselView.AppEngine.AppEngine u_AppEngine)
        {
            InitializeComponent();

            _AppEngine = u_AppEngine;

            _CategoryViewModel = new StockViewModels.Category.CategoryViewModel(this, u_AppEngine);

            this.BindingContext = _CategoryViewModel;

            

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
                        this._CategoryViewModel.Dispose();
                        
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