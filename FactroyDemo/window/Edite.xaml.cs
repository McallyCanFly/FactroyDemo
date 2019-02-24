using Model;
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
using System.Windows.Shapes;
using Utillib;

namespace FactroyDemo.window
{
    /// <summary>
    /// Edite.xaml 的交互逻辑
    /// </summary>
    public partial class Edite : Window
    {

        private string LoignID;
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
             LoignID = Convert.ToString(rows["LoginID"]);
        }




        private void Sure_Click(object sender, RoutedEventArgs e)
        {
            Login mifiy = Init();
            if (mifiy !=null) {

                bool IsOk = LoginService.Update(mifiy);
                if (IsOk)
                {
                    MyCustomControlLibrary.MMessageBox.ShowSuccessAlert("用户修改成功 ^_^ ");
                    this.Close();
                }
                else
                {
                    MyCustomControlLibrary.MMessageBox.ShowSuccessAlert("用户修改失败请联系管理员 ^_^ ");

                }
            }



        }
        private Login Init()
        {
            string Account = this.Account.Text;
          
            string Job = this.Job.Text;
            string EmpNo = this.EmpNo.Text;
            string UserName = this.UserName.Text;
            string Age = this.Age.Text;
            string SexCombox = this.SexCombox.Text;
            string Modifly = this.Modifly.Text;
            string Address = this.Address.Text;
            //if (Check.IsEmpty(Account))
            //{
            //    MyCustomControlLibrary.MMessageBox.ShowSuccessAlert("账号不能为空 ^_^ ");
            //    return null;
            //}
            //if (LoginService.CheckAccount(Account))
            //{
            //    MyCustomControlLibrary.MMessageBox.ShowSuccessAlert($"账号:{Account}已存在不能重复添加 ^_^ ");
            //    return null;
            //}


            

            if (Check.IsEmpty(UserName))
            {
                MyCustomControlLibrary.MMessageBox.ShowSuccessAlert("姓名不能为空 ^_^ ");
                return null;
            }
            if (Check.IsEmpty(Age))
            {
                MyCustomControlLibrary.MMessageBox.ShowSuccessAlert("年龄不能为空 ^_^ ");
                return null;
            }
            else
            {
                if (!Regex.Match(Age, @"^[0-9]*$").Success)
                {
                    MyCustomControlLibrary.MMessageBox.ShowSuccessAlert("年龄请输入数字 ^_^ ");
                    return null;
                }
            }
            if (Check.IsEmpty(SexCombox))
            {
                MyCustomControlLibrary.MMessageBox.ShowSuccessAlert("性别不能为空 ^_^ ");
                return null;
            }

            return new Login()
            {
                LoginID = LoignID,
                Account = Account,
                UserName = UserName,
                Age = int.Parse(Age),
                Job = Job,
                EmpNo = EmpNo,
                Address = Address,
                Sex = SexCombox == "男" ? 0 : 1,
                ModifyTime=Modifly,
               
            };


        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
