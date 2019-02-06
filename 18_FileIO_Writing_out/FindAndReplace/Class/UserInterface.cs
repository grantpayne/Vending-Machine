using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FindAndReplace.Class
{
    public class UserInterface
    {
        public void RunUI()
        {
            string searchPhraseInput = "";
            while (searchPhraseInput == "")
            {
                Console.Write("Search Phrase: ");
                searchPhraseInput = Console.ReadLine();

            }

            Console.Write("Replace Phrase:  ");
            string replacePhraseInput = Console.ReadLine();


            string sourcePath = "";

            while (sourcePath == "" || (!(File.Exists(sourcePath))))
            {
                Console.Write("Fully Qualified Source File Path:  ");
                sourcePath = Console.ReadLine();
                if (!(File.Exists(sourcePath)))
                {
                    Console.WriteLine("Invalid source path!!!");
                }

            }
            string fileName = Path.GetFileName(sourcePath);

            string destinationPath = "";
            //TODO not null try catch 

            while (destinationPath == ""|| (!(Directory.Exists(destinationPath))))
            {
                Console.Write("Destination File Path: ");
                destinationPath = Path.GetDirectoryName(Console.ReadLine());

                if (File.Exists(Path.Combine(destinationPath, fileName)))
                {
                    Console.WriteLine("ERROR ERROR ERROR ERROR");
                    return;
                }

            }

            Console.Write(boBo(destinationPath, searchPhraseInput, searchPhraseInput, replacePhraseInput));
            Console.Write($" occurrences of the search phrase {searchPhraseInput} that was found and replaced with {replacePhraseInput}.");

           

            }

     int boBo(string sourcePath, string destinationPath, string searchPhraseInput, string replacePhraseInput)
        {
            string fullDestinationName = Path.Combine(destinationPath, (Path.GetFileName(sourcePath)));
            string source = "";

            using (StreamReader reader = new StreamReader(sourcePath))
            {

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    source += line;
                    //replacement
                    if (line.Contains(searchPhraseInput))
                    {
                        line = line.Replace(searchPhraseInput, replacePhraseInput);//do replacement

                    }

                    using (StreamWriter writer = new StreamWriter(fullDestinationName, true))
                    {

                        writer.WriteLine(line);
                    }
                }

                return CountStringOccurrences(source, searchPhraseInput);


            }

           


        }

        public static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }



    }
    }


//string searchTerm = "data";

////Convert the string into an array of words  

//string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

//// Create the query.  Use ToLowerInvariant to match "data" and "Data"   
//var matchQuery = from word in source
//                 where word. == replacementPhraseInput;
//                 select word;

//// Count the matches, which executes the query.  
//int wordCount = matchQuery.Count();
