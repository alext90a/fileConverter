namespace FileConverter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mInputFileListBox = new System.Windows.Forms.ListBox();
            this.mSelectInputFiles = new System.Windows.Forms.Button();
            this.mOutputFilesListBox = new System.Windows.Forms.ListBox();
            this.mConvertBtn = new System.Windows.Forms.Button();
            this.mDeletePunctMarkChkBox = new System.Windows.Forms.CheckBox();
            this.mMinWordLenNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.mFileConvertGB = new System.Windows.Forms.GroupBox();
            this.mEditOutput = new System.Windows.Forms.Button();
            this.mDelSelBtn = new System.Windows.Forms.Button();
            this.mConvertTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mProcGB = new System.Windows.Forms.GroupBox();
            this.mFileIndex = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mFileName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mLinesProcessed = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mExceptionBox = new System.Windows.Forms.TextBox();
            this.mErrorGB = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.mMinWordLenNum)).BeginInit();
            this.mFileConvertGB.SuspendLayout();
            this.mProcGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mInputFileListBox
            // 
            this.mInputFileListBox.FormattingEnabled = true;
            this.mInputFileListBox.HorizontalScrollbar = true;
            this.mInputFileListBox.Location = new System.Drawing.Point(19, 48);
            this.mInputFileListBox.Name = "mInputFileListBox";
            this.mInputFileListBox.Size = new System.Drawing.Size(171, 95);
            this.mInputFileListBox.TabIndex = 1;
            this.mInputFileListBox.SelectedIndexChanged += new System.EventHandler(this.mInputFileListBox_SelectedIndexChanged);
            // 
            // mSelectInputFiles
            // 
            this.mSelectInputFiles.Location = new System.Drawing.Point(19, 19);
            this.mSelectInputFiles.Name = "mSelectInputFiles";
            this.mSelectInputFiles.Size = new System.Drawing.Size(75, 23);
            this.mSelectInputFiles.TabIndex = 2;
            this.mSelectInputFiles.Text = "Add files";
            this.mSelectInputFiles.UseVisualStyleBackColor = true;
            this.mSelectInputFiles.Click += new System.EventHandler(this.mSelectInputFiles_Click);
            // 
            // mOutputFilesListBox
            // 
            this.mOutputFilesListBox.FormattingEnabled = true;
            this.mOutputFilesListBox.HorizontalScrollbar = true;
            this.mOutputFilesListBox.Location = new System.Drawing.Point(236, 48);
            this.mOutputFilesListBox.Name = "mOutputFilesListBox";
            this.mOutputFilesListBox.Size = new System.Drawing.Size(195, 95);
            this.mOutputFilesListBox.TabIndex = 3;
            this.mOutputFilesListBox.SelectedIndexChanged += new System.EventHandler(this.mOutputFilesListBox_SelectedIndexChanged);
            // 
            // mConvertBtn
            // 
            this.mConvertBtn.Enabled = false;
            this.mConvertBtn.Location = new System.Drawing.Point(19, 231);
            this.mConvertBtn.Name = "mConvertBtn";
            this.mConvertBtn.Size = new System.Drawing.Size(171, 23);
            this.mConvertBtn.TabIndex = 4;
            this.mConvertBtn.Text = "Convert";
            this.mConvertBtn.UseVisualStyleBackColor = true;
            this.mConvertBtn.Click += new System.EventHandler(this.mConvertBtn_Click);
            // 
            // mDeletePunctMarkChkBox
            // 
            this.mDeletePunctMarkChkBox.AutoSize = true;
            this.mDeletePunctMarkChkBox.Location = new System.Drawing.Point(19, 197);
            this.mDeletePunctMarkChkBox.Name = "mDeletePunctMarkChkBox";
            this.mDeletePunctMarkChkBox.Size = new System.Drawing.Size(142, 17);
            this.mDeletePunctMarkChkBox.TabIndex = 5;
            this.mDeletePunctMarkChkBox.Text = "Delete punctuation mark";
            this.mDeletePunctMarkChkBox.UseVisualStyleBackColor = true;
            this.mDeletePunctMarkChkBox.CheckedChanged += new System.EventHandler(this.mDeletePunctMarkChkBox_CheckedChanged);
            // 
            // mMinWordLenNum
            // 
            this.mMinWordLenNum.Location = new System.Drawing.Point(19, 162);
            this.mMinWordLenNum.Name = "mMinWordLenNum";
            this.mMinWordLenNum.Size = new System.Drawing.Size(64, 20);
            this.mMinWordLenNum.TabIndex = 7;
            this.mMinWordLenNum.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.mMinWordLenNum.ValueChanged += new System.EventHandler(this.mMinWordLenNum_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Min word length";
            // 
            // mFileConvertGB
            // 
            this.mFileConvertGB.Controls.Add(this.mEditOutput);
            this.mFileConvertGB.Controls.Add(this.mDelSelBtn);
            this.mFileConvertGB.Controls.Add(this.mConvertTime);
            this.mFileConvertGB.Controls.Add(this.label2);
            this.mFileConvertGB.Controls.Add(this.label1);
            this.mFileConvertGB.Controls.Add(this.mMinWordLenNum);
            this.mFileConvertGB.Controls.Add(this.mDeletePunctMarkChkBox);
            this.mFileConvertGB.Controls.Add(this.mConvertBtn);
            this.mFileConvertGB.Controls.Add(this.mOutputFilesListBox);
            this.mFileConvertGB.Controls.Add(this.mSelectInputFiles);
            this.mFileConvertGB.Controls.Add(this.mInputFileListBox);
            this.mFileConvertGB.Controls.Add(this.mExceptionBox);
            this.mFileConvertGB.Controls.Add(this.mErrorGB);
            this.mFileConvertGB.Location = new System.Drawing.Point(30, 8);
            this.mFileConvertGB.Name = "mFileConvertGB";
            this.mFileConvertGB.Size = new System.Drawing.Size(501, 265);
            this.mFileConvertGB.TabIndex = 11;
            this.mFileConvertGB.TabStop = false;
            this.mFileConvertGB.Text = "Files convert settings";
            // 
            // mEditOutput
            // 
            this.mEditOutput.Location = new System.Drawing.Point(236, 18);
            this.mEditOutput.Name = "mEditOutput";
            this.mEditOutput.Size = new System.Drawing.Size(75, 23);
            this.mEditOutput.TabIndex = 13;
            this.mEditOutput.Text = "Edit output";
            this.mEditOutput.UseVisualStyleBackColor = true;
            this.mEditOutput.Click += new System.EventHandler(this.mEditOutput_Click);
            // 
            // mDelSelBtn
            // 
            this.mDelSelBtn.Location = new System.Drawing.Point(114, 18);
            this.mDelSelBtn.Name = "mDelSelBtn";
            this.mDelSelBtn.Size = new System.Drawing.Size(75, 23);
            this.mDelSelBtn.TabIndex = 12;
            this.mDelSelBtn.Text = "Del selected";
            this.mDelSelBtn.UseVisualStyleBackColor = true;
            this.mDelSelBtn.Click += new System.EventHandler(this.mDelSelBtn_Click);
            // 
            // mConvertTime
            // 
            this.mConvertTime.AutoSize = true;
            this.mConvertTime.Location = new System.Drawing.Point(326, 162);
            this.mConvertTime.Name = "mConvertTime";
            this.mConvertTime.Size = new System.Drawing.Size(0, 13);
            this.mConvertTime.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Convertion time:";
            // 
            // mProcGB
            // 
            this.mProcGB.Controls.Add(this.mFileIndex);
            this.mProcGB.Controls.Add(this.label6);
            this.mProcGB.Controls.Add(this.mFileName);
            this.mProcGB.Controls.Add(this.label4);
            this.mProcGB.Controls.Add(this.label3);
            this.mProcGB.Controls.Add(this.mLinesProcessed);
            this.mProcGB.Controls.Add(this.pictureBox1);
            this.mProcGB.Location = new System.Drawing.Point(30, 280);
            this.mProcGB.Name = "mProcGB";
            this.mProcGB.Size = new System.Drawing.Size(501, 169);
            this.mProcGB.TabIndex = 13;
            this.mProcGB.TabStop = false;
            this.mProcGB.Text = "Processing output";
            this.mProcGB.Visible = false;
            // 
            // mFileIndex
            // 
            this.mFileIndex.AutoSize = true;
            this.mFileIndex.Location = new System.Drawing.Point(225, 20);
            this.mFileIndex.Name = "mFileIndex";
            this.mFileIndex.Size = new System.Drawing.Size(0, 13);
            this.mFileIndex.TabIndex = 6;
            this.mFileIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Files:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mFileName
            // 
            this.mFileName.AutoSize = true;
            this.mFileName.Location = new System.Drawing.Point(225, 120);
            this.mFileName.Name = "mFileName";
            this.mFileName.Size = new System.Drawing.Size(0, 13);
            this.mFileName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Current file:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lines processed:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mLinesProcessed
            // 
            this.mLinesProcessed.AutoSize = true;
            this.mLinesProcessed.Location = new System.Drawing.Point(222, 137);
            this.mLinesProcessed.Name = "mLinesProcessed";
            this.mLinesProcessed.Size = new System.Drawing.Size(13, 13);
            this.mLinesProcessed.TabIndex = 1;
            this.mLinesProcessed.Text = "0";
            this.mLinesProcessed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(190, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 72);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // mExceptionBox
            // 
            this.mExceptionBox.ForeColor = System.Drawing.Color.Red;
            this.mExceptionBox.Location = new System.Drawing.Point(208, 195);
            this.mExceptionBox.Multiline = true;
            this.mExceptionBox.Name = "mExceptionBox";
            this.mExceptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mExceptionBox.Size = new System.Drawing.Size(278, 57);
            this.mExceptionBox.TabIndex = 16;
            this.mExceptionBox.Visible = false;
            // 
            // mErrorGB
            // 
            this.mErrorGB.Location = new System.Drawing.Point(196, 178);
            this.mErrorGB.Name = "mErrorGB";
            this.mErrorGB.Size = new System.Drawing.Size(299, 81);
            this.mErrorGB.TabIndex = 15;
            this.mErrorGB.TabStop = false;
            this.mErrorGB.Text = "Error:";
            this.mErrorGB.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 490);
            this.Controls.Add(this.mProcGB);
            this.Controls.Add(this.mFileConvertGB);
            this.Name = "Form1";
            this.Text = "File converter";
            ((System.ComponentModel.ISupportInitialize)(this.mMinWordLenNum)).EndInit();
            this.mFileConvertGB.ResumeLayout(false);
            this.mFileConvertGB.PerformLayout();
            this.mProcGB.ResumeLayout(false);
            this.mProcGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox mInputFileListBox;
        private System.Windows.Forms.Button mSelectInputFiles;
        private System.Windows.Forms.ListBox mOutputFilesListBox;
        private System.Windows.Forms.Button mConvertBtn;
        private System.Windows.Forms.CheckBox mDeletePunctMarkChkBox;
        private System.Windows.Forms.NumericUpDown mMinWordLenNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox mFileConvertGB;
        private System.Windows.Forms.GroupBox mProcGB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label mLinesProcessed;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label mFileIndex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label mFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label mConvertTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button mDelSelBtn;
        private System.Windows.Forms.Button mEditOutput;
        private System.Windows.Forms.TextBox mExceptionBox;
        private System.Windows.Forms.GroupBox mErrorGB;
    }
}

