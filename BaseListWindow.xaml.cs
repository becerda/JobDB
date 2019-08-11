using System.Windows;

namespace Job_Application_Database
{
    /// <summary>
    /// Interaction logic for AddEditJobTitleWindow.xaml
    /// </summary>
    public partial class BaseListWindow : Window
    {
        /// <summary>
        /// Exit Status Of This Window
        /// </summary>
        public Enum.ExitStatus Exit { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BaseListWindow()
        {
            InitializeComponent();
            Exit = Enum.ExitStatus.Cancel;

        }
    }

}
