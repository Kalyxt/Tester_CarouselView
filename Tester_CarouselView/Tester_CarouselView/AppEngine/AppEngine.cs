using System;
using System.Collections.Generic;
using System.Text;

namespace Tester_CarouselView.AppEngine
{
    /// <summary>
    /// Main class of the program, contains all important classes and data.
    /// </summary>
    public class AppEngine
    {

        public AppEngine()
        {
            prp_CategoryFeatures = new AppEngineClasses.CategoryFeatures(this);

            prp_StockCardFeatures = new AppEngineClasses.StockCardFeatures(this);

            // Load data of classes.
            Load();
        }

        #region PROPERTIES
        private AppEngineClasses.CategoryFeatures prp_CategoryFeatures;
        /// <summary>
        /// Main class for work with categories.
        /// </summary>
        public AppEngineClasses.CategoryFeatures CategoryFeatures
        {
            get
            {
                return prp_CategoryFeatures;
            }
        }

        private AppEngineClasses.StockCardFeatures prp_StockCardFeatures;
        /// <summary>
        /// Main class for work with stockcards.
        /// </summary>
        public AppEngineClasses.StockCardFeatures StockCardFeatures
        {
            get
            {
                return prp_StockCardFeatures;
            }
        }

        #endregion


        #region PRIVATE METHODS

        /// <summary>
        /// Calls load methods of data classes.
        /// </summary>
        private void Load()
        {
            // Load categories
            CategoryFeatures.Load();

            // Load stockcards
            StockCardFeatures.Load();

            // Load StockCards to each Category.
            Load_CategoryContent();
        }

        // Load StockCards to each Category.
        private void Load_CategoryContent()
        {
            try
            {
                foreach(Tester_CarouselView.AppEngine.AppEngineClasses.cls_Category e_Category in this.CategoryFeatures.Items)
                {
                    e_Category.Items = e_Category.GetStockCards();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

    }
}
