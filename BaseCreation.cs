using Job_Application_Database.Enum;
using System.Windows;
using System.Windows.Input;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Job Board creation window extended from BaseCreation
    /// </summary>
    public abstract class BaseCreation : BaseWindow
    {
        /// <summary>
        /// Reference To The Base Creation Window
        /// </summary>
        private BaseCreationWindow BaseCreationWindow
        {
            get
            {
                return (BaseCreationWindow)base.Window;
            }
        }

        /// <summary>
        /// The Exit Status Of Base Creation Window
        /// </summary>
        public override ExitStatus Exit
        {
            get
            {
                return BaseCreationWindow.Exit;
            }
            set
            {
                BaseCreationWindow.Exit = value;
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
                return BaseCreationWindow.textboxName.Text;
            }
            set
            {
                BaseCreationWindow.textboxName.Text = value;
            }
        }

        /// <summary>
        /// The Extra String In The Base Creation's Extra TextBox
        /// </summary>
        private string Extra
        {
            get
            {
                return BaseCreationWindow.textboxExtra.Text;
            }
            set
            {
                BaseCreationWindow.textboxExtra.Text = value;
            }
        }

        /// <summary>
        /// Constructor To Create A New BaseCreationWindow
        /// </summary>
        /// <param name="info">The Info To Be Edited</param>
        /// <param name="mode">The Editing Mode</param>
        /// <param name="title">The Title Of The Window</param>
        /// <param name="label">The Label Of The Extra String</param>
        public BaseCreation(BaseInfo info, Enum.EditMode mode, string title, string label) : base(new BaseCreationWindow(), "")
        {
            Info = info;
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

                BaseCreationWindow.textboxName.Text = info.Name;
                BaseCreationWindow.textboxExtra.Text = info.Extra;
            }

            _title += title;

            BaseCreationWindow.Title = _title;
            BaseCreationWindow.labelExtra.Content = label;
            BaseCreationWindow.textboxExtra.Text = label;
            BaseCreationWindow.buttonOk.Content = _button;

            BaseCreationWindow.Closing += Window_Closing;
            BaseCreationWindow.KeyDown += Window_KeyDown;
        }

        /// <summary>
        /// Overrided Window Loaded Event Method
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BaseCreationWindow.buttonCancel.Click += Element_Click;
            BaseCreationWindow.buttonOk.Click += Element_Click;
        }

        /// <summary>
        /// Window Closing Event Method
        /// Handles Exit Status Flow
        /// </summary>
        /// <param name="sender">Object Which Called This Function</param>
        /// <param name="e">The Arguments</param>
        protected override void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Exit == Enum.ExitStatus.Ok)
            {
                SaveBaseDetails();
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
            if (e.Key == Key.Escape)
            {
                BaseCreationWindow.Exit = ExitStatus.Cancel;
                BaseCreationWindow.Close();
            }
            else if (e.Key == Key.Enter)
            {
                SaveBaseDetails();
                BaseCreationWindow.Exit = ExitStatus.Ok;
                BaseCreationWindow.Close();
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
            if (e.Source == BaseCreationWindow.buttonOk)
            {
                Exit = Enum.ExitStatus.Ok;
            }

            BaseCreationWindow.Close();
        }

        /// <summary>
        /// Takes Info From Window And Saves To Info
        /// </summary>
        protected void SaveBaseDetails()
        {
            Info.Name = Name;
            Info.Extra = Extra;
        }

    }
}
