using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using R5T.T0132;

using R5T.L0030.T000;


namespace R5T.L0030
{
    [FunctionalityMarker]
    public partial interface IXAttributeOperator : IFunctionalityMarker
    {
        public string Get_Value(XAttribute attribute)
        {
            return attribute.Value;
        }

        /// <summary>
        /// Uses the <see cref="XName.LocalName"/> property to avoid the crazed namespace BS.
        /// </summary>
        public bool Is_Name(XAttribute attribute, IAttributeName attributeName)
        {
            var output = attribute.Name.LocalName == attributeName.Value;
            return output;
        }

        /// <inheritdoc cref="Is_Name(XAttribute, IAttributeName)"/>
        public bool Name_Is(XAttribute attribute, IAttributeName attributeName)
        {
            return this.Is_Name(attribute, attributeName);
        }

        public XAttribute New_Attribute(IAttributeName attributeName, object value)
        {
            var output = new XAttribute(attributeName.Value, value);
            return output;
        }

        public XAttribute New_Attribute(IAttributeName attributeName)
        {
            var output = this.New_Attribute(attributeName, Instances.Values.DefaultAttributeValue);
            return output;
        }

        /// <summary>
        /// A helpfully named wrapper for <see cref="XAttribute.SetValue(object)"/>.
        /// </summary>
        public void Set_Value(XAttribute attribute, object value)
        {
            attribute.SetValue(value);
        }

        public IEnumerable<XAttribute> Where_NameIs(IEnumerable<XAttribute> attributes, IAttributeName attributeName)
        {
            var output = attributes
                .Where(attribute => this.Is_Name(attribute, attributeName))
                ;

            return output;
        }
    }
}
