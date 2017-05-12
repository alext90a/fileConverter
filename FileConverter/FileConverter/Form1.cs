using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileConverter;
using System.IO;

namespace FileConverter
{
    public partial class Form1 : Form
    {
        FileConverter mFileConverter = new FileConverter();
        public Form1()
        {
            
            InitializeComponent();
            mConvertBtn.Enabled = false;
            mMinWordLenNum.Value = mFileConverter.minLength;
            mDeletePunctMarkChkBox.Checked = mFileConverter.isNeedPunctuationDelete;

        }

        private void mSelectInputFiles_Click(object sender, EventArgs e)
        {
            
            
            

            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "txt files (*txt)|*.txt|All files(*.*)|*
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] inputFiles = openFileDialog.FileNames;
                mInputFileListBox.Items.Clear();
                mOutputFilesListBox.Items.Clear();
                mInputFileListBox.Items.AddRange(inputFiles);
                mFileConverter.setInputFiles(inputFiles);
                mOutputFilesListBox.Items.AddRange(mFileConverter.getOutputFileNames().ToArray());
                if(inputFiles.Length > 0)
                {
                    mConvertBtn.Enabled = true;
                }
            }
        }

        private void mConvertBtn_Click(object sender, EventArgs e)
        {
            mFileConvertGB.Enabled = false;
            mProcGB.Visible = true;
            //mProcGB.Update();
            Task.Factory.StartNew(() => { mFileConverter.startConvert(convertCompleted, linesProcessed); });
            
        }

        private void mDeletePunctMarkChkBox_CheckedChanged(object sender, EventArgs e)
        {
            mFileConverter.isNeedPunctuationDelete = !mFileConverter.isNeedPunctuationDelete;
        }

        private void mMinWordLenNum_ValueChanged(object sender, EventArgs e)
        {
            mFileConverter.minLength = (int)mMinWordLenNum.Value;
        }


        private void mProgressBar_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        void convertCompleted()
        {
            this.Invoke((MethodInvoker)delegate
            {
                mProcGB.Enabled = false;
                mFileConvertGB.Enabled = true;
            });
        }

        void linesProcessed(string linesAmount)
        {
            this.Invoke((MethodInvoker)delegate
            {
                mLinesProcessed.Text = linesAmount;
            });
        }

    }
}
