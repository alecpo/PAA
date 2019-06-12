using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace trabalho
{
    public class Guloso
    {

        /// <summary>
        /// Na solução golusa, nao deixamos um prato repetir seguidamente
        /// </summary>
        /// <param name="listInput"></param>
        /// <returns>List<Output></returns>
        public List<Output> Start(List<Input> listInput)
        {
            List<Output> listOutput = new List<Output>();

            foreach (var input in listInput)
            {
                Output output = new Output();
                int custo = 0, idPratoAtual = 0;
                Prato pratoAtual = null;

                //Ordena decresente a lista de pratos para de acordo com o os que apresentam melhores lucros
                //Os primeiros pratos, são os que mais dão lucro
                input.Pratos = input.Pratos.OrderByDescending(c => c.lucro).ToList();

                /*foreach (var item in listInput){
                    Console.WriteLine(item.dias + " " + item.quantidadePratos + " " + item.orcamento);
                    foreach (var prato in item.Pratos){
                        Console.WriteLine(prato.custo + " " + prato.lucro);
                    }
                }*/
                
                
                //Percorre todos os dias para esse input
                for (int i = 0; i < input.dias; i++)
                {
                    pratoAtual = input.Pratos[idPratoAtual];
                    
                    //enquanto n tiver orçamento verifica proximo prato
                    while(((custo + pratoAtual.custo) > input.orcamento) && (idPratoAtual < input.quantidadePratos-1)){
                        idPratoAtual++;
                        pratoAtual = input.Pratos[idPratoAtual];
                    }
                    if(idPratoAtual + 1 == input.quantidadePratos){//se nao tiver solução por falta de orçamento
                                                               //retorna lucro 0 e pratos -1
                        output.lucro = 0;
                        output.pratos.Add(-1);
                        listOutput.Add(output);
                        return listOutput;
                    }
                    //se repetir prato pela 3ª vez, não tem lucro
                    if( (i>=2) && (input.Pratos[idPratoAtual-2] == input.Pratos[idPratoAtual]))
                        {
                            output.lucro -= pratoAtual.custo;//sem lucro = prejuiso do custo
                            Console.WriteLine("id: " + idPratoAtual + " Lucro: " + pratoAtual.lucro);
                            Console.WriteLine();
                        }
                    else//se repetir prato pela 2ª vez, o lucro é metade.
                        if( (i>=1) && (input.Pratos[idPratoAtual-1] == input.Pratos[idPratoAtual]))
                            {
                                output.lucro += pratoAtual.lucro/2;
                                Console.WriteLine("id: " + idPratoAtual + " Lucro: " + pratoAtual.lucro);
                                Console.WriteLine();                                
                            }
                        else
                            {
                                output.lucro += pratoAtual.lucro;
                                Console.WriteLine("id: " + idPratoAtual + " Lucro: " + pratoAtual.lucro);
                                Console.WriteLine();                                    
                            }
                    output.pratos.Add(idPratoAtual);
                    custo += pratoAtual.custo;

                    //tenho orçamento para repetir o prato?
                    if((custo + pratoAtual.custo) > input.orcamento)
                        idPratoAtual ++; //se não tiver, analisa o prox prato.
                    else//vai igualar ao orçamento mas vai faltar dia?
                        if((custo + pratoAtual.custo) == input.orcamento && i < input.dias -1)
                            idPratoAtual ++; //se faltar dia, analisa o prox prato.
                    //é viável repetir o prato?
                    if(pratoAtual.lucro/2 < input.Pratos[idPratoAtual+1].lucro)
                        idPratoAtual ++; //se não for, analisa o prox prato
                    
                    if((idPratoAtual>=1) && (input.Pratos[idPratoAtual-1] == input.Pratos[idPratoAtual]))
                        idPratoAtual = 0;
                    
                }

                listOutput.Add(output);
            }

            return listOutput;
        }
    }
}
