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
        // The Base Creation Window
        private BaseCreationWindow _bcw;

        // The Exit Status Of Base Creation Window
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

        // The Information That Is Being Edited
        public BaseInfo Info { get; }

        // The Text In The Base Creation Window's Name Text Box
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

        // The Extra string In The Base Creation's Extra Text Box
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

        // Default Constructor
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
        }

        // On Button Clicked Handler
        protected void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == _bcw.buttonOk)
            {
                Exit = Enum.ExitStatus.Ok;
            }

            _bcw.Close();
        }

        // On Window Closing Handler
        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Exit == Enum.ExitStatus.Ok)
            {
                SaveBaseDetails();
            }
        }

        // Extra Text Box Text Input Handler
        protected void TextboxExtra_TextInput(object sender, TextCompositionEventArgs e) { }

        // Extra Text Box Text Pasting Handler
        protected void TextboxExtra_Pasting(object sender, DataObjectPastingEventArgs e) { }

        // Saves Text Box Details To Info
        protected void SaveBaseDetails()
        {
            Info.Name = Name;
            Info.Extra = Extra;
        }

        // Shows The Base Creation Window
        public void ShowDialog()
        {
            _bcw.ShowDialog();
        }
    }

}
