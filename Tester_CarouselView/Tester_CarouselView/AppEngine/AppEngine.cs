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

        }


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




    }
}
