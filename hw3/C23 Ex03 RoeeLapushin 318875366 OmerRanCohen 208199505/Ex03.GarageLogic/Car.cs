using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_CarColor;
        private eNumOfDoors m_NumOfDoors;

        public Car(int i_NumOfWheels, float i_MaxWheelAirPressure, Engine i_Engine)
        {
            Engine = i_Engine;
            NumOfWheels = i_NumOfWheels;
            MaxWheelAirPressure = i_MaxWheelAirPressure;
        }

        public enum eColor
        {
            Black,
            White,
            Red,
            Blue,
        }

        public enum eNumOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
        }

        public eColor CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public eNumOfDoors NumOfDoors
        {
            get { return m_NumOfDoors; }
            set { m_NumOfDoors = value; }
        }

        public override string ToString()
        {
            StringBuilder carDetails = new StringBuilder();

            carDetails.AppendLine("Type: Car");
            carDetails.AppendLine("Color: " + CarColor);
            carDetails.AppendLine("Number Of Doors: " + NumOfDoors);

            return base.ToString() + carDetails.ToString();
        }
    }
}
