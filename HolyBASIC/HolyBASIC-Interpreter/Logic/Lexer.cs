using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Interpreter.Entities;
using Interpreter.Constants;

namespace Interpreter.Logic
{
    public class Lexer
    {
        public static object[] Analyze(string[] _data)
        {
            List<object> Objects = new List<object>();

            foreach (string _line in _data)
            {
                if (_line.StartsWith(Miscellaneous.Comment))
                    continue;

                string _variableRegex = $"{Variables.Var_Initializer} (.*?) {Variables.Var_Equals}";
                string _stringRegex = $"{Variables.Str_Quote}(.*?){Variables.Str_Quote}";
                string _functionRegex = @"^(.*)\((.*)\)";

                if (Regex.IsMatch(_line, _variableRegex))
                {
                    Match _m = Regex.Match(_line, _variableRegex);

                    string _varName = _m.Groups[1].Value;
                    
                    if (Regex.IsMatch(_m.Groups[1].Value, @"/^\S*$/"))
                        throw new Exception("variable name contains spaces!");

                    string _paramStr = _line.Substring(_m.Value.Count()).TrimStart();
                    object _param = null;

                    if (Regex.IsMatch(_paramStr, _stringRegex))
                    {
                        _param = Utils.AppendCharEscapes(Regex.Match(_paramStr, _stringRegex).Groups[1].Value);
                    }

                    Objects.Add(new Variable(_varName, _param));
                } else if (Regex.IsMatch(_line, _functionRegex))
                {
                    Match _m = Regex.Match(_line, _functionRegex);

                    string _funcName = _m.Groups[1].Value;

                    if (Regex.IsMatch(_m.Groups[1].Value, @"/^\S*$/"))
                        throw new Exception("variable name contains spaces!");

                    string[] _funcArgsStr = _m.Groups[2].Value.Split(Functions.Func_Arg_Delimiter, StringSplitOptions.RemoveEmptyEntries);

                    List<object> _funcArgs = new List<object>();
                    foreach (string _funcArgStr in _funcArgsStr)
                    {
                        if (Regex.IsMatch(_funcArgStr.Trim(), _stringRegex))
                        {
                            _funcArgs.Add(Utils.AppendCharEscapes(Regex.Match(_funcArgStr, _stringRegex).Groups[1].ToString()));
                        }

                        Variable _v = (Variable)Objects.Where(x => x.GetType() == typeof(Variable) && ((Variable)x).Name == _funcArgStr.Trim()).FirstOrDefault();
                        if (_v != null)
                            _funcArgs.Add(_v);
                    }

                    Objects.Add(new Function(_funcName, _funcArgs.ToArray()));
                }
            }

            return Objects.ToArray();
        }
    }
}
