using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : MainMenu
    {
        private readonly string r_BackQuitWord = "Back";

        public MenuItem(string title, List<MenuItem> subMenuItems)
            : base(title, subMenuItems)
        {
        }

        protected override string QuitWord
        {
            get { return r_BackQuitWord; }
        }
    }
}
