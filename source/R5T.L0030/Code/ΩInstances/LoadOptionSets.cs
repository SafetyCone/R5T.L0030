using System;


namespace R5T.L0030
{
    public class LoadOptionSets : ILoadOptionSets
    {
        #region Infrastructure

        public static ILoadOptionSets Instance { get; } = new LoadOptionSets();


        private LoadOptionSets()
        {
        }

        #endregion
    }
}
