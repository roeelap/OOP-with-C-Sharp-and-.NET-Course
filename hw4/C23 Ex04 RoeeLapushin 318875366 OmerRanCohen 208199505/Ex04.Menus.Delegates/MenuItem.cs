using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MenuItem : MainMenu
    {
        private readonly string r_BackQuitWord = "Back";

        public MenuItem(string i_Title, List<MenuItem> i_SubMenuItems)
            : base(i_Title, i_SubMenuItems)
        {
        }

        protected override string QuitWord
        {
            get { return r_BackQuitWord; }
        }
    }
}
