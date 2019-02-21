using Model;
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

namespace FactroyDemo
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        
        public UserControl1(string Name)
        {
            
            InitializeComponent();
           this.dataGrid1.ItemsSource = GetAccountData();
        }

        private void UserControl_Load(object sender, RoutedEventArgs e)
        {
           
        }


        public List<Account> GetAccountData() {
            return new List<Account>() {

                           new Account(){UserName="Mcally",Password="Mcally",CreateTime="2019-02-20",Midfly="" },
                           new Account(){UserName="Loee",Password="Mcally",CreateTime="2019-02-20",Midfly="" },
                           new Account(){UserName="Tom",Password="Mcally",CreateTime="2019-02-20",Midfly="" },
                           new Account(){UserName="Mcally",Password="Mcally",CreateTime="2019-02-20",Midfly="" },
                           new Account(){UserName="Jack",Password="Mcally",CreateTime="2019-02-20",Midfly="" },
                           new Account(){UserName="Tim",Password="Mcally",CreateTime="2019-02-20",Midfly="" },
                           new Account(){UserName="Mcally",Password="Mcally",CreateTime="2019-02-20",Midfly="" },
                           new Account(){UserName="Mcally",Password="Mcally",CreateTime="2019-02-20",Midfly="" },
                           new Account(){UserName="Mcally",Password="Mcally",CreateTime="2019-02-20",Midfly="" },
                           new Account(){UserName="Jack",Password="Mcally",CreateTime="2019-02-20",Midfly="" },
                           new Account(){UserName="Tim",Password="Mcally",CreateTime="2019-02-20",Midfly="" },
                           new Account(){UserName="Mcally",Password="Mcally",CreateTime="2019-02-20",Midfly="" },
                           new Account(){UserName="Mcally",Password="Mcally",CreateTime="2019-02-20",Midfly="" },





            };




        }

    }




    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public enum Sex { 男, 女 };  //注意 写在命名空间内 ，不要写在类里，否则台前local:Sex找不到路径

}
