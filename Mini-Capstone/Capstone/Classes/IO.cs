using System;
using System.Collections.Generic;
using System.IO;
using Capstone.Classes;
using System.Text;

namespace Capstone.Classes
{
    class IO
    {

        public List<string[]> FetchData(string filePath, string fileName) 
        {
            List<string[]> stockList = new List<string[]>();

            try
            {
                using (StreamReader reader = new StreamReader(Path.Combine(filePath, fileName)))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        string[] item = new string[3]; //SlotID, ItemName, Price

                        item = line.Split('|');

                        stockList.Add(item);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error reading file!  Please try again with file in proper directory.");
                Console.WriteLine(ex.Message);
            }

            return stockList;
            
        }
        
        public void WriteReport(string filePath, string fileName) //override
        {
            //TODO: Optional report
        }

        public void WriteLog(string filePath, string activity, decimal moneyPlaceHolder, decimal transactionBalance) //append
        {
            //TODO: make date and currency pretty/correct
            DateTime dateTime = new DateTime();
            string currentDate = dateTime.Date.ToLongDateString();
            string writePhrase = $"{currentDate} {activity} {moneyPlaceHolder} {transactionBalance}";

            try
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(filePath, "Log.txt"), true))
                {
                    writer.WriteLine(writePhrase);
                }
            }
            catch (IOException ex)
            {

                Console.WriteLine("File write error - call customer support at (614) 565-8382");
                Console.WriteLine(ex.Message);
            }
        }

    }
}
