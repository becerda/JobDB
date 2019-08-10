using System.Windows;

namespace Job_Application_Database
{
    /// <summary>
    /// Interaction logic for AddCompanyWindow.xaml
    /// </summary>
    /// 
    public partial class CompanyCreationWindow : Window
    {
        /// <summary>
        /// The Exit Status Of This Window
        /// </summary>
        public Enum.ExitStatus Exit { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CompanyCreationWindow()
        {
            InitializeComponent();
            Exit = Enum.ExitStatus.Cancel;
        }
    }

}
