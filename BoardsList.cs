using Job_Application_Database.IO;
using Job_Application_Database.Singleton;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Class For Displaying Job Boards Lists
    /// </summary>
    public class BoardsListWindow : BaseList
    {
        // Base Constructor
        public BoardsListWindow() : base("Job Board", Boards.Instance.AllObjects()) { }

        // Add Job Board To Boards List
        protected override void Add()
        {
            BoardCreation bc = new BoardCreation();
            bc.ShowDialog();
            if (bc.Exit == Enum.ExitStatus.Ok)
            {
                Boards.Instance.AddObject(bc.Info);
                Files.Instance.SaveBoardFile();
                RefreshListView(Boards.Instance);
            }
        }

        // Edit Board From Job Boards List
        protected override void Edit()
        {
            Board b = _blw.listviewCurrent.SelectedItem as Board;
            if (b != null)
            {
                BoardCreation bc = new BoardCreation(b);
                bc.ShowDialog();
                Files.Instance.SaveBoardFile();
                RefreshListView(Boards.Instance);
            }
        }

        // Delete Board From Job Boards List
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
                        Boards.Instance.RemoveObject(info);
                    }
                    Files.Instance.SaveBoardFile();
                    RefreshListView(Boards.Instance);
                }
            }
        }
    }

}
