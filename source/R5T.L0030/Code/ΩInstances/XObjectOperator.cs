using System;


namespace R5T.L0030
{
    public class XObjectOperator : IXObjectOperator
    {
        #region Infrastructure

        public static IXObjectOperator Instance { get; } = new XObjectOperator();


        private XObjectOperator()
        {
        }

        #endregion
    }
}
