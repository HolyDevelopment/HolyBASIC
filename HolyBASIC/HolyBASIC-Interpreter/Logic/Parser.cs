using System;
using System.Linq;
using System.Threading.Tasks;

using Interpreter.Entities;
using Interpreter.Globals;

namespace Interpreter.Logic
{
    public class Parser
    {
        public static void Parse(object[] Tokens)
        {
            foreach (object _obj in Tokens)
            {
                if (_obj.GetType() == typeof(Variable))
                {
                    Variable _v = (Variable)_obj;
                }

                if (_obj.GetType() == typeof(Function))
                {
                    Function _f = (Function)_obj;

                    if (_f.Name == Defaults.DefaultFunctions[0])
                    {
                        if (_f.Arguments.Last().GetType() == typeof(Variable))
                        {
                            Variable _v = (Variable)_f.Arguments.Last();
                            Console.WriteLine((string)_v.Object);
                        } else 
                        {
                            Console.WriteLine((string)_f.Arguments.Last());
                        }
                    }

                    if (_f.Name == Defaults.DefaultFunctions[1])
                    {
                        Console.ReadKey();
                    }

                    if (_f.Name == Defaults.DefaultFunctions[2])
                    {
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
