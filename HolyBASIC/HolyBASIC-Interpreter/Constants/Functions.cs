namespace Interpreter.Constants
{
    public class Functions
    {
        public const char Func_Arg_Start        = '(';
        public const char Func_Arg_End          = ')';
        public const char Func_Arg_Delimiter    = ',';

        public const string Func_Print          = "gprint";
        public const string Func_Listen_Key     = "glisten";
        public const string Func_Listen_Line    = "gread";

        public static string[] GetDefaultFunctions()
        {
            return new[] { Func_Print, Func_Listen_Key, Func_Listen_Line };
        }
    }
}
