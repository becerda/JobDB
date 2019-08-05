using Job_Application_Database.Classes;
using Job_Application_Database.Singleton;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

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
