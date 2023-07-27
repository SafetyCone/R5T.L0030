using System;


namespace R5T.L0030.Internal
{
    public class XElementOperator : IXElementOperator
    {
        #region Infrastructure

        public static IXElementOperator Instance { get; } = new XElementOperator();


        private XElementOperator()
        {
        }

        #endregion
    }
}
