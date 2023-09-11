using System.Collections.Generic;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public static class DelegatesTester
    {
        public static void TestDelegatesMainMenu()
        {
            ExecutableMenuItem showDateItem = new ExecutableMenuItem("Show Date");
            showDateItem.Executed += showDateItem_Executed;

            ExecutableMenuItem showTimeItem = new ExecutableMenuItem("Show Time");
            showTimeItem.Executed += showTimeItem_Executed;

            MenuItem showDateTimeItem = new MenuItem("Show Date/Time", new List<MenuItem> { showDateItem, showTimeItem });

            ExecutableMenuItem showVersionItem = new ExecutableMenuItem("Show Version");
            showVersionItem.Executed += showVersionItem_Executed;

            ExecutableMenuItem countCapitalsItem = new ExecutableMenuItem("Count Capitals");
            countCapitalsItem.Executed += countCapitalsItem_Executed;

            MenuItem versionAndCapitalsItem = new MenuItem("Version and Capitals", new List<MenuItem> { showVersionItem, countCapitalsItem });

            MainMenu mainMenu = new MainMenu("Delegates Main Menu", new List<MenuItem> { showDateTimeItem, versionAndCapitalsItem });

            mainMenu.Show();
        }

        private static void showDateItem_Executed()
        {
            TestMethods.ShowDate();
        }

        private static void showTimeItem_Executed()
        {
            TestMethods.ShowTime();
        }

        private static void showVersionItem_Executed()
        {
            TestMethods.ShowVersion();
        }

        private static void countCapitalsItem_Executed()
        {
            TestMethods.CountCapitals();
        }
    }
}
