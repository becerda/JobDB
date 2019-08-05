using Job_Application_Database.Classes;
using Job_Application_Database.Singleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Job_Application_Database
{
    class CompanyCreation
    {
        private CompanyCreationWindow _ccw;

        private Enum.Status _status;

        private Enum.PositionType _pt;

        public Enum.ExitStatus Exit
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

        public Company Company { get; }

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

        private Rep Rep
        {
            get
            {
                int idx = _ccw.comboboxRep.SelectedIndex;
                if (idx < 0) idx = 0;
                return Reps.Instance.ObjectAt(idx) as Rep;
            }
        }

        private Job Job
        {
            get
            {
                int idx = _ccw.comboboxJob.SelectedIndex;
                if (idx < 0) idx = 0;
                return Jobs.Instance.NamesToTable(idx) as Job;
            }
        }

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

        private Enum.Status Status
        {
            get
            {
                _status = _ccw.checkboxApplied.IsChecked == true ? (_status | Enum.Status.Applied) : (_status & ~Enum.Status.Applied);
                _status = _ccw.checkboxHunted.IsChecked == true ? (_status | Enum.Status.Hunted) : (_status & ~Enum.Status.Hunted);
                _status = _ccw.checkboxAssign.IsChecked == true ? (_status | Enum.Status.Assignment) : (_status & ~Enum.Status.Assignment);
                _status = _ccw.checkboxInterview.IsChecked == true ? (_status | Enum.Status.Interview) : (_status & ~Enum.Status.Interview);
                _status = _ccw.checkboxOffered.IsChecked == true ? (_status | Enum.Status.Offered) : (_status & ~Enum.Status.Offered);
                _status = _ccw.checkboxAccepted.IsChecked == true ? (_status | Enum.Status.Accepted) : (_status & ~Enum.Status.Accepted);
                _status = _ccw.checkboxDenied.IsChecked == true ? (_status | Enum.Status.Denied) : (_status & ~Enum.Status.Denied);
                _status = _ccw.checkboxRejected.IsChecked == true ? (_status | Enum.Status.Rejected) : (_status & ~Enum.Status.Rejected);

                return _status;
            }
            set
            {
                {
                    if (value.HasFlag(Enum.Status.Applied)) _ccw.checkboxApplied.IsChecked = true;
                    if (value.HasFlag(Enum.Status.Hunted)) _ccw.checkboxHunted.IsChecked = true;
                    if (value.HasFlag(Enum.Status.Assignment)) _ccw.checkboxAssign.IsChecked = true;
                    if (value.HasFlag(Enum.Status.Interview)) _ccw.checkboxInterview.IsChecked = true;
                    if (value.HasFlag(Enum.Status.Offered)) _ccw.checkboxOffered.IsChecked = true;
                    if (value.HasFlag(Enum.Status.Accepted)) _ccw.checkboxAccepted.IsChecked = true;
                    if (value.HasFlag(Enum.Status.Denied)) _ccw.checkboxDenied.IsChecked = true;
                    if (value.HasFlag(Enum.Status.Rejected)) _ccw.checkboxRejected.IsChecked = true;
                }
            }
        }

        private string Notes
        {
            get
            {
                return _ccw.textboxNotes.Text;
            }
        }

        private Enum.PositionType Position
        {
            get
            {
                if (_ccw.radiobuttonPartTime.IsChecked == true)
                    _pt = Enum.PositionType.Part;
                else if (_ccw.radiobuttonFullTime.IsChecked == true)
                    _pt = Enum.PositionType.Full;
                else if (_ccw.radiobuttonContract.IsChecked == true)
                    _pt = Enum.PositionType.Contract;
                else
                    _pt = Enum.PositionType.NA;

                return _pt;
            }
            set
            {
                if (value == Enum.PositionType.Part)
                    _ccw.radiobuttonPartTime.IsChecked = true;
                else if (value == Enum.PositionType.Full)
                    _ccw.radiobuttonFullTime.IsChecked = true;
                else if (value == Enum.PositionType.Contract)
                    _ccw.radiobuttonContract.IsChecked = true;
                else
                    _ccw.radiobuttonNA.IsChecked = true;
            }
        }

        private Enum.EditMode Mode { get; set; }

        public CompanyCreation(ref Company company, Enum.EditMode mode)
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

            if (Company.Status.HasFlag(Enum.Status.Applied)) _ccw.checkboxApplied.IsChecked = true;
            if (Company.Status.HasFlag(Enum.Status.Hunted)) _ccw.checkboxHunted.IsChecked = true;
            if (Company.Status.HasFlag(Enum.Status.Assignment)) _ccw.checkboxAssign.IsChecked = true;
            if (Company.Status.HasFlag(Enum.Status.Interview)) _ccw.checkboxInterview.IsChecked = true;
            if (Company.Status.HasFlag(Enum.Status.Offered)) _ccw.checkboxOffered.IsChecked = true;
            if (Company.Status.HasFlag(Enum.Status.Accepted)) _ccw.checkboxAccepted.IsChecked = true;
            if (Company.Status.HasFlag(Enum.Status.Denied)) _ccw.checkboxDenied.IsChecked = true;
            if (Company.Status.HasFlag(Enum.Status.Rejected)) _ccw.checkboxRejected.IsChecked = true;

            if (Company.Position == Enum.PositionType.Part) _ccw.radiobuttonPartTime.IsChecked = true;
            else if (Company.Position == Enum.PositionType.Full) _ccw.radiobuttonFullTime.IsChecked = true;
            else if (Company.Position == Enum.PositionType.Contract) _ccw.radiobuttonContract.IsChecked = true;
            else _ccw.radiobuttonNA.IsChecked = true;

            _ccw.textboxNotes.Text = Company.Notes;


            if (Mode == Enum.EditMode.New)
            {
                _ccw.Title = "Add New Company";

            }
            else if (Mode == Enum.EditMode.Edit)
            {
                _ccw.Title = "Edit " + Company.Name;
                _ccw.buttonCreate.Content = "Save";
            }

            _ccw.KeyDown += new KeyEventHandler(Window_KeyDown);
            _ccw.buttonCreate.Click += Button_Click;
            _ccw.buttonCancel.Click += Button_Click;
            _ccw.buttonAddRep.Click += Button_Click;
            _ccw.buttonAddTitle.Click += Button_Click;
            _ccw.Closing += Window_Closing;
            _ccw.Loaded += Window_Loaded;

            _ccw.comboboxBoard.DisplayMemberPath = "Name";
            _ccw.comboboxBoard.ItemsSource = Boards.Instance.AllObjects();
            _ccw.comboboxBoard.SelectedIndex = Boards.Instance.TableToNames(Company.BoardID);

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Mode == Enum.EditMode.New)
            {
                _ccw.textboxName.Focus();
                _ccw.textboxName.SelectAll();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SaveCompanyDetails();
                _ccw.Close();
            }
            if (e.Key == Key.Escape)
            {
                _ccw.Close();
            }
        }

        private void TextInput_MouseDown(object sender, MouseEventArgs e)
        {
            var tb = sender as TextBox;
            if(e.OriginalSource.GetType().Name == "TextBoxView")
            {
                e.Handled = true;
                tb.Focus();
            }

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if(Exit == Enum.ExitStatus.Ok)
            {
                SaveCompanyDetails();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == _ccw.buttonCreate)
            {
                Exit = Enum.ExitStatus.Ok;
                _ccw.Close();
            }
            else if (e.Source == _ccw.buttonCancel)
            {
                Exit = Enum.ExitStatus.Cancel;
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
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {

            ((TextBox)sender).SelectAll();

        }

        private void SaveCompanyDetails()
        {
            Company.Name = Name;
            Company.WebSite = Website;
            Company.Rep = Rep;
            Company.Job = Job;
            Company.Location = Location;
            Company.AppDate = Date;
            Company.Status = Status;
            Company.Position = Position;
            Company.Notes = Notes;

            Exit = Enum.ExitStatus.Ok;
        }

        private void EditJobs()
        {
            new JobsListWindow().ShowDialog();
            RefreshJobCB();
        }

        private void EditReps()
        {
            new RepsListWindow().ShowDialog();
            RefreshRepCB();
        }

        private void RefreshJobCB()
        {
            _ccw.comboboxJob.ItemsSource = Jobs.Instance.AllObjects();
            ICollectionView view = CollectionViewSource.GetDefaultView(_ccw.comboboxJob.ItemsSource);
            view.Refresh();
        }

        private void RefreshRepCB()
        {
            _ccw.comboboxRep.ItemsSource = Reps.Instance.AllObjects();
            ICollectionView view = CollectionViewSource.GetDefaultView(_ccw.comboboxRep.ItemsSource);
            view.Refresh();
        }

        public void ShowDialog()
        {
            _ccw.ShowDialog();
        }
    }
}
