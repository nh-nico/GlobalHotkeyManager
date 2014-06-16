using nhammerl.GlobalHotkeyManager.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace nhammerl.GlobalHotkeyManager
{
    public partial class GlobalKeyBackgroundListener : Form
    {
        private TextBox _logger;
        private NotifyIcon _trayNotification;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem _autostartMenueItem;

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

            _autostartMenueItem = new ToolStripMenuItem("Autostart",
                ((Icon)resources.GetObject("autostart")).ToBitmap(), AutoStartMenueItemClicked) { CheckOnClick = true };

            var trayNotificationContextMenue = new ContextMenuStrip();
            trayNotificationContextMenue.Items.Add(new ToolStripMenuItem("Configure Hotkeys", ((Icon)resources.GetObject("settings")).ToBitmap(), TrayMenueConfigureHotkeys));
            trayNotificationContextMenue.Items.Add(_autostartMenueItem);
            trayNotificationContextMenue.Items.Add(new ToolStripMenuItem("Exit", ((Icon)resources.GetObject("exit")).ToBitmap(), TrayMenueExit));

            //
            // trayNotification
            //
            this._trayNotification.Icon = ((Icon)(resources.GetObject("keyboard")));
            this._trayNotification.Text = Resources.GlobalKeyBackgroundListener_InitializeComponent_GlobalHotkeyManager;
            this._trayNotification.Visible = true;
            this._trayNotification.ContextMenuStrip = trayNotificationContextMenue;

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