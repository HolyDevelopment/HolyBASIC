namespace Interpreter.Entities
{
    public class Variable
    {
        public string Name;
        public object Object;
        public bool Fetch;

        public Variable(string _vn, object _obj, bool _fetch = false)
        {
            Name = _vn;
            Object = _obj;
            Fetch = _fetch;
        }
    }
}
