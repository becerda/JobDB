using Job_Application_Database.IO;
using Job_Application_Database.Singleton;
using System.Windows;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Class For Displaying Jobs Lists
    /// </summary>
    public class JobsList : BaseList
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public JobsList() : base("Job", Jobs.Instance.AllObjects()) { }

        /// <summary>
        /// Add Job To Jobs List
        /// </summary>
        protected override void Add()
        {
            JobCreation jcw = new JobCreation();
            jcw.ShowDialog();
            if (jcw.Exit == Enum.ExitStatus.Ok)
            {
                Jobs.Instance.AddObject(jcw.Info);
                Files.Instance.SaveJobFile();
                RefreshListView(Jobs.Instance);
            }
        }

        /// <summary>
        /// Edit Job From Jobs List
        /// </summary>
        protected override void Edit()
        {
            Job j = BaseListWindow.listviewCurrent.SelectedItem as Job;
            if (j != null)
            {
                JobCreation jcw = new JobCreation(j);
                jcw.ShowDialog();
                Files.Instance.SaveJobFile();
                RefreshListView(Jobs.Instance);
            }
        }

        /// <summary>
        /// Delete Job From Jobs List
        /// </summary>
        protected override void Delete()
        {
            if (BaseListWindow.listviewCurrent.SelectedItem != null)
            {
                string msg;
                if (BaseListWindow.listviewCurrent.SelectedItems.Count > 1)
                {
                    msg = "these " + BaseListWindow.listviewCurrent.SelectedItems.Count + " Jobs?";
                }
                else
                {
                    msg = (BaseListWindow.listviewCurrent.SelectedItems[0] as IBaseInfo).Name + "?";
                }

                if (MessageBox.Show("Are you sure you want to delete " + msg, "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    foreach (BaseInfo info in BaseListWindow.listviewCurrent.SelectedItems)
                    {
                        Jobs.Instance.RemoveObject(info);
                    }
                    Files.Instance.SaveJobFile();
                    RefreshListView(Jobs.Instance);
                }
            }
        }
    }

}
