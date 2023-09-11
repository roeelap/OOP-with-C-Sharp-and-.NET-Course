namespace Ex03.ConsoleUI
{
    internal static class Messages
    {
        internal static readonly string sr_AskForLicenseNumber = "Please enter the license number of your vehicle:";

        internal static readonly string sr_AskForNewStatus = "Enter new status (UnderRepair, Repaired, Paid):";

        internal static readonly string sr_InvalidChoice = "Invalid choice! Please select a valid option.";

        internal static readonly string sr_ExitGarage = "Exiting the garage system. Thank you!";

        internal static readonly string sr_AskForAFilterStatus = "Enter vehicle status (UnderRepair, Repaired, Paid) or press Enter to view all vehicles:";

        internal static readonly string sr_MainMenu =
            @"-------------------------------
--------- Garage Menu ---------
1. Insert a new vehicle
2. Display vehicles by status
3. Change vehicle status
4. Inflate wheels of a certain vehicle
5. Refuel a vehicle
6. Recharge a vehicle
7. Display vehicle details
8. Exit
-------------------------------
Enter your choice (1 - 8):
-------------------------------";

        internal static readonly string sr_VehicleAddedSuccessfully = "Vehicle successfully added to the garage.";

        internal static readonly string sr_VehicleAlreadyExistsInGarage = "Vehicle with this license number is already in the garage. Its status has been updated to 'Under Repair'.";

        internal static readonly string sr_VehiclesList = "Vehicles with the provided status:";

        internal static readonly string sr_StatusUpdated = "Status of vehicle with license {0} has been updated.";

        internal static readonly string sr_AskForAmountToRecharge = "Enter the amount of minutes to recharge:";

        internal static readonly string sr_AskForTypeOfFuel = "Enter the type of fuel (Octan95, Octan96, Octan98, Soler):";

        internal static readonly string sr_AskForAmountToRefuel = "Enter the amount of fuel:";

        internal static readonly string sr_AskForProperty = "Enter {0}:";

        internal static readonly string sr_AskForVehicleType = "Enter the vehicle's type ({0}):";

        internal static readonly string sr_WheelsInflatedSuccessfuly = "Successfully inflated the wheels for vehicle with license number - {0}";

        internal static readonly string sr_RefueledSuccessfuly = "Successfully refueled for vehicle with license number - {0}";

        internal static readonly string sr_RechargedSuccessfuly = "Successfully recharged for vehicle with license number - {0}";

        internal static readonly string sr_NoLicenseNumbersFound = "There aren't any vehicles with the provided status in the garage.";

        internal static readonly string sr_vehicleTypeNotValid = "Please enter a valid vehicle type!";
    }
}