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
    public abstract class BaseList
    {
        /// <summary>
        /// Reference To The Base List Window
        /// </summary>
        protected BaseListWindow _blw;

        /// <summary>
        /// The Exit Status Of Base List Window
        /// </summary>
        public Enum.ExitStatus Exit
        {
            get
            {
                return _blw.Exit;
            }
            set
            {
                _blw.Exit = value;
            }
        }

        /// <summary>
        /// Construtor To Create A New BaseListWindow
        /// </summary>
        /// <param name="title">The Title Of The Window</param>
        /// <param name="info">The Source</param>
        public BaseList(String title, List<BaseInfo> info)
        {

            _blw = new BaseListWindow();

            _blw.Title = "Edit " + title + "s";
            _blw.buttonAdd.Content = "Add " + title;
            _blw.buttonDelete.Content = "Delete " + title;
            _blw.buttonEdit.Content = "Edit " + title;

            Style s = new Style();
            s.Setters.Add(new EventSetter(Control.MouseDoubleClickEvent, new MouseButtonEventHandler(ListViewItem_MouseDoubleClick)));
            _blw.listviewCurrent.ItemContainerStyle = s;
            _blw.listviewCurrent.ItemsSource = info;

            _blw.buttonAdd.Click += Button_Click;
            _blw.buttonDelete.Click += Button_Click;
            _blw.buttonEdit.Click += Button_Click;
            _blw.Closing += Window_Closing;
            _blw.KeyDown += new KeyEventHandler(Window_KeyDown);
        }

        /// <summary>
        /// Window Closing Event Method
        /// Handles Exit Status Flow
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        private void Window_Closing(object sender, CancelEventArgs e) { }

        /// <summary>
        /// Window Key Down Event Method
        /// Handles Enter And Escape Key Presses
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
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
                _blw.Close();
            }
        }

        /// <summary>
        /// Window Button Click Method
        /// Handles Button Presses
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == _blw.buttonAdd)
            {
                Add();
            }
            else if (e.Source == _blw.buttonDelete)
            {
                Delete();
            }
            else if (e.Source == _blw.buttonEdit)
            {
                Edit();
            }

            Exit = Enum.ExitStatus.Ok;
        }

        /// <summary>
        /// ListView Double Click Method
        /// Handles Mouse Double Click On listviewCurrent
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
            _blw.listviewCurrent.ItemsSource = bs.AllObjects();
            ICollectionView view = CollectionViewSource.GetDefaultView(_blw.listviewCurrent.ItemsSource);
            view.Refresh();
        }

        /// <summary>
        /// Shows The Base List Window Dialog
        /// </summary>
        public void ShowDialog()
        {
            _blw.ShowDialog();
        }
    }

}
