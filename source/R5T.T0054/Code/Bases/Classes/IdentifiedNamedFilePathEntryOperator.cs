using System;


namespace R5T.T0054
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class IdentifiedNamedFilePathEntryOperator : IIdentifiedNamedFilePathEntryOperator
    {
        #region Static
        
        public static IdentifiedNamedFilePathEntryOperator Instance { get; } = new();

        #endregion
    }
}