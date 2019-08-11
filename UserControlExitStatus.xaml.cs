using Job_Application_Database.Enum;
using System.Windows.Controls;

namespace Job_Application_Database
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControlExitStatus : UserControl
    {
        public ExitStatus Exit { get; set; }

        public UserControlExitStatus()
        {
            InitializeComponent();
        }
    }
}
