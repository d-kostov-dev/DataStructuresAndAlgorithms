namespace FilesAndFolders
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Define classes File { string name, int size } and Folder { string name, File[] files, Folder[]childFolders } 
    /// and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS. 
    /// Implement a method that calculates the sum of the file sizes in given subtree of the tree 
    /// and test it accordingly. Use recursive DFS traversal.
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            Console.WriteLine("Loading...");
            Console.WriteLine("For faster results you can run the program in Command Prompt with > output.txt");

            var mainFolder = new DirectoryInfo(@"C:\Windows");
            var directoryTree = GetDirectoryContent(mainFolder);
            ShowDirectoriesTree(directoryTree, 0);
        }

        /// <summary>
        /// Creates an instance of Folder class for each folder and recursively go down for all subfolders. 
        /// All files are added in the Folder.Files property.
        /// </summary>
        /// <param name="startingDirectory">Staring Directory.</param>
        /// <returns>Folder instance with all of its subfolders and files.</returns>
        private static Folder GetDirectoryContent(DirectoryInfo startingDirectory)
        {
            try
            {
                var folder = new Folder(startingDirectory.Name);

                var files = startingDirectory.EnumerateFiles("*");

                foreach (var file in files)
                {
                    var currentFile = new File();
                    currentFile.Name = file.Name;
                    currentFile.Size = file.Length;
                    folder.Files.Add(currentFile);
                }

                var subFolders = startingDirectory.EnumerateDirectories("*");

                foreach (var subFolder in subFolders)
                {
                    folder.SubFolders.Add(GetDirectoryContent(subFolder));
                }

                return folder;
            }
            catch (Exception)
            {
                return new Folder("ACCESS DENIED");
            }
        }

        /// <summary>
        /// Prints the folders tree with separator for better view.
        /// </summary>
        /// <param name="mainFolder">The root folder.</param>
        /// <param name="separatorLength">The size of the separator.</param>
        private static void ShowDirectoriesTree(Folder mainFolder, int separatorLength)
        {
            Console.WriteLine("Total Files Size: {0}", mainFolder.FolderFilesSize);

            foreach (var subFolder in mainFolder.SubFolders)
            {
                Console.WriteLine(Separator(separatorLength) + subFolder.Name);
                ShowDirectoriesTree(subFolder, separatorLength + 1);
            }

            foreach (var file in mainFolder.Files)
            {
                Console.WriteLine(Separator(separatorLength) + file.Name);
            }
        }

        /// <summary>
        /// Crates a separator string by given length.
        /// </summary>
        /// <param name="length">Length of the separator.</param>
        /// <returns>A string with the given length.</returns>
        private static string Separator(int length)
        {
            return new string('-', length);
        }
    }
}
