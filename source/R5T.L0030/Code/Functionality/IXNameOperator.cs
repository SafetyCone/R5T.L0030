using System;
using System.Xml.Linq;

using R5T.T0132;

using R5T.L0030.T000;


namespace R5T.L0030
{
    [FunctionalityMarker]
    public partial interface IXNameOperator : IFunctionalityMarker
    {
        public XName ToXName(string name)
        {
            var output = XName.Get(name);
            return output;
        }

        public XName ToXName(IElementName elementName)
        {
            var output = this.ToXName(elementName.Value);
            return output;
        }
    }
}
