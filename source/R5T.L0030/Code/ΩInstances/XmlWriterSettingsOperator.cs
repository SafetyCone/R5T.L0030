using System;


namespace R5T.L0030
{
    public class XmlWriterSettingsOperator : IXmlWriterSettingsOperator
    {
        #region Infrastructure

        public static IXmlWriterSettingsOperator Instance { get; } = new XmlWriterSettingsOperator();


        private XmlWriterSettingsOperator()
        {
        }

        #endregion
    }
}
