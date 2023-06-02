using System;


namespace R5T.L0030
{
    public class XmlWriterSettingSets : IXmlWriterSettingSets
    {
        #region Infrastructure

        public static IXmlWriterSettingSets Instance { get; } = new XmlWriterSettingSets();


        private XmlWriterSettingSets()
        {
        }

        #endregion
    }
}
