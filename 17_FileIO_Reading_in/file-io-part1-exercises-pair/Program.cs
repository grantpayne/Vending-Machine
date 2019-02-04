using System;
using System.IO;
using System.Collections.Generic;

namespace file_io_part1_exercises_pair
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ask user for filepath:
            Console.WriteLine("What is the fully qualified filepath of the file?");
            string filePath = Console.ReadLine();

            GetFile(filePath);
        }
        public static void GetFile(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    //int wordCounter = 0;
                    int sentenceCounter = 0;
                    int lineCounter = 0;
                    List<string> words = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        lineCounter++;
                        // Read in the line
                        string line = reader.ReadLine();
                        //This is counting the sentences in the text file:
                        for (int i = 0; i < line.Length; i++)
                        {
                            if ((line.Length > 0) && (line[i] == '.' || line[i] == '!' || line[i] == '?'))
                            {
                                sentenceCounter++;
                            }
                        }
                        //This is counting the words in the text file:
                        string[] wordArray = line.Split(new char[] { ' ', '.', '!', '?', '\n' });
                        words.AddRange(wordArray);
                        for (int i = 0; i < words.Count; i++)
                        {
                            if (String.IsNullOrEmpty(words[i]))
                            {
                                words.RemoveAt(i);
                            }
                        }
                       



                    }
                    Console.WriteLine("Word count: " + words.Count);
                    Console.WriteLine("Sentence count: " + sentenceCounter);
                }
            }
            catch (IOException ex) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
