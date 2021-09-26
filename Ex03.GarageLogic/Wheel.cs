namespace Ex03.GarageLogic
{
    public sealed class Wheel
    {
        private readonly float r_MaxAirPressure;
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        
        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            r_MaxAirPressure = i_MaxAirPressure;
            CurrentAirPressure = i_CurrentAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }

            set
            {
                m_ManufacturerName = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                if (value <= r_MaxAirPressure && value >= 0)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(null, 0, r_MaxAirPressure);
                }
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public void AirInflation(float i_AmountOfAirToAdd)
        {
            if ((m_CurrentAirPressure + i_AmountOfAirToAdd) > r_MaxAirPressure || (i_AmountOfAirToAdd < 0))
            {
                throw new ValueOutOfRangeException(null, r_MaxAirPressure - m_CurrentAirPressure, 0);
            }
            else
            {
                m_CurrentAirPressure += i_AmountOfAirToAdd;
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"Manufacturer Name :{0} , Current Air Pressure: {1}",
                ManufacturerName, 
                CurrentAirPressure);
        }
    }
}