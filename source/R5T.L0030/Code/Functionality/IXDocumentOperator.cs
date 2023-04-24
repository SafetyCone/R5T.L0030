using System;
using System.Threading.Tasks;
using System.Xml.Linq;

using R5T.F0000;
using R5T.T0132;
using R5T.T0181;


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

        public WasFound<XElement> Has_Root(XDocument document)
        {
            var rootElement = document.Root;

            var rootExists = Instances.NullOperator.Is_NotNull(rootElement);

            var output = WasFound.From(rootExists, rootElement);
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

        public async Task<XDocument> Load(IXmlFilePath filePath)
        {
            using var fileStream = Instances.FileStreamOperator.NewRead(filePath.Value);

            var loadOptions = this.Get_LoadOptions_Standard();

            var xDocument = await XDocument.LoadAsync(
                fileStream,
                loadOptions,
                Instances.CancellationTokens.None);

            return xDocument;
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
    }
}
