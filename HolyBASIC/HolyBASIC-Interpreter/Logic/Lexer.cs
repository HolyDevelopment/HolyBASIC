using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Interpreter.Entities;
using Interpreter.Globals;

namespace Interpreter.Logic
{
    public class Lexer
    {
        public static object[] Analyze(string[] _data)
        {
            List<object> Objects = new List<object>();

            foreach (string _line in _data)
            {
                string _variableRegex = @"HOLY (.*?) =";
                string _stringRegex = "\"(.*?)\"";
                
                if (Regex.IsMatch(_line, _variableRegex))
                {
                    Match _m = Regex.Match(_line, _variableRegex);

                    string _varName = _m.Groups[1].Value;
                    
                    if (Regex.IsMatch(_m.Groups[1].Value, @"/^\S*$/"))
                        throw new Exception("variable name contains spaces!");

                    string _paramStr = _line.Substring(_m.Value.Count() + 1);
                    object _param = null;

                    if (Regex.IsMatch(_paramStr, _stringRegex))
                    {
                        _param = Regex.Match(_paramStr, _stringRegex).Groups[1].Value;
                    }

                    Objects.Add(new Variable(_varName, _param));
                }

                if (Defaults.DefaultFunctions.Where(x => _line.StartsWith($"{x} ")).Count() > 0)
                {
                    string _fName = Defaults.DefaultFunctions.Where(x => _line.StartsWith(x)).FirstOrDefault();

                    List<object> _params = new List<object>();
                    foreach (string _paramStr in _line.Substring(_fName.Length + 1).Split(','))
                    {
                        Variable _posVar = (Variable)Objects.Where(x => x.GetType() == typeof(Variable) && ((Variable)x).Name == _paramStr).FirstOrDefault();

                        if (_posVar != null)
                            _params.Add(_posVar);
                        else if (Regex.IsMatch(_paramStr, _stringRegex))
                            _params.Add(Regex.Match(_paramStr, _stringRegex).Groups[1].Value);
                    }

                    Function _f = new Function(_fName, _params.ToArray());
                    Objects.Add(_f);
                } else if (Defaults.DefaultFunctions.Where(x => _line.StartsWith($"{x}")).Count() > 0)
                {
                    string _fName = Defaults.DefaultFunctions.Where(x => _line.StartsWith(x)).FirstOrDefault();
                    Function _f = new Function(_fName, new object[] { });
                    Objects.Add(_f);
                }
            }

            return Objects.ToArray();
        }
    }
}
