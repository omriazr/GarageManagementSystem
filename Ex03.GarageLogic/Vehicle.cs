using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_LicenseNumber;
        protected readonly string r_ModelName;
        protected List<Wheel> r_ListOfWheels;
        protected Engine m_Engine;
      
        public Vehicle(string i_LicenseNumber, string i_ModelName, Engine i_Engine, int i_NumberOfWheels)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_Engine = i_Engine;
            r_ListOfWheels = new List<Wheel>(i_NumberOfWheels);
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return r_ListOfWheels;
            }
        }

        public abstract void SetWheelsOfVehicle(string i_ManufacturerName, float i_CurrentAirPressure);

        protected void initWheelsList(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure, byte i_NumOfWheels)
        {
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                r_ListOfWheels.Add(new Wheel(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure));
            }
        }

        public void FillMaxWheelsAir()
        {
            foreach (Wheel wheel in r_ListOfWheels)
            {
                wheel.AirInflation(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }

        public override string ToString()
        {
            StringBuilder wheels = new StringBuilder();
            foreach (Wheel wheel in r_ListOfWheels)
            {
                wheels.Append(Environment.NewLine + wheel);
            }

            return string.Format(
                @"License Number: {0}, Model Name: {1}, wheels details: {2},
Engine information:
{3}",
 r_LicenseNumber, 
 r_ModelName,
 wheels, 
 Engine);
        }
    }
}