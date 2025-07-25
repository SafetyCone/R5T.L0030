using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using R5T.L0089.T000;
using R5T.T0132;
using R5T.T0181;
using R5T.T0203;
using R5T.T0203.Extensions;

using R5T.L0030.Extensions;
using R5T.L0030.T000;


namespace R5T.L0030
{
    [FunctionalityMarker]
    public partial interface IXElementOperator : IFunctionalityMarker,
        F0000.IXElementOperator,
        L0056.IXElementOperator
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

        public void Clear_Children(XElement element)
        {
            Instances.XContainerOperator.Clear_Children(element);
        }

        /// <summary>
        /// There is no such thing as a shallow-copy for <see cref="XElement"/>s.
        /// This due to the <see cref="XObject.Parent"/> behavior.
        /// Whenever an element is added as a child element, if it already has a parent the parent is not changed, but instead the node is deep-copied and a copy is added as a child.
        /// This allows functional behavior.
        /// </summary>
        /// <remarks>
        /// See the Clone_Only() methods for specific behavior.
        /// </remarks>
        public XElement Shallow_Copy(XElement element)
        {
            throw new NotImplementedException("There is no such thing has shallow copy for XElements. See Clone_Only() methods for specific behavior.");
        }

        /// <inheritdoc cref="IXNodeOperator.DeepEquals(XNode, XNode)"/>
        public bool DeepEquals(XElement a, XElement b)
        {
            var output = Instances.XNodeOperator.DeepEquals(a, b);
            return output;
        }
        
        /// <summary>
        /// Are two <see cref="XElement"/>s the same object?
        /// </summary>
        public bool Equals_ByReference(XElement a, XElement b)
        {
            var output = Object.ReferenceEquals(a, b);
            return output;
        }

        public bool Equals_ByValue_Deep(XElement a, XElement b)
        {
            var output = this.DeepEquals(a, b);
            return output;
        }

        public XElement From_Text(string xmlText)
        {
            return this.Parse(xmlText);
        }

        public XElement From(IXmlText xmlText)
        {
            return this.Parse(xmlText);
        }

        public async Task<XElement> From(IXmlFilePath xmlFilePath)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Read(xmlFilePath.Value);

            var output = await XElement.LoadAsync(
                fileStream,
                Instances.LoadOptionsSets.Default,
                Instances.CancellationTokens.None);

            return output;
        }

        public XElement Get_Child(
            XElement element,
            IElementName chldName)
        {
            var output = element.Get_Child(chldName);
            return output;
        }

        public WasFound<XElement> Has_Child(
            XElement element,
            IElementName childName)
        {
            return element.Has_Child(childName);
        }

        /// <summary>
        /// Same as <see cref="Enumerate_ChildrenWithName(XElement, IElementName)"/>
        /// </summary>
        public IEnumerable<XElement> Get_Children(
            XElement element,
            IElementName childName)
        {
            return this.Enumerate_ChildrenWithName(
                element,
                childName);
        }

        /// <summary>
        /// Same as <see cref="Get_Children(XElement, IElementName)"/>
        /// </summary>
        public IEnumerable<XElement> Enumerate_ChildrenWithName(
            XElement element,
            IElementName name)
        {
            return Instances.XContainerOperator.Enumerate_Children(
                element,
                name);
        }

        /// <summary>
        /// Same as <see cref="Get_DescendantsWithName(XElement, IElementName)"/>
        /// </summary>
        public IEnumerable<XElement> Get_Descendants(
            XElement element,
            IElementName name)
        {
            return this.Get_DescendantsWithName(
                element,
                name);
        }

        /// <summary>
        /// Same as <see cref="Get_Children(XElement, IElementName)"/>
        /// </summary>
        public IEnumerable<XElement> Get_DescendantsWithName(
            XElement element,
            IElementName name)
        {
            var output = Instances.XContainerOperator.Get_Descendants(
                element,
                name);

            return output;
        }

        public WasFound<XElement> Has_Descendant_First(
            XElement element,
            IElementName name)
        {
            var output = Instances.XContainerOperator.Has_Descendant_First(
                element,
                name);

            return output;
        }

        public void RemoveAll_Children(XElement element)
        {
            Instances.XContainerOperator.RemoveAll_Children(element);
        }

        public XAttribute Get_Attribute(
            XElement element,
            IAttributeName attributeName)
        {
            var output = this.Has_Attribute(element, attributeName)
                .Get_Result_OrExceptionIfNotFound();

            return output;
        }

        public string Get_AttributeValue(XElement element,
            IAttributeName attributeName)
        {
            var attribute = this.Get_Attribute(
                element,
                attributeName);

            var output = attribute.Value;
            return output;
        }

        public void Remove_LeadingAndTrailingWhitespaceNodes(XElement element)
        {
            var nodesToKeep = this.Get_Nodes_ExceptLeadingAndTrailingWhitespaceNodes(element);

            element.RemoveAll();
            element.Add(nodesToKeep);
        }

        public IEnumerable<XNode> Get_Nodes_ExceptLeadingAndTrailingWhitespaceNodes(XElement element)
        {
            static IEnumerable<XNode> ExceptLeadingWhitespaceNodes(IEnumerable<XNode> nodes)
            {
                var inLeadingWhitespace = true;

                foreach (var node in nodes)
                {
                    if (inLeadingWhitespace)
                    {
                        if (node is XText textNode)
                        {
                            var isWhitespace = textNode.Value.Trim() == System.String.Empty;
                            if (isWhitespace)
                            {
                                continue;
                            };
                        }

                        inLeadingWhitespace = false;
                    }

                    yield return node;
                }
            }

            var nodes = element.Nodes().Now();

            var output = ExceptLeadingWhitespaceNodes(
                ExceptLeadingWhitespaceNodes(
                    nodes
                )
                .Reverse()
            ).Reverse();

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

        public WasFound<string> Has_AttributeValue(XElement element, IAttributeName attributeName)
        {
            var output = this.Has_Attribute(
                element,
                attributeName)
                .Convert(attribute => attribute.Value);

            return output;
        }

        /// <summary>
        /// Uses the <see cref="XName.LocalName"/> property to avoid the crazed namespace BS.
        /// </summary>
        public bool Is_Name(XElement element, IElementName elementName)
        {
            var output = element.Name.LocalName == elementName.Value;
            return output;
        }

        public bool Is_SelfClosed(XElement inheritdocElement)
        {
            var output = !inheritdocElement.HasElements;
            return output;
        }

        public bool Is_Value(
            XElement element,
            string value)
        {
            var elementValue = this.Get_Value(element);

            var output = elementValue == value;
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

        public XElement New(
            IElementName elementName,
            params object[] contents)
        {
            var output = new XElement(
                elementName.Value,
                contents);

            return output;
        }

        public XElement[] Parse_MultipleRoots(
            IXmlText xmlText,
            LoadOptions loadOptions = ILoadOptionsSets.Default_Constant)
        {
            return this.Parse_MultipleRoots(
                xmlText.Value,
                loadOptions);
        }

        public XElement[] Parse_MultipleRoots(
            string xmlText,
            LoadOptions loadOptions = ILoadOptionsSets.Default_Constant)
        {
            var modifiedXmlText = "<temp>" + xmlText + "</temp>";

            var tempElement = this.Parse(modifiedXmlText);

            var output = tempElement.Elements().ToArray();
            return output;
        }

        public XElement Parse(
            IXmlText xmlText,
            LoadOptions loadOptions = ILoadOptionsSets.Default_Constant)
        {
            var output = this.Parse(
                xmlText.Value,
                loadOptions);

            return output;
        }

        public IEnumerable<XElement> Where_NameIs(IEnumerable<XElement> elements, IElementName elementName)
        {
            var output = elements
                .Where(element => this.Is_Name(element, elementName))
                ;

            return output;
        }

        public Task To_File(
            IXmlFilePath xmlFilePath,
            XElement xElement,
            XmlWriterSettings xmlWriterSettings)
        {
            return this.To_File(
                xmlFilePath.Value,
                xElement,
                xmlWriterSettings);
        }

        public Task To_File(
            IXmlFilePath xmlFilePath,
            XElement xElement)
        {
            return this.To_File(
                xmlFilePath.Value,
                xElement);
        }

        /// <summary>
        /// Writes an <see cref="XElement"/> to a file using the standard XML writer settings (<see cref="L0053.IXmlWriterSettingsSet.Standard"/>).
        /// <para>Hides the <see cref="L0066.IXElementOperator.To_File(string, XElement)"/> method:</para>
        /// <para><inheritdoc cref="L0066.IXElementOperator.To_File(string, XElement)" path="descendant::description"/></para>
        /// </summary>
        public new Task To_File(
            string xmlFilePath,
            XElement xElement)
        {
            return this.To_File(
                xmlFilePath,
                xElement,
                Instances.XmlWriterSettingsSet.Standard);
        }

        public void To_File_Synchronous(
            IXmlFilePath xmlFilePath,
            XElement xElement,
            XmlWriterSettings xmlWriterSettings)
        {
            this.To_File_Synchronous(
                xmlFilePath.Value,
                xElement,
                xmlWriterSettings);
        }

        public void To_File_Synchronous(
            IXmlFilePath xmlFilePath,
            XElement xElement)
        {
            this.To_File_Synchronous(
                xmlFilePath,
                xElement,
                Instances.XmlWriterSettingsSet.Standard);
        }

        public void To_File_AsIs_Synchronous(
            IXmlFilePath xmlFilePath,
            XElement xElement)
        {
            this.To_File_Synchronous(
                xmlFilePath,
                xElement,
                Instances.XmlWriterSettingsSet.Standard);
        }

        /// <summary>
        /// Allows use of <see cref="XmlWriterSettings.Async"/> when writing to an in-memory string.
        /// </summary>
        public async Task<string> To_Text_Asynchronous(
            XElement xElement,
            XmlWriterSettings writerSettings)
        {
            var stringBuilder = new StringBuilder();

            using (var xmlWriter = XmlWriter.Create(stringBuilder, writerSettings))
            {
                await xElement.WriteToAsync(
                    xmlWriter,
                    Instances.CancellationTokens.None);
            }

            var output = stringBuilder.ToString();
            return output;
        }

        public new string To_Text(XElement xElement)
        {
            var writerSettings = Instances.XmlWriterSettingsSet.Standard;

            var output = this.To_Text(
                xElement,
                writerSettings);

            return output;
        }

        public string To_Text(
            IEnumerable<XElement> xElements,
            XmlWriterSettings writerSettings)
        {
            var stringBuilder = new StringBuilder();

            writerSettings.ConformanceLevel = ConformanceLevel.Fragment;
            writerSettings.NewLineHandling = NewLineHandling.Replace;

            using (var xmlWriter = XmlWriter.Create(stringBuilder, writerSettings))
            {
                foreach (var xElement in xElements)
                {
                    xElement.WriteTo(xmlWriter);
                }
            }

            var output = stringBuilder.ToString();
            return output;
        }

        public string To_Text(IEnumerable<XElement> xElements)
        {
            var writerSettings = Instances.XmlWriterSettingsSet.Standard;

            var output = this.To_Text(
                xElements,
                writerSettings);

            return output;
        }

        public IXmlText To_XmlText(XElement xElement)
        {
            var output = this.To_Text(xElement)
                .ToXmlText();

            return output;
        }
    }
}
