using Job_Application_Database.Classes;
using Job_Application_Database.Enum;
using Job_Application_Database.Singleton;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Job_Application_Database
{
    /// <summary>
    /// Company Creation 
    /// </summary>
    class CompanyCreation
    {
        /// <summary>
        /// The Reference To The Company Creation Window
        /// </summary>
        private CompanyCreationWindow _ccw;

        /// <summary>
        /// The Application Status Of The Company
        /// </summary>
        private ApplicationStatus _status;

        /// <summary>
        /// The Position Type Of The Company
        /// </summary>
        private PositionType _pt;

        /// <summary>
        /// The Exit Status Of The Window
        /// </summary>
        public ExitStatus Exit
        {
            get
            {
                return _ccw.Exit;
            }
            set
            {
                _ccw.Exit = value;
            }
        }

        /// <summary>
        /// The Company To Edit Or Create
        /// </summary>
        public Company Company { get; }

        /// <summary>
        /// The String Value From textboxName TextBox
        /// </summary>
        private string Name
        {
            get
            {
                return _ccw.textboxName.Text;
            }
            set
            {
                _ccw.textboxName.Text = value;
            }
        }

        /// <summary>
        /// The String Value From textboxWebsite TextBox
        /// </summary>
        private string Website
        {
            get
            {
                return _ccw.textboxWebsite.Text;
            }
            set
            {
                _ccw.textboxWebsite.Text = value;
            }
        }

        /// <summary>
        /// The Rep From comboboxRep ComboBox
        /// </summary>
        private Rep Rep
        {
            get
            {
                int idx = _ccw.comboboxRep.SelectedIndex;
                if (idx < 0) idx = 0;
                return Reps.Instance.ObjectAt(idx) as Rep;
            }
        }

        /// <summary>
        /// The Job From comboboxJob Combobox
        /// </summary>
        private Job Job
        {
            get
            {
                int idx = _ccw.comboboxJob.SelectedIndex;
                if (idx < 0) idx = 0;
                return Jobs.Instance.NamesToTable(idx) as Job;
            }
        }

        /// <summary>
        /// The Job Board From comboboxBoard ComboBox
        /// </summary>
        private JobBoard Board
        {
            get
            {
                int idx = _ccw.comboboxBoard.SelectedIndex;
                if (idx < 0) idx = 0;
                return JobBoards.Instance.NamesToTable(idx) as JobBoard;
            }
        }

        /// <summary>
        /// The String Value From textboxLocation TextBox
        /// </summary>
        private string Location
        {
            get
            {
                return _ccw.textboxLocation.Text;
            }
            set
            {
                _ccw.textboxLocation.Text = value;
            }
        }

        /// <summary>
        /// The DateTime Value From datepickerAppDate DatePicker
        /// </summary>
        private DateTime Date
        {
            get
            {
                string[] date = _ccw.datepickerAppDate.Text.Split('/');
                int year = Int32.Parse(date[2]);
                int month = Int32.Parse(date[0]);
                int day = Int32.Parse(date[1]);
                return new DateTime(year, month, day);
            }
        }

        /// <summary>
        /// The Application Status Value From Status CheckBoxes
        /// </summary>
        private ApplicationStatus Status
        {
            get
            {
                _status = _ccw.checkboxApplied.IsChecked == true ? (_status | ApplicationStatus.Applied) : (_status & ~ApplicationStatus.Applied);
                _status = _ccw.checkboxHunted.IsChecked == true ? (_status | ApplicationStatus.Hunted) : (_status & ~ApplicationStatus.Hunted);
                _status = _ccw.checkboxAssign.IsChecked == true ? (_status | ApplicationStatus.Assignment) : (_status & ~ApplicationStatus.Assignment);
                _status = _ccw.checkboxInterview.IsChecked == true ? (_status | ApplicationStatus.Interview) : (_status & ~ApplicationStatus.Interview);
                _status = _ccw.checkboxOffered.IsChecked == true ? (_status | ApplicationStatus.Offered) : (_status & ~ApplicationStatus.Offered);
                _status = _ccw.checkboxAccepted.IsChecked == true ? (_status | ApplicationStatus.Accepted) : (_status & ~ApplicationStatus.Accepted);
                _status = _ccw.checkboxDenied.IsChecked == true ? (_status | ApplicationStatus.Denied) : (_status & ~ApplicationStatus.Denied);
                _status = _ccw.checkboxRejected.IsChecked == true ? (_status | ApplicationStatus.Rejected) : (_status & ~ApplicationStatus.Rejected);

                return _status;
            }
            set
            {
                {
                    if (value.HasFlag(ApplicationStatus.Applied)) _ccw.checkboxApplied.IsChecked = true;
                    if (value.HasFlag(ApplicationStatus.Hunted)) _ccw.checkboxHunted.IsChecked = true;
                    if (value.HasFlag(ApplicationStatus.Assignment)) _ccw.checkboxAssign.IsChecked = true;
                    if (value.HasFlag(ApplicationStatus.Interview)) _ccw.checkboxInterview.IsChecked = true;
                    if (value.HasFlag(ApplicationStatus.Offered)) _ccw.checkboxOffered.IsChecked = true;
                    if (value.HasFlag(ApplicationStatus.Accepted)) _ccw.checkboxAccepted.IsChecked = true;
                    if (value.HasFlag(ApplicationStatus.Denied)) _ccw.checkboxDenied.IsChecked = true;
                    if (value.HasFlag(ApplicationStatus.Rejected)) _ccw.checkboxRejected.IsChecked = true;
                }
            }
        }

        /// <summary>
        /// The String Value From textboxNotes TextBox
        /// </summary>
        private string Notes
        {
            get
            {
                return _ccw.textboxNotes.Text;
            }
        }

        /// <summary>
        /// The Postition Type From All Position RadioButtons
        /// </summary>
        private PositionType Position
        {
            get
            {
                if (_ccw.radiobuttonPartTime.IsChecked == true)
                    _pt = PositionType.Part;
                else if (_ccw.radiobuttonFullTime.IsChecked == true)
                    _pt = PositionType.Full;
                else if (_ccw.radiobuttonContract.IsChecked == true)
                    _pt = PositionType.Contract;
                else
                    _pt = PositionType.NA;

                return _pt;
            }
            set
            {
                if (value == PositionType.Part)
                    _ccw.radiobuttonPartTime.IsChecked = true;
                else if (value == PositionType.Full)
                    _ccw.radiobuttonFullTime.IsChecked = true;
                else if (value == PositionType.Contract)
                    _ccw.radiobuttonContract.IsChecked = true;
                else
                    _ccw.radiobuttonNA.IsChecked = true;
            }
        }

        /// <summary>
        /// The Window New/Edit Mode
        /// </summary>
        private EditMode Mode { get; set; }

        /// <summary>
        /// Constructor To Edit Company Info
        /// </summary>
        /// <param name="company">The Company To Edit</param>
        /// <param name="mode">The Editing Mode</param>
        public CompanyCreation(ref Company company, EditMode mode)
        {
            Company = company;
            Mode = mode;
            _ccw = new CompanyCreationWindow();

            _ccw.textboxName.Text = Company.Name;
            _ccw.textboxWebsite.Text = Company.WebSite;
            _ccw.comboboxRep.SelectedIndex = Company.RepID;
            _ccw.comboboxJob.SelectedIndex = Company.JobID;
            _ccw.textboxLocation.Text = Company.Location;
            _ccw.datepickerAppDate.SelectedDate = Company.AppDate;

            if (Company.Status.HasFlag(ApplicationStatus.Applied)) _ccw.checkboxApplied.IsChecked = true;
            if (Company.Status.HasFlag(ApplicationStatus.Hunted)) _ccw.checkboxHunted.IsChecked = true;
            if (Company.Status.HasFlag(ApplicationStatus.Assignment)) _ccw.checkboxAssign.IsChecked = true;
            if (Company.Status.HasFlag(ApplicationStatus.Interview)) _ccw.checkboxInterview.IsChecked = true;
            if (Company.Status.HasFlag(ApplicationStatus.Offered)) _ccw.checkboxOffered.IsChecked = true;
            if (Company.Status.HasFlag(ApplicationStatus.Accepted)) _ccw.checkboxAccepted.IsChecked = true;
            if (Company.Status.HasFlag(ApplicationStatus.Denied)) _ccw.checkboxDenied.IsChecked = true;
            if (Company.Status.HasFlag(ApplicationStatus.Rejected)) _ccw.checkboxRejected.IsChecked = true;

            if (Company.Position == PositionType.Part) _ccw.radiobuttonPartTime.IsChecked = true;
            else if (Company.Position == PositionType.Full) _ccw.radiobuttonFullTime.IsChecked = true;
            else if (Company.Position == PositionType.Contract) _ccw.radiobuttonContract.IsChecked = true;
            else _ccw.radiobuttonNA.IsChecked = true;

            _ccw.textboxNotes.Text = Company.Notes;


            if (Mode == EditMode.New)
            {
                _ccw.Title = "Add New Company";

            }
            else if (Mode == EditMode.Edit)
            {
                _ccw.Title = "Edit " + Company.Name;
                _ccw.buttonCreate.Content = "Save";
            }

            _ccw.KeyDown += new KeyEventHandler(Window_KeyDown);
            _ccw.buttonCreate.Click += Button_Click;
            _ccw.buttonCancel.Click += Button_Click;
            _ccw.buttonAddRep.Click += Button_Click;
            _ccw.buttonAddTitle.Click += Button_Click;
            _ccw.buttonAddBoard.Click += Button_Click;
            _ccw.Closing += Window_Closing;
            _ccw.Loaded += Window_Loaded;

            _ccw.comboboxBoard.DisplayMemberPath = "Name";
            _ccw.comboboxBoard.ItemsSource = JobBoards.Instance.AllObjects();
            _ccw.comboboxBoard.SelectedIndex = JobBoards.Instance.TableToNames(Company.BoardID);

            _ccw.comboboxJob.DisplayMemberPath = "Name";
            _ccw.comboboxJob.ItemsSource = Jobs.Instance.AllObjects();
            _ccw.comboboxJob.SelectedIndex = Jobs.Instance.TableToNames(Company.JobID);

            _ccw.comboboxRep.DisplayMemberPath = "Name";
            _ccw.comboboxRep.ItemsSource = Reps.Instance.AllObjects();
            _ccw.comboboxRep.SelectedIndex = Reps.Instance.TableToNames(Company.RepID);

            _ccw.textboxName.GotFocus += TextBox_GotFocus;
            _ccw.textboxWebsite.GotFocus += TextBox_GotFocus;
            _ccw.textboxLocation.GotFocus += TextBox_GotFocus;
            _ccw.textboxNotes.GotFocus += TextBox_GotFocus;

            _ccw.textboxName.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(TextInput_MouseDown);
            _ccw.textboxWebsite.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(TextInput_MouseDown);
            _ccw.textboxLocation.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(TextInput_MouseDown);
            _ccw.textboxNotes.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(TextInput_MouseDown);
        }

        /// <summary>
        /// Window Loaded Event Method
        /// Sets Focus To textboxName TextBox And Selects All Text
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Mode == EditMode.New)
            {
                _ccw.textboxName.Focus();
                _ccw.textboxName.SelectAll();
            }
        }

        /// <summary>
        /// Window Key Down Event Method
        /// Handles Enter And Escape Key Presses
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SaveCompanyDetails();
                Exit = ExitStatus.Ok;
                _ccw.Close();
            }
            else if (e.Key == Key.Escape)
            {
                Exit = ExitStatus.Cancel;
                _ccw.Close();
            }

        }

        /// <summary>
        /// Window Text Input Event Method
        /// Used With Window Loaded To Prevent Selection Of Text To Disappear
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        private void TextInput_MouseDown(object sender, MouseEventArgs e)
        {
            var tb = sender as TextBox;
            if (e.OriginalSource.GetType().Name == "TextBoxView")
            {
                e.Handled = true;
                tb.Focus();
            }

        }

        /// <summary>
        /// Window Closing Event Method
        /// Handles Exit Status Flow
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (Exit == ExitStatus.Ok)
            {
                SaveCompanyDetails();
            }
        }

        /// <summary>
        /// Window Button Click Method
        /// Handles Button Presses
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == _ccw.buttonCreate)
            {
                Exit = ExitStatus.Ok;
                _ccw.Close();
            }
            else if (e.Source == _ccw.buttonCancel)
            {
                Exit = ExitStatus.Cancel;
                _ccw.Close();
            }
            else if (e.Source == _ccw.buttonAddRep)
            {
                EditReps();
            }
            else if (e.Source == _ccw.buttonAddTitle)
            {
                EditJobs();
            }
            else if (e.Source == _ccw.buttonAddBoard)
            {
                EditBoards();
            }
        }

        /// <summary>
        /// Window Got Focus Event Method
        /// When Any TextBox Gains Focus All Text Is Selected
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        /// <summary>
        /// Takes Info From Window And Saves To Company
        /// </summary>
        private void SaveCompanyDetails()
        {
            Company.Name = Name;
            Company.WebSite = Website;
            Company.Rep = Rep;
            Company.Job = Job;
            Company.Board = Board;
            Company.Location = Location;
            Company.AppDate = Date;
            Company.Status = Status;
            Company.Position = Position;
            Company.Notes = Notes;
        }

        /// <summary>
        /// Opens The BoardsList Window
        /// </summary>
        private void EditBoards()
        {
            new JobBoardsList().ShowDialog();
            RefreshBoardCB();
        }

        /// <summary>
        /// Opens The JobsList Window
        /// </summary>
        private void EditJobs()
        {
            new JobsList().ShowDialog();
            RefreshJobCB();
        }

        /// <summary>
        /// Opens The RepsList Window
        /// </summary>
        private void EditReps()
        {
            new RepsList().ShowDialog();
            RefreshRepCB();
        }

        /// <summary>
        /// Refreshes The comboboxBoard's Source
        /// </summary>
        private void RefreshBoardCB()
        {
            RefereshComboBox(_ccw.comboboxBoard, JobBoards.Instance);
        }

        /// <summary>
        /// Refreshes The comboboxJob's Source
        /// </summary>
        private void RefreshJobCB()
        {
            RefereshComboBox(_ccw.comboboxJob, Jobs.Instance);
        }

        /// <summary>
        /// Refreshes The comboboxRep's Source
        /// </summary>
        private void RefreshRepCB()
        {
            RefereshComboBox(_ccw.comboboxRep, Reps.Instance);
        }

        /// <summary>
        /// Refreshes A ComboBox's Source
        /// </summary>
        /// <param name="cb">The ComboBox To Refresh</param>
        /// <param name="bs">The Source Of The ComboBox</param>
        private void RefereshComboBox(ComboBox cb, BaseSingleton bs)
        {
            cb.ItemsSource = bs.AllObjects();
            ICollectionView view = CollectionViewSource.GetDefaultView(cb.ItemsSource);
            view.Refresh();
        }

        /// <summary>
        /// Calls CompanyCreationWindow's ShowDialog Method
        /// </summary>
        public void ShowDialog()
        {
            _ccw.ShowDialog();
        }
    }

}
