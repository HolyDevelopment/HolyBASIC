using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter.Entities
{
    public class Extern
    {
        public string FunctionName;
        public string Function;

        public Extern(string _fName, string _func)
        {
            FunctionName = _fName;
            Function = _func;
        }
    }
}
