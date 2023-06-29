using System;
using System.Xml.Linq;

using R5T.T0131;


namespace R5T.L0030
{
    /// <summary>
    /// Save options instances (<see cref="SaveOptions"/>).
    /// </summary>
    [ValuesMarker]
    public partial interface ISaveOptionSets : IValuesMarker
    {
        /// <summary>
        /// Default is <see cref="SaveOptions.None"/>.
        /// </summary>
        public const SaveOptions Default_Constant = SaveOptions.None;


        /// <inheritdoc cref="Default_Constant"/>
        public SaveOptions Default => Default_Constant;
    }
}
