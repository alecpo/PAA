using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace trabalho
{
    public class Dinamico
    {
        public List<Output> Start(List<Input> listInput)
        {
            List<Output> listOutput = new List<Output>();

            foreach (var input in listInput)
            {
                Output output = new Output();

                int custo = 0;

                for (int i = 0; i < input.dias; i++)
                {
                               
                }

                listOutput.Add(output);
            }

            return listOutput;
        }
    }
}
