﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;

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

        public static XElement Add_Attribute(this XElement element, IAttributeName attributeName)
        {
            Instances.XElementOperator.Add_Attribute(element, attributeName);

            return element;
        }

        public static XElement Add_Attribute(this XElement element, IAttributeName attributeName, object value)
        {
            Instances.XElementOperator.Add_Attribute(element, attributeName, value);

            return element;
        }

        public static XElement Add_Child(this XElement element, XElement child)
        {
            Instances.XElementOperator.Add_Child(element, child);

            return element;
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