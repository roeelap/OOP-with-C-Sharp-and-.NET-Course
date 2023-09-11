using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly string r_ExitQuitWord = "Exit";
        private string m_Title;
        private List<MenuItem> m_MenuItems;

        public MainMenu(string i_Title, List<MenuItem> i_MenuItems)
        {
            Title = i_Title;
            MenuItems = i_MenuItems;
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public List<MenuItem> MenuItems
        {
            get { return m_MenuItems; }
            set { m_MenuItems = value; }
        }

        protected virtual string QuitWord
        {
            get { return r_ExitQuitWord; }
        }

        public void Show()
        {
            bool userWantsToExit = false;

            while (!userWantsToExit)
            {
                displayMenu();
                int userChoice = getAndValidateUserInput();

                if (userChoice == 0)
                {
                    Console.Clear();
                    userWantsToExit = true;
                }
                else
                {
                    MenuItem chosenMenuItem = MenuItems[userChoice - 1];

                    if (chosenMenuItem is ExecutableMenuItem)
                    {
                        Console.Clear();
                        ((ExecutableMenuItem)chosenMenuItem).NotifyExecuteObservers();
                    }
                    else
                    {
                        Console.Clear();
                        chosenMenuItem.Show();
                    }
                }
            }
        }

        private void displayMenu()
        {
            Console.WriteLine(string.Format("**{0}**", Title));
            Console.WriteLine("-----------------------");

            if (MenuItems != null)
            {
                for (int i = 0; i < MenuItems.Count; i++)
                {
                    Console.WriteLine(string.Format("{0} -> {1}", i + 1, MenuItems[i].Title));
                }
            }

            Console.WriteLine(string.Format("0 -> {0}", QuitWord));
            Console.WriteLine("-----------------------");

            if (MenuItems == null)
            {
                Console.WriteLine(string.Format("Press '0' to {0}.", QuitWord));
            }
            else
            {
                Console.WriteLine(string.Format("Enter your request: (1 to {0} or press '0' to {1}).", MenuItems.Count, QuitWord));
            }
        }

        private int getAndValidateUserInput()
        {
            int userInputAsInt = 0;
            bool isInputValid = false;

            while (!isInputValid)
            {
                string userInput = Console.ReadLine();

                if (MenuItems == null)
                {
                    isInputValid = userInput == "0";

                    if (!isInputValid)
                    {
                        Console.WriteLine(string.Format("Please press '0' to {0}.", QuitWord));
                    }
                }
                else
                {
                    bool isInputValidInteger = int.TryParse(userInput, out userInputAsInt);
                    bool isInputInAllowedRange = userInputAsInt >= 0 && userInputAsInt <= MenuItems.Count;

                    isInputValid = isInputValidInteger && isInputInAllowedRange;

                    if (!isInputValidInteger)
                    {
                        Console.WriteLine(string.Format("Your input is not a valid integer. Please enter a integer between 0 and {0}", MenuItems.Count));
                    }
                    else if (!isInputInAllowedRange)
                    {
                        Console.WriteLine(string.Format("Your input is not in the allowed range. Please enter a integer between 0 and {0}", MenuItems.Count));
                    }
                }
            }

            return userInputAsInt;
        }
    }
}