using System;


namespace R5T.T0054
{
    public static class Instances
    {
        public static IIdentifiedNamedFilePathEntryOperator EntryOperator { get; } = IdentifiedNamedFilePathEntryOperator.Instance;
        public static IIdentifiedNamedFilePathListingOperator ListingOperator { get; } = IdentifiedNamedFilePathListingOperator.Instance;
    }
}
