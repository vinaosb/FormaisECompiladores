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
        public ExpressaoRegular()
        {
            arvore = new ArvoreSintatica();
        }
        public Automato transformERtoAFD(string text)
        {
            Automato a = new Automato(1);
            regex = text;
            createTree();
            readTree();
            return a;
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
            private int indicador;
            public Stack<Nodo> NodosInternos;

            public class Nodo
            {
                public Nodo nodoPai = null;
                public Nodo nodoEsquerda = null;
                public Nodo nodoDireita = null;
                public string valor = "";
                public HashSet<int> primeira_posicao = new HashSet<int>();
                public HashSet<int> ultima_posicao = new HashSet<int>();
                public HashSet<int> posicao_seguinte = new HashSet<int>();
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
                    indicador++;
                    nodo.primeira_posicao.Add(indicador);
                    nodo.ultima_posicao.Add(indicador);
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
            public Nodo initialNodo(String regex)
            {
                Nodo nodo = new Nodo();
                nodo.valor = regex;
                return nodo;
            }
        }
    }
}
