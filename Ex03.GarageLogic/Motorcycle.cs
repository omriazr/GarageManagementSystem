namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private const int k_NumberOfWheelsMotorcycle = 2;
        private const int k_MaximumAirPressurePerWheel = 30;
        private int m_EngineVolume;
        protected eTypeOfLicense m_TypeOfLicense;

        public Motorcycle(string i_LicenseNumber, string i_ModelName, Engine i_Engine)
            : base(i_LicenseNumber, i_ModelName, i_Engine, k_NumberOfWheelsMotorcycle)
        {
        }

        public eTypeOfLicense LicenseType
        {
            get
            {
                return m_TypeOfLicense;
            }

            set
            {
                m_TypeOfLicense = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }

            set
            {
                m_EngineVolume = value;
            }
        }

        public override void SetWheelsOfVehicle(string i_ManufacturerName, float i_CurrentAirPressure)
        {
         initWheelsList(i_ManufacturerName, i_CurrentAirPressure, k_MaximumAirPressurePerWheel, k_NumberOfWheelsMotorcycle);
        }

        public override string ToString()
        {
            return string.Format(
                @"{0} Motorcycle license type: {1}, Engine volume: {2}",
                base.ToString(), 
                m_TypeOfLicense, 
                m_EngineVolume);
        }

        public enum eTypeOfLicense
        {
            A,
            AA,
            A1,
            B
        }
    }
}
