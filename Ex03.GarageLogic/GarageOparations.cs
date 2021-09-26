using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageOparation
    {
        private readonly Dictionary<string, Client> r_ClientDetails = new Dictionary<string, Client>();

        public void ChargeBattary(string i_LicenseNumber, float i_TimeToCharge)
        {
            const string electric = "Electric";

            if (!r_ClientDetails.TryGetValue(i_LicenseNumber, out Client Client))
            {
                throw new Exception("Vehicle doesn't exists in garage");
            }

            if (Client.Vehicle.Engine.TypeOfEnergy == electric)
            {
                Client.Vehicle.Engine.FillEnergy(i_TimeToCharge, electric);
            }
            else
            {
                throw new Exception("Only electric");
            }
        }

        public void RefuelVehicle(string i_LicenseNum, float i_FuelAmount, eFuelType i_FuelType)
        {
            if (!r_ClientDetails.TryGetValue(i_LicenseNum, out Client Client))
            {
                throw new Exception("Vehicle doesn't exists in garage");
            }

            Client.Vehicle.Engine.FillEnergy(i_FuelAmount, i_FuelType.ToString());
        }

        public void FillWheelsToMaxAir(string i_LicenseNumber)
        {
            if (!r_ClientDetails.TryGetValue(i_LicenseNumber, out Client Client))
            {
                throw new Exception("Vehicle doesn't exists in garage");
            }

            Client.Vehicle.FillMaxWheelsAir();
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, Client.eVehicleStatusInGarage i_NewStatus)
        {
            if (!r_ClientDetails.TryGetValue(i_LicenseNumber, out Client Client))
            {
                throw new Exception("Vehicle doesn't exists in garage");
            }

            Client.VehicleStatus = i_NewStatus;
        }

        public string FullDetailsOfVehicle(string i_LicenseNumber)
        {
            if (!r_ClientDetails.TryGetValue(i_LicenseNumber, out Client Client))
            {
                throw new Exception("Vehicle doesn't exists in garage");
            }

            return Client.ToString();
        }

        public void InsertNewClient(Vehicle i_NewVehicle, string i_ClientName, string i_ClientPhoneNumber)
        {
            Client newClient = new Client(i_NewVehicle, i_ClientName, i_ClientPhoneNumber);
            r_ClientDetails.Add(newClient.Vehicle.LicenseNumber, newClient);
        }

        public Vehicle getCurretVehicle(string i_CurrentKeyNumber)
        {
            Client Client = null;
            if (!r_ClientDetails.TryGetValue(i_CurrentKeyNumber, out Client))
            {
                throw new Exception("Vehicle doesn't exists in garage");
            }

            return Client.Vehicle;
        }

        public string MsgOfAllVehicleInGarageFillterStatus(bool i_OrderByStatus)
        {
            string msgAllVehicles;

            msgAllVehicles = i_OrderByStatus ? listOfAllVehiclesByStatus() : msgOfAllVehicleInGarage();

            return msgAllVehicles;
        }

        private string msgOfAllVehicleInGarage()
        {
            StringBuilder vehicles = new StringBuilder(120);
            vehicles.AppendLine("Vehicles in garage");
            foreach (Client Client in r_ClientDetails.Values)
            {
                vehicles.AppendLine(Client.Vehicle.LicenseNumber);
            }

            return vehicles.ToString();
        }

        private string listOfAllVehiclesByStatus()
        {
            string newLine = Environment.NewLine;
            StringBuilder vehicleInRepair = new StringBuilder(string.Format(" Vehicles in repair : {0}", newLine), 60);
            StringBuilder vehicleDoneRepair = new StringBuilder(string.Format("{0}  Vehicles done repair  {0}", newLine), 60);
            StringBuilder vehiclePaid = new StringBuilder(string.Format("{0}  Vehicles paid  {0}", newLine), 60);

            foreach (Client Client in r_ClientDetails.Values)
            {
                if (Client.VehicleStatus == Client.eVehicleStatusInGarage.InRepair)
                {
                    vehicleInRepair.AppendLine(Client.Vehicle.LicenseNumber);
                }
                else if (Client.VehicleStatus == Client.eVehicleStatusInGarage.DoneRepair)
                {
                    vehicleDoneRepair.AppendLine(Client.Vehicle.LicenseNumber);
                }
                else
                {
                    vehiclePaid.AppendLine(Client.Vehicle.LicenseNumber);
                }
            }

            vehicleInRepair.AppendFormat("{0}{1}", vehicleDoneRepair, vehiclePaid);
            return vehicleInRepair.ToString();
        }

        public bool IsExistInGarage(string i_LicenceNum)
        {
            bool isInTheGarage = false;
            foreach (string licenceNumInGarage in r_ClientDetails.Keys)
            {
                if (licenceNumInGarage == i_LicenceNum)
                {
                    isInTheGarage = true;
                    break;
                }
            }

            return isInTheGarage;
        }
    }
}
