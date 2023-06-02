using System;
using System.Xml;

using R5T.L0030.Extensions;
using R5T.T0131;


namespace R5T.L0030
{
    /// <summary>
    /// Contains XML writer setting instances.
    /// </summary>
    [ValuesMarker]
    public partial interface IXmlWriterSettingSets : IValuesMarker
    {
        /// <summary>
        /// The default writer settings contain the values set by the parameterless constructor. 
        /// </summary>
        public XmlWriterSettings Default => new XmlWriterSettings();

        /// <inheritdoc cref="IXmlWriterSettingsOperator.Set_Standard(XmlWriterSettings)"/>
        public XmlWriterSettings Standard => new XmlWriterSettings().Set_Standard();

        /// <inheritdoc cref="IXmlWriterSettingsOperator.Set_Standard_Synchronous(XmlWriterSettings)"/>
        public XmlWriterSettings Standard_Synchronous => new XmlWriterSettings().Set_Standard_Synchronous();
    }
}
