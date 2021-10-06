using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0054;


namespace System
{
    public static partial class IEntryOperatorExtensions
    {
        public static string GetFilePath(this IIdentifiedNamedFilePathEntryOperator _, Entry entry)
        {
            var output = entry.FilePath;
            return output;
        }

        public static string GetName(this IIdentifiedNamedFilePathEntryOperator _, Entry entry)
        {
            var output = entry.Name;
            return output;
        }

        public static bool HasDefaultIdentity(this IIdentifiedNamedFilePathEntryOperator _, Entry entry)
        {
            var output = _.IdentityIsDefault(entry);
            return output;
        }

        public static bool IdentityIs(this IIdentifiedNamedFilePathEntryOperator _, Entry entry,
            string identity)
        {
            var output = entry.Identity == identity;
            return output;
        }

        public static bool IdentityIsDefault(this IIdentifiedNamedFilePathEntryOperator _,
            string identity)
        {
            var output = identity == Entry.DefaultIdentity;
            return output;
        }

        public static bool IdentityIsDefault(this IIdentifiedNamedFilePathEntryOperator _, Entry entry)
        {
            var output = _.IdentityIsDefault(entry.Identity);
            return output;
        }

        public static bool PropertiesAre(this IIdentifiedNamedFilePathEntryOperator _, Entry entry,
            string identity,
            string name,
            string filePath)
        {
            var output = true
                && entry.Identity == identity
                && entry.Name == name
                && entry.FilePath == filePath
                ;

            return output;
        }

        /// <summary>
        /// Entries in a listing are not guaranteed to be unique by name.
        /// </summary>
        public static Dictionary<string, List<Entry>> ToListingEntriesByName(this IIdentifiedNamedFilePathEntryOperator _, IEnumerable<Entry> entries)
        {
            var output = entries
                .GroupBy(xEntry => xEntry.Name)
                .ToDictionary(
                    xGroup => xGroup.Key,
                    xGroup => xGroup.ToList());

            return output;
        }

        public static bool ValuesAre(this IIdentifiedNamedFilePathEntryOperator _, Entry entry,
            string name,
            string filePath)
        {
            var output = true
                && entry.Name == name
                && entry.FilePath == filePath
                ;

            return output;
        }
    }
}
