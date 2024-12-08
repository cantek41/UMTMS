 using System;

namespace Core.Component.Data.Stream
{

    ///<summary>
    /// 50C-100C
    ///</summary>
    public abstract class IFluid
    {
        protected readonly float StartViscosity;
        protected readonly float EndViscosity;
        public readonly float Densty;
        public readonly float hu;

        protected IFluid(float StartViscosity, float EndViscosity, float Densty,float hu){
            this.Densty = Densty;
            this.StartViscosity = StartViscosity;
            this.EndViscosity = EndViscosity;
            this.hu = hu;

        }
        public float FlowRate { get; set; }
        public float FlowVelocity { get; set; }
        public float Pressure { get; set; }
        public float Temperature { get; set; }
        public float Viscosity(){
            return ((EndViscosity - StartViscosity) * (Temperature - 50) / 50) + StartViscosity;

        }

    }

}