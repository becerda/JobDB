using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Job_Application_Database.Commands
{
    public static class MenuCommands
    {
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

