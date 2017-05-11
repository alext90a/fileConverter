using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Threading;

namespace FileConverter
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            FileStream fs = File.Create("Test.txt");

            for(int i = 0; i< 1000000; ++i)
            {
                byte[] info = new UTF8Encoding(true).GetBytes("Some text"+ Guid.NewGuid().ToString()+", and messages, and questions!\n");
                fs.Write(info, 0, info.Length);
            }
            */
            string inputFileName = "Test";
            string fileExtension = "txt";
            StreamReader sr = File.OpenText(inputFileName + "." + fileExtension);
            string outputFileName = inputFileName + "_converted." + fileExtension;
            if (File.Exists(outputFileName))
            {
                File.Delete(outputFileName);
            }
                
            FileStream fsConverted = File.Create(outputFileName);
            int batchCount = 1000;
            List<string> batchData = new List<string>(batchCount);
            string[] convertedData = new string[batchCount];
            string data = String.Empty;
            List<char> deletedChars = new List<char>() { ',', '.', '!', '?', ':', ';' };
            int amountOfChars = 0;

            DateTime startTime = DateTime.Now;
            while ((data = sr.ReadLine()) != null)
            {
                batchData.Add(data);
                if (batchData.Count == batchCount)
                {
                    CheckBatchData(batchData, deletedChars, convertedData);
                    //CheckBatchDataParallel(batchData, deletedChars, convertedData);
                    WriteDataToFile(convertedData, batchData.Count, fsConverted);
                    batchData.Clear();
                    
                }
            }
            CheckBatchData(batchData, deletedChars, convertedData);
            //CheckBatchDataParallel(batchData, deletedChars, convertedData);
            WriteDataToFile(convertedData, batchData.Count, fsConverted);
            batchData.Clear();
            

            DateTime endTime = DateTime.Now;
            TimeSpan productionTime = endTime - startTime;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());



        }

        static string ConvertString(string inputString, int minLength, List<char> deletedChars)
        {
            String outputString = String.Empty;
            StringBuilder createdString = new StringBuilder();
            StringBuilder curWord = new StringBuilder();
            for(int i=0; i<inputString.Length; ++i)
            {
                if(deletedChars.Contains(inputString[i]))
                {
                    continue;
                }
                if(inputString[i] != ' ')
                {
                    curWord.Append(inputString[i]);
                }
                else
                {
                    if(curWord.Length>= minLength)
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

        static void CheckBatchData(List<string> batchData, List<char> deletedChars, string[] convertedData)
        {
            for (int i = 0; i < batchData.Count; ++i)
            {
                string curString = batchData[i];
                                
                convertedData[i] = ConvertString(curString, 4, deletedChars);

            }
            
        }

        static void CheckBatchDataParallel(List<string> batchData, List<char> deletedChars, string[] convertedData)
        {




            object lockObject = new object();
            Parallel.For(0, batchData.Count,

                (i) =>
                {
                    string curString = batchData[i];
                    
                    convertedData[i] = ConvertString(curString, 4, deletedChars);


                });
        }

        static void WriteDataToFile(string[] convertedData, int elementsAmount, FileStream fs)
        {
            for(int i= 0; i<elementsAmount; ++i)
            {
                byte[] info = new UTF8Encoding(true).GetBytes(convertedData[i]);
                fs.Write(info, 0, info.Length);
            }
            
        }
    }
}
