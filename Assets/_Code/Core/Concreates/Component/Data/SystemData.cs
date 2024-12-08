using System;

namespace Core.Concreates.Component.Data
{

    ///<summary>
    /// 50C-100C
    ///</summary>
    public class SystemData
    {
        protected readonly float StartViscosity;
        protected readonly float EndViscosity;
        public readonly float Densty;
        public readonly float hu;

        public readonly SystemData DefaultData;



        // protected ComponentData(float StartViscosity, float EndViscosity, float Densty,float hu){
        //     this.Densty = Densty;
        //     this.StartViscosity = StartViscosity;
        //     this.EndViscosity = EndViscosity;
        //     this.hu = hu;

        // }
        public SystemData()
        {            
        }
        public SystemData(float Current,float Voltage,float FREQUENCY)
        {
            this.CURRENT = Current;
            this.FREQUENCY = FREQUENCY;
            this.VOLTAGE= Voltage;
            DefaultData = this.Clone();
            
        }
        public SystemData(float Pressure, float Temperature, float FlowVelocity, float FlowRate)
        {
            this.Pressure = Pressure;
            this.Temperature = Temperature;
            this.FlowVelocity = FlowVelocity;
            this.FlowRate = FlowRate;
            DefaultData = this.Clone();

        }

          public SystemData(float Pressure, float Temperature, float FlowVelocity, float FlowRate,float level)
        {
            this.Pressure = Pressure;
            this.Temperature = Temperature;
            this.FlowVelocity = FlowVelocity;
            this.FlowRate = FlowRate;
            this.LEVEL = level;
            DefaultData = this.Clone();

        }


        public void SetDefault()
        {
            this.Pressure = DefaultData.Pressure;
            this.Temperature = DefaultData.Temperature;
            this.FlowVelocity = DefaultData.FlowVelocity;
            this.FlowRate = DefaultData.FlowRate;
            this.LEVEL = DefaultData.LEVEL;

        }
        public float FlowRate;
        public float FlowVelocity;
        public float Pressure;
        public float Temperature;
        public float VOLTAGE;
        public float CURRENT;
        public float FREQUENCY = 80;
        public float RESISTANCE;
        public float LEVEL;


        public float Viscosity()
        {
            return ((EndViscosity - StartViscosity) * (Temperature - 50) / 50) + StartViscosity;

        }

        public SystemData Clone()
        {
            return (SystemData)this.MemberwiseClone();
        }
    }

}