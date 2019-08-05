using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Job_Application_Database.Classes;
using System.Linq;
using Job_Application_Database.IO;
using Job_Application_Database.Singleton;
using System.Collections.Generic;

namespace Job_Application_Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /*private Companies _cm;
        private Jobs _jm;
        private Reps _rm;
        private Files _fm;

        private bool _isSaved = true;

        private GridViewColumnHeader _sortCol;
        private ListSortDirection _sortDir;

        private string _title = "Job Application Database";*/

        public Enum.ExitStatus Exit { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Exit = Enum.ExitStatus.Cancel;

            /*
            _cm = Companies.Instance;
            _jm = Jobs.Instance;
            _rm = Reps.Instance;
            _fm = Files.Instance;

            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
            */
        }
        /*
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fm.LoadRepFile();
            _fm.LoadJobFile();
            _fm.LoadBoardFile();

            if (Properties.Settings.Default.AutoLoadLastFile)
            {
                menuItemAutoload.IsChecked = true;
                if (Properties.Settings.Default.LastLoadedFile.Length > 1)
                {
                    _fm.LoadCompanyFile(Properties.Settings.Default.LastLoadedFile);
                }
            }

            if (Properties.Settings.Default.AutoSave)
                menuItemAutoSave.IsChecked = true;
            listviewCompanies.ItemsSource = _cm.AllObjects();
            RefreshListView();

            // Sorts list alphabetically 
            Binding b = gridviewcolCompany.DisplayMemberBinding as Binding;
            ICollectionView result = CollectionViewSource.GetDefaultView(listviewCompanies.ItemsSource);
            result.SortDescriptions.Clear();
            result.SortDescriptions.Add(new SortDescription(b.Path.Path, ListSortDirection.Ascending));
            gridviewcolCompany.HeaderTemplate = Resources["ArrowUp"] as DataTemplate;
            _sortDir = ListSortDirection.Ascending;

            textboxSearch.TextChanged += SearchBox_TextChanged;
            textboxSearch.LostFocus += SearchBox_FocusChanged;
            textboxSearch.GotFocus += SearchBox_FocusChanged;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!_isSaved)
            {
                MessageBoxResult result = MessageBox.Show("Warning: Content not saved.\nAre you sure you want to exit?", "Content Not Saved", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }


        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = from Emp in _cm.AllObjects()
                         let name = Emp.Name
                         where name.ToUpper().StartsWith(textboxSearch.Text.ToUpper())
                         select Emp;

            RefreshListView(filter);
        }

        private void SearchBox_FocusChanged(object sender, RoutedEventArgs e)
        {
            if (textboxSearch.IsFocused)
            {
                textboxSearch.Text = "";
            }
            else
            {
                textboxSearch.TextChanged -= SearchBox_TextChanged;
                textboxSearch.Text = "Search...";
                textboxSearch.TextChanged += SearchBox_TextChanged;
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.N && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                AddCompany();
            }
            else if (e.Key == Key.O && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                OpenFile();
            }
            else if (e.Key == Key.S && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                SaveCompanyFile();
            }
            else if (e.Key == Key.E && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                EditCompany();
            }
            else if (e.Key == Key.Delete)
            {
                DeleteCompany();
            }
            else if (e.Key == Key.T && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                EditJobs();
            }
        }

        public void ListViewHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader col = e.OriginalSource as GridViewColumnHeader;

            if (col == null) { return; }

            if (_sortCol == col)
            {
                _sortDir = _sortDir == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
            }
            else
            {
                if (_sortCol != null)
                {
                    _sortCol.Column.HeaderTemplate = null;
                }

                _sortCol = col;
                _sortDir = ListSortDirection.Ascending;
            }

            if (_sortDir == ListSortDirection.Ascending)
            {
                col.Column.HeaderTemplate = Resources["ArrowUp"] as DataTemplate;
            }
            else
            {
                col.Column.HeaderTemplate = Resources["ArrowDown"] as DataTemplate;
            }

            string header = string.Empty;

            Binding b = _sortCol.Column.DisplayMemberBinding as Binding;
            if (b != null)
            {
                header = b.Path.Path;
            }

            ICollectionView result = CollectionViewSource.GetDefaultView(listviewCompanies.ItemsSource);
            result.SortDescriptions.Clear();
            result.SortDescriptions.Add(new SortDescription(header, _sortDir));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == buttonNewCompany)
            {
                AddCompany();
            }
            else if (e.Source == buttonEditCompany)
            {
                EditCompany();
            }
            else if (e.Source == buttonDeleteCompany)
            {
                DeleteCompany();
            }
            else if (e.Source == buttonEditJobs)
            {
                EditJobs();
            }
            else if (e.Source == buttonEditReps)
            {
                EditReps();
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditCompany();
        }

        private void MenuCommand_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == menuitemSave)
            {
                SaveCompanyFile();
            }
            else if (e.Source == menuitemOpen)
            {
                OpenFile();
            }
            else if (e.Source == menuitemExit)
            {
                Close();
            }
            else if (e.Source == menuitemNew)
            {
                AddCompany();
            }
            else if (e.Source == menuitemEdit)
            {
                EditCompany();
            }
            else if (e.Source == menuitemDelete)
            {
                DeleteCompany();
            }
            else if (e.Source == menuItemAutoload)
            {
                if (menuItemAutoload.IsChecked)
                    Properties.Settings.Default.AutoLoadLastFile = true;
                else
                    Properties.Settings.Default.AutoLoadLastFile = false;
            }
            else if (e.Source == menuItemAutoSave)
            {
                if (menuItemAutoSave.IsChecked)
                    Properties.Settings.Default.AutoSave = true;
                else
                    Properties.Settings.Default.AutoSave = false;
            }
        }

        private void OpenFile()
        {

            _fm.OpenCompanyFile();
            listviewCompanies.ItemsSource = _cm.AllObjects();
            RefreshListView();
        }

        private void SaveCompanyFile()
        {
            _fm.SaveCompanyFile();
            MarkSaved();
        }

        private void AddCompany()
        {
            Company c = new Company();
            CompanyCreation aec = new CompanyCreation(ref c, Enum.EditMode.New);
            aec.ShowDialog();
            if (aec.Exit == Enum.ExitStatus.Ok)
            {
                _cm.AddObject(aec.Company);
                RefreshListView();
                MarkUnsaved();
            }
        }

        private void EditCompany()
        {

            Company c = listviewCompanies.SelectedItem as Company;
            if (c != null)
            {
                CompanyCreation aec = new CompanyCreation(ref c, Enum.EditMode.Edit);
                aec.ShowDialog();
                RefreshListView();
                MarkUnsaved();
            }
        }

        private void DeleteCompany()
        {

            if (listviewCompanies.SelectedItem != null)
            {
                string msg;
                if (listviewCompanies.SelectedItems.Count > 1)
                {
                    msg = "these " + listviewCompanies.SelectedItems.Count + " companies?";
                }
                else
                {
                    msg = (listviewCompanies.SelectedItems[0] as Company).Name + "?";
                }
                if (MessageBox.Show("Are you sure you want to delete " + msg, "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    foreach (Company comp in listviewCompanies.SelectedItems)
                    {
                        _cm.RemoveObject(comp);
                    }
                    RefreshListView();
                    MarkUnsaved();
                }
            }
        }

        private void EditJobs()
        {
            new JobsListWindow().ShowDialog();
        }

        private void EditReps()
        {
            new RepsListWindow().ShowDialog();
        }

        private void MarkUnsaved()
        {
            if (Properties.Settings.Default.AutoSave)
            {
                SaveCompanyFile();
            }
            else
            {
                this.Title = _title + "*";
                _isSaved = false;
            }

        }

        private void MarkSaved()
        {
            this.Title = _title;
            _isSaved = true;
        }

        private void RefreshListView()
        {
            RefreshListView(_cm.AllObjects());
        }

        private void RefreshListView(IEnumerable<BaseInfo> source)
        {
            if (source != null)
            {
                listviewCompanies.ItemsSource = source;
                ICollectionView view = CollectionViewSource.GetDefaultView(listviewCompanies.ItemsSource);
                view.Refresh();
                labelCount.Content = "Count: " + source.ToList<BaseInfo>().Count;
            }
        }*/
    }
}
