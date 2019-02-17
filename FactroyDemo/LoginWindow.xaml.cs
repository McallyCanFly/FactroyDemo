﻿using MaterialDesignThemes.Wpf;
using Model;
using ModelService;
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
using winDemo;

namespace FactroyDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 登录
        /// Mcally  2019年2月17日14:30:12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clike_Login(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_UserName.Text.Trim()))
            {
                MyCustomControlLibrary.MMessageBox.Reault reault = MyCustomControlLibrary.MMessageBox.ShouBox(
                                     "账号不能为空！",
                                     "提示",
                                     MyCustomControlLibrary.MMessageBox.ButtonType.No,
                                     MyCustomControlLibrary.MMessageBox.IconType.error
                                     );
                return;

            }

            if (string.IsNullOrWhiteSpace(Txt_Password.Password.Trim()))
            {
                MyCustomControlLibrary.MMessageBox.Reault reault = MyCustomControlLibrary.MMessageBox.ShouBox(
                                 "密码不能为空",
                                 "提示",
                                 MyCustomControlLibrary.MMessageBox.ButtonType.No,
                                 MyCustomControlLibrary.MMessageBox.IconType.error
                                 );
                return;
            }
            Login login = new Login()
            {
                UserName = txt_UserName.Text.Trim(),
                PassWord = Txt_Password.Password.Trim()

            };

            Login lg = LoginService.GetUser(login);
            if (lg == null)
            {
                MyCustomControlLibrary.MMessageBox.Reault reault = MyCustomControlLibrary.MMessageBox.ShouBox(
                                     "密码或账号错误！",
                                     "提示",
                                     MyCustomControlLibrary.MMessageBox.ButtonType.No,
                                     MyCustomControlLibrary.MMessageBox.IconType.error
                                     );
                return;
            }
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();



        }
        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Load(object sender, RoutedEventArgs e)
        {

        }
    }
}
