using System.Windows;

namespace Job_Application_Database
{
    /// <summary>
    /// Interaction logic for RepCreationWindow.xaml
    /// </summary>
    public partial class BaseCreationWindow : Window
    {
        /// <summary>
        /// The Exit Status Of This Window
        /// </summary>
        public Enum.ExitStatus Exit { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BaseCreationWindow()
        {
            InitializeComponent();
            Exit = Enum.ExitStatus.Cancel;
        }
    }

}
