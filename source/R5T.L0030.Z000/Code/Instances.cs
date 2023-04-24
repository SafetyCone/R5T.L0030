using System;


namespace R5T.L0030.Z000
{
    public static class Instances
    {
        public static F0120.IExecutableFileRelativePathOperator ExecutableFileRelativePathOperator => F0120.ExecutableFileRelativePathOperator.Instance;
        public static IFilePaths FilePaths => Z000.FilePaths.Instance;
        public static IRelativeFilePaths RelativeFilePaths => Z000.RelativeFilePaths.Instance;
        public static IXDocumentOperator XDocumentOperator => L0030.XDocumentOperator.Instance;
    }
}