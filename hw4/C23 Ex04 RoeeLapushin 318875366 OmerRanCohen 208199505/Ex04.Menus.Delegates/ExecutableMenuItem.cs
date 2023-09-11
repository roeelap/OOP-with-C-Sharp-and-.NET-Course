namespace Ex04.Menus.Delegates
{
    public delegate void ExecuteMenuItemDelegate();

    public class ExecutableMenuItem : MenuItem
    {
        public ExecutableMenuItem(string i_Title)
            : base(i_Title, null)
        {
        }

        public event ExecuteMenuItemDelegate Executed;

        public void Execute()
        {
            OnExecute();
        }

        protected virtual void OnExecute()
        {
            if (Executed != null)
            {
                Executed.Invoke();
            }
        }
    }
}
