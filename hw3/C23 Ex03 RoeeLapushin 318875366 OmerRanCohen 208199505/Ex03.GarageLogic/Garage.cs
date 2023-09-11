using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_Vehicles;

        public Garage()
        {
            m_Vehicles = new Dictionary<string, Vehicle>();
        }

        public enum eGarageStatus
        {
            UnderRepair,
            Repaired,
            Paid,
        }

        public Dictionary<string, Vehicle> Vehicles
        {
            get { return m_Vehicles; }
        }

        public bool InsertNewVehicle(Vehicle i_NewVehicle)
        {
            bool hasNewVehicleBeenInserted = false;

            if (Vehicles.ContainsKey(i_NewVehicle.LicenseNumber))
            {
                Vehicles[i_NewVehicle.LicenseNumber].GarageStatus = eGarageStatus.UnderRepair;
            }
            else
            {
                Vehicles.Add(i_NewVehicle.LicenseNumber, i_NewVehicle);
                hasNewVehicleBeenInserted = true;
            }

            return hasNewVehicleBeenInserted;
        }

        public void ChangeVehicleGarageStatus(string i_LicenseNumber, string i_NewStatus)
        {
            if (!Vehicles.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("Vehicle not found in the garage.");
            }

            Vehicles[i_LicenseNumber].GarageStatus = garageStatusStringToEnum(i_NewStatus);
        }

        public List<string> GetVehiclesByGarageStatus(string i_VehicleStatus)
        {
            List<string> licenseNumbers = Vehicles.Keys.ToList();

            if (!string.IsNullOrEmpty(i_VehicleStatus))
            {
                eGarageStatus filterStatus = garageStatusStringToEnum(i_VehicleStatus);

                licenseNumbers.RemoveAll(licenseNumber => Vehicles[licenseNumber].GarageStatus != filterStatus);
            }

            return licenseNumbers;
        }

        public string GetVehicleDetails(string i_LicenseNumber)
        {
            if (!Vehicles.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("Vehicle not found in the garage.");
            }

            return Vehicles[i_LicenseNumber].ToString();
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            Vehicle vehicleToInflateWheels;

            bool isVehcileInGarage = Vehicles.TryGetValue(i_LicenseNumber, out vehicleToInflateWheels);

            if (isVehcileInGarage)
            {
                foreach (Wheel wheel in vehicleToInflateWheels.Wheels)
                {
                    float amountToInflate = wheel.MaxAirPressure - wheel.CurrentAirPressure;
                    wheel.Inflate(amountToInflate);
                }
            }
            else
            {
                throw new ArgumentException(string.Format("There is no vehicle with license number {0} in the garage", i_LicenseNumber));
            }
        }

        public void FillGas(string i_LicenseNumber, string i_GasType, string i_GasAmountToAdd)
        {
            Vehicle vehicleToFillUp;
            float amountToAdd;

            bool isVehcileInGarage = Vehicles.TryGetValue(i_LicenseNumber, out vehicleToFillUp);

            if (!isVehcileInGarage)
            {
                throw new ArgumentException(string.Format("There is no vehicle with license number {0} in the garage", i_LicenseNumber));
            }

            if (!(vehicleToFillUp.Engine is FuelBasedEngine))
            {
                throw new ArgumentException(string.Format("The vehicle with license number {0} is not fuel based", i_LicenseNumber));
            }

            if (!float.TryParse(i_GasAmountToAdd, out amountToAdd))
            {
                throw new FormatException(string.Format("Input {0} is not valid for amount of fuel, expecting float", i_GasAmountToAdd));
            }

            ((FuelBasedEngine)vehicleToFillUp.Engine).Refuel(amountToAdd, i_GasType);
            vehicleToFillUp.EnergyPercentage = vehicleToFillUp.Engine.CurrentAmountInEngine / vehicleToFillUp.Engine.MaxCapacity * 100;
        }

        public void FillBattary(string i_LicenseNumber, string i_TimeToFillTheBatteryInMinutes)
        {
            Vehicle vehicleToFillUp;
            float amountToAdd;

            bool isVehcileInGarage = Vehicles.TryGetValue(i_LicenseNumber, out vehicleToFillUp);

            if (!isVehcileInGarage)
            {
                throw new ArgumentException(string.Format("There is no vehicle with license number {0} in the garage", i_LicenseNumber));
            }

            if (!(vehicleToFillUp.Engine is ElectricEngine))
            {
                throw new ArgumentException(string.Format("The vehicle with license number {0} is not electric", i_LicenseNumber));
            }

            if (!float.TryParse(i_TimeToFillTheBatteryInMinutes, out amountToAdd))
            {
                throw new FormatException(string.Format("Input {0} is not valid for amount of fuel, expecting float", i_TimeToFillTheBatteryInMinutes));
            }

            ((ElectricEngine)vehicleToFillUp.Engine).Recharge(amountToAdd);
            vehicleToFillUp.EnergyPercentage = vehicleToFillUp.Engine.CurrentAmountInEngine / vehicleToFillUp.Engine.MaxCapacity * 100;
        }

        private eGarageStatus garageStatusStringToEnum(string i_statusString)
        {
            eGarageStatus status;

            switch (i_statusString)
            {
                case "UnderRepair":
                    status = eGarageStatus.UnderRepair;
                    break;

                case "Repaired":
                    status = eGarageStatus.Repaired;
                    break;

                case "Paid":
                    status = eGarageStatus.Paid;
                    break;

                default:
                    throw new FormatException(string.Format("Input {0} not in the right format - expecting UnderRepair/Repaired/Paid", i_statusString));
            }

            return status;
        }
    }
}