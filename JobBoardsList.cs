using Job_Application_Database.IO;
using Job_Application_Database.Singleton;
using System.Windows;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Class For Displaying Job Boards Lists
    /// </summary>
    public class JobBoardsList : BaseList
    {
        /// <summary>
        /// Base Constructor
        /// </summary>
        public JobBoardsList() : base("Job Board", JobBoards.Instance.AllObjects()) { }

        /// <summary>
        /// Add Job Board To Boards List
        /// </summary>
        protected override void Add()
        {
            JobBoardCreation bc = new JobBoardCreation();
            bc.ShowDialog();
            if (bc.Exit == Enum.ExitStatus.Ok)
            {
                JobBoards.Instance.AddObject(bc.Info);
                Files.Instance.SaveBoardFile();
                RefreshListView(JobBoards.Instance);
            }
        }

        /// <summary>
        /// Edit Board From Job Boards List
        /// </summary>
        protected override void Edit()
        {
            JobBoard b = _blw.listviewCurrent.SelectedItem as JobBoard;
            if (b != null)
            {
                JobBoardCreation bc = new JobBoardCreation(b);
                bc.ShowDialog();
                Files.Instance.SaveBoardFile();
                RefreshListView(JobBoards.Instance);
            }
        }

        /// <summary>
        /// Delete Board From Job Boards List
        /// </summary>
        protected override void Delete()
        {
            if (_blw.listviewCurrent.SelectedItem != null)
            {
                string msg;
                if (_blw.listviewCurrent.SelectedItems.Count > 1)
                {
                    msg = "these " + _blw.listviewCurrent.SelectedItems.Count + " Boards?";
                }
                else
                {
                    msg = (_blw.listviewCurrent.SelectedItems[0] as IBaseInfo).Name + "?";
                }

                if (MessageBox.Show("Are you sure you want to delete " + msg, "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    foreach (BaseInfo info in _blw.listviewCurrent.SelectedItems)
                    {
                        JobBoards.Instance.RemoveObject(info);
                    }
                    Files.Instance.SaveBoardFile();
                    RefreshListView(JobBoards.Instance);
                }
            }
        }
    }

}
