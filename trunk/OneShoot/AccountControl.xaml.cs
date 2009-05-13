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
	public partial class AccountControl
	{
		public AccountControl()
		{
			this.InitializeComponent();

			// 在此点之下插入创建对象所需的代码。
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
            acc.Type = TypeComboBox.SelectedItem.ToString();
            Manager.AccountMgr.Add(acc);

            NewGridLayout.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NewGridLayout.Visibility = Visibility.Collapsed;
        }

        private void AccountListBox_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Manager.Main.TweetPanel.Visibility = Visibility.Visible;
            Manager.Main.AccountPanel.Visibility = Visibility.Hidden;
        }
	}
}