using System;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            bool isValidHeight = false;

            while (!isValidHeight)
            {
                Console.WriteLine("Please type the desired height of your hourglass (and then press enter):");
                string heightInput = Console.ReadLine();
                int height = parseHeightIfValid(heightInput);

                if (height > 0)
                {
                    if (height % 2 == 0)
                    {
                        height++; // we add a line in the middle so the hourglass will be symetrical
                    }

                    Ex01_02.Program.PrintHourglass(height);

                    return;
                }
                
                Console.WriteLine(string.Format("{0} is not a valid input, expecting a positive integer!", heightInput));
            }
        }

        /**
         * returns the height as an int if i_HeightString represents a valid positive integer. returns 0 otherwise. 
         */
        private static int parseHeightIfValid(string i_HeightString)
        {
            int parsedHeight;

            if (!int.TryParse(i_HeightString, out parsedHeight)) return 0;

            return parsedHeight;
        }
    }
}
