using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0054;


namespace System
{
    public static partial class IEntryOperatorExtensions
    {
        public static bool HasEntryByIdentity(this IIdentifiedNamedFilePathEntryOperator _,
            IEnumerable<Entry> entries,
            string entryIdentity)
        {
            var output = entries
                .Where(xEntry => Instances.EntryOperator.IdentityIs(xEntry,
                    entryIdentity))
                .Any()
                ;

            return output;
        }

        public static bool HasEntryByIdentity(this IIdentifiedNamedFilePathEntryOperator _,
            IEnumerable<Entry> entries,
            Entry entry)
        {
            var output = _.HasEntryByIdentity(entries,
                entry.Identity);

            return output;

        }

        public static bool HasEntryByValues(this IIdentifiedNamedFilePathEntryOperator _,
            IEnumerable<Entry> entries,
            string name,
            string filePath)
        {
            var output = entries
                .Where(xEntry => Instances.EntryOperator.ValuesAre(xEntry,
                    name,
                    filePath))
                .Any()
                ;

            return output;
        }

        public static bool HasEntryByValues(this IIdentifiedNamedFilePathEntryOperator _,
            IEnumerable<Entry> entries,
            Entry entry)
        {
            var output = _.HasEntryByValues(entries,
                entry.Name,
                entry.FilePath);

            return output;
        }

        public static bool HasEntryByBothIdentityAndValues(this IIdentifiedNamedFilePathEntryOperator _,
            IEnumerable<Entry> entries,
            string identity,
            string name,
            string filePath)
        {
            var output = entries
                .Where(xEntry => Instances.EntryOperator.PropertiesAre(xEntry,
                    identity,
                    name,
                    filePath))
                .Any()
                ;

            return output;
        }

        public static bool HasEntryByBothIdentityAndValues(this IIdentifiedNamedFilePathEntryOperator _,
            IEnumerable<Entry> entries,
            Entry entry)
        {
            var output = _.HasEntryByBothIdentityAndValues(entries,
                entry.Identity,
                entry.Name,
                entry.FilePath);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="HasEntryByBothIdentityAndValues(IIdentifiedNamedFilePathEntryOperator, IEnumerable{Entry}, Entry)"/>
        /// </summary>
        public static bool HasEntry(this IIdentifiedNamedFilePathEntryOperator _,
            IEnumerable<Entry> entries,
            Entry entry)
        {
            var output = _.HasEntryByBothIdentityAndValues(entries, entry);
            return output;
        }
    }
}
