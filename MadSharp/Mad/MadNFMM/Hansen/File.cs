namespace Cum
{
    internal struct File
    {
        internal string Path;

        public File(string str)
        {
            Path = str;
        }

        public File(File parent, string child)
        {
            Path = $@"{parent.Path}\{child}";
        }

        public File Parent => new File(_getParent());
        public string file => System.IO.Path.GetFileNameWithoutExtension(Path);

        private string _getParent() => System.IO.Path.GetDirectoryName(Path);

        public bool Exists() => System.IO.File.Exists(Path);
    }
}