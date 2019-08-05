using System.Windows;

namespace Job_Application_Database
{
    /// <summary>
    /// Interaction logic for AddEditJobTitleWindow.xaml
    /// </summary>
    public partial class BaseListWindow : Window
    {
        public Enum.ExitStatus Exit { get; set; }

        public BaseListWindow()
        {
            InitializeComponent();
            Exit = Enum.ExitStatus.Cancel;

        }
    }

}
