using System;

namespace Core.Component.Data.Stream
{
    ///<summary>
    /// ExxonMobil VISCOSITY-TEMPERATURE chart
    /// RMK 700, d=1.010 at 15C
    /// 50C-100C
    ///</summary>    
    public class FuelOil : IFluid
    {
        # region Singleton        

        private static FuelOil _instance;
        private FuelOil():base(700,9,1.010f,9200)
        {
            
        }
        public static FuelOil Instance()
        {
            if (_instance == null) _instance = new FuelOil();
            return _instance;
        }
        # endregion


    }

}