using System;

using R5T.T0054;


namespace System
{
    public static partial class IEntryOperatorExtensions
    {
        public static bool EqualByIdentities(this IIdentifiedNamedFilePathEntryOperator _,
            Entry a,
            Entry b)
        {
            var output = EqualityHelper.NullHandling(a, b)
                && a.Identity == b.Identity
                ;

            return output;
        }

        public static bool EqualByValues(this IIdentifiedNamedFilePathEntryOperator _,
            Entry a,
            Entry b)
        {
            var output = EqualityHelper.NullHandling(a, b)
                && a.Name == b.Name
                && a.FilePath == b.FilePath
                ;

            return output;
        }

        public static bool EqualByBothIdentitiesAndValues(this IIdentifiedNamedFilePathEntryOperator _,
            Entry a,
            Entry b)
        {
            var output = true
                && _.EqualByIdentities(a, b)
                && _.EqualByValues(a, b)
                ;

            return output;
        }

        /// <summary>
        /// Chooses <see cref="EqualByIdentities(IIdentifiedNamedFilePathEntryOperator, Entry, Entry)"/> as the default.
        /// </summary>
        public static bool Equal(this IIdentifiedNamedFilePathEntryOperator _,
            Entry a,
            Entry b)
        {
            var output = _.EqualByIdentities(a, b);
            return output;
        }
    }
}
