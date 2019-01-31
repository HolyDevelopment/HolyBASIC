using System;
using System.Linq;

using Interpreter.Entities;
using Interpreter.Constants;

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

                    if (_f.Name == Functions.Func_Print)
                    {
                        foreach (string _str in _f.Arguments.Where(x => x.GetType() == typeof(string)))
                        {
                            Console.Write(_str);
                        }

                        foreach (Variable _var in _f.Arguments.Where(x => x.GetType() == typeof(Variable)))
                        {
                            Console.Write((string)_var.Object);
                        }
                    }

                    if (_f.Name == Functions.Func_Listen_Key)
                    {
                        Console.ReadKey();
                    }

                    if (_f.Name == Functions.Func_Listen_Line)
                    {
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
