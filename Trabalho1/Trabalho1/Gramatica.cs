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
            public char Atual;
            public List<string> Proximos;
        }

        public HashSet<char> SimbolosTerminais = new HashSet<char>();
        public HashSet<char> SimbolosNaoTerminais = new HashSet<char>();
        public Dictionary<char,Regular> Producoes = new Dictionary<char,Regular>();
		public char Inicial;

        public Gramatica()
        {
			Random random = new Random();         
			this.ID = random.Next(0,2000).ToString();
            Inicial = '\0';
        }

        public Gramatica (string ID)
        {
            this.ID = ID;
            Inicial = '\0';
        }

        public Gramatica (Automato a)
        {
            foreach (var e in a.estados)
                foreach (var s in e.ToCharArray())
                    SimbolosNaoTerminais.Add(s);
            foreach (var s in a.simbolos)
                foreach (var c in s.ToCharArray())
                    SimbolosTerminais.Add(c);
            Inicial = a.estadoInicial.ToCharArray()[0];

            foreach (var trans in a.transicoes)
            {
                foreach (var tra in trans.Value.estado2)
                {
                    Regular temp;
                    temp.Atual = trans.Value.estado1.ToArray()[0];
                    temp.Proximos = new List<string>();
                    temp.Proximos.Add(trans.Value.simbolo + tra);

                    if (a.estadosFinais.Contains(tra))
                    {
                        Regular temp2;
                        temp2.Atual = trans.Value.estado1.ToCharArray()[0];
                        temp2.Proximos = new List<string>();
                        temp2.Proximos.Add(trans.Key.simbolo);
                        AddProducao(temp2);
                    }
                }
            }
            
        }

        private void AddSimboloNaoTerminal(char s)
        {
			if (!SimbolosNaoTerminais.Contains(s)) {
                SimbolosNaoTerminais.Add(s);
			}
        }

        private void AddSimboloTerminal (char s)
        {
            if (!SimbolosTerminais.Contains(s))
                SimbolosTerminais.Add(s);
        }

        public void AddProducao (Regular p)
        {
            if (!Producoes.ContainsKey(p.Atual))
            {
                if (Inicial.Equals('\0'))
                    Inicial = p.Atual;

                if (SimbolosTerminais.Contains(p.Atual))
                    SimbolosTerminais.Remove(p.Atual);

                AddSimboloNaoTerminal(p.Atual);

                foreach (var next in p.Proximos)
                {
                    foreach (var chara in next.ToCharArray())
                    {
                        if (!SimbolosNaoTerminais.Contains(chara))
                        {
                            AddSimboloTerminal(chara);
                        }
                    }
                }
                Producoes.Add(p.Atual,p);
            }
            else
            {
                Regular temp;
                Producoes.TryGetValue(p.Atual, out temp);

                temp.Proximos.Union(p.Proximos);

                Producoes.Remove(p.Atual);
                Producoes.Add(p.Atual, temp);
            }
            
        }

		public Automato GetAutomato() {
			Automato ret = new Automato();
            Random rand = new Random();

            string novo = rand.Next(100).ToString();

            foreach (var NT in SimbolosNaoTerminais)
            {
                ret.addEstado(NT.ToString());
            }
            ret.addEstado(novo);

            ret.estadoInicial = Inicial.ToString();

            foreach (var T in SimbolosTerminais)
            {
                ret.simbolos.Add(T.ToString());
            }
            

            foreach (var Pr in Producoes)
            {
                foreach (var P in Pr.Value.Proximos)
                {

                    string nt = "";
                    string t = "";

                    foreach (var NT in SimbolosNaoTerminais)
                    {
                        if (P.Contains(NT))
                        {
                            nt += NT;
                        }
                    }
                    foreach (var T in SimbolosTerminais)
                    {
                        if (P.Contains(T))
                        {
                            t += T;
                        }
                    }

                    if (nt.Length != 0 && t.Length != 0)
                    {
                        foreach(var c in t)
                            ret.addTransicao(Pr.Key.ToString(), nt, c.ToString());
                    }
                    else if (nt.Length != 0)
                    {
                        ret.addTransicao(Pr.Key.ToString(), nt, novo);
                    }
                }
                
            }

            return ret;
		}
        
    }
}
