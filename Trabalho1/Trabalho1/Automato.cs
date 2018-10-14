using System;
using System.Collections;
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
        //Minimização, invoca os tres passos da Minimização de AFD:
        //1-Elimina Estados Inalcancaveis
        //2-Elimina Estados Mortos
        //3-Elimina Estados Equivalentes
        public Automato Minimizacao(Automato automato, int ID)
        {
            Automato miniAuto = new Automato(ID)
            {
                estadoInicial = automato.estadoInicial,                
                simbolos = automato.simbolos
            };
            miniAuto.addEstado(miniAuto.estadoInicial);
            miniAuto = eliminaEstadosInalcancaveis(automato, miniAuto, automato.estadoInicial);
            miniAuto = eliminaEstadosMortos(miniAuto);
            miniAuto = eliminaEstadosEquivalentes(miniAuto);

            return miniAuto;
        }
        public Automato eliminaEstadosInalcancaveis(Automato automato, Automato miniAuto, string estado)
        {
            foreach (string s in automato.simbolos)
            {
                HashSet<string> temp = automato.GetTransicao(estado, s).estado2;
                foreach (string e in temp)
                {
                    bool exists = miniAuto.estados.Contains(e);                                    
                    if (!exists)
                        miniAuto.addEstado(e);                        
                    miniAuto.addTransicao(estado, s, e);
                    if(!exists /*&& !miniAuto.estadoInicial.Contains(e)*/)
                        eliminaEstadosInalcancaveis(automato, miniAuto, e);
                }
            }
            return miniAuto;
        }
        //Metodo Elimina Estados Mortos.
        //Todo estado que não alcança un estado final é removido.
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
        //Metodo Elimina Estados Equivalentes.
        public Automato eliminaEstadosEquivalentes(Automato automato)
        {
           // System.Collections.Hashtable passos = new System.Collections.Hashtable();
            HashSet<HashSet<string>> classes = new HashSet<HashSet<string>>();
            HashSet<HashSet<string>> classesNovas = new HashSet<HashSet<string>>();
            classes.Add(automato.estadosFinais);
            HashSet<string> notFinals = new HashSet<string>(automato.estados);
            notFinals.SymmetricExceptWith(automato.estadosFinais);
            classes.Add(notFinals);
            bool novoPasso = true;
            while (novoPasso)
            {
                foreach (var e in automato.estados)
                {
                    alocaEstadoEmClasseNova(e, classesNovas, classes);
                }
                if (classes.Count == classesNovas.Count)
                    novoPasso = false;
                else
                    novoPasso = true;

                classes = new HashSet<HashSet<string>>(classesNovas);
                classesNovas.Clear();
            }

            //debug
            Console.WriteLine("classes");
            foreach (var c in classes)
            {                
                Console.Write("{");
                foreach(var e in c)
                {
                    Console.Write(e);
                }
                Console.Write("}");
                Console.WriteLine(".");
            }
            Automato newAuto = new Automato(5);
            newAuto.simbolos = automato.simbolos;
            Hashtable relEstadoClasse = new Hashtable();
            foreach (var c in classes)
            {
                string nomeEstado = "";
                foreach (var e in c)
                {
                    nomeEstado = nomeEstado + e;
                }
                foreach(var est in c)
                {
                    relEstadoClasse.Add(est, nomeEstado);
                }
                foreach(var f in estadosFinais)
                    if (c.Contains(f))
                    {
                        nomeEstado = "*" + nomeEstado;
                        break;
                    }
                if (c.Contains(automato.estadoInicial))
                    nomeEstado = "+" + nomeEstado;
                newAuto.addEstado(nomeEstado);
            }
            newAuto.criaTransicoes(classes, automato, relEstadoClasse);
            return newAuto;
        }
        //Cria Transições para o novo Automato resultante das classes de equivalencia.
        private void criaTransicoes(HashSet<HashSet<string>> classes, Automato automato, Hashtable rel)
        {
            foreach(var classe in classes)
            {
                foreach(var e in classe)
                {
                    foreach (var s in simbolos)
                    {
                        foreach(var e2 in automato.GetTransicao(e, s).estado2)
                        {
                            string origem = (string)rel[e];
                            string destino = (string)rel[e2];
                            addTransicao(origem, s, destino);
                        }
                    }
                    break;
                }
            }
        }
        //Passo do algoritmo de classes de equivalencia.
        //Verifica em que classe o estado se encaixa, caso contrario cria uma classe nova para o estado.
        private void alocaEstadoEmClasseNova(string e, HashSet<HashSet<string>> classesNovas, HashSet<HashSet<string>> classesAntigas)
        {
            bool newClass = true;
            foreach(var classe in classesNovas)
            {
                foreach(var estado in classe)
                {
                    if (mesmaClasseEquivalencia(e, estado, classesAntigas))
                    {
                        classe.Add(e);
                        newClass = false;
                    }
                    break; //Só precisa comparar com um estado da classe.
                }
            }
            if (newClass)
            {
                HashSet<string> novaCE = new HashSet<string>();
                novaCE.Add(e);
                classesNovas.Add(novaCE);
            }
        }
        //Verifica se dois estados estão na mesma classe de equivalência, de acordo as classes do passe anterior.
        private bool mesmaClasseEquivalencia(string estado1, string estado2, HashSet<HashSet<string>> classes)
        {
            bool mesmaClasse = false;
            foreach (var s in simbolos)
            {
                string destinoEstado1="", destinoEstado2="";
                HashSet<string> classeDoEstado1 = new HashSet<string>(), 
                    classeDoEstado2 = new HashSet<string>();
                HashSet<string> temp = GetTransicao(estado1, s).estado2;
                foreach (string e in temp)
                {
                    destinoEstado1 = e;
                }
                HashSet<string> temp2 = GetTransicao(estado2, s).estado2;
                foreach (string e in temp2)
                {
                    destinoEstado2 = e;
                }
                foreach(var classe in classes)
                {
                    if (classe.Contains(destinoEstado1))
                        classeDoEstado1 = new HashSet<string>(classe);
                    if (classe.Contains(destinoEstado2))
                        classeDoEstado2 = new HashSet<string>(classe);
                }
                if (classeDoEstado1.Count > 0 && classeDoEstado2.Count > 0)
                    if (classeDoEstado1.SetEquals(classeDoEstado2))
                        mesmaClasse = true;
                    else
                        return false;
            }
            return mesmaClasse;
        }
        //metodo para debugar o automato na caixa de saída.
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