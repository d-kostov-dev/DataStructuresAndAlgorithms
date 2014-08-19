namespace ListAllExeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively 
    /// and to display all files matching the mask *.exe. Use the class System.IO.Directory. 
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            var mainDirectory = new DirectoryInfo(@"C:\Windows").EnumerateDirectories("*");
            var allExeFiles = FindExeFiles(mainDirectory);
            ShowExeFiles(allExeFiles);
        }

        /// <summary>
        /// Finds all exe files in all allowed directories.
        /// </summary>
        /// <param name="directories">Directory to search in. Recursively</param>
        /// <returns> Returns a stringbuilder object with the names of all files found.</returns>
        private static StringBuilder FindExeFiles(IEnumerable<DirectoryInfo> directories)
        {
            StringBuilder filesList = new StringBuilder();

            foreach (var directory in directories)
            {
                try
                {
                    var files = directory.EnumerateFiles("*.exe");

                    foreach (var file in files)
                    {
                       filesList.AppendLine(file.Name);
                    }

                    var subDirectories = directory.EnumerateDirectories("*");
                    filesList.Append(FindExeFiles(subDirectories));
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
            }

            return filesList;
        }

        /// <summary>
        /// Prints all file names in the stringbuilder object.
        /// </summary>
        /// <param name="filesList">Stringbuilder object with file names.</param>
        private static void ShowExeFiles(StringBuilder filesList)
        {
            Console.WriteLine(filesList.ToString());
            Console.WriteLine("Total files found: {0}", filesList.Length);
        }
    }
}
