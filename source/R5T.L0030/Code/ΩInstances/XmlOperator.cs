using System;


namespace R5T.L0030
{
    public class XmlOperator : IXmlOperator
    {
        #region Infrastructure

        public static IXmlOperator Instance { get; } = new XmlOperator();


        private XmlOperator()
        {
        }

        #endregion
    }
}
