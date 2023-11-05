using System;


namespace R5T.L0030
{
    public class LoadOptionsSets : ILoadOptionsSets
    {
        #region Infrastructure

        public static ILoadOptionsSets Instance { get; } = new LoadOptionsSets();


        private LoadOptionsSets()
        {
        }

        #endregion
    }
}
