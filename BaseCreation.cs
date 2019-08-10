using Job_Application_Database.Enum;
using System.Windows;
using System.Windows.Input;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Job Board creation window extended from BaseCreation
    /// </summary>
    public abstract class BaseCreation
    {
        /// <summary>
        /// Reference To The Base Creation Window
        /// </summary>
        private BaseCreationWindow _bcw;

        /// <summary>
        /// The Exit Status Of Base Creation Window
        /// </summary>
        public Enum.ExitStatus Exit
        {
            get
            {
                return _bcw.Exit;
            }
            set
            {
                _bcw.Exit = value;
            }
        }

        /// <summary>
        /// The Information That Is Being Edited
        /// </summary>
        public BaseInfo Info { get; }

        /// <summary>
        /// The Text In The Base Creation Window's Name TextBoxes
        /// </summary>
        private string Name
        {
            get
            {
                return _bcw.textboxName.Text;
            }
            set
            {
                _bcw.textboxName.Text = value;
            }
        }

        /// <summary>
        /// The Extra String In The Base Creation's Extra TextBox
        /// </summary>
        private string Extra
        {
            get
            {
                return _bcw.textboxExtra.Text;
            }
            set
            {
                _bcw.textboxExtra.Text = value;
            }
        }

        /// <summary>
        /// Constructor To Create A New BaseCreationWindow
        /// </summary>
        /// <param name="info">The Info To Be Edited</param>
        /// <param name="mode">The Editing Mode</param>
        /// <param name="title">The Title Of The Window</param>
        /// <param name="label">The Label Of The Extra String</param>
        public BaseCreation(BaseInfo info, Enum.EditMode mode, string title, string label)
        {
            Info = info;
            _bcw = new BaseCreationWindow();
            string _title = string.Empty;
            string _button = string.Empty;
            if (mode == EditMode.New)
            {
                _title = "New ";
                _button = "Create";
            }
            else if (mode == EditMode.Edit)
            {
                _title = "Edit " + info.Name + " ";
                _button = "Save";

                _bcw.textboxName.Text = info.Name;
                _bcw.textboxExtra.Text = info.Extra;
            }

            _title = title;

            _bcw.Title = _title;
            _bcw.labelExtra.Content = label;
            _bcw.textboxExtra.Text = label;
            _bcw.buttonOk.Content = _button;

            _bcw.buttonCancel.Click += Button_Click;
            _bcw.buttonOk.Click += Button_Click;
            _bcw.Closing += Window_Closing;
            _bcw.KeyDown += BaseCreationWindow_KeyDown;
        }

        /// <summary>
        /// Window Key Down Event Method
        /// Handles Enter And Escape Key Presses
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        private void BaseCreationWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _bcw.Exit = ExitStatus.Cancel;
                _bcw.Close();
            }
            else if (e.Key == Key.Enter)
            {
                SaveBaseDetails();
                _bcw.Exit = ExitStatus.Ok;
                _bcw.Close();
            }
        }

        /// <summary>
        /// Window Button Click Method
        /// Handles Button Presses
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == _bcw.buttonOk)
            {
                Exit = Enum.ExitStatus.Ok;
            }

            _bcw.Close();
        }

        /// <summary>
        /// Window Closing Event Method
        /// Handles Exit Status Flow
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Exit == Enum.ExitStatus.Ok)
            {
                SaveBaseDetails();
            }
        }

        /// <summary>
        /// Takes Info From Window And Saves To Info
        /// </summary>
        protected void SaveBaseDetails()
        {
            Info.Name = Name;
            Info.Extra = Extra;
        }

        /// <summary>
        /// Calls CompanyCreationWindow's ShowDialog Method
        /// </summary>
        public void ShowDialog()
        {
            _bcw.ShowDialog();
        }
    }

}
