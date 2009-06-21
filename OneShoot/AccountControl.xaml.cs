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
            AccountListBox.ItemsSource = Manager.AccountMgr;
            TypeComboBox.ItemsSource = Manager.AddinMgr;

            if ( Manager.AccountMgr.Count == 0 )
                NewButton_Click(null, null );
		}

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserNameTextBox.Text == "")
            {
                UserNameTextBox.Focus();
                return;
            }

            if (TypeComboBox.SelectedIndex < 0)
            {
                TypeComboBox.Focus();
                return;
            }

            AccountInfo acc = new AccountInfo();
            acc.UserName = UserNameTextBox.Text;
            acc.Password = PasswordTextBox.Password;
            acc.Type = (TypeComboBox.SelectedItem as AddinInfo).Name;
            Manager.AccountMgr.Add(acc);

            //
            AccountListBox.ItemsSource = Manager.AccountMgr;
            CancelButton_Click( null, null );
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NewGridLayout.Visibility = Visibility.Collapsed;
            NewButton.Visibility = Visibility.Visible;
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            NewButton.Visibility = Visibility.Collapsed;
            NewGridLayout.Visibility = Visibility.Visible;
            UserNameTextBox.Text = "";
            UserNameTextBox.Focus();
            PasswordTextBox.Clear();
        }

        private void Delete_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Manager.AccountMgr.Remove( ( sender as Image ).DataContext as AccountInfo );
            AccountListBox.ItemsSource = Manager.AccountMgr;
        }
	}
}