using System;


namespace R5T.L0030.Construction
{
    public static class Instances
    {
        public static Z0015.IFilePaths FilePaths => Z0015.FilePaths.Instance;
        public static F0033.INotepadPlusPlusOperator NotepadPlusPlusOperator => F0033.NotepadPlusPlusOperator.Instance;
        public static Z000.IXmlDocuments XmlDocuments => Z000.XmlDocuments.Instance;
        public static IXmlOperator XmlOperator => L0030.XmlOperator.Instance;
    }
}