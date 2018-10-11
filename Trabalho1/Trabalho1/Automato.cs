using System;
using System.Collections.Generic;

namespace Trabalho1
{
    public class Automato
    {
        public int ID = 0;
        public string estadoInicial = "";
        public HashSet<string> estadosFinais = new HashSet<string>();
        public Dictionary<KeyTransicao, Transicao> transicoes = new Dictionary<KeyTransicao, Transicao>();
        public HashSet<string> estados = new HashSet<string>();
        public HashSet<string> simbolos = new HashSet<string>();

        public class Transicao
        {
            public string estado1 = "";
            public string simbolo = "";
            public HashSet<string> estado2 = new HashSet<string>();

            public Transicao()
            {

            }
        }

        public struct KeyTransicao
        {
            public string estado;
            public string simbolo;

            public KeyTransicao(string e1, string s)
            {
                estado = e1;
                simbolo = s;
            }
        }

		public Automato() {
			ID = (new Random()).Next(0,2000);
		}

        public Automato(int id)
        {
            ID = id;
        }

        public Automato(int id, Automato a) : this(id)
        {
            simbolos.UnionWith(a.simbolos);
            estados.UnionWith(a.estados);
            estadoInicial = a.estadoInicial;
            estadosFinais.UnionWith(a.estadosFinais);

            foreach (var t in a.transicoes)
            {
                transicoes.Add(t.Key, t.Value);
            }
        }

        public void addEstado(string e)
        {
            if (e.Contains("+"))
            {
                estadoInicial = e.Split('+')[1];
                estadoInicial = estadoInicial.Replace("*", "");
            }

            if (e.Contains("*") && !estadosFinais.Contains(e.Split('*')[1]))
            {
                estadosFinais.Add(e.Split('*')[1]);
            }
            
            //char[] delimiter = { '+', '*' };
            if (e.Contains("+") || e.Contains("*"))
            {
                //e = e.Split(delimiter)[1];
                e = e.Replace("*", "");
                e = e.Replace("+", "");
            }

            if (!estados.Contains(e))
            {
                estados.Add(e);
            }
        }

        public Transicao GeraTransicao(string e1, string s, string e2)
        {
            Transicao t = new Transicao();
            KeyTransicao temp = new KeyTransicao( e1, s );
            if (transicoes.ContainsKey(temp))
            {
                transicoes.TryGetValue(temp, out t);
            }

            //char[] delimiter = { '*', '+' };
            if (e1.Contains("*") || e1.Contains("+"))
            {
                //e1 = e1.Split(delimiter)[1];
                e1 = e1.Replace("*", "");
                e1 = e1.Replace("+", "");
            }

            t.estado1 = e1;
            t.simbolo = s;
            if (!t.estado2.Contains(e2))
            {
                if (e2.Contains("*") || e2.Contains("+"))
                {
                    //t.estado2.Add(e2.Split(delimiter)[1]);
                    string aux = e2;
                    aux = aux.Replace("*", "");
                    aux = aux.Replace("+", "");
                    t.estado2.Add(aux);
                }
                else
                {
                    t.estado2.Add(e2);
                }
            }

            return t;
        }

        public Transicao GeraTransicao(string e1, string s, HashSet<string> e2)
        {
            Transicao t = new Transicao();
            KeyTransicao temp = new KeyTransicao (e1, s);
            if (transicoes.ContainsKey(temp))
            {
                transicoes.TryGetValue(temp, out t);
            }

            //char[] delimiter = { '*', '+' };
            if (e1.Contains("*") || e1.Contains("+"))
            {
                // e1 = e1.Split(delimiter)[1];
                e1 = e1.Replace("*", "");
                e1 = e1.Replace("+", "");
            }

            t.estado1 = e1;
            t.simbolo = s;
            foreach (string e in e2)
            {
                if (e.Contains("*") || e.Contains("+"))
                {
                    //t.estado2.Add(e.Split(delimiter)[1]);
                    string aux = e;
                    aux = aux.Replace("*", "");
                    aux = aux.Replace("+", "");
                    t.estado2.Add(aux);
                }
                else
                {
                    t.estado2.Add(e);
                }
            }

            return t;
        }

        public void addTransicao(Transicao t)
        {
            Transicao te = new Transicao();
            if (estados.Contains(t.estado1) & simbolos.Contains(t.simbolo) & estados.IsSupersetOf(t.estado2))
            {
                KeyTransicao temp = new KeyTransicao(t.estado1, t.simbolo );
                if (!transicoes.ContainsKey(temp))
                {
                    transicoes.Add(temp, t);
                }
                else
                {
                    transicoes.TryGetValue(temp, out te);
                    foreach (string item in t.estado2)
                    {
                        if (!te.estado2.Contains(item))
                        {
                            te.estado2.Add(item);
                        }
                    }
                }

            }
        }
        public void addTransicao(string e1, string s, string e2)
        {
            Transicao t = GeraTransicao(e1, s, e2);
            Transicao te = new Transicao();
            if (estados.Contains(t.estado1) & simbolos.Contains(t.simbolo) & estados.IsSupersetOf(t.estado2))
            {
                KeyTransicao temp = new KeyTransicao (t.estado1, t.simbolo);
                if (!transicoes.ContainsKey(temp))
                {
                    transicoes.Add(temp, t);
                }
                else
                {
                    transicoes.TryGetValue(temp, out te);
                    foreach (string item in t.estado2)
                    {
                        if (!te.estado2.Contains(item))
                        {
                            te.estado2.Add(item);
                        }
                    }
                }
            }
        }

        public void addTransicao(string e1, string s, HashSet<string> e2)
        {
            Transicao t = GeraTransicao(e1, s, e2);
            Transicao te = new Transicao();
            if (estados.Contains(t.estado1) & simbolos.Contains(t.simbolo) & estados.IsSupersetOf(t.estado2))
            {
                KeyTransicao temp = new KeyTransicao(t.estado1, t.simbolo);
                if (!transicoes.ContainsKey(temp))
                {
                    transicoes.Add(temp, t);
                }
                else
                {
                    transicoes.TryGetValue(temp, out te);
                    foreach (string item in t.estado2)
                    {
                        if (!te.estado2.Contains(item))
                        {
                            te.estado2.Add(item);
                        }
                    }
                }
            }
        }

        public void addSimbolo(string s)
        {
            if (!simbolos.Contains(s))
            {
                simbolos.Add(s);
            }
        }

        public Transicao GetTransicao(string estado, string simbolo)
        {
            Transicao t = new Transicao();
            KeyTransicao temp = new KeyTransicao(estado,simbolo);
            

            if (transicoes.ContainsKey(temp))
            {
                transicoes.TryGetValue(temp, out t);
            }

            return t;
        }

        public void Clear()
        {
            transicoes.Clear();
            estados.Clear();
            estadoInicial = "";
            estadosFinais.Clear();
            simbolos.Clear();
        }

        public Automato Uniao(Automato a2)
        {
            Automato r = new Automato(ID * a2.ID, this);

            r.estadosFinais.UnionWith(a2.estadosFinais);
            r.simbolos.UnionWith(a2.simbolos);
            r.simbolos.Add("&");

            foreach (var tra in a2.transicoes)
            {
                r.addTransicao(tra.Value);
            }

            r.addEstado("+Uniao");
            HashSet<string> temp = new HashSet<string>
            {
                a2.estadoInicial,
                estadoInicial
            };
            r.addTransicao("+Uniao", "&", temp);
            return r;
        }

        public Automato Interseccao(Automato a2)
        {
            Automato r = new Automato(ID * a2.ID, this);
            r.simbolos.UnionWith(a2.simbolos);
            r.estados.UnionWith(a2.estados);

            foreach (var tra in a2.transicoes)
            {
                r.addTransicao(tra.Value);
            }

            HashSet<string> temp = new HashSet<string>
            {
                a2.estadoInicial
            };

            foreach (string ef in r.estadosFinais)
            {
                r.addTransicao(ef, "&", temp);
            }

            r.estadosFinais.Clear();
            r.estadosFinais.UnionWith(a2.estadosFinais);

            return r;
        }

        public Automato Minimizacao(Automato automato, int ID)
        {
            Automato miniAuto = new Automato(ID)
            {
                estadoInicial = automato.estadoInicial,
                simbolos = automato.simbolos
            };

            miniAuto = eliminaEstadosInalcancaveis(automato, miniAuto, automato.estadoInicial);
            miniAuto = eliminaEstadosMortos(miniAuto);

            //eliminateEqStates(miniAuto);
            return miniAuto;
        }
        public Automato eliminaEstadosInalcancaveis(Automato automato, Automato miniAuto, string estado)
        {
            foreach (string s in automato.simbolos)
            {
                HashSet<string> temp = automato.GetTransicao(estado, s).estado2;
                foreach (string e in temp)
                {
                    miniAuto.addEstado(e);
                    miniAuto.addTransicao(estado, s, e);
                    eliminaEstadosInalcancaveis(automato, miniAuto, e);
                }
            }
            return miniAuto;
        }
        public Automato eliminaEstadosMortos(Automato automato)
        {
            List<string> temp = new List<string>();
            foreach (string e1 in automato.estados)
            {
                temp.Clear();
                foreach (string s in automato.simbolos)
                {
                    foreach (string t in automato.GetTransicao(e1, s).estado2)
                    {
                        if (!temp.Contains(t))
                        {
                            temp.Add(t);
                        }
                    }
                }
                if (temp.Contains(e1) & temp.Count == 1 & !automato.estadosFinais.Contains(e1))
                {
                    automato.estados.Remove(temp[0]);
                    foreach (string s in automato.simbolos)
                    {
                        KeyTransicao tra = new KeyTransicao(temp[0], s);
                        automato.transicoes.Remove(tra);
                    }
                }
            }
            return automato;
        }
        public void showAutomato(Automato automato)
        {
            System.Console.WriteLine("transicoes");
            foreach (var t in automato.transicoes)
            {
                foreach (var e in t.Value.estado2)
                {
                    KeyTransicao k = t.Key;
                    System.Console.WriteLine("{0}, {1} -> {2}", k.estado, k.simbolo, e);
                    //showAutomato(a, e2);
                }
            }
        }
    }
}