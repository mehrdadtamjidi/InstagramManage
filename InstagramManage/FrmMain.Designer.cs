namespace InstagramManage
{
    partial class FrmMain
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._lblWrongAccount = new System.Windows.Forms.Label();
            this._lblCorrectAccount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._lblSpam = new System.Windows.Forms.Label();
            this._lblCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._lbAccountList = new System.Windows.Forms.ListBox();
            this.btnLoadAccount = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.bgwCheckAccount = new System.ComponentModel.BackgroundWorker();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._lblWrongAccount);
            this.groupBox2.Controls.Add(this._lblCorrectAccount);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this._lblSpam);
            this.groupBox2.Controls.Add(this._lblCount);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this._lbAccountList);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 573);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Instagram Account";
            // 
            // _lblWrongAccount
            // 
            this._lblWrongAccount.AutoSize = true;
            this._lblWrongAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this._lblWrongAccount.ForeColor = System.Drawing.Color.Red;
            this._lblWrongAccount.Location = new System.Drawing.Point(222, 546);
            this._lblWrongAccount.Name = "_lblWrongAccount";
            this._lblWrongAccount.Size = new System.Drawing.Size(0, 13);
            this._lblWrongAccount.TabIndex = 13;
            // 
            // _lblCorrectAccount
            // 
            this._lblCorrectAccount.AutoSize = true;
            this._lblCorrectAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this._lblCorrectAccount.ForeColor = System.Drawing.Color.Green;
            this._lblCorrectAccount.Location = new System.Drawing.Point(130, 546);
            this._lblCorrectAccount.Name = "_lblCorrectAccount";
            this._lblCorrectAccount.Size = new System.Drawing.Size(0, 13);
            this._lblCorrectAccount.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 546);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Wrong :";
            // 
            // _lblSpam
            // 
            this._lblSpam.AutoSize = true;
            this._lblSpam.Location = new System.Drawing.Point(80, 566);
            this._lblSpam.Name = "_lblSpam";
            this._lblSpam.Size = new System.Drawing.Size(0, 13);
            this._lblSpam.TabIndex = 10;
            // 
            // _lblCount
            // 
            this._lblCount.AutoSize = true;
            this._lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this._lblCount.Location = new System.Drawing.Point(53, 546);
            this._lblCount.Name = "_lblCount";
            this._lblCount.Size = new System.Drawing.Size(0, 13);
            this._lblCount.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 546);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Correct :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 546);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Count :";
            // 
            // _lbAccountList
            // 
            this._lbAccountList.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._lbAccountList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbAccountList.FormattingEnabled = true;
            this._lbAccountList.ItemHeight = 16;
            this._lbAccountList.Location = new System.Drawing.Point(6, 19);
            this._lbAccountList.Name = "_lbAccountList";
            this._lbAccountList.ScrollAlwaysVisible = true;
            this._lbAccountList.Size = new System.Drawing.Size(280, 516);
            this._lbAccountList.TabIndex = 0;
            // 
            // btnLoadAccount
            // 
            this.btnLoadAccount.Location = new System.Drawing.Point(310, 34);
            this.btnLoadAccount.Name = "btnLoadAccount";
            this.btnLoadAccount.Size = new System.Drawing.Size(75, 23);
            this.btnLoadAccount.TabIndex = 12;
            this.btnLoadAccount.Text = "Load";
            this.btnLoadAccount.UseVisualStyleBackColor = true;
            this.btnLoadAccount.Click += new System.EventHandler(this.btnLoadAccount_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(310, 63);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(310, 92);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(155, 591);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(73, 36);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(76, 591);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(73, 36);
            this.btnStart.TabIndex = 15;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // bgwCheckAccount
            // 
            this.bgwCheckAccount.WorkerReportsProgress = true;
            this.bgwCheckAccount.WorkerSupportsCancellation = true;
            this.bgwCheckAccount.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCheckAccount_DoWork);
            this.bgwCheckAccount.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCheckAccount_ProgressChanged);
            this.bgwCheckAccount.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCheckAccount_RunWorkerCompleted);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 635);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnLoadAccount);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instagram Bot - M@T";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label _lblSpam;
        private System.Windows.Forms.Label _lblCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox _lbAccountList;
        private System.Windows.Forms.Button btnLoadAccount;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.ComponentModel.BackgroundWorker bgwCheckAccount;
        private System.Windows.Forms.Label _lblWrongAccount;
        private System.Windows.Forms.Label _lblCorrectAccount;
    }
}

