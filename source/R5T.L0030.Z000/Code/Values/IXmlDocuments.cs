using System;
using System.Threading.Tasks;
using System.Xml.Linq;

using R5T.T0131;


namespace R5T.L0030.Z000
{
    [ValuesMarker]
    public partial interface IXmlDocuments : IValuesMarker
    {
        /// <summary>
        /// An empty document.
        /// </summary>
        public XDocument Empty => Instances.XDocumentOperator.New_Empty();

        /// <inheritdoc cref="IFilePaths.Example01"/>
        public Task<XDocument> Example01 => Instances.XDocumentOperator.Load(
            Instances.FilePaths.Example01);
    }
}
