using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace OneShoot
{
    public partial class MainWindow
	{
		public MainWindow()
		{
			this.InitializeComponent();
			
			// 在此点之下插入创建对象所需的代码。
		}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //
            Manager.Init();
            Manager.Main = this;

            //
            AccountPanel.AccountListBox.ItemsSource = Manager.Accounts;

            //
            TweetPanel.Visibility = Visibility.Hidden;
            AccountPanel.Visibility = Visibility.Visible;
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            TweetPanel.Visibility = Visibility.Hidden;
            AccountPanel.Visibility = Visibility.Visible;
        }
	}
}