using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using R5T.F0000;
using R5T.T0132;

using R5T.L0030.Extensions;
using R5T.L0030.T000;


namespace R5T.L0030
{
    [FunctionalityMarker]
    public partial interface IXElementOperator : IFunctionalityMarker
    {
        public XAttribute Acquire_Attribute(XElement element, IAttributeName attributeName)
        {
            var hasAttribute = this.Has_Attribute(element, attributeName);
            if (!hasAttribute)
            {
                var attribute = this.Add_Attribute(element, attributeName);

                return attribute;
            }
            else
            {
                return hasAttribute.Result;
            }
        }

        public XAttribute Add_Attribute(XElement element, IAttributeName attributeName)
        {
            var attribute = Instances.XAttributeOperator.New_Attribute(attributeName);

            element.Add(attribute);

            return attribute;
        }

        public XAttribute Add_Attribute(XElement element, IAttributeName attributeName, object value)
        {
            var attribute = this.Add_Attribute(element, attributeName);

            attribute.SetValue(value);

            return attribute;
        }

        public void Add_Child(XElement element, XElement child)
        {
            element.Add(child);
        }

        public IEnumerable<XAttribute> Get_Attributes(XElement element)
        {
            return element.Attributes();
        }

        public string Get_AttributeValue(XElement element,
            IAttributeName attributeName)
        {
            var attribute = this.Has_Attribute(element, attributeName)
                .ResultOrExceptionIfNotFound();

            var output = attribute.Value;
            return output;
        }

        public WasFound<XAttribute> Has_Attribute_First(XElement element, IAttributeName attributeName)
        {
            var attributeOrDefault = this.Get_Attributes(element)
                .Where_NameIs(attributeName)
                .FirstOrDefault();

            var output = WasFound.From(attributeOrDefault);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Has_Attribute_First(XElement, IAttributeName)"/> as the default.
        /// </summary>
        public WasFound<XAttribute> Has_Attribute(XElement element, IAttributeName attributeName)
        {
            return this.Has_Attribute_First(element, attributeName);
        }

        /// <summary>
        /// Uses the <see cref="XName.LocalName"/> property to avoid the crazed namespace BS.
        /// </summary>
        public bool Is_Name(XElement element, IElementName elementName)
        {
            var output = element.Name.LocalName == elementName.Value;
            return output;
        }

        /// <inheritdoc cref="Is_Name(XElement, IElementName)"/>
        public bool Name_Is(XElement element, IElementName elementName)
        {
            return this.Is_Name(element, elementName);
        }

        public XElement New(IElementName elementName)
        {
            var output = new XElement(elementName.Value);
            return output;
        }

        public IEnumerable<XElement> Where_NameIs(IEnumerable<XElement> elements, IElementName elementName)
        {
            var output = elements
                .Where(element => this.Is_Name(element, elementName))
                ;

            return output;
        }
    }
}
