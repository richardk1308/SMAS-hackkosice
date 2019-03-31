using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
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

namespace HACKKOSICE_WPF
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

        private void SumbitBtn_Click(object sender, RoutedEventArgs e)
        {
            string _id = id.Text;
            string _password = password.Password.ToString();
            NurseDbs nurseDbs = new NurseDbs();
            bool state = nurseDbs.CheckNurseLogin(_id, _password);

            if (state)
            {
                MenuWindow menuWindow = new MenuWindow(_id);
                menuWindow.Show();
                this.Close();
            }
            else
            {
                statusLbl.Content = "Invalid nurse ID or password";
                statusLbl.Foreground = Brushes.Red;
            }

        }
    }
}
