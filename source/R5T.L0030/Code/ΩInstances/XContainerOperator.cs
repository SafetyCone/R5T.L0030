using System;


namespace R5T.L0030
{
    public class XContainerOperator : IXContainerOperator
    {
        #region Infrastructure

        public static IXContainerOperator Instance { get; } = new XContainerOperator();


        private XContainerOperator()
        {
        }

        #endregion
    }
}
