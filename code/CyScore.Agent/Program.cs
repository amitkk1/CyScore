using System;

namespace CyScore.Agent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool hasAntiVirus = Policies.AntivirusInstalled();
            Console.WriteLine(hasAntiVirus);
        }
    }
}
