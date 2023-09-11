using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private const string k_OwnerNamePattern = @"^[a-zA-Z\s]+$";
        private const string k_OwnerPhoneNumberPattern = @"^\d+$";
        private const string k_LicenseNumberPattern = @"^[a-zA-Z0-9]+$";

        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_InitialAmountInEngine;
        private float m_EnergyPercentage = 0;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private int m_NumOfWheels;
        private float m_InitialWheelAirPressure;
        private float m_MaxWheelAirPressure;
        private string m_WheelManufacturer;
        private Garage.eGarageStatus m_GarageStatus = Garage.eGarageStatus.UnderRepair;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }

            set
            {
                Regex namePattern = new Regex(k_OwnerNamePattern);

                if (namePattern.IsMatch(value))
                {
                    m_OwnerName = value;
                }
                else
                {
                    throw new FormatException("Please provide a valid owner name - expecting a string of letters and spaces.");
                }
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }

            set
            {
                Regex namePattern = new Regex(k_OwnerPhoneNumberPattern);

                if (namePattern.IsMatch(value))
                {
                    m_OwnerPhoneNumber = value;
                }
                else
                {
                    throw new FormatException("Please provide a valid phone number - expecting digits only.");
                }
            }
        }

        public Garage.eGarageStatus GarageStatus
        {
            get { return m_GarageStatus; }
            set { m_GarageStatus = value; }
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                Regex namePattern = new Regex(k_LicenseNumberPattern);

                if (namePattern.IsMatch(value))
                {
                    m_LicenseNumber = value;
                }
                else
                {
                    throw new FormatException("Please provide a valid license number - expecting a string of letters and digits.");
                }
            }
        }

        public float InitialAmountInEngine
        {
            get
            {
                return m_InitialAmountInEngine;
            }

            set
            {
                if (value > Engine.MaxCapacity)
                {
                    throw new ValueOutOfRangeException(new Exception(), 0, value, MaxWheelAirPressure, "wheel");
                }
                else
                {
                    m_InitialAmountInEngine = value;
                }
            }
        }

        public float EnergyPercentage
        {
            get { return m_EnergyPercentage; }
            set { m_EnergyPercentage = value; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value;  }
        }

        public Engine Engine
        {
            get { return m_Engine; }
            set { m_Engine = value; }
        }

        public int NumOfWheels
        {
            get { return m_NumOfWheels; }
            set { m_NumOfWheels = value;  }
        }

        public float InitialWheelAirPressure
        {
            get
            {
                return m_InitialWheelAirPressure;
            }

            set
            {
                if (value > MaxWheelAirPressure)
                {
                    throw new ValueOutOfRangeException(new Exception(), 0, value, MaxWheelAirPressure, "wheel");
                }
                else
                {
                    m_InitialWheelAirPressure = value;
                }
            }
        }

        public float MaxWheelAirPressure
        {
            get { return m_MaxWheelAirPressure; }
            set { m_MaxWheelAirPressure = value; }
        }

        public string WheelManufacturer
        {
            get { return m_WheelManufacturer; }
            set { m_WheelManufacturer = value; }
        }

        public void CreateNewWheels(string i_Manufacturer, float i_CurrentAirPressure)
        {
            if (i_CurrentAirPressure > MaxWheelAirPressure)
            {
                throw new ValueOutOfRangeException(new Exception(), 0, i_CurrentAirPressure, MaxWheelAirPressure, "wheel");
            }

            Wheels = new List<Wheel>();

            for (int i = 0; i < NumOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_Manufacturer, i_CurrentAirPressure, MaxWheelAirPressure));
            }
        }

        public void InitDetailsForThisVehicle(Dictionary<PropertyInfo, string> i_Details)
        {
            foreach (KeyValuePair<PropertyInfo, string> detail in i_Details)
            {
                PropertyInfo property = detail.Key;
                string valueAsString = detail.Value;
                object valueAsCorrectType;

                try
                {
                    if (property.PropertyType == typeof(int))
                    {
                        valueAsCorrectType = int.Parse(valueAsString);
                    }
                    else if (property.PropertyType == typeof(float))
                    {
                        valueAsCorrectType = float.Parse(valueAsString);
                    }
                    else if (property.PropertyType == typeof(bool))
                    {
                        valueAsCorrectType = bool.Parse(valueAsString);
                    }
                    else if (property.PropertyType.IsEnum)
                    {
                        valueAsCorrectType = Enum.Parse(property.PropertyType, valueAsString);
                    }
                    else
                    {
                        valueAsCorrectType = valueAsString;
                    }

                    property.SetValue(this, valueAsCorrectType, null);
                }
                catch (Exception)
                {
                    throw new FormatException("Some of you inputs are not valid, please check them.");
                }
            }

            Engine.CurrentAmountInEngine = InitialAmountInEngine;
            EnergyPercentage = Engine.CurrentAmountInEngine / Engine.MaxCapacity * 100;
            CreateNewWheels(WheelManufacturer, InitialWheelAirPressure);
        }

        public override string ToString()
        {
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.AppendLine("Model: " + ModelName);
            vehicleDetails.AppendLine("License Number: " + LicenseNumber);
            vehicleDetails.AppendLine("Owner: " + OwnerName);
            vehicleDetails.AppendLine("Owner's Phone Number: " + OwnerPhoneNumber);
            vehicleDetails.AppendLine("Current Status: " + GarageStatus);
            vehicleDetails.AppendLine("Fuel Based / Electric Engine: " + Engine.GetType().Name);

            if (Engine is FuelBasedEngine)
            {
                vehicleDetails.AppendLine("Type Of Fuel: " + ((FuelBasedEngine)Engine).FuelType);
            }

            vehicleDetails.AppendLine("Current Energy Source Level: %" + EnergyPercentage);

            for (int i = 0; i < Wheels.Count; i++)
            {
                Wheel wheel = Wheels[i];

                vehicleDetails.AppendLine(string.Format("Wheel {0} - Manufacturer: {1}, Air Pressure: {2}", i + 1, wheel.Manufacturer, wheel.CurrentAirPressure));
            }

            return vehicleDetails.ToString();
        }
    }
}
