using System;
using System.Collections.Generic;

using R5T.T0054;

using Instances = R5T.T0054.Instances;


namespace System
{
    public static partial class IListingOperatorExtensions
    {
        public static void AddEntryUnconstrained(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            Entry entry)
        {
            listing.Entries.Add(entry);
        }

        /// <summary>
        /// Chooses <see cref="AddEntryUnconstrained(IIdentifiedNamedFilePathListingOperator, Listing, Entry)"/> as the default.
        /// </summary>
        public static void AddEntry(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            Entry entry)
        {
            _.AddEntryUnconstrained(listing, entry);
        }

        public static void AddEntry(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            string identity,
            string name,
            string filePath)
        {
            var entry = Instances.EntryOperator.From(
                identity,
                name,
                filePath);

            _.AddEntry(listing, entry);
        }

        public static void AddEntriesUnconstrained(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            IEnumerable<Entry> entries)
        {
            listing.Entries.AddRange(entries);
        }

        /// <summary>
        /// Chooses <see cref="AddEntriesUnconstrained(IIdentifiedNamedFilePathListingOperator, Listing, IEnumerable{Entry})"/> as the default.
        /// </summary>
        public static void AddEntries(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            IEnumerable<Entry> entries)
        {
            _.AddEntriesUnconstrained(listing, entries);
        }

        public static bool HasEntryByIdentity(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            string entryIdentity)
        {
            var output = Instances.EntryOperator.HasEntryByIdentity(listing.Entries, entryIdentity);
            return output;
        }

        public static bool HasEntryByIdentity(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            Entry entry)
        {
            var output = Instances.EntryOperator.HasEntryByIdentity(listing.Entries, entry);
            return output;
        }

        public static bool HasEntryByValues(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            string name,
            string filePath)
        {
            var output = Instances.EntryOperator.HasEntryByValues(listing.Entries,
                name,
                filePath);

            return output;
        }

        public static bool HasEntryByValues(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            Entry entry)
        {
            var output = Instances.EntryOperator.HasEntryByValues(listing.Entries,
                entry.Name,
                entry.FilePath);

            return output;
        }

        public static bool HasEntryByBothIdentityAndValues(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            string identity,
            string name,
            string filePath)
        {
            var output = Instances.EntryOperator.HasEntryByBothIdentityAndValues(listing.Entries,
                identity,
                name,
                filePath);

            return output;
        }

        public static bool HasEntryByBothIdentityAndValues(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            Entry entry)
        {
            var output = Instances.EntryOperator.HasEntryByBothIdentityAndValues(listing.Entries, entry);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="HasEntryByBothIdentityAndValues(IIdentifiedNamedFilePathListingOperator, Listing, Entry)"/> as the default.
        /// </summary>
        public static bool HasEntry(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            Entry entry)
        {
            var output = Instances.EntryOperator.HasEntry(listing.Entries, entry);
            return output;
        }
    }
}
