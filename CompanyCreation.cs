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
    class CompanyCreation : BaseWindow
    {
        /// <summary>
        /// The Reference To The Company Creation Window
        /// </summary>
        private CompanyCreationWindow CompanyCreationWindow
        {
            get
            {
                return (CompanyCreationWindow)base.Window;
            }
        }

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
        public override ExitStatus Exit
        {
            get
            {
                return CompanyCreationWindow.Exit;
            }
            set
            {
                CompanyCreationWindow.Exit = value;
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
                return CompanyCreationWindow.textboxName.Text;
            }
            set
            {
                CompanyCreationWindow.textboxName.Text = value;
            }
        }

        /// <summary>
        /// The String Value From textboxWebsite TextBox
        /// </summary>
        private string Website
        {
            get
            {
                return CompanyCreationWindow.textboxWebsite.Text;
            }
            set
            {
                CompanyCreationWindow.textboxWebsite.Text = value;
            }
        }

        /// <summary>
        /// The Rep From comboboxRep ComboBox
        /// </summary>
        private Rep Rep
        {
            get
            {
                int idx = CompanyCreationWindow.comboboxRep.SelectedIndex;
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
                int idx = CompanyCreationWindow.comboboxJob.SelectedIndex;
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
                int idx = CompanyCreationWindow.comboboxBoard.SelectedIndex;
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
                return CompanyCreationWindow.textboxLocation.Text;
            }
            set
            {
                CompanyCreationWindow.textboxLocation.Text = value;
            }
        }

        /// <summary>
        /// The DateTime Value From datepickerAppDate DatePicker
        /// </summary>
        private DateTime Date
        {
            get
            {
                string[] date = CompanyCreationWindow.datepickerAppDate.Text.Split('/');
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
                _status = CompanyCreationWindow.checkboxApplied.IsChecked == true ? (_status | ApplicationStatus.Applied) : (_status & ~ApplicationStatus.Applied);
                _status = CompanyCreationWindow.checkboxHunted.IsChecked == true ? (_status | ApplicationStatus.Hunted) : (_status & ~ApplicationStatus.Hunted);
                _status = CompanyCreationWindow.checkboxAssign.IsChecked == true ? (_status | ApplicationStatus.Assignment) : (_status & ~ApplicationStatus.Assignment);
                _status = CompanyCreationWindow.checkboxInterview.IsChecked == true ? (_status | ApplicationStatus.Interview) : (_status & ~ApplicationStatus.Interview);
                _status = CompanyCreationWindow.checkboxOffered.IsChecked == true ? (_status | ApplicationStatus.Offered) : (_status & ~ApplicationStatus.Offered);
                _status = CompanyCreationWindow.checkboxAccepted.IsChecked == true ? (_status | ApplicationStatus.Accepted) : (_status & ~ApplicationStatus.Accepted);
                _status = CompanyCreationWindow.checkboxDenied.IsChecked == true ? (_status | ApplicationStatus.Denied) : (_status & ~ApplicationStatus.Denied);
                _status = CompanyCreationWindow.checkboxRejected.IsChecked == true ? (_status | ApplicationStatus.Rejected) : (_status & ~ApplicationStatus.Rejected);

                return _status;
            }
            set
            {
                {
                    if (value.HasFlag(ApplicationStatus.Applied)) CompanyCreationWindow.checkboxApplied.IsChecked = true;
                    if (value.HasFlag(ApplicationStatus.Hunted)) CompanyCreationWindow.checkboxHunted.IsChecked = true;
                    if (value.HasFlag(ApplicationStatus.Assignment)) CompanyCreationWindow.checkboxAssign.IsChecked = true;
                    if (value.HasFlag(ApplicationStatus.Interview)) CompanyCreationWindow.checkboxInterview.IsChecked = true;
                    if (value.HasFlag(ApplicationStatus.Offered)) CompanyCreationWindow.checkboxOffered.IsChecked = true;
                    if (value.HasFlag(ApplicationStatus.Accepted)) CompanyCreationWindow.checkboxAccepted.IsChecked = true;
                    if (value.HasFlag(ApplicationStatus.Denied)) CompanyCreationWindow.checkboxDenied.IsChecked = true;
                    if (value.HasFlag(ApplicationStatus.Rejected)) CompanyCreationWindow.checkboxRejected.IsChecked = true;
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
                return CompanyCreationWindow.textboxNotes.Text;
            }
        }

        /// <summary>
        /// The Postition Type From All Position RadioButtons
        /// </summary>
        private PositionType Position
        {
            get
            {
                if (CompanyCreationWindow.radiobuttonPartTime.IsChecked == true)
                    _pt = PositionType.Part;
                else if (CompanyCreationWindow.radiobuttonFullTime.IsChecked == true)
                    _pt = PositionType.Full;
                else if (CompanyCreationWindow.radiobuttonContract.IsChecked == true)
                    _pt = PositionType.Contract;
                else
                    _pt = PositionType.NA;

                return _pt;
            }
            set
            {
                if (value == PositionType.Part)
                    CompanyCreationWindow.radiobuttonPartTime.IsChecked = true;
                else if (value == PositionType.Full)
                    CompanyCreationWindow.radiobuttonFullTime.IsChecked = true;
                else if (value == PositionType.Contract)
                    CompanyCreationWindow.radiobuttonContract.IsChecked = true;
                else
                    CompanyCreationWindow.radiobuttonNA.IsChecked = true;
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
        public CompanyCreation(ref Company company, EditMode mode) : base(new CompanyCreationWindow(), "")
        {
            Company = company;
            Mode = mode;

            CompanyCreationWindow.Loaded += Window_Loaded;
            CompanyCreationWindow.Closing += Window_Closing;
            CompanyCreationWindow.KeyDown += Window_KeyDown;
        }

        /// <summary>
        /// Window Loaded Event Method
        /// Sets Focus To textboxName TextBox And Selects All Text
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CompanyCreationWindow.textboxName.Text = Company.Name;
            CompanyCreationWindow.textboxWebsite.Text = Company.WebSite;
            CompanyCreationWindow.comboboxRep.SelectedIndex = Company.RepID;
            CompanyCreationWindow.comboboxJob.SelectedIndex = Company.JobID;
            CompanyCreationWindow.textboxLocation.Text = Company.Location;
            CompanyCreationWindow.datepickerAppDate.SelectedDate = Company.AppDate;

            if (Company.Status.HasFlag(ApplicationStatus.Applied)) CompanyCreationWindow.checkboxApplied.IsChecked = true;
            if (Company.Status.HasFlag(ApplicationStatus.Hunted)) CompanyCreationWindow.checkboxHunted.IsChecked = true;
            if (Company.Status.HasFlag(ApplicationStatus.Assignment)) CompanyCreationWindow.checkboxAssign.IsChecked = true;
            if (Company.Status.HasFlag(ApplicationStatus.Interview)) CompanyCreationWindow.checkboxInterview.IsChecked = true;
            if (Company.Status.HasFlag(ApplicationStatus.Offered)) CompanyCreationWindow.checkboxOffered.IsChecked = true;
            if (Company.Status.HasFlag(ApplicationStatus.Accepted)) CompanyCreationWindow.checkboxAccepted.IsChecked = true;
            if (Company.Status.HasFlag(ApplicationStatus.Denied)) CompanyCreationWindow.checkboxDenied.IsChecked = true;
            if (Company.Status.HasFlag(ApplicationStatus.Rejected)) CompanyCreationWindow.checkboxRejected.IsChecked = true;

            if (Company.Position == PositionType.Part) CompanyCreationWindow.radiobuttonPartTime.IsChecked = true;
            else if (Company.Position == PositionType.Full) CompanyCreationWindow.radiobuttonFullTime.IsChecked = true;
            else if (Company.Position == PositionType.Contract) CompanyCreationWindow.radiobuttonContract.IsChecked = true;
            else CompanyCreationWindow.radiobuttonNA.IsChecked = true;

            CompanyCreationWindow.textboxNotes.Text = Company.Notes;

            CompanyCreationWindow.buttonCreate.Click += Element_Click;
            CompanyCreationWindow.buttonCancel.Click += Element_Click;
            CompanyCreationWindow.buttonAddRep.Click += Element_Click;
            CompanyCreationWindow.buttonAddTitle.Click += Element_Click;
            CompanyCreationWindow.buttonAddBoard.Click += Element_Click;

            CompanyCreationWindow.comboboxBoard.DisplayMemberPath = "Name";
            CompanyCreationWindow.comboboxBoard.ItemsSource = JobBoards.Instance.AllObjects();
            CompanyCreationWindow.comboboxBoard.SelectedIndex = JobBoards.Instance.TableToNames(Company.BoardID);

            CompanyCreationWindow.comboboxJob.DisplayMemberPath = "Name";
            CompanyCreationWindow.comboboxJob.ItemsSource = Jobs.Instance.AllObjects();
            CompanyCreationWindow.comboboxJob.SelectedIndex = Jobs.Instance.TableToNames(Company.JobID);

            CompanyCreationWindow.comboboxRep.DisplayMemberPath = "Name";
            CompanyCreationWindow.comboboxRep.ItemsSource = Reps.Instance.AllObjects();
            CompanyCreationWindow.comboboxRep.SelectedIndex = Reps.Instance.TableToNames(Company.RepID);

            CompanyCreationWindow.textboxName.GotFocus += Element_FocusChanged;
            CompanyCreationWindow.textboxWebsite.GotFocus += Element_FocusChanged;
            CompanyCreationWindow.textboxLocation.GotFocus += Element_FocusChanged;
            CompanyCreationWindow.textboxNotes.GotFocus += Element_FocusChanged;

            CompanyCreationWindow.textboxName.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(Element_MouseDown);
            CompanyCreationWindow.textboxWebsite.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(Element_MouseDown);
            CompanyCreationWindow.textboxLocation.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(Element_MouseDown);
            CompanyCreationWindow.textboxNotes.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(Element_MouseDown);

            if (Mode == EditMode.New)
            {
                CompanyCreationWindow.Title = "Add New Company";
                CompanyCreationWindow.textboxName.Focus();
                CompanyCreationWindow.textboxName.SelectAll();
            }
            else if (Mode == EditMode.Edit)
            {
                CompanyCreationWindow.Title = "Edit " + Company.Name;
                CompanyCreationWindow.buttonCreate.Content = "Save";
            }
        }

        /// <summary>
        /// Window Closing Event Method
        /// Handles Exit Status Flow
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Window_Closing(object sender, CancelEventArgs e)
        {
            if (Exit == ExitStatus.Ok)
            {
                SaveCompanyDetails();
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
            if (e.Key == Key.Enter)
            {
                SaveCompanyDetails();
                Exit = ExitStatus.Ok;
                CompanyCreationWindow.Close();
            }
            else if (e.Key == Key.Escape)
            {
                Exit = ExitStatus.Cancel;
                CompanyCreationWindow.Close();
            }

        }

        /// <summary>
        /// Window Button Click Method
        /// Handles Button Presses
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Element_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == CompanyCreationWindow.buttonCreate)
            {
                Exit = ExitStatus.Ok;
                CompanyCreationWindow.Close();
            }
            else if (e.Source == CompanyCreationWindow.buttonCancel)
            {
                Exit = ExitStatus.Cancel;
                CompanyCreationWindow.Close();
            }
            else if (e.Source == CompanyCreationWindow.buttonAddRep)
            {
                EditReps();
            }
            else if (e.Source == CompanyCreationWindow.buttonAddTitle)
            {
                EditJobs();
            }
            else if (e.Source == CompanyCreationWindow.buttonAddBoard)
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
        protected override void Element_FocusChanged(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        /// <summary>
        /// Window Text Input Event Method
        /// Used With Window Loaded To Prevent Selection Of Text To Disappear
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Element_MouseDown(object sender, MouseEventArgs e)
        {
            var tb = sender as TextBox;
            if (e.OriginalSource.GetType().Name == "TextBoxView")
            {
                e.Handled = true;
                tb.Focus();
            }

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
            RefereshComboBox(CompanyCreationWindow.comboboxBoard, JobBoards.Instance);
        }

        /// <summary>
        /// Refreshes The comboboxJob's Source
        /// </summary>
        private void RefreshJobCB()
        {
            RefereshComboBox(CompanyCreationWindow.comboboxJob, Jobs.Instance);
        }

        /// <summary>
        /// Refreshes The comboboxRep's Source
        /// </summary>
        private void RefreshRepCB()
        {
            RefereshComboBox(CompanyCreationWindow.comboboxRep, Reps.Instance);
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

    }

}
