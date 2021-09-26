using System;

namespace Ex03.GarageLogic
{
    public class CreateVichles
    {
        public static Vehicle CreateVehicle(eTypeOfVehicles i_TypeOfVehicle, string i_LicenceNumber, string i_ModelNumber)
        {
            Vehicle newVehicle = null;
            switch (i_TypeOfVehicle)
            {
                case eTypeOfVehicles.FuelMotorcycle:
                    newVehicle = new FuelMotorcycle(i_LicenceNumber, i_ModelNumber);
                    break;
                case eTypeOfVehicles.ElectricMotorcycle:
                    newVehicle = new ElectricMotorcycle(i_LicenceNumber, i_ModelNumber);
                    break;
                case eTypeOfVehicles.FuelCar:
                    newVehicle = new FuelCar(i_LicenceNumber, i_ModelNumber);
                    break;
                case eTypeOfVehicles.ElecticCar:
                    newVehicle = new ElectirCar(i_LicenceNumber, i_ModelNumber);
                    break;

                case eTypeOfVehicles.FuelTruck:
                    newVehicle = new FuelTruck(i_LicenceNumber, i_ModelNumber);
                    break;
            }

            return newVehicle;
        }

        public static void VehicleWheelsProperty(Vehicle i_Vehicle, string i_ManufacturerName, float i_CurrentAirPressure)
        {
            i_Vehicle.SetWheelsOfVehicle(i_ManufacturerName, i_CurrentAirPressure);
        }

        public static void VehicleEnergyProperty(Vehicle i_Vehicle, float i_CurrentPercentEnergy)
        {
            i_Vehicle.Engine.SetPercentAndFillEnergy(i_CurrentPercentEnergy);
        }

        public static void CarPropertise(Vehicle i_Car, Car.eNumberOfDoors i_NumberOfDoors, Car.eCarColor i_CarColor)
        {
            Car car = i_Car as Car;

            if (car != null)
            {
                car.NumberOfDoors = i_NumberOfDoors;
                car.CarColor = i_CarColor;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public static void MotorcyclePropertise(Vehicle i_Motorcycle, int i_EngineVolume, Motorcycle.eTypeOfLicense licenseType)
        {
            Motorcycle motorcycle = i_Motorcycle as Motorcycle;
            if (motorcycle != null)
            {
                motorcycle.EngineVolume = i_EngineVolume;
                motorcycle.LicenseType = licenseType;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public static void TruckPropertise(Vehicle i_Truck, float i_CargoCapacity, bool i_IsHazardousMaterial)
        {
            Truck truck = i_Truck as FuelTruck;

            if (truck != null)
            {
                truck.IsCarryHazardousMaterial = i_IsHazardousMaterial;
                truck.CargoCapacity = i_CargoCapacity;
            }
        }
    }
}
