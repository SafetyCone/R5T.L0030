using System;
using System.Collections.Generic;
using System.Xml.Linq;

using R5T.L0030.T000;


namespace R5T.L0030.Extensions
{
    public static class XAttributeExtensions
    {
        /// <inheritdoc cref="IXAttributeOperator.Is_Name(XAttribute, IAttributeName)"/>
        public static bool Is_Name(this XAttribute attribute,
            IAttributeName attributeName)
        {
            return Instances.XAttributeOperator.Is_Name(attribute, attributeName);
        }

        /// <inheritdoc cref="IXAttributeOperator.Name_Is(XAttribute, IAttributeName)"/>
        public static bool Name_Is(this XAttribute attribute,
            IAttributeName attributeName)
        {
            return Instances.XAttributeOperator.Name_Is(attribute, attributeName);
        }

        public static IEnumerable<XAttribute> Where_NameIs(this IEnumerable<XAttribute> attributes,
            IAttributeName attributeName)
        {
            return Instances.XAttributeOperator.Where_NameIs(
                attributes,
                attributeName);
        }
    }
}
