using Job_Application_Database.Enum;
using System.Windows;
using System.Windows.Input;

namespace Job_Application_Database.Classes
{
    public abstract class BaseCreation
    {
        private BaseCreationWindow _bcw;

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

        public BaseInfo Info { get; }

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

        public BaseCreation(BaseInfo info, Enum.EditMode mode, string title, string label)
        {
            Info = info;
            _bcw = new BaseCreationWindow();
            string _title = string.Empty;
            string _label = string.Empty;
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
            _label = label;

            /*if (info.GetType() == typeof(Job))
            {
                _title += "Job";
                _label = "Salary";
            }
            else if (info.GetType() == typeof(Rep))
            {
                _title += "Representative";
                _label = "Email";
            }
            else if (info.GetType() == typeof(Board))
            {
                _title += "Job Board";
                _label = "Website";
            }*/

            _bcw.Title = _title;
            _bcw.labelExtra.Content = _label;
            _bcw.textboxExtra.Text = _label;
            _bcw.buttonOk.Content = _button;

            _bcw.buttonCancel.Click += Button_Click;
            _bcw.buttonOk.Click += Button_Click;
            _bcw.Closing += Window_Closing;
        }

        protected void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == _bcw.buttonOk)
            {
                Exit = Enum.ExitStatus.Ok;
            }

            _bcw.Close();
        }

        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Exit == Enum.ExitStatus.Ok)
            {
                SaveBaseDetails();
            }
        }

        protected void TextboxExtra_TextInput(object sender, TextCompositionEventArgs e) { }

        protected void TextboxExtra_Pasting(object sender, DataObjectPastingEventArgs e) { }

        protected void SaveBaseDetails()
        {
            Info.Name = Name;
            Info.Extra = Extra;
        }

        public void ShowDialog()
        {
            _bcw.ShowDialog();
        }
    }

    public class JobCreation : BaseCreation
    {
        public JobCreation() : this(new Job(), Enum.EditMode.New) { }

        public JobCreation(Job job) : this(job, Enum.EditMode.Edit) { }

        public JobCreation(Job job, EditMode mode) : base(job, mode, "Job", "Salary") { }
    }

    public class RepCreation : BaseCreation
    {
        public RepCreation() : this(new Rep(), Enum.EditMode.New) { }

        public RepCreation(Rep rep) : this(rep, Enum.EditMode.Edit) { }

        public RepCreation(Rep rep, EditMode mode) : base(rep, mode, "Representative", "Email") { }
    }

    public class BoardCreation : BaseCreation
    {
        public BoardCreation() : this(new Board(), Enum.EditMode.New) { }

        public BoardCreation(Board board) : this(board, Enum.EditMode.Edit) { }

        public BoardCreation(Board board, EditMode mode) : base(board, mode, "Job Board", "Website") { }
    }
}
