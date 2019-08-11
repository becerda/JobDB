using Job_Application_Database.Enum;
using Job_Application_Database.Singleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Base Class For Displaying Singleton Lists
    /// </summary>
    public abstract class BaseList : BaseWindow
    {
        /// <summary>
        /// Reference To The Base List Window
        /// </summary>
        protected BaseListWindow BaseListWindow
        {
            get
            {
                return (BaseListWindow)base.Window;
            }
        }

        /// <summary>
        /// The Exit Status Of Base List Window
        /// </summary>
        public override ExitStatus Exit
        {
            get
            {
                return BaseListWindow.Exit;
            }
            set
            {
                BaseListWindow.Exit = value;
            }
        }

        /// <summary>
        /// Construtor To Create A New BaseListWindow
        /// </summary>
        /// <param name="title">The Title Of The Window</param>
        /// <param name="info">The Source</param>
        public BaseList(String title, List<BaseInfo> info) : base(new BaseListWindow(), title)
        {
            BaseListWindow.Loaded += Window_Loaded;
            BaseListWindow.Closing += Window_Closing;
            BaseListWindow.KeyDown += Window_KeyDown;

            BaseListWindow.listviewCurrent.ItemsSource = info;
            BaseListWindow.Title = "Edit " + title + "s";
            BaseListWindow.buttonAdd.Content = "Add " + title;
            BaseListWindow.buttonDelete.Content = "Delete " + title;
            BaseListWindow.buttonEdit.Content = "Edit " + title;
        }

        /// <summary>
        /// Overrided Window Loaded Event Method
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Style s = new Style();
            s.Setters.Add(new EventSetter(Control.MouseDoubleClickEvent, new MouseButtonEventHandler(Element_DoubleClick)));
            BaseListWindow.listviewCurrent.ItemContainerStyle = s;

            BaseListWindow.buttonAdd.Click += Element_Click;
            BaseListWindow.buttonDelete.Click += Element_Click;
            BaseListWindow.buttonEdit.Click += Element_Click;
        }

        /// <summary>
        /// Window Closing Event Method
        /// Handles Exit Status Flow
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Window_Closing(object sender, CancelEventArgs e) { }

        /// <summary>
        /// Window Key Down Event Method
        /// Handles Enter And Escape Key Presses
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.N && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Add();
            }
            else if (e.Key == Key.E && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Edit();
            }
            else if (e.Key == Key.Delete)
            {
                Delete();
            }
            else if (e.Key == Key.Escape)
            {
                BaseListWindow.Close();
            }
        }

        /// <summary>
        /// Window Button Click Method
        /// Handles Button Presses
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Element_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == BaseListWindow.buttonAdd)
            {
                Add();
            }
            else if (e.Source == BaseListWindow.buttonDelete)
            {
                Delete();
            }
            else if (e.Source == BaseListWindow.buttonEdit)
            {
                Edit();
            }

            e.Handled = true;
            Exit = ExitStatus.Ok;
        }

        /// <summary>
        /// ListView Double Click Method
        /// Handles Mouse Double Click On listviewCurrent
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Element_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Edit();
        }

        /// <summary>
        /// Adds A New BaseInfo To A Singleton
        /// </summary>
        protected abstract void Add();

        /// <summary>
        /// Deletes A BaseInfo From A Singleton
        /// </summary>
        protected abstract void Delete();

        /// <summary>
        /// Edits A BaseInfo From A Singleton
        /// </summary>
        protected abstract void Edit();

        /// <summary>
        /// Refreshes The List View
        /// </summary>
        /// <param name="bs"></param>
        protected void RefreshListView(BaseSingleton bs)
        {
            BaseListWindow.listviewCurrent.ItemsSource = bs.AllObjects();
            ICollectionView view = CollectionViewSource.GetDefaultView(BaseListWindow.listviewCurrent.ItemsSource);
            view.Refresh();
        }

    }
}
