using System;
using System.Threading.Tasks;

using R5T.T0141;
using R5T.T0181.Extensions;


namespace R5T.L0030.Construction
{
    /// <summary>
    /// XML demonstrations.
    /// </summary>
    [DemonstrationsMarker]
    public partial interface IDemonstrations : IDemonstrationsMarker
    {
        /// <summary>
        /// Load the <see cref="Z000.IFilePaths.Example01"/> XML file.
        /// </summary>
        /// <returns></returns>
        public async Task Load_Example01()
        {
            /// Run.
            // While acting as a value, this actually loads the example XML file.
            var example01 = await Instances.XmlDocuments.Example01;

            Console.WriteLine(example01);
        }

        /// <summary>
        /// Write an empty XML file.
        /// <para>
        /// Shows that an empty file <em>can</em> be written.
        /// This is actually a technical feat, since a new XDocument <em>cannot</em> actually be written (since to be a correct XML document, it would need a root element).
        /// </para>
        /// </summary>
        public async Task Write_Empty()
        {
            /// Inputs.
            var outputFilePath = Instances.FilePaths.OutputXmlFilePath.ToXmlFilePath();


            /// Run.
            var empty = Instances.XmlDocuments.Empty;

            await Instances.XmlOperator.Save(
                outputFilePath,
                empty);

            Instances.NotepadPlusPlusOperator.Open(
                outputFilePath.Value);
        }
    }
}
