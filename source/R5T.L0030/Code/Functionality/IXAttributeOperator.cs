using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using R5T.T0132;

using R5T.L0030.T000;

using XmlDocumentation = R5T.Y0006.Documentation.For_Xml;


namespace R5T.L0030
{
    [FunctionalityMarker]
    public partial interface IXAttributeOperator : IFunctionalityMarker,
        L0066.IXAttributeOperator
    {
        /// <summary>
        /// Creates a separate, but identical instance.
        /// <para>Same as <see cref="Deep_Copy(XAttribute)"/></para>
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="XmlDocumentation.WhichXObjectsAreCloneable" path="/summary"/>
        /// </remarks>
        public XAttribute Clone(XAttribute element)
        {
            // Use the constructor.
            var output = new XAttribute(element);
            return output;
        }

        /// <summary>
        /// Creates a copy of the element, and all child-nodes.
        /// <para>Same as <see cref="Clone(XAttribute)"/></para>
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="XmlDocumentation.WhichXObjectsAreCloneable" path="/summary"/>
        /// </remarks>
        public XAttribute Deep_Copy(XAttribute element)
        {
            return this.Clone(element);
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

        public IEnumerable<XAttribute> Where_NameIs(IEnumerable<XAttribute> attributes, IAttributeName attributeName)
        {
            var output = attributes
                .Where(attribute => this.Is_Name(attribute, attributeName))
                ;

            return output;
        }
    }
}
