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
                        foreach (object _o in _f.Arguments)
                        {
                            if (_o.GetType() == typeof(string))
                                Console.Write(_o.ToString());
                            if (_o.GetType() == typeof(char))
                                Console.Write(_o.ToString());
                            if (_o.GetType() == typeof(Variable))
                                Console.Write(((Variable)_o).Object);
                        }
                    }

                    if (_f.Name == Functions.Func_Listen_Key)
                    {
                        if (_f.Arguments.Length < 1)
                        {
                            Console.ReadKey();
                        } else
                        {
                            ((Variable)Tokens[
                                Tokens.ToList().FindIndex(x => x.GetType() == typeof(Variable) && ((Variable)x) == _f.Arguments[0])
                                ]).Object = Console.ReadKey();
                        }
                    }

                    if (_f.Name == Functions.Func_Listen_Line)
                    {
                        if (_f.Arguments.Length < 1)
                        {
                            Console.ReadLine();
                        }
                        else
                        {
                            ((Variable)Tokens[
                                Tokens.ToList().FindIndex(x => x.GetType() == typeof(Variable) && ((Variable)x) == _f.Arguments[0])
                                ]).Object = Console.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
