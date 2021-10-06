using System;

using R5T.T0054;


namespace System
{
    public static partial class IEntryOperatorExtensions
    {
        public static Entry From(this IIdentifiedNamedFilePathEntryOperator _,
            string identity,
            string name,
            string filePath)
        {
            var output = new Entry
            {
                FilePath = filePath,
                Identity = identity,
                Name = name,
            };

            return output;
        }

        public static Entry New(this IIdentifiedNamedFilePathEntryOperator _)
        {
            var output = new Entry();
            return output;
        }
    }
}
