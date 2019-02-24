using FactroyDemo.window;
using MaterialDesignThemes.Wpf;
using Model;
using ModelService;
using Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using Utillib;
using winDemo;

namespace FactroyDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
 
    {

        //当前UI线程
        Dispatcher MainThread = Dispatcher.CurrentDispatcher;
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



            //Login l = new Login()
            //{
            //    LoginID = GetOnlyOneID.GuidToLongID("AC"),
            //    Account = "ML0000",
            //    PassWord = Encryption.SHA512Encrypt("123465"),
            //    UserName = "King",
            //    Sex = 0,
            //    Address = "广州东莞市南沙",
            //    Status = "10000000",


            //};
            //bool f = LoginService.Insert(l);
            //if (f)
            //{

            //}


            if (Check.IsEmpty(txt_UserName.Text.Trim()))
            {

                MyCustomControlLibrary.MMessageBox.Reault reault = MyCustomControlLibrary.MMessageBox.ShouBox(
                                     "账号不能为空！",
                                     "提示",
                                     MyCustomControlLibrary.MMessageBox.ButtonType.No,
                                     MyCustomControlLibrary.MMessageBox.IconType.error
                                     );
                return;

            }

            if (Check.IsEmpty(Txt_Password.Password.Trim()))
            {
                MyCustomControlLibrary.MMessageBox.Reault reault = MyCustomControlLibrary.MMessageBox.ShouBox(
                                 "密码不能为空",
                                 "提示",
                                 MyCustomControlLibrary.MMessageBox.ButtonType.No,
                                 MyCustomControlLibrary.MMessageBox.IconType.error
                                 );
                return;
            }
            //this.loading.IsIndeterminate = true;

            Login login = new Login()
            {
                Account = txt_UserName.Text.Trim(),
                PassWord = Encryption.SHA512Encrypt(Txt_Password.Password.Trim()),
                Status = "10000000"

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
            //Stopwatch stopwatch = new Stopwatch();

            //stopwatch.Start(); // 开始监视代码运行时间

            //double hours = timespan.TotalHours; // 总小时
            //double minutes = timespan.TotalMinutes; // 总分钟
            //double seconds = timespan.TotalSeconds; // 总秒数
            //double milliseconds = timespan.TotalMilliseconds; // 总毫秒数

            //ThreadStart start = () =>
            //{
            //    while (true)
            //    {
            //        TimeSpan timespan = stopwatch.Elapsed;  // 获取当前实例测量得出的总时间
            //        if (timespan.TotalMilliseconds == 5000)
            //        {
            //            stopwatch.Stop(); // 停止监视
            //            break;
            //        }

            //    }

            //};
            //new Thread(start).Start();



            //Task.Factory.StartNew(() =>
            //{
            //    Thread.Sleep(500);
            //}).ContinueWith(t =>
            //{
            //    MainSnackbar.MessageQueue.Enqueue(message);
            //}, TaskScheduler.FromCurrentSynchronizationContext());


           // updateTime();
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();



        }

        private async void updateTime()
        {
            while (true)
            {
                await Task.Run(() => Thread.Sleep(5000));
               
                await Task.Delay(100);
            }
        }
        private void ShowLoadingDialog()
        {
            var TableUserControl = new TableUserControl();

            var result = DialogHost.Show(TableUserControl, "TableUserControl", delegate (object sender, DialogOpenedEventArgs args)
            {



                //ThreadStart start = delegate ()
                //{
                //    string url = $"https://api.bobdong.cn/time_manager/user/login?name={name}&pw={pw}";

                //    var ReturnDatastr = NetHelper.HttpCall(url, null, HttpEnum.Get);

                //    var ReturnDataObject = JsonHelper.Deserialize<ReturnData<User>>(ReturnDatastr);

                //    Mainthread.BeginInvoke((Action)delegate ()// 异步更新界面
                //    {

                //        args.Session.Close(false);
                //        if (ReturnDataObject.code != 0)
                //        {
                //            MessageTips(ReturnDataObject.message);
                //        }
                //        else
                //        {
                //            MainStaticData.AccessToken = ReturnDataObject.data.access_token;
                //            Close();
                //        }
                //        // 线程结束后的操作
                //    });

                //};

                //new Thread(start).Start(); // 启动线程

            });

        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Load(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_CoseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Sample2_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("SAMPLE 2: Closing dialog with parameter: " + (eventArgs.Parameter ?? ""));
        }
    }
}
