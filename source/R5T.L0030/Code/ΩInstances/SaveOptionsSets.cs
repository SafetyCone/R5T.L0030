using System;


namespace R5T.L0030
{
    public class SaveOptionsSets : ISaveOptionsSets
    {
        #region Infrastructure

        public static ISaveOptionsSets Instance { get; } = new SaveOptionsSets();


        private SaveOptionsSets()
        {
        }

        #endregion
    }
}
