using System;
using System.Text;
using System.Linq;

namespace Ex01_04
{
    internal class Program
    {
        public static void Main()
        {
            runStringAnalyzer();
        }

        private static void runStringAnalyzer()
        {

            Console.WriteLine("Please enter a string of 8 characters:");
            string userInput = Console.ReadLine();

            while (!isValidInput(userInput))
            {
                Console.WriteLine("Invalid input. Please provide a string with 8 characters that's either all letters or all digits.");
                userInput = Console.ReadLine();
            }
            
            analyzeString(userInput);
        }

        private static void analyzeString(string i_userInputString)
        {
            StringBuilder output = new StringBuilder();

            if (isPalindrome(i_userInputString))
            {
                output.Append(string.Format("The input string is a palindrome. {0}", Environment.NewLine));
            }
            else
            {
                output.Append(string.Format("The input string is not a palindrome. {0}", Environment.NewLine));
            }

            if (isAllDigits(i_userInputString))
            {
                if (isDivisibleByFour(i_userInputString))
                {
                    output.Append(string.Format("The input number is divisible by 4 without a remainder. {0}", Environment.NewLine));
                }
                else
                {
                    output.Append(string.Format("The input number is not divisible by 4. {0}", Environment.NewLine));
                }
            }

            if (isAllEnglishLetters(i_userInputString))
            {
                int uppercaseCount = countUppercaseLetters(i_userInputString);
                output.Append(string.Format("The input string contains {0} uppercase letters. {1}", uppercaseCount, Environment.NewLine));
            }

            Console.WriteLine(output.ToString());
        }

        private static bool isPalindrome(string i_UserStrInput)
        {
            return i_UserStrInput.Length <= 1 ||
                   (i_UserStrInput[0] == i_UserStrInput[i_UserStrInput.Length - 1] &&
                   isPalindrome(i_UserStrInput.Substring(1, i_UserStrInput.Length - 2)));
        }

        private static bool isAllDigits(string i_UserStrInput)
        {
            return i_UserStrInput.All(char.IsDigit);
        }

        private static bool isDivisibleByFour(string i_UserStrInput)
        {
            if (!isAllDigits(i_UserStrInput))
            {
                return false;
            }

            if (int.TryParse(i_UserStrInput, out int userNumberInput))
            {
                return userNumberInput % 4 == 0;
            }
            return false;
        }


        private static bool isAllEnglishLetters(string i_UserStrInput)
        {
            return i_UserStrInput.All(char.IsLetter);
        }

        private static int countUppercaseLetters(string i_UserStrInput)
        {
            int uppercaseCount = 0;

            foreach (char c in i_UserStrInput)
            {
                if (char.IsUpper(c))
                {
                    uppercaseCount++;
                }
            }

            return uppercaseCount;
        }

        private static bool isValidInput(string i_UserStrInput)
        {
            return isLengthValid(i_UserStrInput) && isAllNumbersOrAllLetters(i_UserStrInput);
        }

        private static bool isLengthValid(string i_UserStrInput)
        {
            return i_UserStrInput.Length == 8;
        }


        private static bool isAllNumbersOrAllLetters(string i_UserStrInput)
        {
            bool allNumbers = i_UserStrInput.All(char.IsDigit);
            bool allLetters = i_UserStrInput.All(char.IsLetter);
            bool isAllNumbersOrAllLetters = (allNumbers || allLetters) && !(allNumbers && allLetters);

            return isAllNumbersOrAllLetters;
        }
    }
}