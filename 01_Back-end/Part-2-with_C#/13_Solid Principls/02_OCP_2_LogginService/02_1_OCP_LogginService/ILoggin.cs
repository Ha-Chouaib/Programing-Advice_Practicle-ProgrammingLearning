using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_1_OCP_LogginService
{
    public interface ILoggin
    {
        public void Log(string message);
    }
}
