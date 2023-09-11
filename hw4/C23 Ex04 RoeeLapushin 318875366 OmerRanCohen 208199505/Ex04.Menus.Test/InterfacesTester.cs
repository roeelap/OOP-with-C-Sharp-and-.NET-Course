using System.Collections.Generic;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfacesTester : IExecuteObserver
    {
        private MainMenu m_MainMenu;
        private MenuItem m_ShowDateTimeItem;
        private MenuItem m_VersionAndCapitalsItem;
        private ExecutableMenuItem m_ShowDateItem;
        private ExecutableMenuItem m_ShowTimeItem;
        private ExecutableMenuItem m_ShowVersionItem;
        private ExecutableMenuItem m_CountCapitalsItem;

        public InterfacesTester()
        {
            m_ShowDateItem = new ExecutableMenuItem("Show Date");
            m_ShowDateItem.AttachObserver(this);

            m_ShowTimeItem = new ExecutableMenuItem("Show Time");
            m_ShowTimeItem.AttachObserver(this);

            m_ShowVersionItem = new ExecutableMenuItem("Show Version");
            m_ShowVersionItem.AttachObserver(this);

            m_CountCapitalsItem = new ExecutableMenuItem("Count Capitals");
            m_CountCapitalsItem.AttachObserver(this);

            m_ShowDateTimeItem = new MenuItem("Show Date/Time", new List<MenuItem> { m_ShowDateItem, m_ShowTimeItem });
            m_VersionAndCapitalsItem = new MenuItem("Version and Capitals", new List<MenuItem> { m_ShowVersionItem, m_CountCapitalsItem });

            m_MainMenu = new MainMenu("Interfaces Main Menu", new List<MenuItem> { m_ShowDateTimeItem, m_VersionAndCapitalsItem });
        }

        public void TestMainMenu()
        {
            m_MainMenu.Show();
        }

        public void ReportExecuted(ExecutableMenuItem i_ExecutableMenuItem)
        {
            if (i_ExecutableMenuItem == m_ShowDateItem)
            {
               TestMethods.ShowDate();
            }
            else if (i_ExecutableMenuItem == m_ShowTimeItem)
            {
                TestMethods.ShowTime();
            }
            else if (i_ExecutableMenuItem == m_ShowVersionItem)
            {
                TestMethods.ShowVersion();
            }
            else if (i_ExecutableMenuItem == m_CountCapitalsItem)
            {
                TestMethods.CountCapitals();
            }
        }
    }
}
