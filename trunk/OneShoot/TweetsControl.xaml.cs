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
	public partial class TweetsControl
	{
		public TweetsControl()
		{
			this.InitializeComponent();

			// 在此点之下插入创建对象所需的代码。
            
		}

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            NewButton.Visibility = Visibility.Collapsed;
            NewGridLayout.Visibility = Visibility.Visible;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NewGridLayout.Visibility = Visibility.Collapsed;
            NewButton.Visibility = Visibility.Visible;
        }

        private void TweetTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountLabel.Content = 140 - TweetTextBox.Text.Length;
        }
	}
}