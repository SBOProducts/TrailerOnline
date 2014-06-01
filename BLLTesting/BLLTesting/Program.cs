using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLTesting
{
    class Program
    {
        static void Main(string[] args)
        {

            EmailTesting email = new EmailTesting();
            email.Run();

            Console.ReadLine();

        }
    }
}
