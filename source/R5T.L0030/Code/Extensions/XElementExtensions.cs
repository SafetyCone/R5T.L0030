using System;
using System.Collections.Generic;
using System.Xml.Linq;

using R5T.F0000;
using R5T.L0030.T000;


namespace R5T.L0030.Extensions
{
    public static class XElementExtensions
    {
        /// <inheritdoc cref="IXElementOperator.Acquire_Attribute(XElement, IAttributeName)"/>
        public static XAttribute Acquire_Attribute(this XElement element, IAttributeName attributeName)
        {
            return Instances.XElementOperator.Acquire_Attribute(element, attributeName);
        }

        public static XAttribute Add_Attribute(this XElement element, IAttributeName attributeName)
        {
            return Instances.XElementOperator.Add_Attribute(element, attributeName);
        }

        public static XAttribute Add_Attribute(this XElement element, IAttributeName attributeName, object value)
        {
            return Instances.XElementOperator.Add_Attribute(element, attributeName, value);
        }

        public static XElement Add_Child(this XElement element, XElement child)
        {
            Instances.XElementOperator.Add_Child(element, child);

            return element;
        }

        public static bool Contains_Descendant(this XElement element, XObject xObject)
        {
            var output = Instances.XObjectOperator.Contains_Descendant(
                element,
                xObject);

            return output;
        }

        public static bool IsOrContains_Descendant(this XElement element, XObject xObject)
        {
            var output = Instances.XObjectOperator.IsOrContains_Descendant(
                element,
                xObject);

            return output;
        }

        public static XAttribute Get_Attribute(this XElement element,
            IAttributeName attributeName)
        {
            return Instances.XElementOperator.Get_Attribute(
                element,
                attributeName);
        }

        public static IEnumerable<XAttribute> Get_Attributes(this XElement element)
        {
            return Instances.XElementOperator.Get_Attributes(element);
        }

        public static string Get_AttributeValue(this XElement element,
            IAttributeName attributeName)
        {
            return Instances.XElementOperator.Get_AttributeValue(element, attributeName);
        }

        public static IEnumerable<XElement> Get_Children(this XElement element)
        {
            return Instances.XElementOperator.Get_Children(element);
        }

        public static IEnumerable<XElement> Get_Children(this XElement element,
            IElementName childName)
        {
            return Instances.XElementOperator.Get_Children(
                element,
                childName);
        }

        public static string Get_Name(this XElement xElement)
        {
            var name = Instances.XElementOperator.Get_Name(xElement);
            return name;
        }

        public static WasFound<XAttribute> Has_Attribute(this XElement element,
            IAttributeName attributeName)
        {
            return Instances.XElementOperator.Has_Attribute(
                element,
                attributeName);
        }

        /// <inheritdoc cref="IXElementOperator.Is_Name(XElement, IElementName)"/>
        public static bool Is_Name(this XElement element,
            IElementName elementName)
        {
            return Instances.XElementOperator.Is_Name(element, elementName);
        }

        /// <inheritdoc cref="IXElementOperator.Name_Is(XElement, IElementName)"/>
        public static bool Name_Is(this XElement element,
            IElementName elementName)
        {
            return Instances.XElementOperator.Name_Is(element, elementName);
        }

        public static IEnumerable<XElement> Where_NameIs(this IEnumerable<XElement> elements,
            IElementName elementName)
        {
            return Instances.XElementOperator.Where_NameIs(
                elements,
                elementName);
        }
    }
}
