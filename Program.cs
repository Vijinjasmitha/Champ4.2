using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandlingQuestion1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filename = "Q1.txt";
            string appendText = " This is the appended by me.";

            // Append text to the file
            AppendTextToFile(filename, appendText);

            // Read the content of the file
            string fileContent = ReadFile(filename);

            // Display the file content
            Console.WriteLine("File content after appending:");
            Console.WriteLine(fileContent);
        }

        static void AppendTextToFile(string path, string text)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
                {
                    // Move to the end of the file
                    fs.Seek(0, SeekOrigin.End); 
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.Write(text);
                    }
                }
                Console.WriteLine(" appended successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error appending text to the file: " + ex.Message);
            }
        }

        static string ReadFile(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(fs))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading the file: " + ex.Message);
                return string.Empty;
            }
        }
    }
}


