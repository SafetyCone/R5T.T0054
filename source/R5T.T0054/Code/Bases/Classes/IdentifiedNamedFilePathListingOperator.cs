using System;


namespace R5T.T0054
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class IdentifiedNamedFilePathListingOperator : IIdentifiedNamedFilePathListingOperator
    {
        #region Static
        
        public static IdentifiedNamedFilePathListingOperator Instance { get; } = new();

        #endregion
    }
}