
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
            
          

        }

        private List<string> GetData()
        {
            return new List<string>() { "用户管理", "人员列表", "作业模式", "查询列表" };
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

        private async void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
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
          
          UserControl u=  new UserControl1(DemoItemsListBox.SelectedValue.ToString()+"  "+ ((ListBox)sender).SelectedIndex);
            //u.Name = ;

            this.Cotent.Content = u;
        }
    }
}
