using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
