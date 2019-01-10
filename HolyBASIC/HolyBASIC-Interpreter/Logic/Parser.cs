using System;
using System.Linq;
using System.Threading.Tasks;

using Interpreter.Entities;
using Interpreter.Globals;

namespace Interpreter.Logic
{
    public class Parser
    {
        public static async Task ParseAsync(object[] Tokens)
        {
            foreach (object _obj in Tokens)
            {
                if (_obj.GetType() == typeof(Variable))
                {
                    Variable _v = (Variable)_obj;
                    // await Console.Out.WriteLineAsync($"Found variable! {_v.Name} {_v.Object}");
                    Runtime.DefinedVariables.Add(_v);
                }

                if (_obj.GetType() == typeof(Function))
                {
                    Function _f = (Function)_obj;

                    if (_f.Name == Defaults.DefaultFunctions[0])
                    {
                        if (_f.Arguments.Last().GetType() == typeof(Variable))
                        {
                            Variable _v = (Variable)_f.Arguments.Last();
                            if (_v.Fetch == true)
                            {
                                _v = Runtime.DefinedVariables.Where(x => x.Name == _v.Name).FirstOrDefault();
                                await Console.Out.WriteLineAsync((string)_v.Object);
                            }
                        } else 
                        {
                            await Console.Out.WriteLineAsync((string)_f.Arguments.Last());
                        }
                    }

                    if (_f.Name == Defaults.DefaultFunctions[1])
                    {
                        if (_f.Arguments.Last().GetType() == typeof(Variable))
                        {
                            Variable _v = (Variable)_f.Arguments.Last();
                            if (_v.Fetch == true)
                            {
                                Runtime.DefinedVariables.Where(x => x.Name == _v.Name).FirstOrDefault().Object = Console.ReadKey().KeyChar;
                            }
                        } else
                        {
                            Console.ReadKey();
                        }
                    }

                    if (_f.Name == Defaults.DefaultFunctions[2])
                    {
                        if (_f.Arguments.Last().GetType() == typeof(Variable))
                        {
                            Variable _v = (Variable)_f.Arguments.Last();
                            if (_v.Fetch == true)
                            {
                                Runtime.DefinedVariables.Where(x => x.Name == _v.Name).FirstOrDefault().Object = Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
