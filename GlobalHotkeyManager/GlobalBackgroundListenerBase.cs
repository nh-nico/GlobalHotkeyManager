using System.Windows.Forms;

namespace nhammerl.GlobalHotkeyManager
{
    public partial class GlobalKeyBackgroundListener : Form
    {
        private TextBox Logger;
        private NotifyIcon trayNotification;
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalKeyBackgroundListener));
            this.trayNotification = new System.Windows.Forms.NotifyIcon(this.components);
            this.Logger = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // trayNotification ContextMenue
            //
            var trayNotificationContextMenue = new ContextMenu();
            trayNotificationContextMenue.MenuItems.Add(new MenuItem("Configure Hotkeys", TrayMenueConfigureHotkeys));
            trayNotificationContextMenue.MenuItems.Add(new MenuItem("Exit", TrayMenueExit));

            //
            // trayNotification
            //
            this.trayNotification.Icon = ((System.Drawing.Icon)(resources.GetObject("trayNotification.Icon")));
            this.trayNotification.Text = "notifyIcon1";
            this.trayNotification.Visible = true;
            this.trayNotification.ContextMenu = trayNotificationContextMenue;

            //
            // Logger
            //
            this.Logger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Logger.Location = new System.Drawing.Point(0, 0);
            this.Logger.Multiline = true;
            this.Logger.Name = "Logger";
            this.Logger.ReadOnly = true;
            this.Logger.Size = new System.Drawing.Size(284, 261);
            this.Logger.TabIndex = 1;
            //
            // GlobalKeyBackgroundListener
            //
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Logger);
            this.Name = "GlobalKeyBackgroundListener";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}