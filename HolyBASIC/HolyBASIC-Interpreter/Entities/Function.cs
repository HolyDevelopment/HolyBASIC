namespace Interpreter.Entities
{
    public class Function
    {
        public string Name;
        public object[] Arguments;

        public Function(string _fn, params object[] _args)
        {
            Name = _fn;
            Arguments = _args;
        }
    }
}
