using Job_Application_Database.Classes;
using System;
using System.ComponentModel;
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
using Job_Application_Database.IO;
using Job_Application_Database.Singleton;

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
