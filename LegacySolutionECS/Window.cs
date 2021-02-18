using System;
using System.Collections.Generic;
using System.Text;

namespace LegacySolutionECS
{
    public class Window: IWindow
    {
        public void open()
        {
            Console.WriteLine("Window is open\n");
        }

        public void close()
        {
            Console.WriteLine("Window is closed\n");
        }
    }
}
