using System;
using System.Threading.Tasks;
using System.Xml.Linq;

using R5T.L0030.T000;
using R5T.L0089.T000;
using R5T.T0132;
using R5T.T0181;
using R5T.T0203;

using XmlDocumentation = R5T.Y0006.Documentation.ForXml;


namespace R5T.L0030
{
    [FunctionalityMarker]
    public partial interface IXDocumentOperator : IFunctionalityMarker,
        L0056.IXDocumentOperator
    {
        /// <summary>
        /// Creates a separate, but identical instance.
        /// <para>Same as <see cref="Deep_Copy(XDocument)"/></para>
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="XmlDocumentation.WhichXObjectsAreCloneable" path="/summary"/>
        /// </remarks>
        public XDocument Clone(XDocument document)
        {
            // Use the constructor.
            var output = new XDocument(document);
            return output;
        }

        /// <summary>
        /// Creates a copy of the document, and all child-nodes.
        /// <para>Same as <see cref="Clone(XDocument)"/></para>
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="XmlDocumentation.WhichXObjectsAreCloneable" path="/summary"/>
        /// </remarks>
        public XDocument Deep_Copy(XDocument document)
        {
            return this.Clone(document);
        }

        public XElement Get_Root(
            XDocument document,
            IElementName rootElementName)
        {
            return this.Has_Root(
                document,
                rootElementName)
                .Get_Result_OrExceptionIfNotFound(
                    () => $"No root element with name {rootElementName} found.");
        }

        public WasFound<XElement> Has_Root(XDocument document)
        {
            var hasRoot = this.Has_Root(
                document,
                out var root_OrDefault);

            var output = WasFound.From(hasRoot, root_OrDefault);
            return output;
        }

        public WasFound<XElement> Has_Root(
            XDocument document,
            IElementName rootElementName)
        {
            var hasRoot = this.Has_Root(document);
            if(!hasRoot)
            {
                return WasFound.NotFound<XElement>();
            }

            // Now does the root have the desired name?
            var correctlyNamed = Instances.XElementOperator.Name_Is(
                hasRoot.Result,
                rootElementName);

            var output = correctlyNamed
                ? WasFound.Found(hasRoot.Result)
                : WasFound.NotFound<XElement>()
                ;

            return output;
        }

        public XDocument Parse(
            IXmlText xmlText,
            LoadOptions loadOptions)
        {
            var output = XDocument.Parse(
                xmlText.Value,
                loadOptions);

            return output;
        }

        public XDocument Parse(IXmlText xmlText)
        {
            var output = this.Parse(
                xmlText,
                Instances.LoadOptionsSets.Default);

            return output;
        }

        /// <summary>
        /// Construct a new empty XML document.
        /// </summary>
        public XDocument New_Empty()
        {
            var output = new XDocument();
            return output;
        }

        public void Save_Synchronous(
            IXmlFilePath filePath,
            XDocument document,
            SaveOptions saveOptions = ISaveOptionsSets.Default_Constant)
        {
            Instances.XmlOperator_F0000.WriteToFile_EmptyIsOk_Synchronous(
                document,
                filePath.Value,
                saveOptions);
        }

        public Task Save(
            IXmlFilePath xmlFilePath,
            XDocument document,
            SaveOptions saveOptions = ISaveOptionsSets.Default_Constant)
        {
            return this.Save(
                xmlFilePath.Value,
                document,
                saveOptions);
        }

        public string WriteToString(
            XDocument document,
            SaveOptions saveOptions = ISaveOptionsSets.Default_Constant)
        {
            var output = Instances.XmlOperator_F0000.WriteToString_Synchronous(
                document,
                saveOptions);

            return output;
        }
    }
}
