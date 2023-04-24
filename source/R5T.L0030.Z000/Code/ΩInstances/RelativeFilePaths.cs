using System;


namespace R5T.L0030.Z000
{
    public class RelativeFilePaths : IRelativeFilePaths
    {
        #region Infrastructure

        public static IRelativeFilePaths Instance { get; } = new RelativeFilePaths();


        private RelativeFilePaths()
        {
        }

        #endregion
    }
}
