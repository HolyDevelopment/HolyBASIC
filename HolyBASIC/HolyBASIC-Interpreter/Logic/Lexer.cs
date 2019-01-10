using System;
using System.Collections.Generic;
using System.Linq;

using Interpreter.Entities;
using Interpreter.Globals;

namespace Interpreter.Logic
{
    public class Lexer
    {
        public static object[] Analyze(string[] _data, bool _useNumberSystem = true)
        {
            if (_data[0].StartsWith("_USENUMBERSYS "))
                switch (_data[0].Substring("_USENUMBERSYS ".Length))
                {
                    case "1":
                        _useNumberSystem = true;
                        break;
                    case "0":
                        _useNumberSystem = false;
                        break;
                    default:
                        break;
                }

            // sorting stuff

            if (_useNumberSystem == true)
                _data = _data.ToList().OrderBy(x => int.Parse(x.Split(' ')[0])).ToArray();

            // oh boy this is gonna be a clusterfuck

            List<object> Objects = new List<object>();
            if (!Objects.Contains(Runtime.DefinedVariables))
                Objects.Add(Runtime.DefinedVariables);

            foreach (string _line in _data)
            {
                Variable _v = null;
                Function _f = null;

                bool _sBool = false;
                string _sValue = null;

                int _vLevel = 0;
                int _fLevel = 0;

                string _tokenStr = "";

                foreach (char _char in _line)
                {
                    if (_vLevel == 1 && _char == ' ')
                    {
                        _v.Name = _tokenStr;
                        _vLevel++;
                    }

                    _tokenStr += _char;

                    if (_tokenStr == "HOLY ")
                    {
                        _vLevel = 1;
                        _v = new Variable(null, null);
                    }

                    if (Defaults.DefaultFunctions.Contains(_tokenStr))
                    {
                        _fLevel = 1;
                        _f = new Function(_tokenStr, null);
                    }

                    if (_vLevel == 2 && _char == '=')
                        _vLevel++;

                    if (_char == '\"' && _sBool == true)
                    {
                        _sValue = _tokenStr;
                        _sBool = false;
                        if (_vLevel == 3)
                        {
                            _v.Object = _sValue.Substring(1, _sValue.Length - 2);
                            _vLevel = 0;
                        }

                        if (_fLevel == 1)
                        {
                            _f.Arguments = new[] { _sValue.Substring(1, _sValue.Length - 2) };
                            _fLevel = 0;
                        }
                    }

                    if (Runtime.DefinedVariables.Where(x => x.Name == _tokenStr).Count() > 0)
                    {
                        if (_fLevel == 1)
                        {
                            _f.Arguments = new[] { new Variable(_tokenStr, new object(), true) };
                            _fLevel = 0;
                        }
                    }

                    if (_char == '\"' && _sBool == false)
                        _sBool = true;

                    if (_char == ' ' && _sBool == false)
                        _tokenStr = "";
                }

                if (_v != null)
                    Objects.Add(_v);

                if (_f != null)
                    Objects.Add(_f);
            }

            // it literally is a clusterfuck

            return Objects.ToArray();
        }
    }
}
