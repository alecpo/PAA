using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace trabalho
{
    public class Dinamico
    {
        /// <param name="listInput"></param>
        /// <returns>List<Output></returns>
        public List<Output> Start(List<Input> listInput)
        {
            List<Output> listOutput = new List<Output>();

            foreach (var input in listInput)
            {
                Output output = new Output();
                
                //Ordena decresente a lista de pratos para de acordo com o os que apresentam menores custos
                //Os primeiros pratos, são os que possuem menor custo
                input.Pratos = input.Pratos.OrderBy(c => c.custo).ToList();
                float[,] Tabela = new float[input.quantidadePratos, input.orcamento + 1];
                
                //Preenchimento da primeira linha
                for(int j = 0; j < Tabela.GetLength(1); j++){
                    if(j < input.Pratos[0].custo)
                        Tabela[0,j] = 0;
                    else
                        Tabela[0,j] = Tabela[0,j-input.Pratos[0].custo] + input.Pratos[0].lucro;
                }
                for(int i = 1; i < Tabela.GetLength(0); i++){
                    for(int j = 0; j < Tabela.GetLength(1); j++){
                        if(j < input.Pratos[i].custo)
                            Tabela[i,j] = Tabela[i-1,j];
                        else
                            Tabela[i,j] = Math.Max(Tabela[i-1,j],Tabela[i,j - input.Pratos[i].custo] + input.Pratos[i].lucro);
                    }
                }

                printTable(Tabela);
                /* int custo = 0;

                for (int i = 0; i < input.dias; i++)
                {
                               
                }

                listOutput.Add(output);*/
            }

            return listOutput;
        }

        static void printTable(float [,] Tabela) {
            for(int j = 0; j < Tabela.GetLength(1); j++){
                Console.Write(j + "\t");
            }

            Console.WriteLine();

            for(int i = 0; i < Tabela.GetLength(0); i++){
                for(int j = 0; j < Tabela.GetLength(1); j++){
                    Console.Write(Tabela[i,j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
