using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2
{
    internal class Card
    {
        public string Model     { get; private set; }
        public string Hex       { get; private set; }
        public string Facility  { get; private set; }
        public string Number    { get; private set; }

        internal Card(string model, string hex, string fac, string number)
        {
            Model = model;
            Hex = hex;
            Facility = fac;
            Number = number;
        }

        public override string ToString()
        {
            return Model + " " + Hex + " " + Facility + " " + Number;
        }
    }
}
