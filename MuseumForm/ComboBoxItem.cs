using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumForm
{
    public class ComboboxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public double doubleValue { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
