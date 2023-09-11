using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_HasRefrigeration;
        private float m_CargoVolume;

        public Truck(int i_NumOfWheels, float i_MaxWheelAirPressure, Engine i_Engine)
        {
            Engine = i_Engine;
            NumOfWheels = i_NumOfWheels;
            MaxWheelAirPressure = i_MaxWheelAirPressure;
        }

        public bool HasRefrigeration
        {
            get { return m_HasRefrigeration; }
            set { m_HasRefrigeration = value; }
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }

        public override string ToString()
        {
            StringBuilder truckDetails = new StringBuilder();

            truckDetails.AppendLine("Type: Truck");
            truckDetails.AppendLine("Has Refrigeration: " + HasRefrigeration);
            truckDetails.AppendLine("Cargo Volume: " + CargoVolume);

            return base.ToString() + truckDetails.ToString();
        }
    }
}