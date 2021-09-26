using System;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class 
        GarageManagement
    {
        private const string k_MenuMessage =
@"
=========================================================================
Please choose one of the following and then press 'enter' 

1. Insert car to garage
2. List of vehicle's Licens number .  
3. New vehicle status
4. Fill untill Max wheel air to vehicle's
5. Refuel fuel vehicle
6. Charge electric vehicle
7. Full data for onwer and vehicle

========================================================================= ";
      
        private readonly GarageLogic.GarageOparation r_Garage;

        public GarageManagement()
        {
            r_Garage = new GarageLogic.GarageOparation();
        }

        public void OpenGarage()
        {
            const byte outOfChoiseRange = 200;
            bool logOut = false;
            eGarageAction actionToDo;
            while (!logOut)
            {
                Console.WriteLine(k_MenuMessage);
                actionToDo = (eGarageAction)(byte.TryParse(Console.ReadLine(), out byte userInputChoise) ? userInputChoise : outOfChoiseRange);
                Console.Clear();
                logOut = doActionInGarage(actionToDo);
            }
        }

        private bool doActionInGarage(eGarageAction i_TypeOfAction)
        {
            bool quit = false;
            switch (i_TypeOfAction)
            {
                case eGarageAction.InsertCarToGarage:
                    createNewClient();
                    break;
                case eGarageAction.ListOfVehicles:
                    printListOfVehicleInGarage();
                    break;
                case eGarageAction.NewVehicleStatus:
                    changeVehicleStatus();
                    break;
                case eGarageAction.FillWheelToMaxAir:
                    fillWheelsToMaximumAir();
                    break;
                case eGarageAction.RefuelFuelVehicle:
                    refuelFuelVehicle();
                    break;
                case eGarageAction.ChargeElectricVehicle:
                    chargeElectricVehicle();
                    break;
                case eGarageAction.InsertDataForOnwerAndVehicle:
                    fullDataForOnwerAndVehicle();
                    break;
                default:
                    Console.WriteLine("wrong input, please try again");
                    break;
            }

            return quit;
        }

        public string EnumChoises(Type i_Type)
        {
            string[] allEnumTypes = Enum.GetNames(i_Type);
            StringBuilder enumChoise = new StringBuilder(100);
            int index = 0;
            foreach (string vehicleType in allEnumTypes)
            {
                enumChoise.AppendFormat("{0}. {1}{2}", index++, vehicleType, Environment.NewLine);
            }

            return enumChoise.ToString();
        }

        private void getEnumChoise<T>(Type i_Type, out T o_Choise) where T : struct
        {
            T userChoise;
            while (!(Enum.TryParse(Console.ReadLine(), out userChoise) && Enum.IsDefined(i_Type, userChoise)))
            {
                Console.WriteLine("Invalid input, please try again.");
            }

            o_Choise = userChoise;
        }


        private Vehicle createNewVehicle(string i_licenceNum, out eTypeOfVehicles o_CurretVehicle)
        {
            string modelName;
            Console.WriteLine(EnumChoises(typeof(eTypeOfVehicles)));
            Console.WriteLine("Insert your number of choice for the type of vehicles and then press 'enter'");
            getEnumChoise(typeof(eTypeOfVehicles), out eTypeOfVehicles currentChoise);
            Console.WriteLine("Insert model for the {0}", currentChoise);
            modelName = Console.ReadLine();
            Vehicle newVehicle = CreateVichles.CreateVehicle(currentChoise, i_licenceNum, modelName);
            o_CurretVehicle = currentChoise;
            return newVehicle;
        }

        private void fullDataForOnwerAndVehicle()
        {
            Console.WriteLine("Insert license number");
            try
            {
                Console.WriteLine(r_Garage.FullDetailsOfVehicle(Console.ReadLine()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void printListOfVehicleInGarage()
        {
            Console.WriteLine("insert true for list of vehicle by status or other input for list of vehicle without status");
            if (!bool.TryParse(Console.ReadLine(), out bool userWantOrderByStatus))
            {
                userWantOrderByStatus = false;
            }

            Console.WriteLine(r_Garage.MsgOfAllVehicleInGarageFillterStatus(userWantOrderByStatus));
        }

        private void changeVehicleStatus()
        {
            string licenseNumber;

            Console.WriteLine("Insert license number");
            licenseNumber = Console.ReadLine();
            Console.WriteLine(EnumChoises(typeof(Client.eVehicleStatusInGarage)));
            getEnumChoise(typeof(Client.eVehicleStatusInGarage), out Client.eVehicleStatusInGarage chosenStatus);
            try
            {
                r_Garage.ChangeVehicleStatus(licenseNumber, chosenStatus);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void chargeElectricVehicle()
        {
            string licenseNumber;
            float chargingHoursAmount;
            Console.WriteLine("Insert license number");
            licenseNumber = Console.ReadLine();
            Console.WriteLine("Insert amount of hours charging to add");
            while (!float.TryParse(Console.ReadLine(), out chargingHoursAmount))
            {
                Console.WriteLine("Wrong input, please try again");
            }

            try
            {
                r_Garage.ChargeBattary(licenseNumber, chargingHoursAmount);
            }
            catch (ValueOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void fillWheelsToMaximumAir()
        {
            Console.WriteLine("Insert license number");
            try
            {
                r_Garage.FillWheelsToMaxAir(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void createNewClient()
        {
            string licenceNum;
            Console.WriteLine("Insert the licence number");
            licenceNum = Console.ReadLine();
            if (r_Garage.IsExistInGarage(licenceNum))
            {
                Console.WriteLine("The vehicle already in the garge , the status os this vehicle change to inrepair.");
                r_Garage.ChangeVehicleStatus(licenceNum, Client.eVehicleStatusInGarage.InRepair);
            }
            else
            { 
            Vehicle newVehicle = createNewVehicle(licenceNum, out eTypeOfVehicles curretVehicle);
            fillAndAddClientToTheGarage(newVehicle);
            wheelsProperty(newVehicle);

            switch (curretVehicle)
                {
                    case eTypeOfVehicles.FuelCar:
                    case eTypeOfVehicles.ElecticCar:
                        carPropertise(newVehicle);
                        break;
                    case eTypeOfVehicles.FuelMotorcycle:
                    case eTypeOfVehicles.ElectricMotorcycle:
                        motorcyclePropertise(newVehicle);
                        break;
                    case eTypeOfVehicles.FuelTruck:
                        truckPropertise(newVehicle);
                        break;
                }

                setEnergyInVehicle(newVehicle);
            }
        }

        private void fillAndAddClientToTheGarage(Vehicle i_NewVehicle)
        {
            string clientName;
            string clientPhoneNumber;
            Console.WriteLine("Insert client name");
            clientName = Console.ReadLine();
            while (!clientName.All(char.IsLetter))
            {
                Console.WriteLine("Name must contain only letters, please try again");
                clientName = Console.ReadLine();
            }

            Console.WriteLine("Insert client phone number");
            clientPhoneNumber = Console.ReadLine();
            while (!clientPhoneNumber.All(char.IsDigit))
            {
                Console.WriteLine("Phone number must contain only digits, please try again");
                clientPhoneNumber = Console.ReadLine();
            }

            r_Garage.InsertNewClient(i_NewVehicle, clientName, clientPhoneNumber);
        }

        private void refuelFuelVehicle()
        {
            string licenseNumber;
            float fuelAmount;
            Console.WriteLine("Insert license number");
            licenseNumber = Console.ReadLine();
            Console.WriteLine("Insert the amount of fuel to add");
            while (!float.TryParse(Console.ReadLine(), out fuelAmount))
            {
                Console.WriteLine("Invalid input, try again");
            }

            Console.WriteLine(EnumChoises(typeof(eFuelType)));
            getEnumChoise(typeof(eFuelType), out eFuelType chosenTypeFuel);
            try
            {
                r_Garage.RefuelVehicle(licenseNumber, fuelAmount, chosenTypeFuel);
            }
            catch (ValueOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void wheelsProperty(Vehicle i_Vehicle)
        {
            bool clientInsertLegalPresser = false;
            string manufacturerNameOfWheels;
            float airPressure = 0;
            Console.WriteLine("Insert wheels manufacturer name ");
            manufacturerNameOfWheels = Console.ReadLine();

            while (!manufacturerNameOfWheels.All(char.IsLetterOrDigit))
            {
                Console.WriteLine("Invalid wheels manufacturer name please try again");
                manufacturerNameOfWheels = Console.ReadLine();
            }

            Console.WriteLine("Insert amount of air pressure that you want to fill ");
            while (!clientInsertLegalPresser)
            {
                if (float.TryParse(Console.ReadLine(), out airPressure))
                {
                    try
                    {
                        CreateVichles.VehicleWheelsProperty(i_Vehicle, manufacturerNameOfWheels, airPressure);
                        clientInsertLegalPresser = true;
                    }
                    catch (ValueOutOfRangeException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again");
                }
            }
        }

        private void setEnergyInVehicle(Vehicle i_Vehicle)
        {
            float currentPercentOfEnergy;
            Console.WriteLine("Insert current percent energy in your vehicle");
            bool clientInsertLegalPercent = float.TryParse(Console.ReadLine(), out currentPercentOfEnergy);
            while (!clientInsertLegalPercent || currentPercentOfEnergy > 100 || currentPercentOfEnergy < 0)
            {
                Console.WriteLine("Please insert percent between 0 to 100");
                clientInsertLegalPercent = float.TryParse(Console.ReadLine(), out currentPercentOfEnergy);
            }

            CreateVichles.VehicleEnergyProperty(i_Vehicle, currentPercentOfEnergy);
        }

        private void carPropertise(Vehicle i_Car)
        {
            Console.WriteLine("Insert number of doors and then press 'enter'");
            Console.WriteLine(EnumChoises(typeof(Car.eNumberOfDoors)));
            getEnumChoise(typeof(Car.eNumberOfDoors), out Car.eNumberOfDoors numOfDoors);

            Console.WriteLine("Now insert the car color");
            Console.WriteLine(EnumChoises(typeof(Car.eCarColor)));
            getEnumChoise(typeof(Car.eCarColor), out Car.eCarColor colorOfcar);

            CreateVichles.CarPropertise(i_Car, numOfDoors, colorOfcar);
        }

        private void motorcyclePropertise(Vehicle i_Motorcycle)
        {
            Console.WriteLine("Insert Engine Capacity and then press 'enter'");
            string answer = Console.ReadLine();
            int engineCapacity;
            while (!int.TryParse(answer, out engineCapacity))
            {
                Console.WriteLine("Invalid Engine Capacity, try again");
                answer = Console.ReadLine();
            }

            Console.WriteLine("Please choose type of license");
            Console.WriteLine(EnumChoises(typeof(Motorcycle.eTypeOfLicense)));
            getEnumChoise(typeof(Motorcycle.eTypeOfLicense), out Motorcycle.eTypeOfLicense typeOfLicense);
            CreateVichles.MotorcyclePropertise(i_Motorcycle, engineCapacity, typeOfLicense);
        }

        private void truckPropertise(Vehicle i_Truck)
        {
            Console.WriteLine("Insert trunk cargo capacity in kg");
            string capacityInput = Console.ReadLine();
            float trunkCapacity;
            while (!float.TryParse(capacityInput, out trunkCapacity) || !(trunkCapacity >= 0))
            {
                Console.WriteLine("Invalid truck capacity, please try again");
                capacityInput = Console.ReadLine();
            }

            Console.WriteLine("Insert 'true' if the Trunk carying a hazardous material, any key if not");
            if (!bool.TryParse(Console.ReadLine(), out bool isCarryHazardousMaterial))
            {
                isCarryHazardousMaterial = false;
            }

            CreateVichles.TruckPropertise(i_Truck, trunkCapacity, isCarryHazardousMaterial);
        }

        private enum eGarageAction 
        {
            InsertCarToGarage = 1,
            ListOfVehicles,
            NewVehicleStatus,
            FillWheelToMaxAir,
            RefuelFuelVehicle,
            ChargeElectricVehicle,
            InsertDataForOnwerAndVehicle,
        }
    }
}
