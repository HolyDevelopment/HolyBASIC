using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Interpreter.Constants;
using Interpreter.Entities;

namespace Interpreter.Logic
{
    public class Utils
    {
        public static string AppendCharEscapes(string text)
        {
            return text
                .Replace("\\a", "\a")
                .Replace("\\b", "\b")
                .Replace("\\t", "\t")
                .Replace("\\r", "\r")
                .Replace("\\v", "\v")
                .Replace("\\f", "\f")
                .Replace("\\n", "\n");
        }

        public static object DeserializeValue(string _param, object[] _vars)
        {
            string _stringRegex = $"{Variables.Str_Quote}(.*?){Variables.Str_Quote}";
            string _charRegex = $"{Variables.Char_Quote}(.*?){Variables.Char_Quote}";

            if (Regex.IsMatch(_param, _stringRegex))
                return AppendCharEscapes(Regex.Match(_param, _stringRegex).Groups[1].ToString());
            else if (Regex.IsMatch(_param, _charRegex))
                return Convert.ToChar(AppendCharEscapes(Regex.Match(_param, _charRegex).Groups[1].ToString()));
            else if (_vars.Where(x => ((Variable)x).Name == _param).Count() > 0)
                return _vars.Where(x => ((Variable)x).Name == _param).FirstOrDefault();
            else
                return null;
        }
    }
}
