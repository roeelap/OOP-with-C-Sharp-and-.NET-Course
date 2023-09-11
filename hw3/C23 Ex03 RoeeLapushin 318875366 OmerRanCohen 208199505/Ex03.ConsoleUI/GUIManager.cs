using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ex03.ConsoleUI
{
    internal static class GUIManager
    {
        internal static Dictionary<PropertyInfo, string> GetVehicleDetailsFromUser(List<PropertyInfo> i_properties)
        {
            Dictionary<PropertyInfo, string> vehicleDetails = new Dictionary<PropertyInfo, string>();

            foreach (PropertyInfo property in i_properties)
            {
                vehicleDetails[property] = AskUserForInput(string.Format(Messages.sr_AskForProperty, property.Name));
            }

            return vehicleDetails;
        }

        internal static void DisplayMessage(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        internal static string AskUserForInput(string i_Message)
        {
            Console.WriteLine(i_Message);

            return Console.ReadLine();
        }

        internal static void DisplayListAndHeader(List<string> i_List, string i_Header = null)
        {
            if (i_Header != null)
            {
                Console.WriteLine(i_Header);
            }

            i_List.ForEach(Console.WriteLine);
        }
    }
}