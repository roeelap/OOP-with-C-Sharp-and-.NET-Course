using System;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_CurrentTimeLeftInBattary, float i_MaxBatteryTimeCapacityInHours)
        {
            CurrentAmountInEngine = i_CurrentTimeLeftInBattary;
            MaxCapacity = i_MaxBatteryTimeCapacityInHours * 60;
        }

        public void Recharge(float i_AmountToRecharge)
        {
            if (IsAmountToAddValid(i_AmountToRecharge))
            {
                CurrentAmountInEngine += i_AmountToRecharge;
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), CurrentAmountInEngine, i_AmountToRecharge, MaxCapacity, "battery");
            }
        }
    }
}