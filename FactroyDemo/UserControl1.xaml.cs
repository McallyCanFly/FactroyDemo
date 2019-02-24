using FactroyDemo.window;
using MaterialDesignThemes.Wpf;
using Model;
using MyCustomControlLibrary;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        int rows = 10;


        #region    初始化窗体
        /// <summary>
        /// 初始化窗体
        /// Mcally  2019年2月24日10:14:38
        /// </summary>
        /// <param name="Name"></param>
        public UserControl1(string Name)
        {
            InitializeComponent();
            int total = 0;
            //两种方式这种需要在xmal 文件里的DataGrid  加上ItemsSource="{Binding}"  必须加 
            this.dataGrid1.DataContext = LoginService.getAllUserDataTable(ref total, 1, rows);
            this.tbkTotal.Text = total.ToString();
            this.tbkCurrentsize.Text = "1";
            this.btnUp.IsEnabled = false;

            //这种不需要加  
            //this.dataGrid1.ItemsSource = (LoginService.getAllUserDataTable("10000000")).DefaultView;
            //设置网格线
            //this.dataGrid1.GridLinesVisibility = DataGridGridLinesVisibility.All;


            this.Title.Text = Name;
        }
        #endregion

        #region  新增按钮事件
        /// <summary>
        /// 新增按钮
        /// Mcally 2019年2月24日10:15:04
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Clike(object sender, RoutedEventArgs e)
        {
            // string s=Convert.ToString(((Button)sender).Tag);
            // MessageBox.Show(s);
            Add a = new Add();

            bool? f = a.ShowDialog();
            if (f == false)
            {
                int total = 0;
                //两种方式这种需要在xmal 文件里的DataGrid  加上ItemsSource="{Binding}"  必须加 
                this.dataGrid1.DataContext = LoginService.getAllUserDataTable(ref total, 1, rows);
                this.tbkTotal.Text = total.ToString();
                this.tbkCurrentsize.Text = "1";
                this.btnUp.IsEnabled = false;
            }



        }
        #endregion

        #region 分页加载
        /// <summary>
        /// 分页加载
        /// Mcally 2019年2月24日10:13:402
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Go_Click(object sender, RoutedEventArgs e)
        {
            string page = this.tbxPageNum.Text;
            //是否输入为空值
            if (string.IsNullOrWhiteSpace(page))
            {
                //MMessageBox.ShowAlert(
                //                     "Success!",
                //                     Orientation.Horizontal,
                //                     null,
                //                     "#3ca9fe",
                //                     false);
                //  MMessageBox.ShowSuccessAlert();
                MMessageBox.ShowSuccessAlert("请先输入页数 ^_^ ");
                return;

            }
            //是否为数值
            if (!Regex.Match(page, @"^[0-9]*$").Success)
            {
                MMessageBox.ShowSuccessAlert("页数请输入数字 ^_^ ");
                return;
            }
            int total = 0;
            this.btnNext.IsEnabled = true;
            this.btnUp.IsEnabled = true;
            DataTable dt = LoginService.getAllUserDataTable(ref total, int.Parse(page), rows);

            if (dt == null || dt.Rows.Count == 0)
            {
                this.btnNext.IsEnabled = false;
                MMessageBox.ShowSuccessAlert("无数据。。 ^_^ ");
                return;
            }
            if (dt.Rows.Count < rows)
            {
                this.btnNext.IsEnabled = false;
            }
            this.dataGrid1.DataContext = dt;
            this.tbkTotal.Text = total.ToString();
            this.tbkCurrentsize.Text = page;

        }
        #endregion

        #region  上一页事件
        /// <summary>
        /// Mcally 2019年2月24日12:12:48
        /// 上一页 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            this.btnNext.IsEnabled = true;
            //读取当前的页数
            int page = int.Parse(this.tbkCurrentsize.Text);
            int total = 0;
            page--;
            if (page == 1)
            {
                this.btnUp.IsEnabled = false;
                this.dataGrid1.DataContext = LoginService.getAllUserDataTable(ref total, page, rows);
                this.tbkCurrentsize.Text = page.ToString();
                return;
            }
            this.dataGrid1.DataContext = LoginService.getAllUserDataTable(ref total, page, rows);
            this.tbkCurrentsize.Text = page.ToString();
            this.tbkTotal.Text = total.ToString();
        }

        #endregion
        #region  下一页
        /// <summary>
        /// Mcally 2019年2月24日12:24:34
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            this.btnUp.IsEnabled = true;
            //读取当前的页数
            int page = int.Parse(this.tbkCurrentsize.Text);

            int total = 0;
            page++;
            DataTable dt = LoginService.getAllUserDataTable(ref total, page, rows);
            if (dt.Rows.Count < rows)
            {
                this.btnNext.IsEnabled = false;
            }
            if (dt == null || dt.Rows.Count == 0)
            {
                this.btnNext.IsEnabled = false;
                MMessageBox.ShowSuccessAlert("已经是最后一页了 ^_^ ");
                return;
            }
            this.dataGrid1.DataContext = dt;
            this.tbkCurrentsize.Text = page.ToString();
            this.tbkTotal.Text = total.ToString();
        }
        #endregion

        #region  删除
        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            MMessageBox.Reault reault = MMessageBox.ShouBox(
                                             "是否要删除？",
                                             "警 告",
                                             MMessageBox.ButtonType.YesNo,
                                             MMessageBox.IconType.warring,
                                             Orientation.Horizontal,
                                             "是",
                                             "否"
                                             );

            if (reault == MMessageBox.Reault.Yes)
            {
                // MMessageBox.ShowSuccessAlert("你点了 是");
                string LoginID = ((Button)sender).Tag.ToString();
                int idex = this.dataGrid1.SelectedIndex;
                string Account = Convert.ToString((((DataView)this.dataGrid1.ItemsSource).Table).Rows[idex]["Account"]);
                string LoginIDtwo = Convert.ToString((((DataView)this.dataGrid1.ItemsSource).Table).Rows[idex]["LoginID"]);
                if (LoginID == LoginIDtwo)
                {
                    if (LoginService.Delete(LoginIDtwo, Account, "10000003"))
                    {

                        MMessageBox.ShowSuccessAlert("删除成功 ^_^ ");
                        //读取当前的页数
                        int page = int.Parse(this.tbkCurrentsize.Text);
                        int total = 0;     
                        DataTable dt = LoginService.getAllUserDataTable(ref total, page, rows);
                        if (dt.Rows.Count < rows)
                        {
                            this.btnNext.IsEnabled = false;
                        }
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            this.btnNext.IsEnabled = false;
                         
                            return;
                        }
                        this.dataGrid1.DataContext = dt;
                        this.tbkCurrentsize.Text = page.ToString();
                        this.tbkTotal.Text = total.ToString();
                    }
                    else
                    {
                        MMessageBox.ShowSuccessAlert("删除失败,请联系管理员 ^_^ ");
                    }
                }
                else
                {
                    MMessageBox.ShowSuccessAlert("系统服务忙，请联系管理员 ^_^ ");

                }
            }

        }
        #endregion

        #region  修改
        private void Modifly_btn_Click(object sender, RoutedEventArgs e)
        {
            int idex = this.dataGrid1.SelectedIndex;
            DataRow row = (((DataView)this.dataGrid1.ItemsSource).Table).Rows[idex];

            Edite edite = new Edite(row);
          
            if (edite.ShowDialog()==false) {

            };
        }
        #endregion
    }




    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    //public enum Sex { 男, 女 };  //注意 写在命名空间内 ，不要写在类里，否则台前local:Sex找不到路径

}
