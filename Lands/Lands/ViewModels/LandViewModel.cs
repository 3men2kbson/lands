namespace Lands.ViewModels
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LandViewModel
    {
        #region Properties
        public Country Land { get; set; }
        #endregion

        #region Constructors
        public LandViewModel(Country country)
        {
            this.Land = country;
        }  
        #endregion
    }
}
