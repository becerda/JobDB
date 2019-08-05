using System.Windows.Input;

namespace Job_Application_Database.Commands
{
    /// <summary>
    /// Menu Commands (Not In Use)
    /// </summary>
    public static class MenuCommands
    {
        // New Menu Command
        public static readonly RoutedUICommand New = new RoutedUICommand
        (
            "_New",
            "New",
            typeof(MenuCommands),
            new InputGestureCollection()
            {
                    new KeyGesture(Key.N, ModifierKeys.Control)
            }
        );

        // Open Menu Command
        public static readonly RoutedUICommand Open = new RoutedUICommand
        (
            "_Open",
            "Open",
            typeof(MenuCommands),
            new InputGestureCollection()
            {
                    new KeyGesture(Key.O, ModifierKeys.Control)
            }
        );

        // Save Menu Command
        public static readonly RoutedUICommand Save = new RoutedUICommand
        (
            "_Save",
            "Save",
            typeof(MenuCommands),
            new InputGestureCollection()
            {
                    new KeyGesture(Key.S, ModifierKeys.Control)
            }
        );

        // Exit Menu Command
        public static readonly RoutedUICommand Exit = new RoutedUICommand
        (
            "Exit",
            "Exit",
            typeof(MenuCommands),
            new InputGestureCollection()
            {
                    new KeyGesture(Key.F4, ModifierKeys.Alt)
            }
        );

        // Add Company Menu Command
        public static readonly RoutedUICommand Add = new RoutedUICommand
        (
            "_Add",
            "Add",
            typeof(MenuCommands),
            new InputGestureCollection()
            {
                    new KeyGesture(Key.A, ModifierKeys.Control)
            }
        );

        // Delete Company Menu Command
        public static readonly RoutedUICommand Delete = new RoutedUICommand
        (
            "Delete",
            "Delete",
            typeof(MenuCommands),
            new InputGestureCollection()
            {
                    new KeyGesture(Key.Delete)
            }
        );
    }

}

