
using FactroyDemo.window;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

using System.Windows.Input;
using System.Windows.Media;


namespace FactroyDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DemoItemsListBox.ItemsSource = GetData();

            this.Cotent.Content = new GifUserControl();

        }

        private List<Object> GetData()
        {
            return new List<object>() {
               new Items{ ImgaUrl="Images/import.png",Content="用户管理"},
               new Items{ ImgaUrl="Images/emp.png",Content="操作管理"},
               

           };

            //return new List<string>() { "用户管理", "人员列表", "作业模式", "查询列表" };
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        private void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        {



        }

        private void OnCopy(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is string stringValue)
            {
                try
                {
                    Clipboard.SetDataObject(stringValue);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }
        }

        private void ListBox_selectClike(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // MessageBox.Show(DemoItemsListBox.SelectedValue.ToString());

            //UserControl u=  new UserControl1(DemoItemsListBox.SelectedValue.ToString()+"  "+ ((ListBox)sender).SelectedIndex);
            //u.Name = ;

            // GifUserControl u = new GifUserControl();
            TableUserControl t = new TableUserControl();
            UserControl1 u = new UserControl1(DemoItemsListBox.SelectedValue as Items);

            this.Cotent.Content = u;

        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            //GifUserControl gif = new GifUserControl();
            //this.Content = gif;
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();

        }

        private void Colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            this.Close();
        }


    }
}
