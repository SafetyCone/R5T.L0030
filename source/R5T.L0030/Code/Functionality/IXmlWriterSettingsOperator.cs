using System;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

using R5T.T0132;


namespace R5T.L0030
{
    [FunctionalityMarker]
    public partial interface IXmlWriterSettingsOperator : IFunctionalityMarker
    {
        public Task DescibeTo(
            XmlWriterSettings settings,
            TextWriter writer)
        {
            var text = this.DescribeTo_Text(settings);

            return writer.WriteAsync(text);
        }

        public void DescibeTo_Synchronous(
            XmlWriterSettings settings,
            TextWriter writer)
        {
            var text = this.DescribeTo_Text(settings);

            writer.Write(text);
        }

        public void DescibeTo_Console_Synchronous(XmlWriterSettings settings)
        {
            this.DescibeTo_Synchronous(
                settings,
                Console.Out);
        }

        public string DescribeTo_Text(XmlWriterSettings settings)
        {
            var indentCharacters = Instances.CharacterOperator.DisplayCharacters(
                settings.IndentChars);

            var newLineCharacters = Instances.CharacterOperator.DisplayCharacters(
                settings.NewLineChars);

            var lines = Instances.EnumerableOperator.From(
                $"{settings.Async}: Asynchronous",
                $"{settings.CheckCharacters}: Check characters",
                $"{settings.CloseOutput}: Close output",
                $"{settings.ConformanceLevel}: Conformance level",
                $"{settings.DoNotEscapeUriAttributes}: Do not escape URI attributes",
                $"{settings.Encoding.EncodingName}: Encoding",
                $"{settings.Indent}: Indent",
                $"{indentCharacters}: Indent characters",
                $"{settings.NamespaceHandling}: Namespace handling",
                $"{newLineCharacters}: New-line characters",
                $"{settings.NewLineHandling}: New-line handling",
                $"{settings.NewLineOnAttributes}: New-line on attributes",
                $"{settings.OmitXmlDeclaration}: Omit XML declaration",
                $"{settings.OutputMethod}: Output method",
                $"{settings.WriteEndDocumentOnClose}: Write end-of-document on close"
            );

            var text = Instances.TextOperator.JoinLines(lines);
            return text;
        }

        /// <summary>
        /// Implements by-value equality check for the XML writer settings type.
        /// </summary>
        /// <remarks>
        /// The XML writer settings type (<inheritdoc cref="XmlWriterSettings"/>) is a reference type, and it has no equality operator overloads.
        /// Thus, it uses the default object equality operation (by-reference).
        /// </remarks>
        public bool Equals_ByValue(
            XmlWriterSettings settings1,
            XmlWriterSettings settings2)
        {
            var output = true
                && settings1.Async == settings2.Async
                && settings1.CheckCharacters == settings2.CheckCharacters
                && settings1.CloseOutput == settings2.CloseOutput
                && settings1.ConformanceLevel == settings2.ConformanceLevel
                && settings1.DoNotEscapeUriAttributes == settings2.DoNotEscapeUriAttributes
                && settings1.Encoding == settings2.Encoding
                && settings1.Indent == settings2.Indent
                && settings1.IndentChars == settings2.IndentChars
                && settings1.NamespaceHandling == settings2.NamespaceHandling
                && settings1.NewLineChars == settings2.NewLineChars
                && settings1.NewLineHandling == settings2.NewLineHandling
                && settings1.NewLineOnAttributes == settings2.NewLineOnAttributes
                && settings1.OmitXmlDeclaration == settings2.OmitXmlDeclaration
                && settings1.OutputMethod == settings2.OutputMethod
                && settings1.WriteEndDocumentOnClose == settings2.WriteEndDocumentOnClose
                ;

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Equals_ByValue(XmlWriterSettings, XmlWriterSettings)"/> as the default.
        /// <para><inheritdoc cref="Equals_ByValue(XmlWriterSettings, XmlWriterSettings)" path="/summary"/></para>
        /// </summary>
        public bool Equals(
            XmlWriterSettings settings1,
            XmlWriterSettings settings2)
        {
            var output = this.Equals_ByValue(
                settings1,
                settings2);

            return output;
        }

        /// <summary>
        /// Asynchronous is the default.
        /// <inheritdoc cref="Set_Standard_Synchronous(XmlWriterSettings)" path="/summary"/>
        /// </summary>
        public void Set_Standard(XmlWriterSettings settings)
        {
            // Asynchonous.
            settings.Async = true;

            this.Set_Standard_Synchronous(settings);
        }

        /// <summary>
        /// Standard values include:
        /// <list type="bullet">
        /// <item>Indent, true</item>
        /// <item>OmitXmlDeclaration, true</item>
        /// </list>
        /// <para><inheritdoc cref="Documentation.NoteOnAsynchronousSettings" path="/summary"/></para>
        /// </summary>
        public void Set_Standard_Synchronous(XmlWriterSettings settings)
        {
            // Indent.
            settings.Indent = true;

            // Omit declaration.
            settings.OmitXmlDeclaration = true;
        }
    }
}
