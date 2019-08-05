using System.Windows;

namespace Job_Application_Database
{
    /// <summary>
    /// Interaction logic for AddCompanyWindow.xaml
    /// </summary>
    /// 
    public partial class CompanyCreationWindow : Window
    {

        public Enum.ExitStatus Exit { get; set; }

        public CompanyCreationWindow()
        {
            InitializeComponent();
            Exit = Enum.ExitStatus.Cancel;
        }
    }

}
