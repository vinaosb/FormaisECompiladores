using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1
{
	public class ExpressaoRegular
	{
		public string regex;
		public ArvoreSintatica arvore;
		public ExpressaoRegular(string text)
		{
			arvore = new ArvoreSintatica();
			regex = text;
		}
		public Automato transformaERemAFD()
		{
			Automato a = new Automato(1);

			createTree(); //Monta Arvore Sintatica
			readTree(); //Marca Indicadores Folha e cria Pilha com Nodos Internos
			arvore.copyStack(); //Duplica Pilha para os metodos seguintes
			arvore.calculaPrimeiraEUltimaPosicao(); //Preenche pri_pos, ult_pos e anulavel - esvazia pilha 1
			arvore.calculaTabelaPosicaoSeguinte(); // usa segunda pilha pra calcular posicao_seguinte
			showPosSeguinte();
			//fixPosSeguinteTable();
			a = montaAutomato();

			return a;
		}

		private Automato montaAutomato()
		{
			Automato automato = new Automato(1);
			Stack<HashSet<int>> stackEstados = new Stack<HashSet<int>>();
			automato.simbolos = arvore.simbolos;
			automato.simbolos.Remove("#");
			HashSet<int> estadoRaiz = arvore.raiz.primeira_posicao;
			string estado = geraNomeDoEstado(estadoRaiz);
			stackEstados.Push(estadoRaiz);
			automato.addEstado("+"+estado);            
			automato = geraEstados(automato, stackEstados);
			return automato;
		}

		private Automato geraEstados(Automato automato, Stack<HashSet<int>> stack)
		{
			HashSet<int> estado1, estado2 = new HashSet<int>();
			while(stack.Count() > 0){
				estado1 = stack.Pop();
				estado2.Clear();
				foreach (var simbol in arvore.simbolos.ToList())
				{
					foreach (var i in estado1.ToList())
					{
						if ((string)arvore.folhas[i] == simbol)
						if(arvore.posicao_seguinte.ContainsKey(i))
							estado2.UnionWith((HashSet<int>)arvore.posicao_seguinte[i]);
					}
					string nomeEstado1 = geraNomeDoEstado(estado1);
					string nomeEstado2 = geraNomeDoEstado(estado2);
					if (estado1.SetEquals(estado2))
					{
						automato.addTransicao(nomeEstado1, simbol, new HashSet<string>( new[] { geraNomeDoEstado(estado1) }));
					}
					else
					{
						automato.addEstado(nomeEstado2);
						stack.Push(estado2);
						automato.addTransicao(nomeEstado1, simbol, new HashSet<string>(new[] { geraNomeDoEstado(estado2) }));
					}
					estado2.Clear();
				}

			}
			return automato;
		}

		private string geraNomeDoEstado(HashSet<int> estado)
		{
			string nome = "";
			bool final = false;
			foreach(var i in estado)
			{
				//nome = nome + i.ToString() + ",";                
				nome = nome + i.ToString();
				if (i == arvore.indicadorFim)
				{
					final = true;
				}
			}
			//nome.Substring(0, nome.Length - 2);
			//nome = nome + "}";
			if (final)
				nome = "*" + nome;
			return nome;
		}
		//private void fixPosSeguinteTable()
		//{
		//    for (int i = 0; i < arvore.indicador; i++)
		//    {
		//        if (!arvore.posicao_seguinte.ContainsKey(i))
		//            arvore.posicao_seguinte.Add(i, "");
		//    }
		//}
		private void showPosSeguinte()
		{
			Console.WriteLine("enter");
			foreach (DictionaryEntry element in arvore.posicao_seguinte)
			{
				Console.WriteLine("cjeck");
				//obtém os valores da HashTable usando Key e Value
				int i = (int)element.Key;
				//HashSet<int> hash = (HashSet<int>)element.Value;
				string pos="";
				foreach (var v in (HashSet<int>)element.Value)
				{
					pos = pos +","+ v.ToString();
				}
				//exibe os valores da HashTable
				Console.WriteLine("i: {0}, pos: {1}", i, pos);
			}

		}

		public void createTree()
		{
			arvore.parseRegex(arvore.initialNodo(regex));
		}
		public String readTree()
		{
			return arvore.listTree();
		}
		public class ArvoreSintatica
		{
			public Nodo raiz = null;
			public int qtNodo = 0;
			public String result;
			public int indicador;
			public Stack<Nodo> NodosInternos = new Stack<Nodo>();
			public Stack<Nodo> NodosPosicaoSeguinte = new Stack<Nodo>();
			public Hashtable posicao_seguinte = new Hashtable();
			public Hashtable folhas = new Hashtable();
			public HashSet<string> simbolos = new HashSet<string>();
			public int indicadorFim;

			public class Nodo
			{
				public Nodo nodoPai = null;
				public Nodo nodoEsquerda = null;
				public Nodo nodoDireita = null;
				public string valor = "";
				public HashSet<int> primeira_posicao = new HashSet<int>();
				public HashSet<int> ultima_posicao = new HashSet<int>();
				internal bool anulavel;
			}

			public bool isLeaf(Nodo nodo)
			{
				return (nodo.nodoEsquerda == null && nodo.nodoDireita == null);
			}
			public Nodo createLeaf(Nodo nodo)
			{
				Nodo n = new Nodo();
				n.nodoPai = nodo;
				if (raiz == null)
					raiz = nodo;
				return n;
			}
			public void splitTerm(Nodo nodoOrigem, String termo, int pos)
			{
				Nodo folhaEsquerda = new Nodo();
				Nodo folhaDireita = new Nodo();
				folhaEsquerda = createLeaf(nodoOrigem);
				folhaEsquerda.valor = termo.Substring(0, pos);
				nodoOrigem.nodoEsquerda = folhaEsquerda;
				parseRegex(folhaEsquerda);
				if (nodoOrigem.valor != "*")
				{
					folhaDireita = createLeaf(nodoOrigem);
					folhaDireita.valor = termo.Substring(pos + 1);
					nodoOrigem.nodoDireita = folhaDireita;
					parseRegex(folhaDireita);
				}
			}
			public void parseRegex(Nodo nodoOrigem) {
				int indexBar = 0, indexConcat = 0;
				//Nodo newNodo = new Nodo();

				String termo = nodoOrigem.valor;
				termo = removeExternalParenthesis(termo);
				String novoTermo = ignoreBetweenParenthesis(termo);

				//int indexParenthesis = termo.IndexOf("(");
				indexConcat      = novoTermo.IndexOf(".");
				indexBar         = novoTermo.IndexOf("|");

				if(indexBar > 0)
				{
					nodoOrigem.valor = "|";
					splitTerm(nodoOrigem, termo, indexBar);
				}
				else if(indexConcat > 0)
				{
					nodoOrigem.valor = ".";
					splitTerm(nodoOrigem, termo, indexConcat);
				}
				else if (novoTermo.Contains("*"))
				{
					nodoOrigem.valor = "*";
					splitTerm(nodoOrigem, termo, novoTermo.IndexOf("*"));
				}


			}

			private string ignoreBetweenParenthesis(string termo)
			{
				String novoTermo = "";
				int openParenthesis = 0;
				foreach (var t in termo)
				{
					if (t == '(')
					{
						openParenthesis++;
						novoTermo = novoTermo + "@";
						continue;
					}
					if (openParenthesis > 0)
					{
						if (t == ')')
							openParenthesis--;
						novoTermo = novoTermo + "@";
						continue;
					}

					novoTermo = novoTermo + t;
				}
				return novoTermo;
			}

			public String removeExternalParenthesis(String text)
			{
				if (text.First() == '(' && text.Last() == ')')
					return text.Substring(1, text.Length - 2);
				return text;
			}
			public void readNodo(Nodo nodo)
			{
				if (isLeaf(nodo))
				{
					result = result + "{"+indicador+"}"+nodo.valor;
					if (nodo.valor == "&")
						nodo.anulavel = true;
					else
						nodo.anulavel = false;
					if (nodo.valor == "#")
						indicadorFim = indicador;
					nodo.primeira_posicao.Add(indicador);
					nodo.ultima_posicao.Add(indicador);
					folhas.Add(indicador, nodo.valor);
					simbolos.Add(nodo.valor);
					indicador++;
					return;
				}
				NodosInternos.Push(nodo);
				readNodo(nodo.nodoEsquerda);
				result = result  + nodo.valor;
				if (nodo.valor!="*")
					readNodo(nodo.nodoDireita);
			}
			public String listTree()
			{
				result = "";
				indicador = 1;
				readNodo(raiz);
				return result;
			}
			public void copyStack()
			{
				NodosPosicaoSeguinte = new Stack<Nodo>(NodosInternos.Reverse());
			}
			public Nodo initialNodo(String regex)
			{
				Nodo nodo = new Nodo();
				nodo.valor = regex;
				return nodo;
			}

			internal void calculaPrimeiraEUltimaPosicao()
			{
				Nodo auxNodo = new Nodo();
				while(NodosInternos.Count > 0)
				{
					auxNodo = NodosInternos.Pop();
					calculaAnulavel(auxNodo);
					calculaPrimeiraPos(auxNodo);
					calculaUltimaPos(auxNodo);
				}
			}
			public void calculaAnulavel(Nodo nodo)
			{
				switch (nodo.valor)
				{
				case "*":
					nodo.anulavel = true;
					break;
				case "|":
					nodo.anulavel = nodo.nodoEsquerda.anulavel || nodo.nodoDireita.anulavel;
					break;
				case ".":
					nodo.anulavel = nodo.nodoEsquerda.anulavel && nodo.nodoDireita.anulavel;
					break;
				}

			}
			public void calculaPrimeiraPos(Nodo nodo)
			{
				switch (nodo.valor)
				{
				case "*":
					nodo.primeira_posicao = nodo.nodoEsquerda.primeira_posicao;
					break;
				case "|":
					nodo.primeira_posicao = nodo.nodoEsquerda.primeira_posicao;
					nodo.primeira_posicao.UnionWith(nodo.nodoDireita.primeira_posicao);
					break;
				case ".":
					nodo.primeira_posicao = nodo.nodoEsquerda.primeira_posicao;
					if (nodo.nodoEsquerda.anulavel)
						nodo.primeira_posicao.UnionWith(nodo.nodoDireita.primeira_posicao);
					break;
				}
			}
			public void calculaUltimaPos(Nodo nodo)
			{
				switch (nodo.valor)
				{
				case "*":
					nodo.ultima_posicao = nodo.nodoEsquerda.ultima_posicao;
					break;
				case "|":
					nodo.ultima_posicao = nodo.nodoEsquerda.ultima_posicao;
					nodo.ultima_posicao.UnionWith(nodo.nodoDireita.ultima_posicao);
					break;
				case ".":
					nodo.ultima_posicao = nodo.nodoDireita.ultima_posicao;
					if (nodo.nodoDireita.anulavel)
						nodo.ultima_posicao.UnionWith(nodo.nodoEsquerda.ultima_posicao);
					break;
				}
			}

			internal void calculaTabelaPosicaoSeguinte()
			{
				Nodo auxNodo = new Nodo();
				Console.WriteLine("Count:{0}", NodosPosicaoSeguinte.Count);
				while (NodosPosicaoSeguinte.Count > 0)
				{
					auxNodo = NodosPosicaoSeguinte.Pop();
					if (auxNodo.valor == "|")
						continue;
					calculaPosicaoSeguinte(auxNodo);
				}
			}

			private void calculaPosicaoSeguinte(Nodo nodo)
			{
				Console.WriteLine("calculaPosicaoSeguinte");
				switch (nodo.valor)
				{
				case "*":
					//i é uma posição em ultima_pos(n), então todas  as posicoes em primeira_pos(n) estão em pos_seguinte(i)
					incluiPosicoesNosIndicadores(nodo.primeira_posicao, nodo.ultima_posicao);
					break;
				case ".":
					//i é uma posição em ultima_pos(c1), então todas as posições em primeira_pos(c2) estão em pos_seguinte(i)
					incluiPosicoesNosIndicadores(nodo.nodoDireita.primeira_posicao, nodo.nodoEsquerda.ultima_posicao);
					break;
				}
			}

			private void incluiPosicoesNosIndicadores(HashSet<int> posicoes, HashSet<int> indicadores)
			{
				foreach(var i in indicadores)
				{
					if (!posicao_seguinte.ContainsKey(i))
					{
						posicao_seguinte.Add(i, posicoes);
					}
					else
					{
						HashSet<int> indiUpdated = (HashSet<int>)posicao_seguinte[i];
						indiUpdated.UnionWith(posicoes);
						posicao_seguinte[i] = indiUpdated;
					}

				}
			}
		}
	}
}
