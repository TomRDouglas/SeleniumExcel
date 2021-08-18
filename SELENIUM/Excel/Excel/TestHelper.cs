using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Excel
{
    class TestHelper
    {
        public static void Pause(int secondInPause =3000)
        { //TestHelper.Pause(3000);
            Thread.Sleep(secondInPause);      
        }
        
    }
}
