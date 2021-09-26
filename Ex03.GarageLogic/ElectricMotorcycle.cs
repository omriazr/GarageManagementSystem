namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaximumBatteryTime = 1.2f;

        public ElectricMotorcycle(string i_LicenseNumber, string i_Model)
            : base(i_LicenseNumber, i_Model, new ElectricEngine(k_MaximumBatteryTime))
        {
        }

        public override string ToString()
        {
            return string.Format(
@"Vehicle type is Electric Motorcycle {0}",
        base.ToString());
        }
    }
}
