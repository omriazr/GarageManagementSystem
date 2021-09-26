using System;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public FuelEngine(eFuelType i_FuelType, float i_MaxEnergyCapacity) : base(i_MaxEnergyCapacity)
        {
            r_FuelType = i_FuelType;
        }

        public override void FillEnergy(float i_AmonutOfEnergy, string i_TypeOfEnergy)
        {
            eFuelType currentFuel = (eFuelType)eFuelType.Parse(typeof(eFuelType), i_TypeOfEnergy);
            if (currentFuel == r_FuelType)
            {
                CheckAmoutAndFillEnergy(i_AmonutOfEnergy);
            }
            else
            {
                throw new ArgumentException("Input Fuel type doesnt match to engine fuel type.");
            }
        }

        public override string TypeOfEnergy
        {
            get
            {
                return r_FuelType.ToString();
            }
        }

        public override string ToString()
        {
            return string.Format(
@"The current percent of gas energy:{0}% 
The current ammount of gas energy:{1} 
The Maximum amount of gas energy: {2}",
m_CurrentPercentEnergy,
m_CurrentamountEnergy, 
r_MaxEnergyCapacity);
        }
    }
}
