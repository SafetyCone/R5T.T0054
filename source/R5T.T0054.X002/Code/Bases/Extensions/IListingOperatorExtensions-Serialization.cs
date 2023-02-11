using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.Magyar;
using R5T.Newport;

using R5T.T0054;

using Instances = R5T.T0054.X002.Instances;


namespace System
{
    public static partial class IListingOperatorExtensions
    {
        public static Listing LoadFromJsonFile(this IIdentifiedNamedFilePathListingOperator _,
            string jsonFilePath)
        {
            var entries = JsonFileHelper.LoadFromFile<Entry[]>(jsonFilePath);

            var output = _.From(entries);
            return output;
        }

        /// <summary>
        /// Writes entries to file in the order they currently exist in the listing.
        /// </summary>
        public static void WriteToJsonFileInListingOrder(this IIdentifiedNamedFilePathListingOperator _,
            string jsonFilePath,
            Listing listing,
            bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            JsonFileHelper.WriteToFile(jsonFilePath, listing.Entries, overwrite: overwrite);
        }

        /// <summary>
        /// Chooses <see cref="WriteToJsonFileInListingOrder(IIdentifiedNamedFilePathListingOperator, string, Listing, bool)"/> as the default.
        /// </summary>
        public static void WriteToJsonFile(this IIdentifiedNamedFilePathListingOperator _,
            string jsonFilePath,
            Listing listing,
            bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            _.WriteToJsonFileInListingOrder(jsonFilePath, listing, overwrite);
        }

        public static void WriteToJsonFileWithOrder(this IIdentifiedNamedFilePathListingOperator _,
            string jsonFilePath,
            Listing listing,
            Func<IEnumerable<Entry>, IOrderedEnumerable<Entry>> orderer,
            bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            var orderedEntries = orderer(listing.Entries);

            JsonFileHelper.WriteToFile(jsonFilePath, orderedEntries, overwrite: overwrite);
        }

        public static void WriteToJsonFileOrderedByName(this IIdentifiedNamedFilePathListingOperator _,
            string jsonFilePath,
            Listing listing,
            bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            _.WriteToJsonFileWithOrder(jsonFilePath, listing,
                entries => entries.OrderAlphabetically(
                    xEntry => xEntry.Name),
                overwrite);
        }
    }
}