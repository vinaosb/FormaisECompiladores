using System;
using System.Collections.Generic;

namespace Trabalho1 {
	public class Automato {
        public int ID = 0;
		public string estadoInicial = "";
		public HashSet<string> estadosFinais = new HashSet<string>();
		public Dictionary<string[],Transicao> transicoes = new Dictionary<string[], Transicao>();
        public HashSet<string> estados = new HashSet<string>();
        public HashSet<string> simbolos = new HashSet<string>();

		public class Transicao {
			public string estado1 = "";
			public string simbolo = "";
			public HashSet<string> estado2 = new HashSet<string>();

            public Transicao()
            {

            }
		}

		public Automato (int id) {
            ID = id;
		}

        public Automato (int id, Automato a) : this(id)
        {
            this.simbolos.UnionWith(a.simbolos);
            this.estados.UnionWith(a.estados);
            this.estadoInicial = a.estadoInicial;
            this.estadosFinais.UnionWith(a.estadosFinais);

            foreach (var t in a.transicoes)
            {
                transicoes.Add(t.Key,t.Value);
            }
        }
        
        public void addEstado(string e)
        {
            if (e.Contains("+"))
                estadoInicial = e.Split('+')[1];
            if (e.Contains("*") && !estadosFinais.Contains(e.Split('*')[1]))
                estadosFinais.Add(e.Split('*')[1]);
            char[] delimiter = {'+', '*' };
            if (e.Contains("+") | e.Contains("*"))
                e = e.Split(delimiter)[1];
            if (!estados.Contains(e))
                estados.Add(e);
        }

        public Transicao GeraTransicao (string e1, string s, HashSet<string> e2)
        {
            Transicao t = new Transicao();
            string[] temp = { e1, s };
            if (transicoes.ContainsKey(temp))
                transicoes.TryGetValue(temp, out t);
            char[] delimiter = {'*','+' };
            if (e1.Contains("*") | e1.Contains("+"))
                e1 = e1.Split(delimiter)[1];
            t.estado1 = e1;
            t.simbolo = s;
            foreach (string e in e2)
            {
                if (e.Contains("*") | e.Contains("+"))
                {
                    t.estado2.Add(e.Split(delimiter)[1]);
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
            if (estados.Contains(t.estado1) & simbolos.Contains(t.simbolo) & estados.IsSupersetOf(t.estado2))
            {
                string[] temp = {t.estado1, t.simbolo };
                transicoes.Add(temp, t);
            }
        }

        public void addTransicao(string e1, string s, HashSet<string> e2)
        {
            Transicao t = GeraTransicao(e1, s, e2);
            if (estados.Contains(t.estado1) & simbolos.Contains(t.simbolo) & estados.IsSupersetOf(t.estado2))
            {
                string[] temp = { t.estado1, t.simbolo };
                transicoes.Add(temp, t);
            }
        }

        public void addSimbolo(string s)
        {
            if (!simbolos.Contains(s))
                simbolos.Add(s);
        }

        public Transicao GetTransicao(string estado, string simbolo)
        {
            Transicao t = new Transicao();
            string[] temp = { estado, simbolo };

            if (transicoes.ContainsKey(temp))
                transicoes.TryGetValue(temp, out t);

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
            Automato r = new Automato(this.ID * a2.ID, this);
            
            r.estadosFinais.UnionWith(a2.estadosFinais);
            r.simbolos.UnionWith(a2.simbolos);

            foreach (var tra in a2.transicoes)
            {
                r.addTransicao(tra.Value);
            }

            r.addEstado("+Uniao");
            var temp = new HashSet<string>();
            temp.Add(a2.estadoInicial);
            temp.Add(this.estadoInicial);
            r.addTransicao("+Uniao", "&", temp);
            return r;
        }

        public Automato Interseccao (Automato a2)
        {
            Automato r = new Automato(this.ID * a2.ID, this);
            r.simbolos.UnionWith(a2.simbolos);
            r.estados.UnionWith(a2.estados);

            foreach (var tra in a2.transicoes)
            {
                r.addTransicao(tra.Value);
            }

            HashSet<string> temp = new HashSet<string>();
            temp.Add(a2.estadoInicial);

            foreach (var ef in r.estadosFinais)
            {
                r.addTransicao(ef, "&", temp);
            }

            r.estadosFinais.Clear();
            r.estadosFinais.UnionWith(a2.estadosFinais);

            return r;
        }

        public Automato Minimizacao(Automato automato)
        {
            Automato miniAuto = new Automato(this.ID+1);
            miniAuto.estadoInicial = automato.estadoInicial;
            miniAuto.simbolos = automato.simbolos;

            miniAuto = eliminaEstadosInalcancaveis(automato, miniAuto, automato.estadoInicial);
            miniAuto = eliminaEstadosMortos(miniAuto);

            //eliminateEqStates(miniAuto);
            return miniAuto;
        }
        public Automato eliminaEstadosInalcancaveis(Automato automato, Automato miniAuto, string estado)
        {
            foreach (var s in automato.simbolos)
            {
                var temp = automato.GetTransicao(estado, s).estado2;
                foreach (var e in temp)
                {
                    miniAuto.addEstado(e);
                    miniAuto.addTransicao(estado, s, temp);
                    eliminaEstadosInalcancaveis(automato,miniAuto,e);
                }
            }
            return miniAuto;   
        }
        public Automato eliminaEstadosMortos(Automato automato)
        {
            return automato;
        }
    }
}