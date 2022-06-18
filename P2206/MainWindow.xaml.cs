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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace P2206
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemBeenden_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItemAdressen_Click(object sender, RoutedEventArgs e)
        {
            Adressen frmAdressen = new Adressen();
            mainframe.Navigate(frmAdressen);
        }

        private void MenuItemTiere_Click(object sender, RoutedEventArgs e)
        {
            Tiere frmTiere = new Tiere();
            mainframe.Navigate(frmTiere);
        }

        private void CommonCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
