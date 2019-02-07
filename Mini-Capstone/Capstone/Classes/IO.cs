using System;
using System.Collections.Generic;
using System.IO;
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

        public void WriteReport(string filePath, string fileName)
        {

        }

        public void WriteLog(string filePath, string fileName)
        {

        }

    }
}
