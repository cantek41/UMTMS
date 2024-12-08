namespace Core.Abstract.Enum
{
    public enum EnumUNIT
    {
        Kg,
        Amper,
        Kg_cm,
        Volt,
        Bar,
        Lt,
        Hz,
        cos,
        ohm,
        kW,
        rpm,
        centigrade
    }

    public enum StreamFeedEnum
    {
        LO,
        FO,
        HFO,
        DIESEL,
        WATER,
        ELECTRIC,
        AIR
    }

    public enum EnumBehaviourType
    {
        ACTUATOR,
        INDICATOR
    }
    public enum EnumCompanentType
    {

        DOOR,
        COLORDISPLAY,
        TEXTDISPLAY,
        ANALOGDISPLAY,
        VALVE,
        POT,
        BUTTON,
        SELECTOR,
        SWITCH,

    }
    public enum EnumSwitch
    {
        MASTER,
        SLAVE
    }


    public enum EnumCompanentStatus
    {
        ON =1,
        OFF = 0
    }
    public enum EnumCompanentActionStatus
    {
        REMOVE =1,
        INSTALL = 0
    }

    public enum EnumUnit
    {
        PRESSURE,
        TEMPERATURE,
        FLOWRATE,
        VELOCITY,
        VISCOSITY,
        VOLTAGE,
        CURRENT,
        RESISTANCE,
        STATUS, 
        FREQUENCY,
        LEVEL
    }
       public enum EnumSystemData
        {
            LOData,
            FOData,
            JWData,
            CCoolWaterData,
            AirData,
            ElectricData,
            SteeringData,
            BoilerSystem
        }

        public enum EnumXYX
        {
            X,
            Y,
            Z
        }

}