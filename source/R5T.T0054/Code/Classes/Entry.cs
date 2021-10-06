using System;


namespace R5T.T0054
{
    public class Entry
    {
        public const string DefaultIdentity = null;


        public string Identity { get; set; } = Entry.DefaultIdentity;
        public string Name { get; set; }
        public string FilePath { get; set; }
    }
}