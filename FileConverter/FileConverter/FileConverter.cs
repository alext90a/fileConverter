using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter
{
    class FileConverter
    {
        List<FileInfo> mInputFiles = new List<FileInfo>();
        List<string> mOutputFiles = new List<string>();
        string kDefaultConverterSuffix = "_converted";
        List<char> mDeletedChars = new List<char>() { ',', '.', '!', '?', ':', ';' };
        int mMinLength = 4;
        bool mIsNeedPunctuationDelete = true;
        TimeSpan mConvertTime;

        public delegate void OnConvertCompleted(string convertTime);
        OnConvertCompleted mOnConverCompleted = null;

        public delegate void OnLinesBatchProcessed(string linesAmount);
        OnLinesBatchProcessed mOnLinesBatchProcessed = null;

        public delegate void OnNextFileProcessed(string fileIndex, string fileName);
        OnNextFileProcessed mOnNextFileProcessed = null;

        public FileConverter()
        {

        }

        public void addInputFiles(string inputFile)
        {
            FileInfo curFileInfo = new FileInfo(inputFile);
            mInputFiles.Add(curFileInfo);

                
            mOutputFiles.Add(curFileInfo.FullName.Substring(0, curFileInfo.FullName.LastIndexOf('.')) + kDefaultConverterSuffix + curFileInfo.Extension);
        }

        public List<string> getOutputFileNames()
        {
            return mOutputFiles;
        }

        public void startConvert(OnConvertCompleted completeFunc, OnLinesBatchProcessed batchProcFunc, OnNextFileProcessed nextFileFunc)
        {
            mConvertTime = new TimeSpan();
            mOnConverCompleted = completeFunc;
            mOnLinesBatchProcessed = batchProcFunc;
            mOnNextFileProcessed = nextFileFunc;
            StringBuilder sb = new StringBuilder();
            for(int i=0; i<mInputFiles.Count; ++i)
            {
                sb.Clear();
                sb.Append((i+1).ToString() + "/" + mInputFiles.Count.ToString());
                mOnNextFileProcessed(sb.ToString(), mInputFiles[i].Name);
                convertSelectedFile(mInputFiles[i].FullName, mOutputFiles[i]);
            }

            //TimeSpan ts = new TimeSpan(3, 42, 0);
            string convertTime = String.Format("{0:%h} hours {0:%m} minutes {0:%s\\.ff} seconds", mConvertTime);
            //Console.WriteLine("{0:%h} hours {0:%m} minutes", ts);
            mOnConverCompleted(convertTime);
        }

        public bool isNeedPunctuationDelete
        {
            get
            {
                return mIsNeedPunctuationDelete;
            }
            set
            {
                mIsNeedPunctuationDelete = value;
            }
        }

        public int minLength
        {
            get
            {
                return mMinLength;
            }
            set
            {
                mMinLength = value;
            }
        }

        public void removeFile(int index)
        {
            mInputFiles.RemoveAt(index);
            mOutputFiles.RemoveAt(index);
        }

        void convertSelectedFile(string inputFileName, string outputFileName)
        {

            FileInfo curInfo = new FileInfo(inputFileName);
            long fileLength = curInfo.Length;
            StreamReader inputReader = File.OpenText(inputFileName);
            
            if (File.Exists(outputFileName))
            {
                File.Delete(outputFileName);
            }
                
            FileStream fsConverted = File.Create(outputFileName);
            int batchCount = 1000;
            List<string> batchData = new List<string>(batchCount);
            string[] convertedData = new string[batchCount];
            string data = String.Empty;
            long totalLines = 0;
            DateTime startTime = DateTime.Now;
            while ((data = inputReader.ReadLine()) != null)
            {
                batchData.Add(data);
                if (batchData.Count == batchCount)
                {
                    //CheckBatchData(batchData, convertedData);
                    CheckBatchDataParallel(batchData, convertedData);
                    WriteDataToFile(convertedData, batchData.Count, fsConverted);
                    totalLines += batchData.Count;
                    mOnLinesBatchProcessed(totalLines.ToString());
                    batchData.Clear();
                }
            }
            //CheckBatchData(batchData, convertedData);
            CheckBatchDataParallel(batchData, convertedData);
            WriteDataToFile(convertedData, batchData.Count, fsConverted);
            totalLines += batchData.Count;
            mOnLinesBatchProcessed(totalLines.ToString());
            batchData.Clear();
            fsConverted.Close();
            inputReader.Close();

            DateTime endTime = DateTime.Now;
            //TimeSpan productionTime = endTime - startTime;
            mConvertTime += endTime - startTime;
        }

        static string ConvertString(string inputString, int minLength, List<char> deletedChars, bool isDeletionNeeded)
        {
            String outputString = String.Empty;
            StringBuilder createdString = new StringBuilder();
            StringBuilder curWord = new StringBuilder();
            for (int i = 0; i < inputString.Length; ++i)
            {
                if (isDeletionNeeded && deletedChars.Contains(inputString[i]))
                {
                    continue;
                }
                if (inputString[i] != ' ')
                {
                    curWord.Append(inputString[i]);
                }
                else
                {
                    if (curWord.Length >= minLength)
                    {
                        createdString.Append(curWord);
                        createdString.Append(inputString[i]);

                    }
                    curWord.Clear();
                }
            }
            createdString.Append(curWord);
            createdString.Append("\n");
            outputString = createdString.ToString();
            return outputString;
        }

        void CheckBatchDataParallel(List<string> batchData, string[] convertedData)
        {
            object lockObject = new object();

            Parallel.For(0, batchData.Count,
                (i) =>
                {
                    string curString = batchData[i];
                    convertedData[i] = ConvertString(curString, mMinLength, mDeletedChars, mIsNeedPunctuationDelete);
                });
        }

        void WriteDataToFile(string[] convertedData, int elementsAmount, FileStream fs)
        {
            for (int i = 0; i < elementsAmount; ++i)
            {
                byte[] info = new UTF8Encoding(true).GetBytes(convertedData[i]);
                fs.Write(info, 0, info.Length);
            }
        }

        void CheckBatchData(List<string> batchData, string[] convertedData)
        {
            for (int i = 0; i < batchData.Count; ++i)
            {
                string curString = batchData[i];
                convertedData[i] = ConvertString(curString, mMinLength, mDeletedChars, mIsNeedPunctuationDelete);
            }
        }

        

        void CreateTestFile()
        {
            /*
            FileStream fs = File.Create("Test.txt");

            for(int i = 0; i< 1000000; ++i)
            {
                byte[] info = new UTF8Encoding(true).GetBytes("Some text"+ Guid.NewGuid().ToString()+", and messages, and questions!\n");
                fs.Write(info, 0, info.Length);
            }
            */
        }
    }
}
