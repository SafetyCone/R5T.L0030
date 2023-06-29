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
        /// The default is none.
        /// <para>
        /// Note: the XElement.SaveAsync() method seems to have a bug in that it will output preserved whitespace (seen when adding a new element without any whitespace to an existing element with whitespace).
        /// The only way to get property indented output from the SaveAsync() method is to remove whitespace when loading.
        /// This default was changed to none from preserve whitespace for this reason.
        /// </para>
        /// </summary>
        public const LoadOptions Default_Constant = LoadOptions.None;

        /// <inheritdoc cref="Default_Constant"/>
        public LoadOptions Default => Default_Constant;

        public LoadOptions PreserveWhitespace => LoadOptions.PreserveWhitespace;
    }
}
