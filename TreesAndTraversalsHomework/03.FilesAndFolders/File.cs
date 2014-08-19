namespace FilesAndFolders
{
    public class File : IFile
    {
        public File()
            : this(string.Empty, 0)
        {
        }

        public File(string name)
            : this(name, 0)
        {
        }

        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name { get; set; }

        public long Size { get; set; }
    }
}
