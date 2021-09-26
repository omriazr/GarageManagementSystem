namespace Ex03.GarageLogic
{
    public class ElectirCar : Car
    {
        private const float k_MaximumBatteryTime = 2.1f;

        public ElectirCar(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName, new ElectricEngine(k_MaximumBatteryTime))
        {
        }

        public override string ToString()
        {
            return string.Format(@"Vehicle type is Electric Car {0}", base.ToString());
        }
    }
}
