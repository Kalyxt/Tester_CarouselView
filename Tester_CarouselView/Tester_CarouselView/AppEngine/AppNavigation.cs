using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Tester_CarouselView.AppEngine
{
    public class AppNavigation : IDisposable
    {

        #region  DECLARATION   

        const string CONST_ClassName = "AppNavigation";

        /// <summary>
        /// Reprezentuje číselné označenie stránok (pages) v aplikácii.
        /// </summary>
        public enum enm_Tester_PageNumbers : int
        {
            None = 0,

            Stock_Categories = 0,

            Stock_StockCards = 1

        }

        /// <summary>
        /// Reprezentuje číselné označenie stránok (pages) v TabbedPage (Stoly, skupiny, atd.). 
        /// </summary>
        public enum enm_Stock_TabbedPageNumbers : int
        {

            Stock_Categories = 0,

            Stock_StockCards = 1,

        }

        #endregion

        #region PROPERTIES


        private INavigation prp_Navigation;
        /// <summary>
        /// Systémové rozhranie pre prácu so stránkami - navigácia a akoky medzi stránkami (pages).
        /// </summary>
        public INavigation Navigation
        {
            get
            {
                return prp_Navigation;
            }
            set
            {
                prp_Navigation = value;
            }
        }

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

        private enm_Tester_PageNumbers prp_NavigationPage;
        /// <summary>
        /// Aktuálna NavigationPage aplikácie.
        /// </summary>
        public enm_Tester_PageNumbers NavigationPage
        {
            get
            {
                return prp_NavigationPage;
            }

            set
            {
                prp_NavigationPage = value;
            }
        }

        private Xamarin.Forms.TabbedPage prp_TabbedPage;
        /// <summary>
        /// Aktuálna TabbedPage aplikácie.
        /// </summary>
        public Xamarin.Forms.TabbedPage TabbedPage
        {
            get
            {
                return prp_TabbedPage;
            }

            set
            {
                prp_TabbedPage = value;
            }
        }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Konštruktor.
        /// </summary>
        public AppNavigation(AppEngine u_AppEngine)
        {

            try
            {

                prp_AppEngine = u_AppEngine;

            }
            catch (Exception ex)
            {


            }

        }



        #endregion

        #region METHODS - PUBLIC


       

        /// <summary>
        /// Presunie aktívnu stránku na predchádzajúcu stránku (potrebné volať cez await).
        /// </summary>
        public System.Threading.Tasks.Task GoBack(bool u_Animated = true)
        {
            return System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await this.Navigation.PopAsync(animated: u_Animated);
                    });
                }
                catch (Exception ex)
                {

                }
            });
        }

        /// <summary>
        /// Zmena page v NavigationStack-u.
        /// </summary>
        /// <returns></returns>
        public System.Threading.Tasks.Task GoPage(enm_Tester_PageNumbers u_Tester_PageNumber, bool u_Animation = true)
        {
            return System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        switch (u_Tester_PageNumber)
                        {

                            case enm_Tester_PageNumbers.Stock_Categories:

                                // Hlavná stránka pre čašníka
                                if (TabbedPage == null)
                                {
                                    // Štandartné spustenie, prvý krát
                                    TabbedPage = new Tester_CarouselView.UI.NavigationPages.StockTabbedPage(this.AppEngine);
                                }

                                this.Navigation.PushAsync(TabbedPage);

                                break;

                            // Stockcards
                            case enm_Tester_PageNumbers.Stock_StockCards:

                                TabbedPage.CurrentPage = TabbedPage.Children[(int)enm_Stock_TabbedPageNumbers.Stock_StockCards];

                                break;


                        }
                    });

                }
                catch (Exception ex)
                {

                }
            });
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
