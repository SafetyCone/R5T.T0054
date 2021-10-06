using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0054;

using Instances = R5T.T0054.Instances;


namespace System
{
    public static partial class IListingOperatorExtensions
    {
        public static Listing From(this IIdentifiedNamedFilePathListingOperator _,
            IEnumerable<Entry> entries)
        {
            var output = _.New();

            _.AddEntries(output, entries);

            return output;
        }

        public static Listing New(this IIdentifiedNamedFilePathListingOperator _)
        {
            var output = new Listing();
            return output;
        }
    }
}
