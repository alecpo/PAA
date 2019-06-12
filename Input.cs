using System;
using System.Collections.Generic;
using System.Text;

namespace trabalho
{
    public class Input
    {
        public Input()
        {
            Pratos = new List<Prato>();
        }

        public int dias { get; set; }

        public int quantidadePratos { get; set; }

        public int orcamento { get; set; }

        public List<Prato> Pratos { get; set; }
    }

    public class Prato
    {
        public int custo { get; set; }

        public int lucro { get; set; }

        public int receita { get { return custo + lucro; } }
    }
}
