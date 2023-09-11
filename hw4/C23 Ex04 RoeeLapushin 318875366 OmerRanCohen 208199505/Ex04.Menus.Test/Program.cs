namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            DelegatesTester.TestDelegatesMainMenu();

            InterfacesTester interfaceTestObserver = new InterfacesTester();
            interfaceTestObserver.TestMainMenu();
        }
    }
}
