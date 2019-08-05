using System.Windows;

namespace Job_Application_Database
{
    /// <summary>
    /// Interaction logic for RepCreationWindow.xaml
    /// </summary>
    public partial class BaseCreationWindow : Window
    {
        public Enum.ExitStatus Exit { get; set; }

        public BaseCreationWindow()
        {
            InitializeComponent();
            Exit = Enum.ExitStatus.Cancel;
        }
    }

}
