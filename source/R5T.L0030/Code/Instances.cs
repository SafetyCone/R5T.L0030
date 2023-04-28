using System;


namespace R5T.L0030
{
    public static class Instances
    {
        public static F0000.ICancellationTokens CancellationTokens => F0000.CancellationTokens.Instance;
        public static F0000.IFileOperator FileOperator => F0000.FileOperator.Instance;
        public static F0000.IFileStreamOperator FileStreamOperator => F0000.FileStreamOperator.Instance;
        public static F0000.IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static F0000.INullOperator NullOperator => F0000.NullOperator.Instance;
        public static IValues Values => L0030.Values.Instance;
        public static IXAttributeOperator XAttributeOperator => L0030.XAttributeOperator.Instance;
        public static IXContainerOperator XContainerOperator => L0030.XContainerOperator.Instance;
        public static IXDocumentOperator XDocumentOperator => L0030.XDocumentOperator.Instance;
        public static IXElementOperator XElementOperator => L0030.XElementOperator.Instance;
        public static F0000.IXmlOperator XmlOperator_F0000 => F0000.XmlOperator.Instance;
        public static IXmlOperator XmlOperator => L0030.XmlOperator.Instance;
        public static IXmlWriterSettingsOperator XmlWriterSettingsOperator => L0030.XmlWriterSettingsOperator.Instance;
    }
}