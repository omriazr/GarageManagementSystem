using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : Motorcycle
    {
        private const float k_MaxFuelTank = 7f;
        private const eFuelType k_FuelType = eFuelType.Octan95;

        public FuelMotorcycle(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName, new FuelEngine(k_FuelType, k_MaxFuelTank))
        {
        }

        public override string ToString()
        {
            return string.Format(
                @"Type of fule is: {0}, Vehicle type is Fuel FuelMotorcycle {1}",
                k_FuelType, 
                base.ToString());
        }
    }
}
