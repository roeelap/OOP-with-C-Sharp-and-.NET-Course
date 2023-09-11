using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        private enum eValidVehicleType
        {
            Car,
            ElectricCar,
            Motorcycle,
            ElectricMotorcycle,
            Truck,
        }

        public static Vehicle GenerateNewVehicle(string newVehicleType)
        {
            Vehicle newVehicle = null;

            bool isTypeOfVehicleValid = VehicleFactory.validateNewVehicleType(newVehicleType);

            if (isTypeOfVehicleValid)
            {
                if (newVehicleType == eValidVehicleType.Car.ToString())
                {
                    Engine newEngine = new FuelBasedEngine(0, 44, FuelBasedEngine.eFuelType.Octan95);
                    newVehicle = new Car(5, 32, newEngine);
                }
                else if (newVehicleType == eValidVehicleType.ElectricCar.ToString())
                {
                    Engine newEngine = new ElectricEngine(0, 5.2f);
                    newVehicle = new Car(5, 32, newEngine);
                }
                else if (newVehicleType == eValidVehicleType.Motorcycle.ToString())
                {
                    Engine newEngine = new FuelBasedEngine(0, 6.2f, FuelBasedEngine.eFuelType.Octan98);
                    newVehicle = new Motorcycle(2, 30, newEngine);
                }
                else if (newVehicleType == eValidVehicleType.ElectricMotorcycle.ToString())
                {
                    Engine newEngine = new ElectricEngine(0, 2.4f);
                    newVehicle = new Motorcycle(2, 30, newEngine);
                }
                else if (newVehicleType == eValidVehicleType.Truck.ToString())
                {
                    Engine newEngine = new FuelBasedEngine(0, 130, FuelBasedEngine.eFuelType.Soler);
                    newVehicle = new Truck(12, 27, newEngine);
                }
            }

            return newVehicle;
        }

        public static List<string> GetValidVehiclesAsList()
        {
            List<string> validVehicles = new List<string>();

            foreach (eValidVehicleType vehicleType in (eValidVehicleType[])Enum.GetValues(typeof(eValidVehicleType)))
            {
                validVehicles.Add(vehicleType.ToString());
            }

            return validVehicles;
        }

        private static bool validateNewVehicleType(string i_VehicleType)
        {
            bool isValid = false;

            List<string> validVehicleTypes = GetValidVehiclesAsList();

            foreach (string validVehicleType in validVehicleTypes)
            {
                if (i_VehicleType == validVehicleType)
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }
    }
}
