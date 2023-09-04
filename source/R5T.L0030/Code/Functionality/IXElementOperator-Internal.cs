using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using R5T.T0132;
using R5T.T0181;


namespace R5T.L0030.Internal
{
    [FunctionalityMarker]
    public partial interface IXElementOperator : IFunctionalityMarker,
        F0000.IXElementOperator
    {
        /// <summary>
        /// Lame! XElement.Save() adds XML declaration! 
        /// </summary>
        public async Task Save(
            string xmlFilePath,
            XElement xElement,
            SaveOptions saveOptions = ISaveOptionSets.Default_Constant)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Write(xmlFilePath);

            await xElement.SaveAsync(
                fileStream,
                saveOptions,
                Instances.CancellationTokens.None);
        }

        /// <summary>
        /// Lame! XElement.Save() adds XML declaration! 
        /// </summary>
        public Task Save(
            IXmlFilePath xmlFilePath,
            XElement xElement,
            SaveOptions saveOptions = ISaveOptionSets.Default_Constant)
        {
            return this.Save(
                xmlFilePath,
                xElement,
                saveOptions);
        }

        /// <summary>
        /// Lame! XElement.Save() adds XML declaration! 
        /// </summary>
        public void WriteToWriter(
            XElement xElement,
            TextWriter textWriter,
            SaveOptions saveOptions = ISaveOptionSets.Default_Constant)
        {
            xElement.Save(
                textWriter,
                saveOptions);
        }

        /// <summary>
        /// Lame! XElement.Save() adds XML declaration! 
        /// </summary>
        public string WriteToString(
            XElement xElement,
            SaveOptions saveOptions = ISaveOptionSets.Default_Constant)
        {
            var stringBuilder = new StringBuilder();
            var writer = new StringWriter(stringBuilder);

            this.WriteToWriter(
                xElement,
                writer,
                saveOptions);

            var output = stringBuilder.ToString();
            return output;
        }
    }
}
