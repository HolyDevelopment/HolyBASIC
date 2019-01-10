using Interpreter.Entities;
using System.Collections.Generic;

namespace Interpreter.Globals
{
    public static class Defaults
    {
        public static string[] DefaultFunctions = new[] { "GODSAY", "GODLISTEN", "LISTENPRAYER" };
    }

    public static class Runtime
    {
        public static List<Variable> DefinedVariables = new List<Variable>();
    }
}
