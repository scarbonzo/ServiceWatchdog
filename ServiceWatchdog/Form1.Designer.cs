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
            this.lbServiceStatus = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lbDatabaseStatus = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tbServicesToMonitor
            // 
            this.tbServicesToMonitor.Location = new System.Drawing.Point(14, 60);
            this.tbServicesToMonitor.Multiline = true;
            this.tbServicesToMonitor.Name = "tbServicesToMonitor";
            this.tbServicesToMonitor.Size = new System.Drawing.Size(307, 415);
            this.tbServicesToMonitor.TabIndex = 0;
            this.tbServicesToMonitor.Text = resources.GetString("tbServicesToMonitor.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Services to watch:";
            this.label1.UseWaitCursor = true;
            // 
            // lbServiceStatus
            // 
            this.lbServiceStatus.FormattingEnabled = true;
            this.lbServiceStatus.ItemHeight = 15;
            this.lbServiceStatus.Location = new System.Drawing.Point(351, 60);
            this.lbServiceStatus.Name = "lbServiceStatus";
            this.lbServiceStatus.Size = new System.Drawing.Size(342, 424);
            this.lbServiceStatus.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(348, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current Service Status:";
            this.label2.UseWaitCursor = true;
            // 
            // timerUpdate
            // 
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(709, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Current Database Status:";
            this.label3.UseWaitCursor = true;
            // 
            // lbDatabaseStatus
            // 
            this.lbDatabaseStatus.FormattingEnabled = true;
            this.lbDatabaseStatus.ItemHeight = 15;
            this.lbDatabaseStatus.Location = new System.Drawing.Point(712, 60);
            this.lbDatabaseStatus.Name = "lbDatabaseStatus";
            this.lbDatabaseStatus.Size = new System.Drawing.Size(342, 424);
            this.lbDatabaseStatus.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1077, 516);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbDatabaseStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbServiceStatus);
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
        private System.Windows.Forms.ListBox lbServiceStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbDatabaseStatus;
    }
}

