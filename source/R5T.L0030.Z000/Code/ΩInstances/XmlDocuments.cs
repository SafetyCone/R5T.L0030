using System;


namespace R5T.L0030.Z000
{
    public class XmlDocuments : IXmlDocuments
    {
        #region Infrastructure

        public static IXmlDocuments Instance { get; } = new XmlDocuments();


        private XmlDocuments()
        {
        }

        #endregion
    }
}
