using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1
{
    public class Gramatica
    {
        public string ID;

        public struct Regular
        {
            public string Atual;
            public List<string> Proximos;
        }

        public HashSet<string> SimbolosTerminais = new HashSet<string>();
        public HaseSet<string> SimbolosNaoTerminais = new HashSet<string>();
        public List<Regular> Producoes = new List<Regular>();
		public string Inicial = "";

        public Gramatica()
        {
			Random random = new Random();         
			this.ID = random.Next(0,2000);
        }

        public Gramatica (string ID)
        {
            this.ID = ID;
        }

        public void AddSimboloNaoTerminal(string s)
        {
			if (!SimbolosTerminais.Contains(s)) {
				
			}
        }

        public void AddProducao (Regular p)
        {
			if (Inicial.Equals(p.Atual))
			{
				Inicial = p.Atual;
			}

			AddSimbolo(p.Atual);

            foreach (var s in p.Proximos)
            {
                AddSimbolo(s);
            }

            Producoes.Add(p);
        }

		public Automato GetAutomato() {
			Automato ret = new Automato(ID);

			foreach (var simb in SimbolosIntermediarios)
			{

			}
		}
    }
}
