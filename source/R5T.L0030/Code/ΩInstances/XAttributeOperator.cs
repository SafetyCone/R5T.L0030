using System;


namespace R5T.L0030
{
    public class XAttributeOperator : IXAttributeOperator
    {
        #region Infrastructure

        public static IXAttributeOperator Instance { get; } = new XAttributeOperator();


        private XAttributeOperator()
        {
        }

        #endregion
    }
}
