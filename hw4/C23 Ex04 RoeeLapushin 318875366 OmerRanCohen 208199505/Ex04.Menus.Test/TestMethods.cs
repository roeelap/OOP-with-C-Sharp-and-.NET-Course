using System;

namespace Ex04.Menus.Test
{
    public static class TestMethods
    {
        internal static void ShowDate()
        {
            DateTime currentDate = DateTime.Today;

            Console.WriteLine(string.Format("Today's date is - {0}", currentDate.ToString("dd/MM/yyyy")));
            Console.WriteLine();
        }

        internal static void ShowTime()
        {
            DateTime currentTime = DateTime.Now;

            Console.WriteLine(string.Format("The time is - {0}", currentTime.ToString("HH:mm:ss")));
            Console.WriteLine();
        }

        internal static void ShowVersion()
        {
            Console.WriteLine("Version: 23.3.4.9835");
            Console.WriteLine();
        }

        internal static void CountCapitals()
        {
            int capitalLettersCount = 0;

            Console.WriteLine("Please enter your sentence:");
            string inputSentence = Console.ReadLine();

            foreach (char character in inputSentence)
            {
                if (char.IsUpper(character))
                {
                    capitalLettersCount++;
                }
            }

            Console.WriteLine(string.Format("There are {0} capitals in your sentence.", capitalLettersCount));
            Console.WriteLine();
        }
    }
}
