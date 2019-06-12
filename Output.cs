using System;
using System.Collections.Generic;
using System.Text;

namespace trabalho
{
    public class Output
    {
        public Output()
        {
            pratos = new List<int>();
            lucro = 0;
        }
        public int lucro { get; set; }

        public List<int> pratos { get; set; }
    }
}
