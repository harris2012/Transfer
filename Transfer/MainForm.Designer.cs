namespace Transfer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.btStop = new System.Windows.Forms.Button();
            this.textRadioButton = new System.Windows.Forms.RadioButton();
            this.fileRadioButton = new System.Windows.Forms.RadioButton();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(28, 139);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(134, 40);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "开始";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(16, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(252, 251);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // inputTextBox
            // 
            this.inputTextBox.AllowDrop = true;
            this.inputTextBox.Location = new System.Drawing.Point(16, 42);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(709, 63);
            this.inputTextBox.TabIndex = 2;
            this.inputTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.inputTextBox_DragDrop);
            this.inputTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.inputTextBox_DragEnter);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(168, 139);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(136, 40);
            this.btStop.TabIndex = 4;
            this.btStop.Text = "停止";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // textRadioButton
            // 
            this.textRadioButton.AutoSize = true;
            this.textRadioButton.Location = new System.Drawing.Point(81, 20);
            this.textRadioButton.Name = "textRadioButton";
            this.textRadioButton.Size = new System.Drawing.Size(59, 16);
            this.textRadioButton.TabIndex = 5;
            this.textRadioButton.Text = "传文本";
            this.textRadioButton.UseVisualStyleBackColor = true;
            // 
            // fileRadioButton
            // 
            this.fileRadioButton.AutoSize = true;
            this.fileRadioButton.Checked = true;
            this.fileRadioButton.Location = new System.Drawing.Point(16, 20);
            this.fileRadioButton.Name = "fileRadioButton";
            this.fileRadioButton.Size = new System.Drawing.Size(59, 16);
            this.fileRadioButton.TabIndex = 6;
            this.fileRadioButton.TabStop = true;
            this.fileRadioButton.Text = "传文件";
            this.fileRadioButton.UseVisualStyleBackColor = true;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(16, 20);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(709, 21);
            this.outputTextBox.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textRadioButton);
            this.groupBox1.Controls.Add(this.fileRadioButton);
            this.groupBox1.Controls.Add(this.inputTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 121);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.outputTextBox);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(742, 331);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输出";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 528);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.RadioButton textRadioButton;
        private System.Windows.Forms.RadioButton fileRadioButton;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

