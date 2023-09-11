using System;
using System.Text;
using Ex02.ConsoleUtils;

namespace BoolPgiaa
{
    internal static class GUIManager
    {
        internal static void ClearConsole()
        {
            Screen.Clear();
        }

        internal static void PrintBoard(string[] i_Guesses, string[] i_Results, int i_NumGuessesUntilNow, string i_Solution = null)
        {
            ClearConsole();

            Console.WriteLine("Current board status:");
            Console.WriteLine();

            string header = "|Pins:    |Result:|";
            string emptyRow = "|{0, -9}|{1, -7}|";
            string separator = "|=========|=======|";

            Console.WriteLine(string.Format(header, string.Empty, string.Empty));
            Console.WriteLine(separator);

            string firstRow = i_Solution == null ? " # # # # " : addSpacesAroundCharacters(i_Solution);

            Console.WriteLine(string.Format(emptyRow, firstRow, string.Empty));
            Console.WriteLine(separator);

            for (int i = 0; i < i_Guesses.Length; i++)
            {
                if (i < i_NumGuessesUntilNow)
                {
                    string pins = addSpacesAroundCharacters(i_Guesses[i]);
                    string result = addSpacesBetweenCharacters(i_Results[i]);

                    Console.WriteLine(string.Format(emptyRow, pins, result));
                }
                else
                {
                    Console.WriteLine(string.Format(emptyRow, string.Empty, string.Empty));
                }

                Console.WriteLine(separator);
            }
        }

        internal static void PrintWin(string[] i_Guesses, string[] i_Results, int i_NumGuessesUntilNow)
        {
            ClearConsole();
            PrintBoard(i_Guesses, i_Results, i_NumGuessesUntilNow);
            PrintMessage(Messages.Win(i_Guesses.Length));
        }

        internal static void PrintLose(string[] i_Guesses, string[] i_Results, int i_NumGuessesUntilNow, string i_Solution)
        {
            ClearConsole();
            PrintBoard(i_Guesses, i_Results, i_NumGuessesUntilNow, i_Solution);
            PrintMessage(Messages.Lose);
        }

        internal static void PrintGoodbye()
        {
            ClearConsole();

            PrintMessage(Messages.Goodbye);
        }

        internal static string AskPlayer(string i_Message)
        {
            PrintMessage(i_Message);

            return Console.ReadLine();
        }

        internal static void PrintMessage(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        private static string addSpacesAroundCharacters(string i_InputString)
        {
            return string.Format(" {0} ", addSpacesBetweenCharacters(i_InputString));
        }

        private static string addSpacesBetweenCharacters(string i_InputString)
        {
            StringBuilder stringWithSpacesBetweenCharacters = new StringBuilder();

            for (int i = 0; i < i_InputString.Length - 1; i++)
            {
                stringWithSpacesBetweenCharacters.Append(i_InputString[i] + " ");
            }

            if (i_InputString.Length > 0)
            {
                stringWithSpacesBetweenCharacters.Append(i_InputString[i_InputString.Length - 1]);
            }

            return stringWithSpacesBetweenCharacters.ToString();
        }
    }
}
