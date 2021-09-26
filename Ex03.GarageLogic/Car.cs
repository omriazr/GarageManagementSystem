namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private const int k_NumberOfWheelsCar = 4;
        private const int k_MaxAirPressure = 32;
        protected eNumberOfDoors m_NumberOfDoors;
        protected eCarColor m_CarColor;

        public Car(string i_LicenseNumber, string i_ModelName, Engine i_Engine)
            : base(i_LicenseNumber, i_ModelName, i_Engine, k_NumberOfWheelsCar)
        {
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }

            set
            {
                m_NumberOfDoors = value;
            }
        }

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = value;
            }
        }

        public override void SetWheelsOfVehicle(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            initWheelsList(i_ManufacturerName, i_CurrentAirPressure, k_MaxAirPressure, k_NumberOfWheelsCar);
        }

        public override string ToString()
        {
            return string.Format(
                @"{0}
Number of doors: {1}, Car color is: {2}",
        base.ToString(),
        m_NumberOfDoors,
        m_CarColor);
        }

        public enum eNumberOfDoors
        {
            Two,
            Three,
            Four,
            Five
        }

        public enum eCarColor
        {
            Black,
            White,
            Red,
            Silver
        }
    }
}
