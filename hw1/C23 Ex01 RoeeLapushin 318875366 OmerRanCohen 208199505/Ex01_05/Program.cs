using System;

namespace Ex01_05
{
    public class Program
    {
        private static readonly int sr_ExpectedNumOfDigitsInInput = 6;

        public static void Main()
        {
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.WriteLine("Please enter a 6 digit Integer (and then press enter):");
                string userInput = Console.ReadLine();
                isValidInput = is6DigitInteger(userInput);

                if (isValidInput)
                {
                    printStatistics(userInput);

                    return;
                }

                Console.WriteLine(string.Format("{0} is not a valid input", userInput));
            }
        }

        private static bool is6DigitInteger(string i_InputString)
        {
            bool isInteger = int.TryParse(i_InputString, out _);
            bool is6DigitPositiveInteger = i_InputString.Length == sr_ExpectedNumOfDigitsInInput && !i_InputString.Contains("-");
            bool is6DigitNegativeInteger = i_InputString.Length == sr_ExpectedNumOfDigitsInInput + 1 && i_InputString.StartsWith("-");

            return isInteger && (is6DigitPositiveInteger || is6DigitNegativeInteger);
        }

        private static void printStatistics(string i_InputNumString)
        {
            Console.WriteLine(string.Format("Statistics about {0}:", i_InputNumString));
            Console.WriteLine("===========================");
            Console.WriteLine(string.Format("{0} digits are greater than the least significant digit.", getNumDigitsGreaterThanLeastSignificantDigit(i_InputNumString)));
            Console.WriteLine(string.Format("{0} is the smallest digit.", getSmallestDigit(i_InputNumString)));
            Console.WriteLine(string.Format("{0} digits are divisible by 3.", getNumDigitsDivisibleBy3(i_InputNumString)));
            Console.WriteLine(string.Format("{0} is the average of the digits.", getDigitAverage(i_InputNumString)));
        }

        private static float getDigitAverage(string i_InputNumString)
        {
            float sum = 0;

            for (int i = 0; i < i_InputNumString.Length; i++)
            {
                char currDigitChar = i_InputNumString[i];
                if (currDigitChar == '-')
                {
                    continue;
                }

                int currDigit = currDigitChar - '0';
                sum += currDigit;
            }

            return sum / sr_ExpectedNumOfDigitsInInput;
        }

        private static int getNumDigitsDivisibleBy3(string i_InputNumString)
        {
            int numDigitsDivisibleBy3 = 0;

            for (int i = 0; i < i_InputNumString.Length; i++)
            {
                char currDigitChar = i_InputNumString[i];
                if (currDigitChar == '-')
                {
                    continue;
                }

                int currDigit = currDigitChar - '0';

                if (currDigit % 3 == 0)
                {
                    numDigitsDivisibleBy3++;
                }
            }

            return numDigitsDivisibleBy3;
        }

        private static int getNumDigitsGreaterThanLeastSignificantDigit(string i_InputNumString)
        {
            int totalDigits = 0;
            int leastSignificantDigit = i_InputNumString[i_InputNumString.Length - 1];

            for (int i = 0; i < i_InputNumString.Length - 1; i++)
            {
                if (i_InputNumString[i] > leastSignificantDigit)
                {
                    totalDigits++;
                }
            }

            return totalDigits;
        }

        private static char getSmallestDigit(string i_InputNumString)
        {
            char smallestDigit = i_InputNumString[i_InputNumString.Length - 1];

            for (int i = 0; i < i_InputNumString.Length - 1; i++)
            {
                char currDigit = i_InputNumString[i];

                if (currDigit < smallestDigit && currDigit != '-')
                {
                    smallestDigit = currDigit;
                }
            }

            return smallestDigit;
        }
    }
}
