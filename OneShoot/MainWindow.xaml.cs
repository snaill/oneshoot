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
        System.Windows.Forms.NotifyIcon notifyIcon;

		public MainWindow()
		{
			this.InitializeComponent();
			
			// 在此点之下插入创建对象所需的代码。
		}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //
            Manager.Init();

            if (Manager.AccountMgr.Count == 0)
                Tabs.SelectedItem = AccountTab;
            else
            {
                AccountListBox.ItemsSource = Manager.AccountMgr;
                Manager.Refresh();
                TweetListBox.ItemsSource = Manager.Tweets;
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.Refresh();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void NewButon_Click(object sender, RoutedEventArgs e)
        {
            TypeComboBox.ItemsSource = Manager.AddinMgr;
            NewGridLayout.Visibility = Visibility.Visible;
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            AccountInfo acc = new AccountInfo();
            acc.UserName = UserNameTextBox.Text;
            acc.Password = PasswordTextBox.Password;
            acc.Type = ((AddinInfo)TypeComboBox.SelectedItem).Name;
      //      Manager.AccountMgr.Add(acc);
            ((AccountManager)AccountListBox.ItemsSource).Add(acc);

            NewGridLayout.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NewGridLayout.Visibility = Visibility.Collapsed;
        }

        private void TitleBar_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                this.DragMove();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount > 1)
            {
                if (this.WindowState == WindowState.Normal)
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
            }
        }

        private void TitleBar_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.notifyIcon = new System.Windows.Forms.NotifyIcon();
            this.notifyIcon.Click += new EventHandler(notifyIcon_Click);
            this.notifyIcon.BalloonTipText = "One shoot still running.";
            this.notifyIcon.Text = "One shoot still running.";
            this.notifyIcon.Icon = new System.Drawing.Icon("Resource/OneShoot.ico");
            this.notifyIcon.Visible = true;
            this.Hide();
        }

        void notifyIcon_Click(object sender, EventArgs e)
        {
            this.notifyIcon.Dispose();
            this.notifyIcon = null;
            this.Show();
        }
	}
}