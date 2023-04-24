using System;
using R5T.T0132;

using R5T.L0030.T000;


namespace R5T.L0030
{
    [FunctionalityMarker]
    public partial interface IXElementBuilderOperator : IFunctionalityMarker
    {
        public IXElementBuilder New(IElementName elementName)
        {
            var output = new XElementBuilder
            {
                Element = Instances.XElementOperator.New(elementName),
            };

            return output;
        }
    }
}
