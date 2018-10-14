using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1
{
    class MainTest
    {
        public static void Main(string[] args)
        {
            //string text = "+1234";
            //text = text.Replace("5", "");
            //Console.WriteLine(text);
            ExpressaoRegular exp = new ExpressaoRegular("(a|b)*.(b|c).#");
            Automato auto = exp.transformaERemAFD();
            Console.WriteLine("Execução OK!");

            //Automato automato = new Automato(1);
            //automato.addEstado("A");
            //automato.addEstado("B");
            //automato.addSimbolo("a");
            //automato.addTransicao("A", "a", "B");
            //foreach (var k in automato.transicoes.Keys)
            //{
            //    Console.WriteLine("k[0]={0}", k[0]);
            //    Console.WriteLine("k[1]={0}", k[1]);
            //}
            //var t = automato.GetTransicao("A", "a");
            //if (t.estado1 == "")
            //    Console.WriteLine("Estado Vazio");
            //if (t.simbolo == "")
            //    Console.WriteLine("Simbolo Vazio");
            //foreach (var e in t.estado2)
            //    Console.WriteLine("estado {0}", e);
        }
    }
}
