using Job_Application_Database.Classes;
using Job_Application_Database.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Job_Application_Database
{
    /// <summary>
    /// Interaction logic for JobWindow.xaml
    /// </summary>
    public partial class JobCreationWindow
    {
        private BaseCreationWindow _bcw;

        private Jobs _jm;
        private static readonly Regex _regex = new Regex("[0-9.,]+");

        public Job Job { get; set; }

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

        public JobCreationWindow() : base()
        {
            Job = new Job();
            _jm = Jobs.Instance;

            _bcw = new BaseCreationWindow();
            _bcw.buttonCancel.Click += Button_Click;
            _bcw.buttonOk.Click += Button_Click;
            _bcw.textboxExtra.PreviewTextInput += TextboxExtra_TextInput;
            DataObject.AddPastingHandler(_bcw.textboxExtra, TextboxExtra_Pasting);

        }

        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Exit == Enum.ExitStatus.Ok)
            {
                _jm.AddObject(Job);
            }
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == _bcw.buttonOk)
            {
                SaveJobDetails();
                Exit = Enum.ExitStatus.Ok;

            }
            else
            {
                Exit = Enum.ExitStatus.Cancel;
            }

            Close();
        }

        public void TextboxExtra_TextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !_regex.IsMatch(e.Text);
        }

        public void TextboxExtra_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (!_regex.IsMatch((string)e.DataObject.GetData(typeof(string))))
            {
                e.CancelCommand();
            }
        }

        private void SaveJobDetails()
        {
            Job.Name = _bcw.textboxName.Text;
            Job.Extra = _bcw.textboxExtra.Text;
        }

        public void SetEditingJob(ref Job j)
        {
            _bcw.textboxName.Text = j.Name;
            _bcw.textboxExtra.Text = j.Extra + "";
            this.Job = j;

            _bcw.buttonOk.Content = "Save";
        }
    }
}
