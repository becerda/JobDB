using Job_Application_Database.IO;
using Job_Application_Database.Singleton;
using System.Windows;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Class For Displaying Reps Lists
    /// </summary>
    public class RepsList : BaseList
    {
        /// <summary>
        /// Base Constructor
        /// </summary>
        public RepsList() : base("Rep", Reps.Instance.AllObjects()) { }

        /// <summary>
        /// Add Rep To Reps List
        /// </summary>
        protected override void Add()
        {
            RepCreation jcw = new RepCreation();
            jcw.ShowDialog();
            if (jcw.Exit == Enum.ExitStatus.Ok)
            {
                Reps.Instance.AddObject(jcw.Info);
                Files.Instance.SaveRepFile();
                RefreshListView(Reps.Instance);
            }
        }

        /// <summary>
        /// Edit Rep From Reps List
        /// </summary>
        protected override void Edit()
        {
            Rep r = _blw.listviewCurrent.SelectedItem as Rep;
            if (r != null)
            {
                RepCreation jcw = new RepCreation(r);
                jcw.ShowDialog();
                Files.Instance.SaveRepFile();
                RefreshListView(Reps.Instance);
            }
        }

        /// <summary>
        /// Delete Rep From Reps List
        /// </summary>
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
                    RefreshListView(Reps.Instance);
                }
            }
        }
    }

}
