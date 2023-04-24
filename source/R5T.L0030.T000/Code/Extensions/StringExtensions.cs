using System;


namespace R5T.L0030.T000.Extensions
{
    public static class StringExtensions
    {
        public static AttributeName ToAttributeName(this string value)
        {
            return Instances.StringOperator.ToAttributeName(value);
        }

        public static ElementName ToElementName(this string value)
        {
            return Instances.StringOperator.ToElementName(value);
        }
    }
}
