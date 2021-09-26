namespace Ex03.GarageLogic
{
    public class Client
    {
        private readonly string r_OnwerName;
        private readonly string r_PhoneNumber;
        private readonly Vehicle r_Vehicle;
        private eVehicleStatusInGarage m_VehicleStatus = eVehicleStatusInGarage.InRepair;

        public Client(Vehicle m_Vehicle, string i_OnwerName, string i_PhoneNumber)
        {
            r_OnwerName = i_OnwerName;
            r_PhoneNumber = i_PhoneNumber;
            r_Vehicle = m_Vehicle;
        }

        public Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }
        }

        public eVehicleStatusInGarage VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public override string ToString()
        {
            string fullClientDetails = string.Format(
@"___Client Details___
Name: {0}
Phone number: {1}
Vehicle status: {2}

___Vehicle Details___
{3}",
                     r_OnwerName,
                    r_PhoneNumber, 
                    m_VehicleStatus, 
                    Vehicle.ToString());
            return fullClientDetails;
        }

        public enum eVehicleStatusInGarage
        {
            InRepair,
            DoneRepair,
            Paid
        }
    }
}
