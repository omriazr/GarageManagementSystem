namespace Ex03.GarageLogic
{
    public abstract class Truck : Vehicle
    {
        private const int k_NumberOfWheelsTruck = 16;
        private const int k_MaxAirPressure = 28;
        private bool m_HazardousMaterials;
        private float m_CargoCapacity;

        public Truck(string i_LicenseNumber, string i_ModelName, Engine i_Engine)
            : base(i_LicenseNumber, i_ModelName, i_Engine, k_NumberOfWheelsTruck)
        {
        }

        public override void SetWheelsOfVehicle(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            initWheelsList(i_ManufacturerName, i_CurrentAirPressure, k_MaxAirPressure, k_NumberOfWheelsTruck);
        }

        public float CargoCapacity
        {
            get
            {
                return m_CargoCapacity;
            }

            set
            {
                m_CargoCapacity = value;
            }
        }

        public bool IsCarryHazardousMaterial
        {
            get
            {
                return m_HazardousMaterials;
            }

            set
            {
                m_HazardousMaterials = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"{0} Cargo capacity: {1}, Carrying Hazardous materials:{2}",
                base.ToString(), 
                m_CargoCapacity, 
                m_HazardousMaterials);
        }
    }
}
