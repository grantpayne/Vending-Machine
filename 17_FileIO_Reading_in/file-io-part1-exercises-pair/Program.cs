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





            //// Wrap the effort in a try-catch block to handle any exceptions
            //try
            //{
            //    //Open a StreamReader with the using statement
            //    using (StreamReader sr = new StreamReader(fullPath))
            //    {
            //        // Read the file until the end of the stream is reached
            //        // EndOfStream is a "marker" that the stream uses to determine 
            //        // if it has reached the end
            //        // As we read forward the marker moves forward like a typewriter.
            //        while (!sr.EndOfStream)
            //        {
            //            // Read in the line
            //            string line = sr.ReadLine();

            //            // Print it to the screen
            //            Console.WriteLine(line);
            //        }
            //    }
            //}
            //catch (IOException e) //catch a specific type of Exception
            //{
            //    Console.WriteLine("Error reading the file");
            //    Console.WriteLine(e.Message);
            //}
        }
        public static void GetFile(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    int wordCounter = 0;
                    int sentenceCounter = 0;
                    int lineCounter = 0;
                    while (!reader.EndOfStream)
                    {
                        lineCounter++;
                        // Read in the line
                        string line = reader.ReadLine();
                        for (int i = 0; i < line.Length; i++)
                        {
                            if ((line.Length > 0) && (line[i] == '.' || line[i] == '!' || line[i] == '?'))
                            {
                                sentenceCounter++;

                                //if (line[i + 1] == '.' || line[i + 1] == '!' || line[i + 1] == '?')
                                //{
                                //    i++;

                                //}
                            }
                        }
                        //if ((line.Length > 0) && (line[line.Length - 1] == '.' || line[line.Length - 1] == '!' || line[line.Length - 1] == '?'))
                        //{
                        //    sentenceCounter++;
                        //}
                        // Print it to the screen
                        Console.WriteLine(line);
                    }
                    Console.WriteLine(sentenceCounter);
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
