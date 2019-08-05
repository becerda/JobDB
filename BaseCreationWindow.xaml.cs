using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
