namespace Challenge159
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
            this.webBrowserHashKiller = new System.Windows.Forms.WebBrowser();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.webBrowserChallenge = new System.Windows.Forms.WebBrowser();
            this.textBoxLogging = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // webBrowserHashKiller
            // 
            this.webBrowserHashKiller.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserHashKiller.Location = new System.Drawing.Point(16, 12);
            this.webBrowserHashKiller.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserHashKiller.Name = "webBrowserHashKiller";
            this.webBrowserHashKiller.Size = new System.Drawing.Size(606, 250);
            this.webBrowserHashKiller.TabIndex = 0;
            // 
            // buttonSolve
            // 
            this.buttonSolve.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSolve.Location = new System.Drawing.Point(12, 268);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(610, 23);
            this.buttonSolve.TabIndex = 5;
            this.buttonSolve.Text = "Fill the CAPTCHA above (nothing else), then click here to solve the challenge";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.SolveClicked);
            // 
            // webBrowserChallenge
            // 
            this.webBrowserChallenge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserChallenge.Location = new System.Drawing.Point(16, 297);
            this.webBrowserChallenge.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserChallenge.Name = "webBrowserChallenge";
            this.webBrowserChallenge.Size = new System.Drawing.Size(606, 250);
            this.webBrowserChallenge.TabIndex = 6;
            // 
            // textBoxLogging
            // 
            this.textBoxLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLogging.Location = new System.Drawing.Point(12, 553);
            this.textBoxLogging.Multiline = true;
            this.textBoxLogging.Name = "textBoxLogging";
            this.textBoxLogging.ReadOnly = true;
            this.textBoxLogging.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogging.Size = new System.Drawing.Size(610, 145);
            this.textBoxLogging.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 710);
            this.Controls.Add(this.textBoxLogging);
            this.Controls.Add(this.webBrowserChallenge);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.webBrowserHashKiller);
            this.Name = "Form1";
            this.Text = "Challenge 159";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserHashKiller;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.WebBrowser webBrowserChallenge;
        private System.Windows.Forms.TextBox textBoxLogging;
    }
}

