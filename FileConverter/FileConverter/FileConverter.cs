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

        public delegate void OnConvertCompleted();
        OnConvertCompleted mOnConverCompleted = null;

        public delegate void OnLinesBatchProcessed(string linesAmount);
        OnLinesBatchProcessed mOnLinesBatchProcessed = null;

        public delegate void OnNextFileProcessed(string fileIndex, string fileName);
        OnNextFileProcessed mOnNextFileProcessed = null;

        public FileConverter()
        {

        }

        public void setInputFiles(string[] inputFiles)
        {

            
            for(int i=0; i<inputFiles.Length; ++i)
            {
                mInputFiles.Add(new FileInfo(inputFiles[i]));

                
                mOutputFiles.Add(mInputFiles[i].FullName.Substring(0, mInputFiles[i].FullName.LastIndexOf('.')) + kDefaultConverterSuffix + mInputFiles[i].Extension);
            }
        }

        public List<string> getOutputFileNames()
        {
            return mOutputFiles;
        }

        public void startConvert(OnConvertCompleted completeFunc, OnLinesBatchProcessed batchProcFunc, OnNextFileProcessed nextFileFunc)
        {
            mOnConverCompleted = completeFunc;
            mOnLinesBatchProcessed = batchProcFunc;
            mOnNextFileProcessed = nextFileFunc;
            StringBuilder sb = new StringBuilder();
            for(int i=0; i<mInputFiles.Count; ++i)
            {
                sb.Clear();
                sb.Append(i.ToString() + "/" + mInputFiles.Count.ToString());
                mOnNextFileProcessed(sb.ToString(), mInputFiles[i].Name);
                convertSelectedFile(mInputFiles[i].FullName, mOutputFiles[i]);
            }
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

        void convertSelectedFile(string inputFileName, string outputFileName)
        {

            FileInfo curInfo = new FileInfo(inputFileName);
            long fileLength = curInfo.Length;
            StreamReader sr = File.OpenText(inputFileName);
            
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
            while ((data = sr.ReadLine()) != null)
            {
                batchData.Add(data);
                if (batchData.Count == batchCount)
                {
                    CheckBatchData(batchData, convertedData);
                    //CheckBatchDataParallel(batchData, deletedChars, convertedData);
                    WriteDataToFile(convertedData, batchData.Count, fsConverted);
                    totalLines += batchData.Count;
                    mOnLinesBatchProcessed(totalLines.ToString());
                    batchData.Clear();
                }
            }
            CheckBatchData(batchData, convertedData);
            //CheckBatchDataParallel(batchData, deletedChars, convertedData);
            WriteDataToFile(convertedData, batchData.Count, fsConverted);
            totalLines += batchData.Count;
            mOnLinesBatchProcessed(totalLines.ToString());
            batchData.Clear();
            

            DateTime endTime = DateTime.Now;
            TimeSpan productionTime = endTime - startTime;
            mOnConverCompleted();
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
