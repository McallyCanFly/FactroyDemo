using Model;
using Service;
using System;
using System.Collections.Generic;
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
    /// Add.xaml 的交互逻辑
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
            this.CreatTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        }

        private void Sure_Click(object sender, RoutedEventArgs e)
        {
            Login user = Init();
            if (user != null)
            {
                bool IsOk = LoginService.Insert(user);
                if (IsOk)
                {
                    MyCustomControlLibrary.MMessageBox.ShowSuccessAlert("用户添加成功 ^_^ ");
                    this.Close();
                }
                else
                {
                    MyCustomControlLibrary.MMessageBox.ShowSuccessAlert("用户添加失败请稍后重试 ^_^ ");

                }
            }
        }

        private Login Init()
        {
            string Account = this.Account.Text;
            string Password = this.Password.Password;
            string surePass = this.surePass.Password;
            string Job = this.Job.Text;
            string EmpNo = this.EmpNo.Text;
            string UserName = this.UserName.Text;
            string Age = this.Age.Text;
            string SexCombox = this.SexCombox.Text;
            string CreatTime = this.CreatTime.Text;
            string Address = this.Address.Text;
            if (Check.IsEmpty(Account))
            {
                MyCustomControlLibrary.MMessageBox.ShowSuccessAlert("账号不能为空 ^_^ ");
                return null;
            }
            if (LoginService.CheckAccount(Account))
            {
                MyCustomControlLibrary.MMessageBox.ShowSuccessAlert($"账号:{Account}已存在不能重复添加 ^_^ ");
                return null;
            }


            if (Check.IsEmpty(Password))
            {
                MyCustomControlLibrary.MMessageBox.ShowSuccessAlert("密码不能为空 ^_^ ");
                return null;
            }
            if (Check.IsEmpty(surePass))
            {
                MyCustomControlLibrary.MMessageBox.ShowSuccessAlert("确认密码不能为空 ^_^ ");
                return null;
            }
            else
            {
                if (Password != surePass)
                {
                    MyCustomControlLibrary.MMessageBox.ShowSuccessAlert("确认密码和原密码不一致 ^_^ ");
                    return null;
                }
            }

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
                LoginID = GetOnlyOneID.GuidToLongID("AC"),
                Account = Account,
                PassWord = Encryption.SHA512Encrypt(Password),
                UserName = UserName,
                Age = int.Parse(Age),
                Job = Job,
                EmpNo = EmpNo,
                Address = Address,
                Sex = SexCombox == "男" ? 0 : 1,
                Status = "10000000"
            };


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
