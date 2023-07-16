using System;

using R5T.T0131;
using R5T.T0181;
using R5T.T0181.Extensions;

namespace R5T.L0030.Z000
{
    [ValuesMarker]
    public partial interface IFilePaths : IValuesMarker
    {
        /// <inheritdoc cref="IRelativeFilePaths.Example01Xml"/>
        public IXmlFilePath Example01 => Instances.ExecutableFileRelativePathOperator.Get_FilePath(
            Instances.RelativeFilePaths.Example01Xml)
            .AsXmlFilePath();
    }
}
