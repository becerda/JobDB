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
using System.Windows.Media;
using Job_Application_Database.Enum;

namespace Job_Application_Database
{
    /// <summary>
    /// Starting Point For Program
    /// </summary>
    class Main : BaseWindow
    {
        /// <summary>
        /// Reference To MainWindow
        /// </summary>
        private MainWindow MainWindow
        {
            get
            {
                return (MainWindow)base.Window;
            }
        }

        /// <summary>
        /// The Exit Status Of MainWindow
        /// </summary>
        public override ExitStatus Exit { get; set; }

        /// <summary>
        /// To Keep Track Of Saved State
        /// </summary>
        private bool _saved = true;

        /// <summary>
        /// To Keep Track Of Sorted Column
        /// </summary>
        private GridViewColumnHeader _sortCol;

        /// <summary>
        /// To Keep Track Of Sorted Direction
        /// </summary>
        private ListSortDirection _sortDir;

        /// <summary>
        /// To Keep Track Of Current Sort Header
        /// </summary>
        private string _sortHeader = "Company";

        /// <summary>
        /// Current Title Of Application
        /// </summary>
        private static string _title = Properties.Settings.Default.MainWindowTitle;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Main() : base(new MainWindow(), _title) { }

        /// <summary>
        /// On Window Loaded Handler
        /// Loads Files Sets Up Window
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Add Event Handlers To Views
            //////////////////////////////////

            // Menu Item Events
            MainWindow.menuitemOpen.Click += Element_Click;
            MainWindow.menuitemSave.Click += Element_Click;
            MainWindow.menuitemExit.Click += Element_Click;
            MainWindow.menuitemNew.Click += Element_Click;
            MainWindow.menuitemEdit.Click += Element_Click;
            MainWindow.menuitemDelete.Click += Element_Click;
            MainWindow.menuItemAutoload.Click += Element_Click;
            MainWindow.menuItemAutoSave.Click += Element_Click;

            // Search Text Box Events
            MainWindow.textboxSearch.TextChanged += Element_TextChanged;
            MainWindow.textboxSearch.LostFocus += Element_FocusChanged;
            MainWindow.textboxSearch.GotFocus += Element_FocusChanged;

            // List View Header Events
            MainWindow.listviewCompanies.AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(Element_Click));
            MainWindow.listviewCompanies.MouseDoubleClick += Element_DoubleClick;

            // Button Events
            MainWindow.buttonNewCompany.Click += Element_Click;
            MainWindow.buttonEditCompany.Click += Element_Click;
            MainWindow.buttonDeleteCompany.Click += Element_Click;
            MainWindow.buttonEditJobs.Click += Element_Click;
            MainWindow.buttonEditReps.Click += Element_Click;
            MainWindow.buttonEditBoards.Click += Element_Click;
            MainWindow.buttonShowGraph.Click += Element_Click;


            // Start Up Functionality
            //////////////////////////////////

            // Load Rep, Job, and Board Files;
            Files.Instance.LoadRepFile();
            Files.Instance.LoadJobFile();
            Files.Instance.LoadBoardFile();

            // Auto Load Last Company File If Enabled
            if (Properties.Settings.Default.AutoLoadLastFile)
            {
                MainWindow.menuItemAutoload.IsChecked = true;
                if (Properties.Settings.Default.LastLoadedFile.Length > 1)
                {
                    Files.Instance.LoadCompanyFile(Properties.Settings.Default.LastLoadedFile);
                }
            }

            // Auto Save Company File If Enabled
            if (Properties.Settings.Default.AutoSave)
                MainWindow.menuItemAutoSave.IsChecked = true;
            MainWindow.listviewCompanies.ItemsSource = Companies.Instance.AllObjects();
            RefreshListView();

            // Sorts List Alphabetically
            Binding b = MainWindow.gridviewcolCompany.DisplayMemberBinding as Binding;
            ICollectionView result = CollectionViewSource.GetDefaultView(MainWindow.listviewCompanies.ItemsSource);
            result.SortDescriptions.Clear();
            result.SortDescriptions.Add(new SortDescription(b.Path.Path, ListSortDirection.Ascending));
        }

        /// <summary>
        /// Overrided Window Closing Event Method
        /// Handles Exit Status Flow
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Window_Closing(object sender, CancelEventArgs e)
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

        /// <summary>
        /// Window Key Down Event Method
        /// Handles Enter And Escape Key Presses
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Window_KeyDown(object sender, KeyEventArgs e)
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

        /// <summary>
        /// Overrided Click Event Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Element_Click(object sender, RoutedEventArgs e)
        {
            if (sender.GetType() == typeof(MenuItem))
                MenuItem_Click(e);
            else if (sender.GetType() == typeof(Button))
                Button_Click(e);
            else if (sender.GetType() == typeof(ListView))
                ListViewHeader_Click(e);
        }

        /// <summary>
        /// Window Menu Item Event Method
        /// Handles Menu Item Click
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        private void MenuItem_Click(RoutedEventArgs e)
        {
            if (e.Source == MainWindow.menuitemSave)
            {
                SaveCompanyFile();
            }
            else if (e.Source == MainWindow.menuitemOpen)
            {
                OpenFile();
            }
            else if (e.Source == MainWindow.menuitemExit)
            {
                MainWindow.Close();
            }
            else if (e.Source == MainWindow.menuitemNew)
            {
                AddCompany();
            }
            else if (e.Source == MainWindow.menuitemEdit)
            {
                EditCompany();
            }
            else if (e.Source == MainWindow.menuitemDelete)
            {
                DeleteCompany();
            }
            else if (e.Source == MainWindow.menuItemAutoload)
            {
                if (MainWindow.menuItemAutoload.IsChecked)
                    Properties.Settings.Default.AutoLoadLastFile = true;
                else
                    Properties.Settings.Default.AutoLoadLastFile = false;
            }
            else if (e.Source == MainWindow.menuItemAutoSave)
            {
                if (MainWindow.menuItemAutoSave.IsChecked)
                    Properties.Settings.Default.AutoSave = true;
                else
                    Properties.Settings.Default.AutoSave = false;
            }
        }

        /// <summary>
        /// Window Button Click Method
        /// Handles Button Presses
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        private void Button_Click(RoutedEventArgs e)
        {
            if (e.Source == MainWindow.buttonNewCompany)
            {
                AddCompany();
            }
            else if (e.Source == MainWindow.buttonEditCompany)
            {
                EditCompany();
            }
            else if (e.Source == MainWindow.buttonDeleteCompany)
            {
                DeleteCompany();
            }
            else if (e.Source == MainWindow.buttonEditJobs)
            {
                EditJobs();
            }
            else if (e.Source == MainWindow.buttonEditReps)
            {
                EditReps();
            }
            else if (e.Source == MainWindow.buttonEditBoards)
            {
                EditBoards();
            }
            else if (e.Source == MainWindow.buttonShowGraph)
            {
                ShowGraph();
            }
        }

        /// <summary>
        /// List View Header Click Method
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        private void ListViewHeader_Click(RoutedEventArgs e)
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
                col.Column.HeaderTemplate = MainWindow.Resources["ArrowUp"] as DataTemplate;
            }
            else
            {
                col.Column.HeaderTemplate = MainWindow.Resources["ArrowDown"] as DataTemplate;
            }

            _sortHeader = string.Empty;

            Binding b = _sortCol.Column.DisplayMemberBinding as Binding;
            if (b != null)
            {
                _sortHeader = b.Path.Path;
            }

            ICollectionView result = CollectionViewSource.GetDefaultView(MainWindow.listviewCompanies.ItemsSource);
            result.SortDescriptions.Clear();
            result.SortDescriptions.Add(new SortDescription(_sortHeader, _sortDir));
        }

        /// <summary>
        /// Overrided Element Double Click Method
        /// Handles Mouse Double Click On listviewCurrent
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Element_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditCompany();
        }

        /// <summary>
        /// Overrided Element Text Changed Method
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Element_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = from Emp in Companies.Instance.AllObjects()
                         let name = Emp.Name
                         where name.ToUpper().StartsWith(MainWindow.textboxSearch.Text.ToUpper())
                         select Emp;

            RefreshListView(filter);
        }

        /// <summary>
        /// Overrided Element Text Focus Changed Method
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Element_FocusChanged(object sender, RoutedEventArgs e)
        {
            if (MainWindow.textboxSearch.IsFocused)
            {
                MainWindow.textboxSearch.Text = "";
            }
            else
            {
                MainWindow.textboxSearch.TextChanged -= Element_TextChanged;
                MainWindow.textboxSearch.Text = "Search...";
                MainWindow.textboxSearch.TextChanged += Element_TextChanged;
            }
        }

        /// <summary>
        /// Refreshes The List View
        /// </summary>
        private void RefreshListView()
        {
            RefreshListView(Companies.Instance.AllObjects());
        }

        /// <summary>
        /// Refreshes The List View By Giving It A New Source
        /// </summary>
        /// <param name="source">The Source Of The List View</param>
        private void RefreshListView(IEnumerable<BaseInfo> source)
        {
            if (source != null)
            {
                MainWindow.listviewCompanies.ItemsSource = source;
                ICollectionView view = CollectionViewSource.GetDefaultView(MainWindow.listviewCompanies.ItemsSource);
                view.Refresh();
                view.SortDescriptions.Add(new SortDescription(_sortHeader, _sortDir));
                MainWindow.labelCount.Content = "Count: " + source.ToList<BaseInfo>().Count;
            }
        }

        /// <summary>
        /// Opens File Dialog For Company List
        /// </summary>
        private void OpenFile()
        {
            Files.Instance.OpenCompanyFile();
            //_mw.listviewCompanies.ItemsSource = _cm.AllObjects();
            RefreshListView();
        }

        /// <summary>
        /// Saves Company List To File
        /// </summary>
        private void SaveCompanyFile()
        {
            Files.Instance.SaveCompanyFile();
            MarkSaved();
        }

        /// <summary>
        /// Opens The Add Company Window 
        /// </summary>
        private void AddCompany()
        {
            Company c = new Company();
            CompanyCreation aec = new CompanyCreation(ref c, Enum.EditMode.New);
            aec.ShowDialog();
            if (aec.Exit == Enum.ExitStatus.Ok)
            {
                Companies.Instance.AddObject(aec.Company);
                RefreshListView();
                MarkUnsaved();
            }
        }

        /// <summary>
        /// Opens The Edit Company Window
        /// </summary>
        private void EditCompany()
        {
            Company c = MainWindow.listviewCompanies.SelectedItem as Company;
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

        /// <summary>
        /// Deletes Selected Company From List View
        /// </summary>
        private void DeleteCompany()
        {
            if (MainWindow.listviewCompanies.SelectedItem != null)
            {
                string msg;
                if (MainWindow.listviewCompanies.SelectedItems.Count > 1)
                {
                    msg = "these " + MainWindow.listviewCompanies.SelectedItems.Count + " companies?";
                }
                else
                {
                    msg = (MainWindow.listviewCompanies.SelectedItems[0] as Company).Name + "?";
                }
                if (MessageBox.Show("Are you sure you want to delete " + msg, "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    foreach (Company comp in MainWindow.listviewCompanies.SelectedItems)
                    {
                        Companies.Instance.RemoveObject(comp);
                    }
                    RefreshListView();
                    MarkUnsaved();
                }
            }
        }

        /// <summary>
        /// Opens The Edit Job Window
        /// </summary>
        private void EditJobs()
        {
            new JobsList().ShowDialog();
        }

        /// <summary>
        /// Opens The Edit Rep Window
        /// </summary>
        private void EditReps()
        {
            new RepsList().ShowDialog();
        }

        /// <summary>
        /// Opens The Edit Job Boards Window
        /// </summary>
        private void EditBoards()
        {
            new JobBoardsList().ShowDialog();
        }

        /// <summary>
        /// Shows A Graph (Testing)
        /// </summary>
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

            GraphHolder bg = new GraphHolder("Statistics");
            GraphHolder bg2 = new GraphHolder("Window 2");
            bg.AddChart(ac);
            bg.AddChart(bc);
            bg.AddChart(cc);
            bg2.AddChart(lc);
            bg2.AddChart(pc);
            bg2.AddChart(sc);
            bg.Show();
            bg2.Show();

        }

        /// <summary>
        /// Makes Note That Current Company Edits Are Not Saved
        /// </summary>
        private void MarkUnsaved()
        {
            if (Properties.Settings.Default.AutoSave)
            {
                SaveCompanyFile();
            }
            else
            {
                MainWindow.Title = _title + "*";
                _saved = false;
            }

        }

        /// <summary>
        /// Makes Note That Current Company Edits Are Saved
        /// </summary>
        private void MarkSaved()
        {
            MainWindow.Title = _title;
            _saved = true;
        }

    }
}
