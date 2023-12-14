using System;


namespace R5T.L0030.T000.Extensions
{
    public static class StringExtensions
    {
        /// <inheritdoc cref="IAttributeName"/>
        public static IAttributeName ToAttributeName(this string value)
        {
            return Instances.StringOperator.ToAttributeName(value);
        }

        /// <inheritdoc cref="IElementName"/>
        public static IElementName ToElementName(this string value)
        {
            return Instances.StringOperator.ToElementName(value);
        }

        /// <inheritdoc cref="N001.IElementName"/>
        public static N001.IElementName ToElementName_N001(this string value)
        {
            return Instances.StringOperator.ToElementName_N001(value);
        }
    }
}
