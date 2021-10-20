using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0054;

using Instances = R5T.T0054.Instances;


namespace System
{
    public static partial class IListingOperatorExtensions
    {
        public static IEnumerable<Entry> GetAllEntries(this IIdentifiedNamedFilePathListingOperator _, Listing listing)
        {
            var output = listing.Entries;
            return output;
        }

        public static IEnumerable<string> GetAllEntryNames(this IIdentifiedNamedFilePathListingOperator _, Listing listing)
        {
            var output = _.GetAllEntries(listing)
                .Select(xEntry => Instances.EntryOperator.GetName(xEntry))
                ;

            return output;
        }

        public static Dictionary<string, Entry> GetEntriesByNameFromUniqueNameFilePathPair(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            Dictionary<string, string> filePathsByName)
        {
            var entriesByName = filePathsByName
                .Select(xPair => (Name: xPair.Key, Entry: _.GetEntryByValuesSingle(listing,
                    xPair.Key,
                    xPair.Value)))
                .ToDictionary(
                    xPair => xPair.Name,
                    xPair => xPair.Entry);

            return entriesByName;
        }

        public static Entry GetEntryByValuesSingle(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            string name,
            string filePath)
        {
            var output = _.GetAllEntries(listing)
                .Where(xEntry => Instances.EntryOperator.ValuesAre(xEntry,
                    name,
                    filePath))
                .Single();

            return output;
        }

        public static Dictionary<string, List<Entry>> GetListingEntriesByName(this IIdentifiedNamedFilePathListingOperator _, Listing listing)
        {
            var output = _.GetAllEntries(listing).ToEntriesByName();
            return output;
        }

        public static Dictionary<string, List<Entry>> GetListingEntriesForNames(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            IEnumerable<string> names)
        {
            var entriesByName = _.GetListingEntriesByName(listing);

            var output = names
                .ToDictionary(
                    xName => xName,
                    xName => entriesByName[xName]);

            return output;
        }

        public static Dictionary<string, List<string>> GetListingFilePathsForNames(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            IEnumerable<string> names)
        {
            var entriesForNames = _.GetListingEntriesForNames(listing, names);

            var output = entriesForNames
                .ToDictionary(
                    xPair => xPair.Key,
                    xPair => xPair.Value
                        .Select(xEntry => Instances.EntryOperator.GetFilePath(xEntry))
                        .ToList());

            return output;
        }

        public static Entry[] GetUniqueEntriesByName(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            Dictionary<string, Entry> duplicateNameEntrySelections,
            HashSet<string> ignoredNames)
        {
            var uniqueEntriesByName = new List<Entry>();

            var namesHandled = new HashSet<string>();
            var duplicateNamesHandled = new HashSet<string>();

            foreach (var entry in _.GetAllEntries(listing))
            {
                var name = Instances.EntryOperator.GetName(entry);

                // Is the name ignored?
                if (ignoredNames.Contains(name))
                {
                    // Ignore the entry for the name.
                    continue;
                }

                // Are there duplicate entries with the same name?
                if (duplicateNameEntrySelections.ContainsKey(name))
                {
                    if (!duplicateNamesHandled.Contains(name))
                    {
                        var duplicateNameEntrySelection = duplicateNameEntrySelections[name];

                        uniqueEntriesByName.Add(duplicateNameEntrySelection);

                        // Now it has been handled.
                        duplicateNamesHandled.Add(name);
                    }

                    // Finished handling this duplicate project name.
                    continue;
                }

                // Now handle the name.
                if(namesHandled.Contains(name))
                {
                    throw new Exception($"Duplicate name without specified entry detected: {name}");
                }

                uniqueEntriesByName.Add(entry);

                namesHandled.Add(name);
            }

            var output = uniqueEntriesByName.ToArray();
            return output;
        }

        /// <summary>
        /// Identity is guaranteed to be unique.
        /// </summary>
        public static Dictionary<string, Entry> ToEntriesByIdentity(this IIdentifiedNamedFilePathListingOperator _, Listing listing)
        {
            var output = _.GetAllEntries(listing)
                .ToDictionary(
                    xEntry => xEntry.Identity);

            return output;
        }

        /// <summary>
        /// Name is not guaranteed to be unique in a listing.
        /// </summary>
        public static Dictionary<string, Entry[]> ToEntriesByName(this IIdentifiedNamedFilePathListingOperator _, Listing listing)
        {
            var output = _.GetAllEntries(listing)
                .GroupBy(xEntry => xEntry.Name)
                .ToDictionary(
                    xGroup => xGroup.Key,
                    xGroup => xGroup.ToArray());

            return output;
        }

        public static Dictionary<string, Entry[]> ToEntriesByNameOperation(this IIdentifiedNamedFilePathListingOperator _, Listing listing,
            Func<string, string> nameOperation)
        {
            var output = _.GetAllEntries(listing)
                .GroupBy(xEntry =>
                {
                    var nameOperationOutputName = nameOperation(xEntry.Name);
                    return nameOperationOutputName;
                })
                .ToDictionary(
                    xGroup => xGroup.Key,
                    xGroup => xGroup.ToArray());

            return output;
        }
    }
}
