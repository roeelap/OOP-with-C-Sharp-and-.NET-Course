namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_CurrentAmountInEngine;
        private float m_MaxCapacity;

        public float CurrentAmountInEngine
        {
            get { return m_CurrentAmountInEngine; }
            set { m_CurrentAmountInEngine = value; }
        }

        public float MaxCapacity
        {
            get { return m_MaxCapacity; }
            set { m_MaxCapacity = value; }
        }

        public bool IsAmountToAddValid(float i_AmountToAdd)
        {
            float newAmountInEngine = i_AmountToAdd + CurrentAmountInEngine;

            return newAmountInEngine > 0 && MaxCapacity >= newAmountInEngine;
        }
    }
}
