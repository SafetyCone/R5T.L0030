using System;
using System.Threading.Tasks;
using System.Xml.Linq;

using R5T.F0000;
using R5T.F0000.Extensions.ForObject;
using R5T.L0030.T000;
using R5T.T0132;
using R5T.T0181;
using R5T.T0203;


namespace R5T.L0030
{
    [FunctionalityMarker]
    public partial interface IXDocumentOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Gets the standard load options, which is <see cref="LoadOptions.None"/>.
        /// </summary>
        /// <remarks>
        /// Do not preserve insignificant whitespace.
        /// Other options seem too esoteric to consider.
        /// </remarks>
        public LoadOptions Get_LoadOptions_Standard()
        {
            return LoadOptions.None;
        }

        public XElement Get_Root(XDocument document)
        {
            return this.Has_Root(document)
                .Get_Result();
        }

        public XElement Get_Root(
            XDocument document,
            IElementName rootElementName)
        {
            return this.Has_Root(
                document,
                rootElementName)
                .ResultOrExceptionIfNotFound(
                    () => $"No root element with name {rootElementName} found.");
        }

        public WasFound<XElement> Has_Root(XDocument document)
        {
            var rootElement = document.Root;

            var rootExists = Instances.NullOperator.Is_NotNull(rootElement);

            var output = WasFound.From(rootExists, rootElement);
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

        public XDocument Load_Synchronous(IXmlFilePath filePath)
        {
            var loadOptions = this.Get_LoadOptions_Standard();

            var xDocument = XDocument.Load(
                filePath.Value,
                loadOptions);

            return xDocument;
        }

        public Task<XDocument> Load(IXmlFilePath filePath)
        {
            var loadOptions = this.Get_LoadOptions_Standard();

            return this.Load(
                filePath,
                loadOptions);
        }

        public async Task<XDocument> Load(
            IXmlFilePath filePath,
            LoadOptions loadOptions)
        {
            using var fileStream = Instances.FileStreamOperator.NewRead(filePath.Value);

            var xDocument = await XDocument.LoadAsync(
                fileStream,
                loadOptions,
                Instances.CancellationTokens.None);

            return xDocument;
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
                Instances.LoadOptionSets.Default);

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
            XDocument document)
        {
            Instances.XmlOperator_F0000.WriteToFile_EmptyIsOk_Synchronous(
                document,
                filePath.Value);
        }

        public async Task Save(
            IXmlFilePath filePath,
            XDocument document)
        {
            await Instances.XmlOperator_F0000.WriteToFile_EmptyIsOk(
                document,
                filePath.Value);
        }

        public string WriteToString(XDocument document)
        {
            var output = Instances.XmlOperator_F0000.WriteToString_Synchronous(document);
            return output;
        }
    }
}
