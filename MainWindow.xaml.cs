using System.Windows;

namespace Job_Application_Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Exit Status Of The Window
        public Enum.ExitStatus Exit { get; set; }

        // Default Constructor
        public MainWindow()
        {
            InitializeComponent();
            Exit = Enum.ExitStatus.Cancel;
        }
    }
}
