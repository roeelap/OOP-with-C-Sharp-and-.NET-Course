using System;
using System.Collections.Generic;
using System.Reflection;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        private Garage m_Garage = new Garage();

        public Garage Garage
        {
            get => m_Garage;
        }

        public void RunGarage()
        {
            bool isUserWantToExit = false;

            while (!isUserWantToExit)
            {
                string choice = GUIManager.AskUserForInput(Messages.sr_MainMenu);

                switch (choice)
                {
                    case "1":
                        handleInsertVehicle();
                        break;

                    case "2":
                        handleViewLicenseNumbers();
                        break;

                    case "3":
                        handleChangeVehicleStatus();
                        break;

                    case "4":
                        handleInflateWheels();
                        break;

                    case "5":
                        handleRefuel();
                        break;

                    case "6":
                        handleRecharge();
                        break;

                    case "7":
                        handleDisplayVehicleDetails();
                        break;

                    case "8":
                        isUserWantToExit = true;
                        break;

                    default:
                        GUIManager.DisplayMessage(Messages.sr_InvalidChoice);
                        break;
                }
            }

            GUIManager.DisplayMessage(Messages.sr_ExitGarage);
        }

        private void handleInsertVehicle()
        {
            bool hasNewVehicleBeenInserted = false;

            List<string> validVehicleTypes = VehicleFactory.GetValidVehiclesAsList();
            string validVehicleTypesString = string.Join(", ", validVehicleTypes);
            string newVehicleType = GUIManager.AskUserForInput(string.Format(Messages.sr_AskForVehicleType, validVehicleTypesString));
            Vehicle newVehicle = VehicleFactory.GenerateNewVehicle(newVehicleType);

            if (newVehicle != null)
            {
                try
                {
                    PropertyInfo[] vehicleProperties = newVehicle.GetType().GetProperties();
                    List<PropertyInfo> propertiesRequiringInput = new List<PropertyInfo>(vehicleProperties);
                    propertiesRequiringInput.RemoveAll(property =>
                        property.Name == "GarageStatus" || property.Name == "MaxWheelAirPressure" || property.Name == "NumOfWheels" || property.Name == "Engine" || property.Name == "EnergyPercentage" || property.Name == "Wheels");

                    Dictionary<PropertyInfo, string> newVehicleDetails = GUIManager.GetVehicleDetailsFromUser(propertiesRequiringInput);
                    newVehicle.InitDetailsForThisVehicle(newVehicleDetails);
                    hasNewVehicleBeenInserted = Garage.InsertNewVehicle(newVehicle);
                    GUIManager.DisplayMessage(hasNewVehicleBeenInserted ? Messages.sr_VehicleAddedSuccessfully : Messages.sr_VehicleAlreadyExistsInGarage);
                }
                catch (Exception exception)
                {
                    GUIManager.DisplayMessage(exception.Message);
                }
            }
            else
            {
                GUIManager.DisplayMessage(Messages.sr_vehicleTypeNotValid);
            }
        }

        private void handleViewLicenseNumbers()
        {
            string status = GUIManager.AskUserForInput(Messages.sr_AskForAFilterStatus);
            try
            {
                List<string> vehiclesByStatus = Garage.GetVehiclesByGarageStatus(status);

                if (vehiclesByStatus.Count == 0)
                {
                    GUIManager.DisplayMessage(Messages.sr_NoLicenseNumbersFound);
                }
                else
                {
                    GUIManager.DisplayListAndHeader(vehiclesByStatus, Messages.sr_VehiclesList);
                }
            }
            catch (FormatException formatException)
            {
                GUIManager.DisplayMessage(formatException.Message);
            }
        }

        private void handleChangeVehicleStatus()
        {
            string licenseForStatusChange = GUIManager.AskUserForInput(Messages.sr_AskForLicenseNumber);
            string newStatus = GUIManager.AskUserForInput(Messages.sr_AskForNewStatus);

            try
            {
                Garage.ChangeVehicleGarageStatus(licenseForStatusChange, newStatus);
                GUIManager.DisplayMessage(string.Format(Messages.sr_StatusUpdated, licenseForStatusChange));
            }
            catch (Exception e)
            {
                GUIManager.DisplayMessage(e.Message);
            }
        }

        private void handleInflateWheels()
        {
            string licenseForWheelInflation = GUIManager.AskUserForInput(Messages.sr_AskForLicenseNumber);

            try
            {
                Garage.InflateWheelsToMax(licenseForWheelInflation);
            }
            catch (Exception e)
            {
                GUIManager.DisplayMessage(e.Message);
            }

            GUIManager.DisplayMessage(string.Format(Messages.sr_WheelsInflatedSuccessfuly, licenseForWheelInflation));
        }

        private void handleRefuel()
        {
            string licenseForRefueling = GUIManager.AskUserForInput(Messages.sr_AskForLicenseNumber);
            string typeOfFuel = GUIManager.AskUserForInput(Messages.sr_AskForTypeOfFuel);
            string amountToRefuel = GUIManager.AskUserForInput(Messages.sr_AskForAmountToRefuel);

            try
            {
                Garage.FillGas(licenseForRefueling, typeOfFuel, amountToRefuel);
            }
            catch (Exception e)
            {
                GUIManager.DisplayMessage(e.Message);
            }

            GUIManager.DisplayMessage(string.Format(Messages.sr_RefueledSuccessfuly, licenseForRefueling));
        }

        private void handleRecharge()
        {
            string licenseForRecharging = GUIManager.AskUserForInput(Messages.sr_AskForLicenseNumber);
            string amountToRecharge = GUIManager.AskUserForInput(Messages.sr_AskForAmountToRecharge);

            try
            {
                Garage.FillBattary(licenseForRecharging, amountToRecharge);
            }
            catch (Exception e)
            {
                GUIManager.DisplayMessage(e.Message);
            }

            GUIManager.DisplayMessage(string.Format(Messages.sr_RechargedSuccessfuly, licenseForRecharging));
        }

        private void handleDisplayVehicleDetails()
        {
            string licenseNumber = GUIManager.AskUserForInput(Messages.sr_AskForLicenseNumber);

            try
            {
                string vehicleDetails = Garage.GetVehicleDetails(licenseNumber);
                GUIManager.DisplayMessage(vehicleDetails);
            }
            catch (Exception e)
            {
                GUIManager.DisplayMessage(e.Message);
            }
        }
    }
}