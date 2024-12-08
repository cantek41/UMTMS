using System;


namespace Core.Component.Data.Stream
{
    ///<summary>
    /// Castrol CDX 30
    /// SAE30
    /// BN- 5-10
    /// 50C-100C
    /// StartViscosity,  EndViscosity,  Densty, hu
    /// 70 cSt 50C
    ///</summary>    
    public class LOil : IFluid
    {
        # region Singleton        

        private static LOil _instance;
        private LOil():base(70,11,0.89f,9200)
        {
            FlowRate = 320; // m3/h
            FlowVelocity =1.8f; // m2/h
            Pressure = 0.1f;
            
        }
        public static LOil Instance()
        {
            if (_instance == null) _instance = new LOil();
            return _instance;
        }
        # endregion


    }

}