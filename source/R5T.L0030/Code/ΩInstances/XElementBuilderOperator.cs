using System;


namespace R5T.L0030
{
    public class XElementBuilderOperator : IXElementBuilderOperator
    {
        #region Infrastructure

        public static IXElementBuilderOperator Instance { get; } = new XElementBuilderOperator();


        private XElementBuilderOperator()
        {
        }

        #endregion
    }
}
