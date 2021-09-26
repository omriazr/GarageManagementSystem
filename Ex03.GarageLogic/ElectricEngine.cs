using System;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private const string k_Electric = "Electric";

        public ElectricEngine(float i_BatteryTime) : base(i_BatteryTime)
        {
        }

        public override string TypeOfEnergy
        {
            get
            {
                return k_Electric;
            }
        }

        public override void FillEnergy(float i_AmonutOfEnergy, string i_EnergyType)
        {
            const string Electric = "Electric"; 

            if (Electric == i_EnergyType)
            {
                CheckAmoutAndFillEnergy(i_AmonutOfEnergy);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            return string.Format(
@"The current percent of battery: {0}% 
The current amount of electric energy: {1} 
The Maximum amount of electric energy: {2}",
m_CurrentPercentEnergy,
m_CurrentamountEnergy, 
r_MaxEnergyCapacity);
        }
    }
}
