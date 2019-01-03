namespace Interpreter.Entities
{
    public class Variable
    {
        public string Name;
        public object Object;

        public Variable(string _vn, object _obj)
        {
            Name = _vn;
            Object = _obj;
        }
    }
}
