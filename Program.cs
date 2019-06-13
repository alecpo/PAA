using System;
using System.Collections.Generic;
using System.Linq;

namespace trabalho
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Input> listInput = new List<Input>();
            const string breakCase = "0 0 0";

            Console.WriteLine("Informe: {dias} {quantidade de pratos} {orcamento}");
            string line = Console.ReadLine();
            
            //Ler os dados do consle ate comando de saida
            while (line != breakCase)
            {
                try
                {
                    Input input = new Input();

                    input.dias = Convert.ToInt32(line.Split(" ")[0]);
                    input.quantidadePratos = Convert.ToInt32(line.Split(" ")[1]);
                    input.orcamento = Convert.ToInt32(line.Split(" ")[2]);

                    for (int i = 0; i < input.quantidadePratos; i++)
                    {
                        Console.WriteLine("Informe o prato " + (i + 1) + ": {custo} {lucro}");
                        line = Console.ReadLine();

                        Prato pratos = new Prato();

                        pratos.custo = Convert.ToInt32(line.Split(" ")[0]);
                        pratos.lucro = Convert.ToInt32(line.Split(" ")[1]);

                        input.Pratos.Add(pratos);
                    }

                    listInput.Add(input);

                    Console.WriteLine("Informe: {dias} {quantidade de pratos} {orcamento}");
                    line = Console.ReadLine();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("PADRAO ERRADO: Tente novamente. (Input descosiderado)");
                }
              
            }

            Guloso guloso = new Guloso();
            //Dinamico dinamico = new Dinamico();

            //Solução gulosa
            List<Output> outputGuloso = guloso.Start(listInput);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("###########################  SOLUCAO GULOSA  ###########################");
            Print(outputGuloso);

           /* Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            List<Output> outputDinamica = dinamico.Start(listInput);
            Console.WriteLine("###########################  SOLUCAO DINAMICA ###########################");
            Print(outputDinamica);*/ 
        }

        private static void Print(List<Output> listOut)
        {
            foreach (var item in listOut)
            {
                Console.WriteLine(item.lucro);

                //if(item.pratos.Count != 0){
                    foreach (var prato in item.pratos)
                        Console.Write(prato + "  ");
                //}
                Console.WriteLine();
                if(item.pratos.IndexOf(-1) != -1){
                    Console.WriteLine("O algoritmo guloso nao conseguiu encontrar uma soluçao.");
                }
                Console.WriteLine();
            }
        }
    }
}
