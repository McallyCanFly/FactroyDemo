using System;
using System.Collections.Generic;
using System.Data;
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

namespace FactroyDemo.window
{
    /// <summary>
    /// Edite.xaml 的交互逻辑
    /// </summary>
    public partial class Edite : Window
    {
        public Edite(DataRow rows)
        {

            InitializeComponent();
            this.Account.Text = Convert.ToString(rows["Account"]);
            this.UserName.Text = Convert.ToString(rows["UserName"]);
            this.SexCombox.Text = Convert.ToString(rows["Sex"]);
            this.Age.Text = Convert.ToString(rows["Age"]);
            this.EmpNo.Text = Convert.ToString(rows["EmpNo"]);
            this.Job.Text = Convert.ToString(rows["Job"]);
            this.Address.Text = Convert.ToString(rows["Address"]);
            this.Modifly.Text = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        }

        private void Sure_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
