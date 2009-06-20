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
	public partial class TitleBarControl
	{
        System.Windows.Forms.NotifyIcon notifyIcon;

		public TitleBarControl()
		{
			this.InitializeComponent();

			// 在此点之下插入创建对象所需的代码。
		}

        public Window Owner { get; set; }

        private void OnMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                Owner.DragMove();
        }

        private void OnMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount > 1)
            {
                if (Owner.WindowState == WindowState.Normal)
                {
                    Owner.WindowState = WindowState.Maximized;
                }
                else
                {
                    Owner.WindowState = WindowState.Normal;
                }
            }
        }

        void notifyIcon_Click(object sender, EventArgs e)
        {
            this.notifyIcon.Dispose();
            this.notifyIcon = null;
            Owner.Show();
        }

        private void OnMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.notifyIcon = new System.Windows.Forms.NotifyIcon();
            this.notifyIcon.Click += new EventHandler(notifyIcon_Click);
            this.notifyIcon.BalloonTipText = "One shoot still running.";
            this.notifyIcon.Text = "One shoot still running.";
            this.notifyIcon.Icon = new System.Drawing.Icon("Resource/OneShoot.ico");
            this.notifyIcon.Visible = true;
            Owner.Hide();
        }


        private void Close_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Owner.Close();
        }

        private void Logo_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://OneShoot.org");
        }
	}
}