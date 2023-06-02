using System;


namespace R5T.L0030
{
    public class XNameOperator : IXNameOperator
    {
        #region Infrastructure

        public static IXNameOperator Instance { get; } = new XNameOperator();


        private XNameOperator()
        {
        }

        #endregion
    }
}
