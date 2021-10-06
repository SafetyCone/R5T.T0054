using System;
using System.Collections.Generic;

using R5T.T0054;


namespace System
{
    public static class EntryExtensions
    {
        /// <summary>
        /// Entries in a listing are not guaranteed to be unique by name.
        /// </summary>
        public static Dictionary<string, List<Entry>> ToEntriesByName(this IEnumerable<Entry> entries)
        {
            var output = Instances.EntryOperator.ToListingEntriesByName(entries);
            return output;
        }
    }
}
