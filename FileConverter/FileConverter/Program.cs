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
            StreamReader sr = File.OpenText("Test.txt");
            //FileStream fsConverted = File.Create("Test_converted.txt");
            int batchCount = 500;
            List<string> batchData = new List<string>(batchCount);
            string[] convertedData = new string[batchCount];
            string data = String.Empty;
            char searchedChar = '!';
            int amountOfChars = 0;

            DateTime startTime = DateTime.Now;
            while ((data = sr.ReadLine()) != null)
            {
                batchData.Add(data);
                if (batchData.Count == batchCount)
                {
                    //CheckBatchData(batchData, searchedChar, convertedData);
                    CheckBatchDataParallel(batchData, searchedChar, convertedData);
                    batchData.Clear();

                }
            }
            //CheckBatchData(batchData, searchedChar, convertedData);
            CheckBatchDataParallel(batchData, searchedChar, convertedData);
            batchData.Clear();

            DateTime endTime = DateTime.Now;
            TimeSpan productionTime = endTime - startTime;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());



        }

        static string ConvertString(string inputString, int minLength)
        {
            String outputString = String.Empty;
            StringBuilder createdString = new StringBuilder();
            StringBuilder curWord = new StringBuilder();
            for(int i=0; i<inputString.Length; ++i)
            {
                if(inputString[i] != ' ')
                {
                    curWord.Append(inputString[i]);
                }
                else
                {
                    if(curWord.Length>= minLength)
                    {
                        createdString.Append(curWord);
                        createdString.Append(' ');
                        
                    }
                    curWord.Clear();
                }
            }
            createdString.Append(curWord);
            outputString = createdString.ToString();
            return outputString;
        }

        static void CheckBatchData(List<string> batchData, char searchedChar, string[] convertedData)
        {
            for (int i = 0; i < batchData.Count; ++i)
            {
                string curString = batchData[i];
                convertedData[i] = ConvertString(curString, 4);

            }
            
        }

        static void CheckBatchDataParallel(List<string> batchData, char searchedChar, string[] convertedData)
        {




            object lockObject = new object();
            int amount = 0;
            Parallel.For(0, batchData.Count,

                (i) =>
                {
                    string curString = batchData[0];
                    convertedData[i] = ConvertString(curString, 4);
                    //list.Add(ConvertString(curString, 4));

                    
                });


            //convertedData.Clear();
        }
    }
}
