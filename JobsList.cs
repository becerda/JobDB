using Job_Application_Database.IO;
using Job_Application_Database.Singleton;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Class For Displaying Jobs Lists
    /// </summary>
    public class JobsListWindow : BaseList
    {
        // Base Constructor
        public JobsListWindow() : base("Job", Jobs.Instance.AllObjects()) { }

        // Add Job To Jobs List
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

        // Edit Job From Jobs List
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

        // Delete Job From Jobs List
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

        // Refreshes The List View
        protected override void RefreshListView()
        {
            _blw.listviewCurrent.ItemsSource = Jobs.Instance.AllObjects();
            ICollectionView view = CollectionViewSource.GetDefaultView(_blw.listviewCurrent.ItemsSource);
            view.Refresh();
        }
    }

}
