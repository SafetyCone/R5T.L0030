using System;

using R5T.T0132;


namespace R5T.L0030.T000
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="IAttributeName"/>
        public AttributeName ToAttributeName(string value)
        {
            var output = new AttributeName(value);
            return output;
        }

        /// <inheritdoc cref="IElementName"/>
        public ElementName ToElementName(string value)
        {
            var output = new ElementName(value);
            return output;
        }

        /// <inheritdoc cref="N001.IElementName"/>
        public N001.ElementName ToElementName_N001(string value)
        {
            var output = new N001.ElementName(value);
            return output;
        }
    }
}
