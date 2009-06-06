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

            if ( Manager.AccountMgr.Accounts.Count == 0 )
                Tabs.SelectedItem = AccountTab;
            else
                AccountListBox.ItemsSource = Manager.AccountMgr.Accounts;
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
            TypeComboBox.ItemsSource = Manager.AddinMgr.Addins;
            NewGridLayout.Visibility = Visibility.Visible;
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            AccountInfo acc = new AccountInfo();
            acc.UserName = UserNameTextBox.Text;
            acc.Password = PasswordTextBox.Password;
            acc.Type = ((AddinInfo)TypeComboBox.SelectedItem).Name;
            Manager.AccountMgr.Add(acc);

            NewGridLayout.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NewGridLayout.Visibility = Visibility.Collapsed;
        }

	}
}