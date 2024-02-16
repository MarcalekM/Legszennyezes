using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legszennyezes
{
    internal class Day
    {
        public List<int> _orak;

        public Day(string sor)
        {
            var v = sor.Split(';').ToList();
            _orak = new();
            foreach (var v2 in v) _orak.Add(int.Parse(v2));
        }

        public override string ToString()
        {
            string text = string.Empty;
            for (int i = 0; i < _orak.Count; i++)
            {
                text += _orak[i].ToString();
                if (i < _orak.Count) text += ", ";
            }
            return text;
        }
    }
}
