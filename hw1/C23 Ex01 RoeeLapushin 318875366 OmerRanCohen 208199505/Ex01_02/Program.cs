using System;
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            PrintHourglass(5);
        }

        public static void PrintHourglass(int i_HourglassHeight)
        {
            printHourglassRows(i_HourglassHeight, i_HourglassHeight);
        }

        private static void printHourglassRows(int i_NumStarsInRow, int i_MaxRowLength)
        {
            int numOfSpacesOnEachSide = (i_MaxRowLength - i_NumStarsInRow) / 2;

            if (i_NumStarsInRow <= 1)
            {
                printHourglassRow(1, numOfSpacesOnEachSide);

                return;
            }

            printHourglassRow(i_NumStarsInRow, numOfSpacesOnEachSide);
            printHourglassRows(i_NumStarsInRow - 2, i_MaxRowLength);
            printHourglassRow(i_NumStarsInRow, numOfSpacesOnEachSide);
        }

        private static void printHourglassRow(int i_NumOfStarsInRow, int i_NumOfSpacesOnEachSide)
        {
            StringBuilder hourglassRow = new StringBuilder();

            hourglassRow.Append(' ', i_NumOfSpacesOnEachSide);
            hourglassRow.Append('*', i_NumOfStarsInRow);
            hourglassRow.Append(' ', i_NumOfSpacesOnEachSide);
            Console.WriteLine(hourglassRow.ToString());
        }
    }
}
