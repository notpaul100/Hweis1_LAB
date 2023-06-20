namespace Hweis1_LAB3
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
            this.UI_btnStart = new System.Windows.Forms.Button();
            this.TickTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UI_btnStart
            // 
            this.UI_btnStart.Location = new System.Drawing.Point(13, 14);
            this.UI_btnStart.Name = "UI_btnStart";
            this.UI_btnStart.Size = new System.Drawing.Size(166, 116);
            this.UI_btnStart.TabIndex = 0;
            this.UI_btnStart.Text = "button1";
            this.UI_btnStart.UseVisualStyleBackColor = true;
            this.UI_btnStart.Click += new System.EventHandler(this.UI_btnStart_Click);
            // 
            // TickTimer
            // 
            this.TickTimer.Enabled = true;
            this.TickTimer.Interval = 30;
            this.TickTimer.Tick += new System.EventHandler(this.TickTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 144);
            this.Controls.Add(this.UI_btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UI_btnStart;
        private System.Windows.Forms.Timer TickTimer;
    }
}

