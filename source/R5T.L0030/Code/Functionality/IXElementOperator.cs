using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using R5T.F0000;
using R5T.T0132;
using R5T.T0181;
using R5T.T0203;
using R5T.T0203.Extensions;

using R5T.L0030.Extensions;
using R5T.L0030.T000;
using System.Xml.Serialization;

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

        public void Clear_Children(XElement element)
        {
            Instances.XContainerOperator.Clear_Children(element);
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
            using var fileStream = Instances.FileStreamOperator.NewRead(xmlFilePath.Value);

            var output = await XElement.LoadAsync(
                fileStream,
                Instances.LoadOptionSets.Default,
                Instances.CancellationTokens.None);

            return output;
        }

        public IEnumerable<XElement> Get_ChildrenWithName(
            XElement element,
            IElementName elementName)
        {
            var output = element.Get_Children()
                .Where(child => child.Name_Is(elementName))
                ;

            return output;
        }

        public void RemoveAll_Children(XElement element)
        {
            Instances.XContainerOperator.RemoveAll_Children(element);
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

        public string Get_Name(XElement xElement)
        {
            var name = xElement.Name.LocalName;
            return name;
        }

        public string Get_Value(XElement element)
        {
            var output = element.Value;
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

        public XElement Parse(
            string xmlText,
            LoadOptions loadOptions = ILoadOptionSets.Default_Constant)
        {
            var output = XElement.Parse(
                xmlText,
                loadOptions);

            return output;
        }

        public XElement Parse(
            IXmlText xmlText,
            LoadOptions loadOptions = ILoadOptionSets.Default_Constant)
        {
            var output = this.Parse(
                xmlText.Value,
                loadOptions);

            return output;
        }

        public void Set_Value(XElement element, string value)
        {
            element.Value = value;
        }

        public IEnumerable<XElement> Where_NameIs(IEnumerable<XElement> elements, IElementName elementName)
        {
            var output = elements
                .Where(element => this.Is_Name(element, elementName))
                ;

            return output;
        }

        public async Task To_File(
            IXmlFilePath xmlFilePath,
            XElement xElement,
            XmlWriterSettings xmlWriterSettings)
        {
            using var fileStream = Instances.FileStreamOperator.NewWrite(xmlFilePath.Value);
            using var xmlWriter = XmlWriter.Create(fileStream, xmlWriterSettings);

            await xElement.SaveAsync(
                xmlWriter,
                Instances.CancellationTokens.None);
        }

        public Task To_File(
            IXmlFilePath xmlFilePath,
            XElement xElement)
        {
            return this.To_File(
                xmlFilePath,
                xElement,
                Instances.XmlWriterSettingSets.Standard);
        }

        public void To_File_Synchronous(
            IXmlFilePath xmlFilePath,
            XElement xElement,
            XmlWriterSettings xmlWriterSettings)
        {
            using var fileStream = Instances.FileStreamOperator.NewWrite(xmlFilePath.Value);
            using var xmlWriter = XmlWriter.Create(fileStream, xmlWriterSettings);

            xElement.Save(xmlWriter);
        }

        public void To_File_Synchronous(
            IXmlFilePath xmlFilePath,
            XElement xElement)
        {
            this.To_File_Synchronous(
                xmlFilePath,
                xElement,
                Instances.XmlWriterSettingSets.Standard);
        }

        public string To_Text(
            XElement xElement,
            XmlWriterSettings writerSettings)
        {
            var stringBuilder = new StringBuilder();

            using (var xmlWriter = XmlWriter.Create(stringBuilder, writerSettings))
            {
                xElement.WriteTo(xmlWriter);
            }

            var output = stringBuilder.ToString();
            return output;
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

        public string To_Text(XElement xElement)
        {
            var writerSettings = Instances.XmlWriterSettingSets.Standard;

            var output = this.To_Text(
                xElement,
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
