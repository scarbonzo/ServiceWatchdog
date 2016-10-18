namespace ServiceWatchdog
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbServicesToMonitor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lvServiceStatus = new System.Windows.Forms.ListView();
            this.timerAlert = new System.Windows.Forms.Timer(this.components);
            this.cbAlerts = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbServicesToMonitor
            // 
            this.tbServicesToMonitor.Location = new System.Drawing.Point(14, 60);
            this.tbServicesToMonitor.Multiline = true;
            this.tbServicesToMonitor.Name = "tbServicesToMonitor";
            this.tbServicesToMonitor.Size = new System.Drawing.Size(309, 531);
            this.tbServicesToMonitor.TabIndex = 0;
            this.tbServicesToMonitor.Text = resources.GetString("tbServicesToMonitor.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Services to watch: <SERVERNAME,SERVICENAME>";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(326, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current Service Status:";
            this.label2.UseWaitCursor = true;
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 15000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(14, 12);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 6;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // lvServiceStatus
            // 
            this.lvServiceStatus.Location = new System.Drawing.Point(329, 60);
            this.lvServiceStatus.Name = "lvServiceStatus";
            this.lvServiceStatus.Size = new System.Drawing.Size(516, 531);
            this.lvServiceStatus.TabIndex = 7;
            this.lvServiceStatus.UseCompatibleStateImageBehavior = false;
            this.lvServiceStatus.View = System.Windows.Forms.View.List;
            // 
            // timerAlert
            // 
            this.timerAlert.Interval = 5000;
            this.timerAlert.Tick += new System.EventHandler(this.timerAlert_Tick);
            // 
            // cbAlerts
            // 
            this.cbAlerts.AutoSize = true;
            this.cbAlerts.ForeColor = System.Drawing.Color.White;
            this.cbAlerts.Location = new System.Drawing.Point(110, 16);
            this.cbAlerts.Name = "cbAlerts";
            this.cbAlerts.Size = new System.Drawing.Size(95, 19);
            this.cbAlerts.TabIndex = 8;
            this.cbAlerts.Text = "Send Alerts?";
            this.cbAlerts.UseVisualStyleBackColor = true;
            this.cbAlerts.CheckedChanged += new System.EventHandler(this.cbAlerts_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(859, 603);
            this.Controls.Add(this.cbAlerts);
            this.Controls.Add(this.lvServiceStatus);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbServicesToMonitor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "ServiceWatchdog";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbServicesToMonitor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.ListView lvServiceStatus;
        private System.Windows.Forms.Timer timerAlert;
        private System.Windows.Forms.CheckBox cbAlerts;
    }
}

