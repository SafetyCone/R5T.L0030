using System;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.L0030
{
    [FunctionalityMarker]
    public partial interface IXObjectOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Does the given element contain the given object?
        /// </summary>
        public bool Contains_Descendant(
            XElement element,
            XObject xObject)
        {
            var hasParent = this.Has_Parent(xObject);
            if(hasParent)
            {
                var parent = xObject.Parent;

                var output = this.Contains_Descendant(element, parent);
                return output;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Is the given element the given object, or does it contain the given object?
        /// </summary>
        public bool IsOrContains_Descendant(
            XElement element,
            XObject xObject)
        {
            // Is the XObject the element?
            if(xObject is XElement xElement)
            {
                var xElementIsElement = xElement == element;
                if(xElementIsElement)
                {
                    return true;
                }
            }

            // Else, does the element contain the object?
            var output = this.Contains_Descendant(
                element,
                xObject);

            return output;
        }

        public bool Has_Parent(XObject xObject)
        {
            var output = xObject.Parent != default;
            return output;
        }
    }
}
