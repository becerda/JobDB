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
using Job_Application_Database.Enum;
using System.Windows.Media;

namespace Job_Application_Database
{
    /// <summary>
    /// Starting Point For Program
    /// </summary>
    class Main
    {
        // The Main Window
        private MainWindow _mw;

        // Reference To Companies Singleton
        private Companies _cm;

        // Reference To Files Singleton
        private Files _fm;

        // To Keep Track Of Saved State
        private bool _saved = true;

        // To Keep Track Of Sorted Column
        private GridViewColumnHeader _sortCol;

        // To Keep Track Of Sorted Direction
        private ListSortDirection _sortDir;

        // To Keep Track Of Current Sort Header
        private string _sortHeader = "Company";

        // Current Title Of Application
        private string _title = Properties.Settings.Default.MainWindowTitle;

        // Default Constructor
        public Main()
        {
            // Create Window & Add Event Handlers
            _mw = new MainWindow();
            _mw.Loaded += MainWindow_Loaded;
            _mw.Closing += MainWindow_Closing;
            _mw.KeyDown += MainWindow_KeyDown;
            //_mw.Closed += (sender, e) => _mw.Dispatcher.InvokeShutdown();
        }

        // On Window Loaded Handler
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Set Singleton References
            _cm = Companies.Instance;
            _fm = Files.Instance;

            // Add Event Handlers To Views
            //////////////////////////////////

            // Menu Item Events
            _mw.menuitemOpen.Click += MenuItem_Click;
            _mw.menuitemSave.Click += MenuItem_Click;
            _mw.menuitemExit.Click += MenuItem_Click;
            _mw.menuitemNew.Click += MenuItem_Click;
            _mw.menuitemEdit.Click += MenuItem_Click;
            _mw.menuitemDelete.Click += MenuItem_Click;
            _mw.menuItemAutoload.Click += MenuItem_Click;
            _mw.menuItemAutoSave.Click += MenuItem_Click;

            // Search Text Box Events
            _mw.textboxSearch.TextChanged += SearchBox_TextChanged;
            _mw.textboxSearch.LostFocus += SearchBox_FocusChanged;
            _mw.textboxSearch.GotFocus += SearchBox_FocusChanged;

            // List View Header Events
            _mw.listviewCompanies.AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(ListViewHeader_Click));
            _mw.listviewCompanies.MouseDoubleClick += ListViewItem_MouseDoubleClick;

            // Button Events
            _mw.buttonNewCompany.Click += Button_Click;
            _mw.buttonEditCompany.Click += Button_Click;
            _mw.buttonDeleteCompany.Click += Button_Click;
            _mw.buttonEditJobs.Click += Button_Click;
            _mw.buttonEditReps.Click += Button_Click;
            _mw.buttonEditBoards.Click += Button_Click;
            _mw.buttonShowGraph.Click += Button_Click;


            // Start Up Functionality
            //////////////////////////////////

            // Load Rep, Job, and Board Files;
            _fm.LoadRepFile();
            _fm.LoadJobFile();
            _fm.LoadBoardFile();

            // Auto Load Last Company File If Enabled
            if (Properties.Settings.Default.AutoLoadLastFile)
            {
                _mw.menuItemAutoload.IsChecked = true;
                if (Properties.Settings.Default.LastLoadedFile.Length > 1)
                {
                    _fm.LoadCompanyFile(Properties.Settings.Default.LastLoadedFile);
                }
            }

            // Auto Save Company File If Enabled
            if (Properties.Settings.Default.AutoSave)
                _mw.menuItemAutoSave.IsChecked = true;
            _mw.listviewCompanies.ItemsSource = _cm.AllObjects();
            RefreshListView();

            // Sorts List Alphabetically
            Binding b = _mw.gridviewcolCompany.DisplayMemberBinding as Binding;
            ICollectionView result = CollectionViewSource.GetDefaultView(_mw.listviewCompanies.ItemsSource);
            result.SortDescriptions.Clear();
            result.SortDescriptions.Add(new SortDescription(b.Path.Path, ListSortDirection.Ascending));
        }

        // On Window Closing Handler
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!_saved)
            {
                MessageBoxResult result = MessageBox.Show("Warning: Content not saved.\nAre you sure you want to exit?", "Content Not Saved", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        // Key Down Event Handler (Hot Keys)
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

        // Menu Item Event Handler
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == _mw.menuitemSave)
            {
                SaveCompanyFile();
            }
            else if (e.Source == _mw.menuitemOpen)
            {
                OpenFile();
            }
            else if (e.Source == _mw.menuitemExit)
            {
                _mw.Close();
            }
            else if (e.Source == _mw.menuitemNew)
            {
                AddCompany();
            }
            else if (e.Source == _mw.menuitemEdit)
            {
                EditCompany();
            }
            else if (e.Source == _mw.menuitemDelete)
            {
                DeleteCompany();
            }
            else if (e.Source == _mw.menuItemAutoload)
            {
                if (_mw.menuItemAutoload.IsChecked)
                    Properties.Settings.Default.AutoLoadLastFile = true;
                else
                    Properties.Settings.Default.AutoLoadLastFile = false;
            }
            else if (e.Source == _mw.menuItemAutoSave)
            {
                if (_mw.menuItemAutoSave.IsChecked)
                    Properties.Settings.Default.AutoSave = true;
                else
                    Properties.Settings.Default.AutoSave = false;
            }
        }

        // Search Text Box Text Changed Handler
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = from Emp in _cm.AllObjects()
                         let name = Emp.Name
                         where name.ToUpper().StartsWith(_mw.textboxSearch.Text.ToUpper())
                         select Emp;

            RefreshListView(filter);
        }

        // Search Text Box Focus Changed Handler
        private void SearchBox_FocusChanged(object sender, RoutedEventArgs e)
        {
            if (_mw.textboxSearch.IsFocused)
            {
                _mw.textboxSearch.Text = "";
            }
            else
            {
                _mw.textboxSearch.TextChanged -= SearchBox_TextChanged;
                _mw.textboxSearch.Text = "Search...";
                _mw.textboxSearch.TextChanged += SearchBox_TextChanged;
            }
        }

        // List View Header Click Handler
        private void ListViewHeader_Click(object sender, RoutedEventArgs e)
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
                col.Column.HeaderTemplate = _mw.Resources["ArrowUp"] as DataTemplate;
            }
            else
            {
                col.Column.HeaderTemplate = _mw.Resources["ArrowDown"] as DataTemplate;
            }

            _sortHeader = string.Empty;

            Binding b = _sortCol.Column.DisplayMemberBinding as Binding;
            if (b != null)
            {
                _sortHeader = b.Path.Path;
            }

            ICollectionView result = CollectionViewSource.GetDefaultView(_mw.listviewCompanies.ItemsSource);
            result.SortDescriptions.Clear();
            result.SortDescriptions.Add(new SortDescription(_sortHeader, _sortDir));
        }

        // List View Item Double Click Handler
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditCompany();
        }

        // On Button Click Handler
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == _mw.buttonNewCompany)
            {
                AddCompany();
            }
            else if (e.Source == _mw.buttonEditCompany)
            {
                EditCompany();
            }
            else if (e.Source == _mw.buttonDeleteCompany)
            {
                DeleteCompany();
            }
            else if (e.Source == _mw.buttonEditJobs)
            {
                EditJobs();
            }
            else if (e.Source == _mw.buttonEditReps)
            {
                EditReps();
            }
            else if (e.Source == _mw.buttonEditBoards)
            {
                EditBoards();
            }
            else if (e.Source == _mw.buttonShowGraph)
            {
                ShowGraph();
            }
        }

        // Refreshes The List View
        private void RefreshListView()
        {
            RefreshListView(_cm.AllObjects());
        }

        // Refreshes The List View By Giving It A New Source
        private void RefreshListView(IEnumerable<BaseInfo> source)
        {
            if (source != null)
            {
                _mw.listviewCompanies.ItemsSource = source;
                ICollectionView view = CollectionViewSource.GetDefaultView(_mw.listviewCompanies.ItemsSource);
                view.Refresh();
                view.SortDescriptions.Add(new SortDescription(_sortHeader, _sortDir));
                _mw.labelCount.Content = "Count: " + source.ToList<BaseInfo>().Count;
            }
        }

        // Opens File Dialog For Company List
        private void OpenFile()
        {
            _fm.OpenCompanyFile();
            //_mw.listviewCompanies.ItemsSource = _cm.AllObjects();
            RefreshListView();
        }

        // Saves Company List To File
        private void SaveCompanyFile()
        {
            _fm.SaveCompanyFile();
            MarkSaved();
        }

        // Opens The Add Company Window 
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

        // Opens The Edit Company Window
        private void EditCompany()
        {
            Company c = _mw.listviewCompanies.SelectedItem as Company;
            if (c != null)
            {
                CompanyCreation aec = new CompanyCreation(ref c, Enum.EditMode.Edit);
                aec.ShowDialog();
                if (aec.Exit == Enum.ExitStatus.Ok)
                {
                    RefreshListView();
                    MarkUnsaved();
                }
            }
        }

        // Deletes Selected Company From List View
        private void DeleteCompany()
        {
            if (_mw.listviewCompanies.SelectedItem != null)
            {
                string msg;
                if (_mw.listviewCompanies.SelectedItems.Count > 1)
                {
                    msg = "these " + _mw.listviewCompanies.SelectedItems.Count + " companies?";
                }
                else
                {
                    msg = (_mw.listviewCompanies.SelectedItems[0] as Company).Name + "?";
                }
                if (MessageBox.Show("Are you sure you want to delete " + msg, "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    foreach (Company comp in _mw.listviewCompanies.SelectedItems)
                    {
                        _cm.RemoveObject(comp);
                    }
                    RefreshListView();
                    MarkUnsaved();
                }
            }
        }

        // Opens The Edit Job Window
        private void EditJobs()
        {
            new JobsList().ShowDialog();
        }

        // Opens The Edit Rep Window
        private void EditReps()
        {
            new RepsList().ShowDialog();
        }

        // Opens The Edit Job Boards Window
        private void EditBoards()
        {
            new BoardsList().ShowDialog();
        }

        private void ShowGraph()
        {
            GraphInfo area = new AreaGraphInfo("Area Graph", Companies.Instance.StatusKeyValue(), Brushes.Purple);
            GraphInfo bar = new BarGraphInfo("Bar Graph", Companies.Instance.StatusKeyValue(), Brushes.Green);
            GraphInfo column = new ColumnGraphInfo("Column Graph", Companies.Instance.StatusKeyValue(), Brushes.Red);
            GraphInfo line = new LineGraphInfo("Line Graph", Companies.Instance.StatusKeyValue());
            GraphInfo pie = new PieGraphInfo(Companies.Instance.StatusKeyValue());
            GraphInfo scatter = new ScatterGraphInfo("Scatter Graph", Companies.Instance.StatusKeyValue(), Brushes.Black);

            ChartInfo ac = new ChartInfo("Area Chart");
            ac.AddGraph(area);
            ChartInfo bc = new ChartInfo("Bar Chart");
            bc.AddGraph(bar);
            ChartInfo cc = new ChartInfo("Column Chart");
            cc.AddGraph(column);
            ChartInfo lc = new ChartInfo("Line Chart");
            lc.AddGraph(line);
            ChartInfo pc = new ChartInfo("Pie Chart");
            pc.AddGraph(pie);
            ChartInfo sc = new ChartInfo("Scatter Chart");
            sc.AddGraph(scatter);

            GraphWindowHolder bg = new GraphWindowHolder("Statistics");
            GraphWindowHolder bg2 = new GraphWindowHolder("Window 2");
            bg.AddChart(ac);
            bg.AddChart(bc);
            bg.AddChart(cc);
            bg2.AddChart(lc);
            bg2.AddChart(pc);
            bg2.AddChart(sc);
            bg.Show();
            bg2.Show();

        }

        // Makes Note That Current Company Edits Are Not Saved
        private void MarkUnsaved()
        {
            if (Properties.Settings.Default.AutoSave)
            {
                SaveCompanyFile();
            }
            else
            {
                _mw.Title = _title + "*";
                _saved = false;
            }

        }

        // Makes Note That Current Company Edits Are Saved
        private void MarkSaved()
        {
            _mw.Title = _title;
            _saved = true;
        }

        // Shows The Main Window Dialog
        public void ShowDialog()
        {
            _mw.ShowDialog();
        }

        public void Show()
        {
            _mw.Show();
        }

    }

}
