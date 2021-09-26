namespace Ex03.GarageLogic
{
    internal class FuelTruck : Truck
    {
        private const float k_FuelTankTruck = 120f;
        private const eFuelType k_FuelType = eFuelType.Soler;

        public FuelTruck(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName, new FuelEngine(k_FuelType, k_FuelTankTruck))
        {
        }

        public override string ToString()
        {
            return string.Format(
                @"Type of fule is: {0}, Vehicle type is Fuel Truck {1}",
                k_FuelType,
                base.ToString());
        }
    }
}
