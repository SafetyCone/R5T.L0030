using System;

using R5T.T0131;
using R5T.T0180;
using R5T.T0180.Extensions;


namespace R5T.L0030.Z000
{
    [ValuesMarker]
    public partial interface IRelativeFilePaths : IValuesMarker
    {
        /// <summary>
        /// A CSPROJ file with a PropertyGroup and several ItemGroups.
        /// </summary>
        public IRelativeFilePath Example01Xml => "Files/R5T.L0030.Z000/Example01.xml".ToRelativeFilePath();
    }
}
