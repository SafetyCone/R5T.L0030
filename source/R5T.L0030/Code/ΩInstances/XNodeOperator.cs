using System;


namespace R5T.L0030
{
    public class XNodeOperator : IXNodeOperator
    {
        #region Infrastructure

        public static IXNodeOperator Instance { get; } = new XNodeOperator();


        private XNodeOperator()
        {
        }

        #endregion
    }
}
