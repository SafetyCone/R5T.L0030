using System;
using System.Threading.Tasks;


namespace R5T.L0030.Construction
{
    class Program
    {
        static async Task Main()
        {
            await Demonstrations.Instance.Write_Empty();
            //await Demonstrations.Instance.Load_Example01();
        }
    }
}