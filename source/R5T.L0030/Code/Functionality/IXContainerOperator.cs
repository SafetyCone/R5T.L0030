using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using R5T.F0000;
using R5T.T0132;

using R5T.L0030.Extensions;
using R5T.L0030.T000;
using R5T.T0179.Extensions;


namespace R5T.L0030
{
    [FunctionalityMarker]
    public partial interface IXContainerOperator : IFunctionalityMarker
    {
        public XElement Acquire_ChildOfChild(
            XContainer container,
            IElementName elementName,
            IElementName childElementName)
        {
            var child = this.Acquire_Child(
                container,
                elementName);

            var grandchild = this.Acquire_Child(
                child,
                childElementName);

            return grandchild;
        }

        public XElement Acquire_Child(XContainer container, IElementName elementName)
        {
            var hasChild = this.Has_Child(container, elementName);
            if(!hasChild)
            {
                var child = Instances.XElementOperator.New(elementName);

                container.Add(child);

                return child;
            }
            else
            {
                return hasChild.Result;
            }
        }

        /// <summary>
        /// Creates a child with the given name and text value, adds the child to the container, then returns the newly created child element.
        /// </summary>
        public XElement Add_Child(XContainer container,
            IElementName childName,
            string childValue)
        {
            var child = Instances.XElementOperator.New(childName);

            child.Value = childValue;

            container.Add(child);

            return child;
        }

        public void Add_Children(XContainer container,
            IEnumerable<object> children)
        {
            this.Add_Children(
                container,
                // Use the array method as the base.
                children.Now());
        }

        public void Add_Children(XContainer container,
            params object[] children)
        {
            container.Add(children);
        }

        public void Clear_Children(XContainer container)
        {
            this.RemoveAll_Children(container);
        }

        public XElement Ensure_HasChild(
            XContainer container,
            IElementName elementName)
        {
            return this.Acquire_Child(
                container,
                elementName);
        }

        /// <summary>
        /// A better named quality-of-life method for <see cref="XContainer.Elements()"/>.
        /// </summary>
        public IEnumerable<XElement> Get_Children(XContainer container)
        {
            return container.Elements();
        }

        public bool Has_Child_Any(XContainer container, IElementName childName)
        {
            var output = this.Get_Children(container)
                .Where_NameIs(childName)
                .Any();

            return output;
        }

        public WasFound<XElement> Has_Child_First(XContainer container, IElementName childName)
        {
            var childOrDefault = this.Get_Children(container)
                .Where_NameIs(childName)
                .FirstOrDefault();

            var output = WasFound.From(childOrDefault);
            return output;
        }

        public WasFound<XElement> Has_Child_Single(XContainer container, IElementName childName)
        {
            var childOrDefault = this.Get_Children(container)
                .Where_NameIs(childName)
                .SingleOrDefault();

            var output = WasFound.From(childOrDefault);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Has_Child_First(XContainer, IElementName)"/> as the default.
        /// </summary>
        public WasFound<XElement> Has_Child(XContainer container, IElementName childName)
        {
            return this.Has_Child_First(container, childName);
        }

        /// <summary>
        /// Chooses <see cref="Has_ChildWithChild_First(XContainer, IElementName, IElementName)"/> as the default.
        /// </summary>
        public WasFound<XElement> Has_ChildWithChild(XContainer container,
            IElementName childName,
            IElementName grandChildName)
        {
            return this.Has_ChildWithChild_First(container,
                childName,
                grandChildName);
        }

        /// <summary>
        /// Determines if an element has a child with the given name that also has an attribute with the given name and value.
        /// </summary>
        public WasFound<XElement> Has_Child_ByNameAndAttributeValue_First(XContainer container,
            IElementName childName,
            IAttributeName attributeName,
            string attributeValue)
        {
            var childWithAttributeValueOrDefault = container.Get_Children()
                .Where_NameIs(childName)
                .Where(propertyGroupElement => propertyGroupElement.Get_Attributes()
                    .Where_NameIs(attributeName)
                    .Where(labelAttribute => labelAttribute.Value == attributeValue)
                    .Any())
                .FirstOrDefault();

            var output = WasFound.From(childWithAttributeValueOrDefault);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Has_Child_ByNameAndAttributeValue_First(XContainer, IElementName, IAttributeName, string)" path="/summary"/>
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Has_Child_ByNameAndAttributeValue_First(XContainer, IElementName, IAttributeName, string)"/> as the default.
        /// </remarks>
        public WasFound<XElement> Has_Child_ByNameAndAttributeValue(XContainer container,
            IElementName childName,
            IAttributeName attributeName,
            string attributeValue)
        {
            return this.Has_Child_ByNameAndAttributeValue_First(container,
                childName,
                attributeName,
                attributeValue);
        }

        public WasFound<XElement> Has_ChildWithChild_First(XContainer container,
            IElementName childName,
            IElementName grandChildName)
        {
            var childOrDefault = container.Get_Children()
                .Where_NameIs(childName)
                .Where(child => child.Has_Child_Any(grandChildName))
                .FirstOrDefault();

            var output = WasFound.From(childOrDefault);
            return output;
        }

        /// <summary>
        /// Orders child nodes by name.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="F0000.IOrderOperator.OrderByNames{TElement}(IEnumerable{TElement}, Func{TElement, string}, string[])" path="/summary"/>
        /// </remarks>
        public void OrderChildren_ByNames(
            XContainer container,
            IEnumerable<string> names)
        {
            var children = container.Get_Children();

            var orderedChildren = Instances.OrderOperator.OrderByNames(
                children,
                child => child.Get_Name(),
                names
            );

            container.RemoveAll_Children();

            container.Add_Children(orderedChildren);
        }

        /// <inheritdoc cref="OrderChildren_ByNames(XContainer, IEnumerable{string})"/>
        public void OrderChildren_ByNames(
            XContainer container,
            params string[] names)
        {
            this.OrderChildren_ByNames(
                container,
                names.AsEnumerable());
        }

        public void OrderChildren_ByNames(
            XContainer container,
            IEnumerable<IElementName> names)
        {
            var nameValues = names.Get_Values();

            this.OrderChildren_ByNames(
                container,
                nameValues);
        }

        public void OrderChildren_ByNames(
            XContainer container,
            params IElementName[] names)
        {
            this.OrderChildren_ByNames(
                container,
                names.AsEnumerable());
        }

        public void RemoveAll_Children(XContainer container)
        {
            container.RemoveNodes();
        }
    }
}
