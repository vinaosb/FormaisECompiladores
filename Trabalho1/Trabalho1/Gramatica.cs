﻿using System;
using System.Collections.Generic;
using System.Linq;

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
        public Dictionary<char, Regular> Producoes = new Dictionary<char, Regular>();
        public char Inicial;

        public Gramatica()
        {
            Random random = new Random();
            ID = random.Next(0, 2000).ToString();
            Inicial = '\0';
        }

        public Gramatica(string ID)
        {
            this.ID = ID;
            Inicial = '\0';
        }

        public Gramatica(Automato a)
        {
            foreach (string e in a.estados)
            {
                foreach (char s in e.ToCharArray())
                {
                    SimbolosNaoTerminais.Add(s);
                }
            }

            foreach (string s in a.simbolos)
            {
                foreach (char c in s.ToCharArray())
                {
                    SimbolosTerminais.Add(c);
                }
            }

            Inicial = a.estadoInicial.ToCharArray()[0];

            foreach (KeyValuePair<Automato.KeyTransicao, Automato.Transicao> trans in a.transicoes)
            {
                foreach (string tra in trans.Value.estado2)
                {
                    Regular temp;
                    temp.Atual = trans.Value.estado1.ToArray()[0];
                    temp.Proximos = new List<string>();

                    if (a.estadosFinais.Contains(tra))
                    {
                        temp.Proximos.Add(trans.Key.simbolo);
                    }
                    else
                    {
                        temp.Proximos.Add(trans.Key.simbolo + tra);
                    }

                    AddProducao(temp);
                }
            }

        }

        private void AddSimboloNaoTerminal(char s)
        {
            if (!SimbolosNaoTerminais.Contains(s))
            {
                SimbolosNaoTerminais.Add(s);
            }
        }

        private void AddSimboloTerminal(char s)
        {
            if (!SimbolosTerminais.Contains(s))
            {
                SimbolosTerminais.Add(s);
            }
        }

        public void AddProducao(Regular p)
        {
            if (!Producoes.ContainsKey(p.Atual))
            {
                if (Inicial.Equals('\0'))
                {
                    Inicial = p.Atual;
                }

                if (SimbolosTerminais.Contains(p.Atual))
                {
                    SimbolosTerminais.Remove(p.Atual);
                }

                AddSimboloNaoTerminal(p.Atual);

                foreach (string next in p.Proximos)
                {
                    foreach (char chara in next.ToCharArray())
                    {
                        if (!SimbolosNaoTerminais.Contains(chara))
                        {
                            AddSimboloTerminal(chara);
                        }
                    }
                }
                Producoes.Add(p.Atual, p);
            }
            else
            {
                Producoes.TryGetValue(p.Atual, out Regular temp);

                foreach (var prox in p.Proximos)
                {
                    if (!temp.Proximos.Contains(prox))
                        temp.Proximos.Add(prox);
                }

                Producoes.Remove(p.Atual);
                Producoes.Add(p.Atual, temp);
            }

        }

        public Automato GetAutomato()
        {
            Automato ret = new Automato();
            Random rand = new Random();

            string novo = rand.Next(100).ToString();

            foreach (char NT in SimbolosNaoTerminais)
            {
                ret.addEstado(NT.ToString());
            }
            ret.addEstado(novo);

            ret.estadoInicial = Inicial.ToString();

            foreach (char T in SimbolosTerminais)
            {
                ret.simbolos.Add(T.ToString());
            }

            ret.estadosFinais.Add(novo);



            foreach (KeyValuePair<char, Regular> Pr in Producoes)
            {
                foreach (string P in Pr.Value.Proximos)
                {

                    string nt = "";
                    string t = "";

                    foreach (char NT in SimbolosNaoTerminais)
                    {
                        if (P.Contains(NT))
                        {
                            nt += NT;
                        }
                    }
                    foreach (char T in SimbolosTerminais)
                    {
                        if (P.Contains(T))
                        {
                            t += T;
                        }
                    }

                    if (nt.Length != 0 && t.Length != 0)
                    {
                        foreach (char c in t)
                        {
                            ret.addTransicao(Pr.Key.ToString(), c.ToString(), nt);
                        }
                    }
                    else if (nt.Length == 0)
                    {
                        foreach (char c in t)
                        {
                            ret.addTransicao(Pr.Key.ToString(), c.ToString(), novo);
                        }
                    }
                }

            }

            return ret;
        }

        public void showGR()
        {
            foreach (var P in Producoes)
            {
                foreach (var Prox in P.Value.Proximos)
                {
                    Console.WriteLine("{0} -> {1}",P.Value.Atual, Prox);
                }
            }
        }

    }
}
