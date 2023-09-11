using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class ExecutableMenuItem : MenuItem
    {
        private readonly List<IExecuteObserver> m_ExecuteObservers = new List<IExecuteObserver>();

        public ExecutableMenuItem(string i_Title)
            : base(i_Title, null)
        {
        }

        public void AttachObserver(IExecuteObserver i_ExecuteObserver)
        {
            m_ExecuteObservers.Add(i_ExecuteObserver);
        }

        public void DetachObserver(IExecuteObserver i_ExecuteObserver)
        {
            m_ExecuteObservers.Remove(i_ExecuteObserver);
        }

        public void NotifyExecuteObservers()
        {
            foreach (IExecuteObserver observer in m_ExecuteObservers)
            {
                observer.ReportExecuted(this);
            }
        }
    }
}
