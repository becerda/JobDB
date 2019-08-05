using Job_Application_Database.Classes;
using Job_Application_Database.IO;
using Job_Application_Database.Singleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Job_Application_Database
{
    /// <summary>
    /// Interaction logic for AddEditJobTitleWindow.xaml
    /// </summary>
    public abstract class BaseList
    {
        protected BaseListWindow _blw;


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

        private void Window_Closing(object sender, CancelEventArgs e) { }

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

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Edit();
        }

        protected abstract void Add();

        protected abstract void Delete();

        protected abstract void Edit();

        protected virtual void RefreshListView()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(_blw.listviewCurrent.ItemsSource);
            view.Refresh();

        }

        public void ShowDialog()
        {
            _blw.ShowDialog();
        }
    }



    public class JobsListWindow : BaseList
    {
        public JobsListWindow() : base("Job", Jobs.Instance.AllObjects()) { }

        protected override void Add()
        {
            JobCreation jcw = new JobCreation();
            jcw.ShowDialog();
            if (jcw.Exit == Enum.ExitStatus.Ok)
            {
                Jobs.Instance.AddObject(jcw.Info);
                Files.Instance.SaveJobFile();
                RefreshListView();
            }
        }

        protected override void Edit()
        {
            Job j = _blw.listviewCurrent.SelectedItem as Job;
            if (j != null)
            {
                JobCreation jcw = new JobCreation(j);
                jcw.ShowDialog();
                Files.Instance.SaveJobFile();
                RefreshListView();
            }
        }

        protected override void Delete()
        {
            if (_blw.listviewCurrent.SelectedItem != null)
            {
                string msg;
                if (_blw.listviewCurrent.SelectedItems.Count > 1)
                {
                    msg = "these " + _blw.listviewCurrent.SelectedItems.Count + " Jobs?";
                }
                else
                {
                    msg = (_blw.listviewCurrent.SelectedItems[0] as IBaseInfo).Name + "?";
                }

                if (MessageBox.Show("Are you sure you want to delete " + msg, "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    foreach (BaseInfo info in _blw.listviewCurrent.SelectedItems)
                    {
                        Jobs.Instance.RemoveObject(info);
                    }
                    Files.Instance.SaveJobFile();
                    RefreshListView();
                }
            }
        }

        protected override void RefreshListView()
        {
            _blw.listviewCurrent.ItemsSource = Jobs.Instance.AllObjects();
            ICollectionView view = CollectionViewSource.GetDefaultView(_blw.listviewCurrent.ItemsSource);
            view.Refresh();
        }
    }

    public class RepsListWindow : BaseList
    {
        public RepsListWindow() : base("Rep", Reps.Instance.AllObjects()) { }

        protected override void Add()
        {
            RepCreation jcw = new RepCreation();
            jcw.ShowDialog();
            if (jcw.Exit == Enum.ExitStatus.Ok)
            {
                Reps.Instance.AddObject(jcw.Info);
                Files.Instance.SaveRepFile();
                RefreshListView();
            }
        }

        protected override void Edit()
        {
            Rep r = _blw.listviewCurrent.SelectedItem as Rep;
            if (r != null)
            {
                RepCreation jcw = new RepCreation(r);
                jcw.ShowDialog();
                Files.Instance.SaveRepFile();
                RefreshListView();
            }
        }

        protected override void Delete()
        {
            if (_blw.listviewCurrent.SelectedItem != null)
            {
                string msg;
                if (_blw.listviewCurrent.SelectedItems.Count > 1)
                {
                    msg = "these " + _blw.listviewCurrent.SelectedItems.Count + " Reps?";
                }
                else
                {
                    msg = (_blw.listviewCurrent.SelectedItems[0] as IBaseInfo).Name + "?";
                }

                if (MessageBox.Show("Are you sure you want to delete " + msg, "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    foreach (BaseInfo info in _blw.listviewCurrent.SelectedItems)
                    {
                        Reps.Instance.RemoveObject(info);
                    }
                    Files.Instance.SaveRepFile();
                    RefreshListView();
                }
            }
        }

        protected override void RefreshListView()
        {
            _blw.listviewCurrent.ItemsSource = Reps.Instance.AllObjects();
            ICollectionView view = CollectionViewSource.GetDefaultView(_blw.listviewCurrent.ItemsSource);
            view.Refresh();
        }
    }
}
