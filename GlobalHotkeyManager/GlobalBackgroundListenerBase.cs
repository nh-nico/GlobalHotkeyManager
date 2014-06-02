using System.Windows.Forms;
using nhammerl.GlobalHotkeyManager.Properties;

namespace nhammerl.GlobalHotkeyManager
{
    public partial class GlobalKeyBackgroundListener : Form
    {
        private TextBox _logger;
        private NotifyIcon _trayNotification;
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalKeyBackgroundListener));
            this._trayNotification = new NotifyIcon(this.components);
            this._logger = new TextBox();
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
            this._trayNotification.Icon = ((System.Drawing.Icon)(resources.GetObject("_trayNotification.Icon")));
            this._trayNotification.Text = Resources.GlobalKeyBackgroundListener_InitializeComponent_GlobalHotkeyManager;
            this._trayNotification.Visible = true;
            this._trayNotification.ContextMenu = trayNotificationContextMenue;

            //
            // Logger
            //
            this._logger.Dock = DockStyle.Fill;
            this._logger.Location = new System.Drawing.Point(0, 0);
            this._logger.Multiline = true;
            this._logger.Name = "_logger";
            this._logger.ReadOnly = true;
            this._logger.Size = new System.Drawing.Size(284, 261);
            this._logger.TabIndex = 1;
            //
            // GlobalKeyBackgroundListener
            //
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this._logger);
            this.Name = "GlobalKeyBackgroundListener";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}