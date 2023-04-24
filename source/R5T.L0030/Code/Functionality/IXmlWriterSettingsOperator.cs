using System;
using System.Xml;

using R5T.T0132;


namespace R5T.L0030
{
    [FunctionalityMarker]
    public partial interface IXmlWriterSettingsOperator : IFunctionalityMarker
    {
        public void Set_Standard(XmlWriterSettings settings)
        {
            // Indent.
            settings.Indent = true;

            // Omit declaration.
            settings.OmitXmlDeclaration = true;
        }
    }
}
