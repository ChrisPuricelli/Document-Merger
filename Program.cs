using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Merger
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileOne = null;
            string fileTwo = null;
            string merge1 = null;
            string merge2 = null;
            string mergedName = null;
            string contents = null;
            int counter = 0, loop = 0, loop2 = 0;

            Console.WriteLine("Document Merger...");
            Console.WriteLine("What is the name of the first document?");
            while (loop == 0)
            {
                fileOne = Console.ReadLine();
                if (!fileOne.Contains(".txt"))
                    fileOne += ".txt";

                if (!File.Exists(fileOne))
                    Console.WriteLine("File not found. Please re-enter file name: ");
                else
                    loop = 1;
            }
                Console.WriteLine("What is the name of the next document?");
            while (loop2 == 0)
            {
                fileTwo = Console.ReadLine();
                if (!fileTwo.Contains(".txt"))
                    fileTwo += ".txt";

                if (!File.Exists(fileTwo))
                    Console.WriteLine("File not found. Please re-enter file name: ");
                else
                    loop2 = 1;
            }
            Console.WriteLine("\n");

            try
            {
                using (StreamReader file1 = new StreamReader(fileOne))
                    while ((contents = file1.ReadLine()) != null)
                        Console.WriteLine(contents);
                Console.WriteLine("\n");
                using (StreamReader file2 = new StreamReader(fileTwo))
                    while ((contents = file2.ReadLine()) != null)
                        Console.WriteLine(contents);
                Console.WriteLine("\n");

                merge1 = fileOne.Replace(".txt", "");
                merge2 = fileTwo.Replace(".txt", "");
                mergedName = merge1 + merge2 + ".txt";

                File.WriteAllText(mergedName, string.Empty);
                contents = File.ReadAllText(fileOne);
                File.AppendAllText(mergedName, contents);
                File.AppendAllText(mergedName, "\n");
                contents = File.ReadAllText(fileTwo);
                File.AppendAllText(mergedName, contents);
                Console.WriteLine("Displaying contents of file {0}...", mergedName);
                using (StreamReader mergeDoc = new StreamReader(mergedName))
                    while ((contents = mergeDoc.ReadLine()) != null)
                    {
                        Console.WriteLine(contents);
                    }
                contents = File.ReadAllText(fileOne) + File.ReadAllText(fileTwo);
            }

            catch (Exception error)
            {
                Console.WriteLine("An error occurred: {0}", error);
            }

            finally
            {
                counter = contents.Length;
                Console.WriteLine("\n{0} saved successfully. The document contains {1} characters.", mergedName, counter);
            }

            Console.ReadLine();
        }
    }
}
