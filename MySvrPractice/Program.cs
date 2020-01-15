using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Kernel kernel = new Kernel();
            kernel.Init();
            kernel.RunTickAsync();
            bool isLoop = true;
            while (isLoop)
            {
                isLoop = kernel.GetInput();
            }
        }
    }
}
