using System;


namespace R5T.L0030
{
    public class SaveOptionSets : ISaveOptionSets
    {
        #region Infrastructure

        public static ISaveOptionSets Instance { get; } = new SaveOptionSets();


        private SaveOptionSets()
        {
        }

        #endregion
    }
}
