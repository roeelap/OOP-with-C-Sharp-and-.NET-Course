using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly float m_MaxAirPressure;
        private string m_Manufacturer;
        private float m_CurrentAirPressure;

        public Wheel(string manufacturer, float currentAirPressure, float maxAirPressure)
        {
            m_Manufacturer = manufacturer;
            m_CurrentAirPressure = currentAirPressure;
            m_MaxAirPressure = maxAirPressure;
        }

        public string Manufacturer
        {
            get { return m_Manufacturer; }
            set { m_Manufacturer = value; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
        }

        public void Inflate(float i_AmountToInflate)
        {
            float newAirPressure = CurrentAirPressure + i_AmountToInflate;

            if (newAirPressure > 0 && newAirPressure <= MaxAirPressure)
            {
                CurrentAirPressure = newAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), CurrentAirPressure, i_AmountToInflate, MaxAirPressure, "wheel");
            }
        }
    }
}