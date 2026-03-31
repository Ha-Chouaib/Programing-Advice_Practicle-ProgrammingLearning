using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAPIBusinessLayer
{
    public sealed class clsCryptography
    {
        public static string PassowrdBcyptHashing(string input)
        {
            return BCrypt.Net.BCrypt.HashPassword(input);
        }
    }
}
