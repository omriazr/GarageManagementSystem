namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected readonly float r_MaxEnergyCapacity;
        protected float m_CurrentPercentEnergy;
        protected float m_CurrentamountEnergy;

        protected Engine(float i_maximumEnergy)
        {
            r_MaxEnergyCapacity = i_maximumEnergy;
        }

        public float CurrentAmountEnergy
        {
            get
            {
                return m_CurrentamountEnergy;
            }

            set
            {
                if (value >= 0 && value + m_CurrentamountEnergy <= r_MaxEnergyCapacity)
                {
                    m_CurrentamountEnergy += value;
                }
                else
                {
                    throw new ValueOutOfRangeException(null, r_MaxEnergyCapacity, 0);
                }
            }
        }

        public float CurrentPercentEnergy
        {
            get
            {
                return m_CurrentPercentEnergy;
            }

            set
            {
                if (value >= 0 && value + m_CurrentPercentEnergy <= 100.0)
                {
                    m_CurrentPercentEnergy += value;
                }
                else
                {
                    throw new ValueOutOfRangeException(null, r_MaxEnergyCapacity, 0);
                }
            }
        }

        public float MaxEnergyCapacity
        { 
            get
            {
                return r_MaxEnergyCapacity;
            }
        }
  
        public abstract void FillEnergy(float i_AmonutOfEnergy, string i_TypeOfEnergy);

        public abstract string TypeOfEnergy
        {
            get;
        }

        internal  void SetPercentAndFillEnergy(float i_PercentOfEnergy)
        {
            if (i_PercentOfEnergy <= 100 && i_PercentOfEnergy > 0)
            { 
                m_CurrentPercentEnergy = i_PercentOfEnergy;
                m_CurrentamountEnergy = (i_PercentOfEnergy / 100) * r_MaxEnergyCapacity;
            }
        }

        protected void CheckAmoutAndFillEnergy(float i_AmonutOfEnergy)
        {
            if (i_AmonutOfEnergy > 0 && m_CurrentamountEnergy + i_AmonutOfEnergy <= r_MaxEnergyCapacity)
            {
                m_CurrentamountEnergy += i_AmonutOfEnergy;
                m_CurrentPercentEnergy += (i_AmonutOfEnergy / r_MaxEnergyCapacity) * 100;
            }
            else
            {
                throw new ValueOutOfRangeException(null, r_MaxEnergyCapacity - m_CurrentPercentEnergy, 0);
            }
        }
    }
}
