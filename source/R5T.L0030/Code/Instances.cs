using System;


namespace R5T.L0030
{
    public static class Instances
    {
        public static F0000.ICancellationTokens CancellationTokens => F0000.CancellationTokens.Instance;
        public static F0000.ICharacterOperator CharacterOperator => F0000.CharacterOperator.Instance;
        public static F0000.IEnumerableOperator EnumerableOperator => F0000.EnumerableOperator.Instance;
        public static F0000.IFileOperator FileOperator => F0000.FileOperator.Instance;
        public static F0000.IFileStreamOperator FileStreamOperator => F0000.FileStreamOperator.Instance;
        public static F0000.IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static ILoadOptionsSets LoadOptionsSets => L0030.LoadOptionsSets.Instance;
        public static L0066.INullOperator NullOperator => L0066.NullOperator.Instance;
        public static F0000.IOrderOperator OrderOperator => F0000.OrderOperator.Instance;
        public static ISaveOptionsSets SaveOptionsSets => L0030.SaveOptionsSets.Instance;
        public static F0000.ITextOperator TextOperator => F0000.TextOperator.Instance;
        public static IValues Values => L0030.Values.Instance;
        public static IXAttributeOperator XAttributeOperator => L0030.XAttributeOperator.Instance;
        public static IXContainerOperator XContainerOperator => L0030.XContainerOperator.Instance;
        public static IXDocumentOperator XDocumentOperator => L0030.XDocumentOperator.Instance;
        public static IXElementOperator XElementOperator => L0030.XElementOperator.Instance;
        public static F0000.IXmlOperator XmlOperator_F0000 => F0000.XmlOperator.Instance;
        public static IXmlOperator XmlOperator => L0030.XmlOperator.Instance;
        public static L0053.IXmlWriterSettingsSet XmlWriterSettingsSet => L0053.XmlWriterSettingsSet.Instance;
        public static L0053.IXmlWriterSettingsOperator XmlWriterSettingsOperator => L0053.XmlWriterSettingsOperator.Instance;
        public static IXNodeOperator XNodeOperator => L0030.XNodeOperator.Instance;
        public static IXObjectOperator XObjectOperator => L0030.XObjectOperator.Instance;
    }
}