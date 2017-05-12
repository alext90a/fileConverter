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
        HashSet<string> mAlreadyAddedFiles = new HashSet<string>();
        HashSet<string> mOutputFiles = new HashSet<string>();
        public Form1()
        {
            
            InitializeComponent();
            mConvertBtn.Enabled = false;
            mMinWordLenNum.Value = mFileConverter.minLength;
            mDeletePunctMarkChkBox.Checked = mFileConverter.isNeedPunctuationDelete;
            changeButtonsState(false);

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

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
                for (int i = 0; i < inputFiles.Length; ++i)
                {
                    if (mAlreadyAddedFiles.Contains(inputFiles[i]))
                    {
                        continue;
                    }
                
                    mInputFileListBox.Items.Add(inputFiles[i]);
                    mFileConverter.addInputFiles(inputFiles[i]);
                    mAlreadyAddedFiles.Add(inputFiles[i]);
                }
                
                mOutputFilesListBox.Items.Clear();
                List<string> outputFiles = mFileConverter.getOutputFileNames();
                for(int i=0; i<outputFiles.Count; ++i)
                {
                    mOutputFilesListBox.Items.Add(outputFiles[i]);
                    mOutputFiles.Add(outputFiles[i]);
                }
                
                
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
            mErrorGB.Visible = false;
            mExceptionBox.Visible = false;
            mExceptionBox.Clear();
            Task.Factory.StartNew(() => { mFileConverter.startConvert(convertCompleted, linesProcessed, nextFileProccessed, exceptionOccured); });
            
        }

        private void mDeletePunctMarkChkBox_CheckedChanged(object sender, EventArgs e)
        {
            mFileConverter.isNeedPunctuationDelete = mDeletePunctMarkChkBox.Checked;
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

        void convertCompleted(string convertTime)
        {
            this.Invoke((MethodInvoker)delegate
            {
                mProcGB.Visible = false;
                mFileConvertGB.Enabled = true;
                mConvertTime.Text = convertTime;
            });
        }

        void linesProcessed(string linesAmount)
        {
            this.Invoke((MethodInvoker)delegate
            {
                mLinesProcessed.Text = linesAmount;
            });
        }

        void nextFileProccessed(string fileIndex, string fileName)
        {
            this.Invoke((MethodInvoker)delegate
            {
                mFileIndex.Text = fileIndex;
                mFileName.Text = fileName;
            });
        }

        void exceptionOccured(string description)
        {
            this.Invoke((MethodInvoker)delegate
            {
                mErrorGB.Visible = true;
                mExceptionBox.Visible = true;
                mExceptionBox.Text = description;
                mProcGB.Enabled = false;
                mFileConvertGB.Enabled = true;

            });
        }

        private void mDelSelBtn_Click(object sender, EventArgs e)
        {
            int selectedIndex = mInputFileListBox.SelectedIndex;
            mAlreadyAddedFiles.Remove((string)mInputFileListBox.SelectedItem);
            mFileConverter.removeFile(selectedIndex);
            mOutputFilesListBox.Items.RemoveAt(selectedIndex);
            mInputFileListBox.Items.RemoveAt(selectedIndex);
            changeButtonsState(false);
            if(mInputFileListBox.Items.Count == 0)
            {
                mConvertBtn.Enabled = false;
            }
        }

        private void mInputFileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mOutputFilesListBox.SelectedIndex = mInputFileListBox.SelectedIndex;
            changeButtonsState(true);
        }

        private void mOutputFilesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mInputFileListBox.SelectedIndex = mOutputFilesListBox.SelectedIndex;
            changeButtonsState(true);
        }

        void changeButtonsState(bool enabled)
        {
            mDelSelBtn.Enabled = enabled;
            mEditOutput.Enabled = enabled;
        }

        private void mEditOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            FileInfo curFileInfo = new FileInfo(mFileConverter.getOutputFileNames()[mOutputFilesListBox.SelectedIndex]);
            saveFileDialog.DefaultExt = curFileInfo.Extension;
            saveFileDialog.AddExtension = true;
            saveFileDialog.OverwritePrompt = false;
            saveFileDialog.InitialDirectory = curFileInfo.DirectoryName;
            saveFileDialog.FileName = curFileInfo.Name;

            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string newPath = saveFileDialog.FileName;
                if(!mOutputFiles.Contains(newPath))
                {
                    mFileConverter.setFileOutputPath(mOutputFilesListBox.SelectedIndex, newPath);
                    mOutputFilesListBox.Items[mOutputFilesListBox.SelectedIndex] = newPath;
                    mOutputFiles.Remove(curFileInfo.FullName);
                    mOutputFiles.Add(newPath);
                }
                else
                {
                    if(newPath != curFileInfo.FullName)
                    {
                        MessageBox.Show("Such output file is already used, output file path change aborted!");
                    }
                    
                    
                }
                
            }
        }
    }
}
