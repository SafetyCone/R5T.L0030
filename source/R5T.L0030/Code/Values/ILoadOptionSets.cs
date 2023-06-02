using System;
using System.Xml.Linq;

using R5T.T0131;


namespace R5T.L0030
{
    /// <summary>
    /// Load options instances (<see cref="LoadOptions"/>).
    /// </summary>
    [ValuesMarker]
    public partial interface ILoadOptionSets : IValuesMarker
    {
        /// <summary>
        /// The default is to preserve whitespace.
        /// </summary>
        public const LoadOptions Default_Constant = LoadOptions.PreserveWhitespace;

        /// <inheritdoc cref="Default_Constant"/>
        public LoadOptions Default => Default_Constant;
    }
}
