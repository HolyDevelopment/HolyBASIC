namespace Interpreter.Entities
{
    public class Function
    {
        public string Name;
        public object ReturnType;
        public object[] Arguments;
        public object[] Actions;
        
        public Function(string _fn, object[] _args, object[] _acts = null, object _rt = null)
        {
            Name = _fn;
            ReturnType = _rt;
            Arguments = _args;
            Actions = _acts;
        }
    }
}
