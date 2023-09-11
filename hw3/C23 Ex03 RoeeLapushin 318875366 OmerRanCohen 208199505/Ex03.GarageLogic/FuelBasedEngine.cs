using System;

namespace Ex03.GarageLogic
{
    public class FuelBasedEngine : Engine
    {
        private eFuelType m_FuelType;

        public FuelBasedEngine(float i_CurrentFuel, float i_MaxFuelCapacity, eFuelType i_FuelType)
        {
            CurrentAmountInEngine = i_CurrentFuel;
            MaxCapacity = i_MaxFuelCapacity;
            m_FuelType = i_FuelType;
        }

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98,
        }

        public eFuelType FuelType
        {
            get => m_FuelType;
        }

        public void Refuel(float i_AmountToFill, string i_FuelType)
        {
            if (i_FuelType == m_FuelType.ToString())
            {
                if (IsAmountToAddValid(i_AmountToFill))
                {
                    CurrentAmountInEngine += i_AmountToFill;
                }
                else
                {
                    throw new ValueOutOfRangeException(new Exception(), CurrentAmountInEngine, i_AmountToFill, MaxCapacity, "fuel tank");
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Input fuel type {0} does not match the vehicle's fuel type - {1}", i_FuelType, FuelType));
            }
        }
    }
}