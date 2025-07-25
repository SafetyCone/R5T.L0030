﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;

using R5T.L0089.T000;

using R5T.L0030.T000;


namespace R5T.L0030.Extensions
{
    public static class XContainerExtensions
    {
        public static XElement Acquire_ChildOfChild(this XContainer container,
            IElementName elementName,
            IElementName childElementName)
        {
            return Instances.XContainerOperator.Acquire_ChildOfChild(
                container,
                elementName,
                childElementName);
        }

        public static XElement Acquire_Child(this XContainer container,
            IElementName elementName)
        {
            return Instances.XContainerOperator.Acquire_Child(container, elementName);
        }

        public static void Add_Children(this XContainer container,
            IEnumerable<object> children)
        {
            Instances.XContainerOperator.Add_Children(
                container,
                children);
        }

        public static void Add_Children(this XContainer container,
            params object[] children)
        {
            Instances.XContainerOperator.Add_Children(
                container,
                children);
        }

        public static XElement Add_Child(this XContainer container,
            IElementName childName,
            string childValue)
        {
            return Instances.XContainerOperator.Add_Child(
                container,
                childName,
                childValue);
        }

        public static XElement Ensure_HasChild(this XContainer container,
            IElementName elementName)
        {
            return Instances.XContainerOperator.Ensure_HasChild(
                container,
                elementName);
        }

        /// <inheritdoc cref="F10Y.L0000.IXContainerOperator.Enumerate_Children(XContainer)"/>
        public static IEnumerable<XElement> Get_Children(this XContainer container)
        {
            return Instances.XContainerOperator.Enumerate_Children(container);
        }

        public static IEnumerable<XElement> Get_Children(this XContainer container,
            IElementName childName)
        {
            return Instances.XContainerOperator.Enumerate_Children(
                container,
                childName);
        }

        public static XElement Get_Child(this XContainer container,
            IElementName childName)
        {
            return Instances.XContainerOperator.Get_Child(
                container,
                childName);
        }

        /// <inheritdoc cref="IXContainerOperator.Has_Child(XContainer, IElementName)"/>
        public static WasFound<XElement> Has_Child(this XContainer container,
            IElementName childName)
        {
            return Instances.XContainerOperator.Has_Child(
                container,
                childName);
        }

        /// <inheritdoc cref="IXContainerOperator.Has_Child_Any(XContainer, IElementName)"/>
        public static bool Has_Child_Any(this XContainer container, IElementName childName)
        {
            return Instances.XContainerOperator.Has_Child_Any(container, childName);
        }

        /// <inheritdoc cref="IXContainerOperator.Has_ChildWithChild_First(XContainer, IElementName, IElementName)"/>
        public static WasFound<XElement> Has_ChildWithChild_First(this XContainer container,
            IElementName childName,
            IElementName grandChildName)
        {
            return Instances.XContainerOperator.Has_ChildWithChild_First(container,
                childName,
                grandChildName);
        }

        /// <inheritdoc cref="IXContainerOperator.Has_ChildWithChild(XContainer, IElementName, IElementName)"/>
        public static WasFound<XElement> Has_ChildWithChild(this XContainer container,
            IElementName childName,
            IElementName grandChildName)
        {
            return Instances.XContainerOperator.Has_ChildWithChild(container,
                childName,
                grandChildName);
        }

        /// <inheritdoc cref="IXContainerOperator.Has_Child_ByNameAndAttributeValue_First(XContainer, IElementName, IAttributeName, string)"/>
        public static WasFound<XElement> Has_Child_ByNameAndAttributeValue_First(this XContainer container,
            IElementName childName,
            IAttributeName attributeName,
            string attributeValue)
        {
            return Instances.XContainerOperator.Has_Child_ByNameAndAttributeValue_First(container,
                childName,
                attributeName,
                attributeValue);
        }

        /// <inheritdoc cref="IXContainerOperator.Has_Child_ByNameAndAttributeValue(XContainer, IElementName, IAttributeName, string)"/>
        public static WasFound<XElement> Has_Child_ByNameAndAttributeValue(this XContainer container,
            IElementName childName,
            IAttributeName attributeName,
            string attributeValue)
        {
            return Instances.XContainerOperator.Has_Child_ByNameAndAttributeValue(container,
                childName,
                attributeName,
                attributeValue);
        }

        /// <inheritdoc cref="IXContainerOperator.OrderChildren_ByNames(XContainer, string[])"/>
        public static void OrderChildren_ByNames(this XContainer container,
            IEnumerable<string> names)
        {
            Instances.XContainerOperator.OrderChildren_ByNames(
                container,
                names);
        }

        /// <inheritdoc cref="IXContainerOperator.OrderChildren_ByNames(XContainer, string[])"/>
        public static void OrderChildren_ByNames(this XContainer container,
            params string[] names)
        {
            Instances.XContainerOperator.OrderChildren_ByNames(
                container,
                names);
        }

        /// <inheritdoc cref="IXContainerOperator.OrderChildren_ByNames(XContainer, string[])"/>
        public static void OrderChildren_ByNames(this XContainer container,
            IEnumerable<IElementName> names)
        {
            Instances.XContainerOperator.OrderChildren_ByNames(
                container,
                names);
        }

        /// <inheritdoc cref="IXContainerOperator.OrderChildren_ByNames(XContainer, string[])"/>
        public static void OrderChildren_ByNames(this XContainer container,
            params IElementName[] names)
        {
            Instances.XContainerOperator.OrderChildren_ByNames(
                container,
                names);
        }

        public static void RemoveAll_Children(this XContainer container)
        {
            Instances.XContainerOperator.RemoveAll_Children(container);
        }
    }
}
