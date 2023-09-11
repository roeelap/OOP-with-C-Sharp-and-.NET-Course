using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eMotorcycleLicenseType m_LicenseType;
        private float m_EngineVolume;

        public Motorcycle(int i_NumOfWheels, float i_MaxWheelAirPressure, Engine i_Engine)
        {
            Engine = i_Engine;
            NumOfWheels = i_NumOfWheels;
            MaxWheelAirPressure = i_MaxWheelAirPressure;
        }

        public enum eMotorcycleLicenseType
        {
            A,
            A1,
            A2,
            AB,
        }

        public eMotorcycleLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public float EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }

        public override string ToString()
        {
            StringBuilder motorcycleDetails = new StringBuilder();

            motorcycleDetails.AppendLine("Type: Motorcycle");
            motorcycleDetails.AppendLine("License Type: " + LicenseType);
            motorcycleDetails.AppendLine("Engine Volume: " + EngineVolume);

            return base.ToString() + motorcycleDetails.ToString();
        }
    }
}
