using System;

namespace Fr.eCampusPlus.Engine.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            
            if (args != null)
            {

                var step = int.Parse(args[0]);
                var genUrl = string.Empty;
                if (args.Length == 2)
                {
                    genUrl = args[0];
                }
                TestDataReader.RunTest(step,genUrl);
            }            
        }
    }
}
