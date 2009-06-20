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
            this.Header.Owner = this;
		}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //
            Manager.Init();

            if (Manager.AccountMgr.Count == 0)
                Tabs.SelectedItem = AccountTab;
            else
            {
                Manager.Refresh();
                TweetListBox.ItemsSource = Manager.Tweets;
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.Refresh();
        }
	}
}