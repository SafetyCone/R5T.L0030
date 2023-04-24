using System;

using R5T.T0132;


namespace R5T.L0030.T000
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        public AttributeName ToAttributeName(string value)
        {
            var output = new AttributeName(value);
            return output;
        }

        public ElementName ToElementName(string value)
        {
            var output = new ElementName(value);
            return output;
        }
    }
}
