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
        // The Base List Window
        protected BaseListWindow _blw;

        // The Exit Status Of Base List Window
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

        // Default Constructor
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
            _blw.KeyDown += new KeyEventHandler(JobTitleWindow_KeyDown);
        }

        // On Window Closing Handler
        private void Window_Closing(object sender, CancelEventArgs e) { }

        // Key Down Event Handler (Hot Keys)
        private void JobTitleWindow_KeyDown(object sender, KeyEventArgs e)
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

        // On Button Clicked Handler
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

        // List View Item Double Click Handler
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Edit();
        }

        // Adds A New BaseInfo To A Singleton
        protected abstract void Add();

        // Deletes A BaseInfo From A Singleton
        protected abstract void Delete();

        // Edits A BaseInfo From A Singleton
        protected abstract void Edit();

        // Refreshes The List View
        protected virtual void RefreshListView()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(_blw.listviewCurrent.ItemsSource);
            view.Refresh();

        }

        // Shows The Base List Window Dialog
        public void ShowDialog()
        {
            _blw.ShowDialog();
        }
    }

}
