using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BACnet_Lucid_Application.Tools
{
    class Decoder
    {
        //Tag number = 0 - Null
        //Tag number = 1 - Boolean
        //Tag number = 2 - Unsigned Integer
        //Tag number = 3 - Signed Integer
        //Tag number = 4 - Real (IEEE-754 floating point)
        public double IEEE_Real(long l)
        {
            //mantissa = 1 + 0.000000119209289550781 * bytenum
            return 0;
        }
        //Tag number = 5 - Double (IEEE-754 double precision point)
        public double IEEE_Double(long l)
        {
            //mantissa = 1 + 0.000000000000000868581956585908 * bytenum
            return 0;
        }

        //Tag number = 6 - Octet String
        //Tag number = 7 - Character String
        //Tag number = 8 - Bit String
    }










}
