using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(Exception i_InnerException, float i_InitialAmount, float i_AmountToFill, float i_MaxCapacity, string i_ContainerType)
            : base(string.Format("An error occured while trying to fill {0} into {1} with max. capacity {2} while initial amount was {3}.", i_AmountToFill, i_ContainerType, i_MaxCapacity, i_InitialAmount), i_InnerException)
        {
            MaxValue = i_MaxCapacity;
            MinValue = 0;
        }

        public float MaxValue
        {
            get { return m_MaxValue; }
            set { m_MaxValue = value; }
        }

        public float MinValue
        {
            get { return m_MinValue; }
            set { m_MinValue = value; }
        }
    }
}
