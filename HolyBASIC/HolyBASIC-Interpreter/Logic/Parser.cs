using System;
using System.Linq;
using System.Threading.Tasks;

using Interpreter.Entities;
using Interpreter.Defaults;

namespace Interpreter.Logic
{
    public class Parser
    {
        public static async Task ParseAsync(object[] Tokens)
        {
            foreach (object _obj in Tokens)
            {
                if ((Function)_obj != null)
                {
                    Function _f = (Function)_obj;
                    if (_f.Name == Functions.AvailableFunctions[0])
                        await Console.Out.WriteLineAsync((string)_f.Arguments.Last());
                    if (_f.Name == Functions.AvailableFunctions[1])
                        Console.ReadKey();
                }
            }
        }
    }
}
