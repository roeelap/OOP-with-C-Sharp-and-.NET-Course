using System;
using System.Linq;

namespace Ex01_01
{
    internal class Program
    {
        public static void Main()
        {
            calculateAndDisplayResults();
        }

        private static void calculateAndDisplayResults()
        {
            string[] binaryInputs = get3BinaryInputs();
            int[] decimalNumbers = new int[3];

            for (int i = 0; i < 3; i++)
            {
                decimalNumbers[i] = convertBinaryToDecimal(binaryInputs[i]);
                Console.WriteLine(string.Format("Binary: {0} => Decimal: {1}", binaryInputs[i], decimalNumbers[i]));
            }

            displayAverageZeroesAndOnes(binaryInputs);
            displayPowerOfTwoCount(decimalNumbers);
            displayAscendingNumbersCount(decimalNumbers);
            displayMinMax(decimalNumbers);
            Console.ReadLine();
        }

        private static string[] get3BinaryInputs()
        {

            string[] binaryNumbersInputArr = new string[3];
            int validInputCounter = 0;

            Console.WriteLine("Please enter 3 7-digit binary numbers and press enter (one by one):");
            while (validInputCounter < 3)
            {
                string binaryNumberInput = Console.ReadLine();

                if (isInputValid(binaryNumberInput))
                {
                    binaryNumbersInputArr[validInputCounter] = binaryNumberInput;
                    validInputCounter++;
                }
                else
                {
                    Console.WriteLine("Please enter a valid 7-digit binary number");
                }
            }
            return binaryNumbersInputArr;
        }

        private static bool isInputValid(string i_UserStrInput)
        {
            if (i_UserStrInput.Length != 7)
            {
                return false;
            }

            foreach (char character in i_UserStrInput)
            {
                if (character != '0' && character != '1')
                {
                    return false;
                }
            }
            return true;
        }

        private static int convertBinaryToDecimal(string i_UserStrInput)
        {
            int decimalNumber = 0;

            for (int i = 0; i < i_UserStrInput.Length; i++)
            {
                if (i_UserStrInput[i] == '1')
                {
                    decimalNumber += (int)Math.Pow(2, i_UserStrInput.Length - i - 1);
                }
            }

            return decimalNumber;
        }

        private static void displayAverageZeroesAndOnes(string[] i_BinaryInputs)
        {
            int zeroCount = 0;
            int oneCount = 0;

            foreach (string binary in i_BinaryInputs)
            {
                int currentOneCount = 0;
                int currentZeroCount = 0;

                foreach (char c in binary)
                {
                    if (c == '1')
                    {
                        currentOneCount++;
                    }
                    else if (c == '0')
                    {
                        currentZeroCount++;
                    }
                }

                zeroCount += currentZeroCount;
                oneCount += currentOneCount;
            }

            string averageZerosOutput = string.Format("Average number of zeros: {0}", zeroCount / 3.0);
            Console.WriteLine(averageZerosOutput);

            string averageOnesOutput = string.Format("Average number of ones: {0}", oneCount / 3.0);
            Console.WriteLine(averageOnesOutput);
        }

        private static void displayPowerOfTwoCount(int[] i_DecimalNumbers)
        {
            int powerOfTwoCount = 0;

            foreach (int number in i_DecimalNumbers)
            {
                if (isPowerOfTwo(number))
                {
                    powerOfTwoCount++;
                }
            }
            string powerOfTwoCountOutput = string.Format("{0} number(s) are power of 2", powerOfTwoCount);
            Console.WriteLine(powerOfTwoCountOutput);
        }

        private static bool isPowerOfTwo(int i_DecimalNumber)
        {
            if (i_DecimalNumber <= 0)
            {
                return false;
            }

            double logValue = Math.Log(i_DecimalNumber, 2);
            bool isInteger = logValue == Math.Floor(logValue);

            return isInteger;
        }

        private static void displayAscendingNumbersCount(int[] i_DecimalNumbers)
        {
            int ascendingCount = 0;

            foreach (int number in i_DecimalNumbers)
            {
                if (isAscending(number))
                {
                    ascendingCount++;
                }
            }

            string acendingCountOutput = string.Format("{0} number(s) have digits in ascending order", ascendingCount);
            Console.WriteLine(acendingCountOutput);
        }

        private static bool isAscending(int i_DecimalNumber)
        {
            int lastDigit = 10;

            while (i_DecimalNumber > 0)
            {
                int currentDigit = i_DecimalNumber % 10;
                if (currentDigit >= lastDigit)
                {
                    return false;
                }
                lastDigit = currentDigit;
                i_DecimalNumber /= 10;
            }
            return true;
        }

        private static void displayMinMax(int[] i_DecimalNumbers)
        {
            int maxNumber = i_DecimalNumbers.Max();
            int minNumber = i_DecimalNumbers.Min();
            string maxOutput = string.Format("Largest number: {0}", maxNumber);
            Console.WriteLine(maxOutput);
            string minOutput = string.Format("Smallest number: {0}", minNumber);
            Console.WriteLine(minOutput);
        }

    }
}
