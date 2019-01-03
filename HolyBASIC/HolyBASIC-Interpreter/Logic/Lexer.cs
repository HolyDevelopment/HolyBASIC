using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Interpreter.Entities;
using Interpreter.Defaults;

namespace Interpreter.Logic
{
    public class Lexer
    {
        public static object[] AnalyzeMultiple(string _data)
        {
            List<string> Code = _data.Split('\n').ToList();

            // sorting stuff

            for (int x = Code.Count - 1; x > 0; x--)
                for (int y = Code.Count - 1; y > 0; y--)
                {
                    int _lnumberx = Convert.ToInt32(Code[x].Split(' ')[0]);
                    int _lnumbery = Convert.ToInt32(Code[y].Split(' ')[0]);

                    if (_lnumberx > _lnumbery)
                    {
                        string _nx = Code[x];
                        string _ny = Code[y];
                        Code[x] = _ny;
                        Code[y] = _nx;
                    }
                }

            // oh boy this is gonna be a clusterfuck

            List<object> Objects = new List<object>();

            foreach (string _line in Code)
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
                    _tokenStr += _char;

                    if (_tokenStr == "HOLY")
                    {
                        _vLevel = 1;
                        _v = new Variable(null, null);
                    }

                    if (Functions.AvailableFunctions.Contains(_tokenStr))
                    {
                        _fLevel = 1;
                        _f = new Function(_tokenStr, null);
                    }

                    if (_vLevel == 1 && _char == ' ')
                    {
                        _v.Name = _tokenStr;
                        _vLevel++;
                    }

                    if (_vLevel == 2 && _char == '=')
                        _vLevel++;

                    if (_char == '\"' && _sBool == true)
                    {
                        _sValue = _tokenStr;
                        _sBool = false;
                        if (_vLevel == 3)
                        {
                            _v.Object = _sValue;
                            _vLevel = 0;
                        }

                        if (_fLevel == 1)
                        {
                            _f.Arguments = new[] { _sValue.Substring(1, _sValue.Length - 2) };
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
