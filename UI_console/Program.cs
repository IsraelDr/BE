using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_console
{
    class Program
    {
        static MyBL bl = new MyBL();
        static void Main(string[] args)
        {
            int input;
            Console.WriteLine("Input any number: 0-exit,1-add child,2-addMother");
            input = int.Parse(Console.ReadLine());
            do
            {
                switch (input)
                {
                    case 1:
                        bl.addChild(new Child(1, 3, "Test", "12/05/1994", true));
                        break;
                    case 2:
                        bl.addMother(new Mother());
                        break;
                    default:
                        break;
                };
                Console.WriteLine("Input any number: 0-exit,1-add child");
                input = int.Parse(Console.ReadLine());
            } while (input != 0);

        }
    }
}
