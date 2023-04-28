using System;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using R5T.F0000;
using R5T.T0132;
using R5T.T0181;

using R5T.L0030.Extensions;
using R5T.L0030.T000;


namespace R5T.L0030
{
    [FunctionalityMarker]
    public partial interface IXmlOperator : IFunctionalityMarker
    {
        public string Get_AttributeValue(XElement element,
            IAttributeName attributeName)
        {
            return Instances.XElementOperator.Get_AttributeValue(element, attributeName);
        }

        public XmlWriterSettings Get_WriterSettings_Standard()
        {
            var output = new XmlWriterSettings()
                .Set_Standard();

            return output;
        }

        /// <summary>
        /// Method standardizes access to the <see cref="XmlWriter"/> constructor (which happens to be the static <see cref="XmlWriter.Create(string, XmlWriterSettings)"/> method).
        /// </summary>
        public XmlWriter Get_Writer(IXmlFilePath xmlFilePath, XmlWriterSettings settings)
        {
            Instances.FileSystemOperator.EnsureDirectoryForFilePathExists(
                xmlFilePath.Value);

            var output = XmlWriter.Create(xmlFilePath.Value, settings);
            return output;
        }

        public XmlWriter Get_Writer_Synchronous(IXmlFilePath xmlFilePath)
        {
            var settings = this.Get_WriterSettings_Standard();

            var output = this.Get_Writer(
                xmlFilePath,
                settings);

            return output;
        }

        public XmlWriter Get_Writer(IXmlFilePath xmlFilePath)
        {
            var settings = this.Get_WriterSettings_Standard();

            settings.Async = true;

            var output = this.Get_Writer(
                xmlFilePath,
                settings);

            return output;
        }

        public WasFound<XElement> Has_Element<TNode>(TNode node,
            Func<TNode, XElement> elementOrDefaultSelector)
            where TNode : XNode
        {
            var elementOrDefault = elementOrDefaultSelector(node);

            var wasFound = WasFound.From(elementOrDefault);
            return wasFound;
        }

        public XDocument Load_Synchronous(IXmlFilePath filePath)
        {
            return Instances.XDocumentOperator.Load_Synchronous(filePath);    
        }

        public Task<XDocument> Load(IXmlFilePath filePath)
        {
            return Instances.XDocumentOperator.Load(filePath);
        }

        public XElement New_Element(IElementName elementName)
        {
            var output = Instances.XElementOperator.New(elementName);
            return output;
        }

        /// <inheritdoc cref="IXDocumentOperator.New_Empty"/>
        public XDocument New_Document_Empty()
        {
            return Instances.XDocumentOperator.New_Empty();
        }

        public Task Save(
            IXmlFilePath filePath,
            XDocument document)
        {
            return Instances.XDocumentOperator.Save(
                filePath,
                document);
        }

        /// <summary>
        /// Saves an <see cref="XDocument"/> to an XML file.
        /// </summary>
        public void Save_Synchronous(
            IXmlFilePath filePath,
            XDocument document)
        {
            Instances.XDocumentOperator.Save_Synchronous(
                filePath,
                document);
        }

        /// <inheritdoc cref="Save{TNode}(IXmlFilePath, TNode)"/>
        public void Save_Synchronous<TNode>(
            IXmlFilePath filePath,
            TNode node)
            where TNode : XNode
        {
            using var writer = this.Get_Writer_Synchronous(filePath);

            // Need an XML writer.
            node.WriteTo(writer);
        }

        /// <summary>
        /// Saves an arbitrary <see cref="XNode"/> to an XML file.
        /// </summary>
        public async Task Save<TNode>(
            IXmlFilePath filePath,
            TNode node)
            where TNode : XNode
        {
            using var writer = this.Get_Writer(filePath);

            // Need an XML writer.
            node.WriteTo(writer);

            await writer.FlushAsync();
        }
    }
}
