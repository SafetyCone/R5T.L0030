using System;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.L0030
{
    [FunctionalityMarker]
    public partial interface IXNodeOperator : IFunctionalityMarker
    {
        public bool DeepEquals(XNode a, XNode b)
        {
            var output = XNode.DeepEquals(a, b);
            return output;
        }
    }
}
