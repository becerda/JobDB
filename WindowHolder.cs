using Job_Application_Database.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Job_Application_Database
{
    /// <summary>
    /// Base Class For Any Class That Holds A Window Object
    /// </summary>
    public abstract class BaseWindow 
    {
        /// <summary>
        /// Reference To The Window
        /// </summary>
        protected Window Window { get;  set; }

        /// <summary>
        /// The Title Of The Window
        /// </summary>
        protected string Title { get; set; }

        /// <summary>
        /// Will Come Back To this
        /// </summary>
        public abstract ExitStatus Exit { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BaseWindow(Window window, string title)
        {
            Window = window;
            Window.Title = title;

            Window.Loaded += Window_Loaded;
            Window.Closing += Window_Closing;
            Window.KeyDown += Window_KeyDown;
        }

        /// <summary>
        /// Delegated Window Loaded Event Method
        /// </summary>
        /// <param name="sender">The Object That Called Triggered This Event</param>
        /// <param name="e">The Event Arguments</param>
        protected virtual void Window_Loaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delegated Window Closing Event Method
        /// </summary>
        /// <param name="sender">The Object That Called Triggered This Event</param>
        /// <param name="e">The Event Arguments</param>
        protected virtual void Window_Closing(object sender, CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delegated Window Key Down Event Method
        /// </summary>
        /// <param name="sender">The Object That Called Triggered This Event</param>
        /// <param name="e">The Event Arguments</param>
        protected virtual void Window_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delegated Element Click Event Method
        /// </summary>
        /// <param name="sender">The Object That Called Triggered This Event</param>
        /// <param name="e">The Event Arguments</param>
        protected virtual void Element_Click(object sender, RoutedEventArgs e) { }

        /// <summary>
        /// Delegated Element Double Click Event Method
        /// </summary>
        /// <param name="sender">The Object That Called Triggered This Event</param>
        /// <param name="e">The Event Arguments</param>
        protected virtual void Element_DoubleClick(object sender, MouseButtonEventArgs e) { }

        /// <summary>
        /// Delegated Element Text Changed Event Method
        /// </summary>
        /// <param name="sender">The Object That Called Triggered This Event</param>
        /// <param name="e">The Event Arguments</param>
        protected virtual void Element_TextChanged(object sender, TextChangedEventArgs e) { }

        /// <summary>
        /// Delegated Element Focus Changed Event Method
        /// </summary>
        /// <param name="sender">The Object That Called Triggered This Event</param>
        /// <param name="e">The Event Arguments</param>
        protected virtual void Element_FocusChanged(object sender, RoutedEventArgs e) { }

        /// <summary>
        /// Delegate Element Mouse Down Event Method
        /// </summary>
        /// <param name="sender">The Object That Called Triggered This Event</param>
        /// <param name="e">The Event Arguments</param>
        protected virtual void Element_MouseDown(object sender, MouseEventArgs e) { }


        public void ShowDialog()
        {
            Window.ShowDialog();
        }

        public void Show()
        {
            Window.Show();
        }
    }
}
