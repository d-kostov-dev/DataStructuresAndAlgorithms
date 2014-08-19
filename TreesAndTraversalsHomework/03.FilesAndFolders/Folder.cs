namespace FilesAndFolders
{
    using System.Collections.Generic;

    public class Folder
    {
        public Folder()
            : this(string.Empty)
        {
        }

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<IFile>();
            this.SubFolders = new List<Folder>();
        }

        public string Name { get; set; }

        public IList<Folder> SubFolders { get; private set; }

        public IList<IFile> Files { get; private set; }

        public long FolderFilesSize
        {
            get
            {
                long totalFileSize = 0;

                for (int i = 0; i < this.Files.Count; i++)
                {
                    totalFileSize += this.Files[i].Size;
                }

                return totalFileSize;
            }
        }
    }
}