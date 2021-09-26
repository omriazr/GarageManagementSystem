namespace Ex03.GarageLogic
{
    internal class FuelCar : Car
    {
        private const float k_FuelTankCar = 60f;
        private const eFuelType k_FuelType = eFuelType.Octan96;

        public FuelCar(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName, new FuelEngine(k_FuelType, k_FuelTankCar))
        {
        }

        public override string ToString()
        {
            return string.Format(
@"Type of fule is: {0}, Vehicle type is Fuel car {1}",
k_FuelType, 
base.ToString());
        }
    }
}
