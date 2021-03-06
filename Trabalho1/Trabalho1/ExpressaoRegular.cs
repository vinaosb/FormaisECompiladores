﻿// ################################################
// Uiversidade Federal de Santa Catarina
// INE5421 - Linguagens Formais e Compiladores
// Trabalho 1 - 2018/2
// Alunos:
//      - Marcelo José Dias (15205398)
//      - Thiago Martendal Salvador (16104594)
//      - Vinícius Schwinden Berkenbrock (16100751)
//#################################################
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
        // ## Classe Expressao Regular para converter uma ER em AFD ##
        // A Expressao regular deve ser escrita com as seguintes regras:
        // 1- Quando 'ou' é usada ex:'|', deve ser usar parenteses: (a|b)
        // 2- Deve-se usar o sinal de concatenação "." Ex: a.(a|b)*
        // 3- Deve-se terminar com o simbolo '#' Ex: a.(a|b).(a|b)*.#
        // ##
        public string regex;
        public ArvoreSintatica arvore;
        public ExpressaoRegular(string text)
        {
            arvore = new ArvoreSintatica();
            regex = text;
        }
        //Metodo Principal para a transformaçao.
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
            a.showAutomato(a);
            return a;
        }
 
        //Função que cria o Automato a partir da tabela posicao_seguinte do algoritmo Aho
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
        //Gera os estados do Automato de acordo com a tabela posicao_seguinte no algoritmo Aho
        private Automato geraEstados(Automato automato, Stack<HashSet<int>> stack)
        {
            HashSet<int> estado1, estado2 = new HashSet<int>();
            while(stack.Count() > 0){
                estado1 = stack.Pop();
                string nomeEstado1 = geraNomeDoEstado(estado1);
                estado2 = new HashSet<int>();
                foreach (var simbol in arvore.simbolos.ToList())
                {
                    estado2 = new HashSet<int>();
                    foreach (var i in estado1.ToList())
                    {
                        if ((string)arvore.folhas[i] == simbol)
                            if(arvore.posicao_seguinte.ContainsKey(i))
                                estado2.UnionWith((HashSet<int>)arvore.posicao_seguinte[i]);
                    }
                    if (estado2.Count > 0)
                    {
                        string nomeEstado2 = geraNomeDoEstado(estado2);

                        if (estado1.SetEquals(estado2))
                        {
                            automato.addTransicao(nomeEstado1, simbol, nomeEstado1);
                        }
                        else
                        {
                            
                            bool contemTransacao = false;
                            var t = automato.GetTransicao(nomeEstado1, simbol);
                            foreach(var e in t.estado2)
                                if(e == nomeEstado2)
                                    contemTransacao = true;
                            //foreach (var k in automato.transicoes.Keys)
                            //    if (k[0] == nomeEstado1 && k[1] == simbol)
                            //        contemTransacao = true;
                            if (!contemTransacao)
                            {
                                if (!automato.estados.Contains(nomeEstado2))
                                {
                                    stack.Push(estado2);
                                    automato.addEstado(nomeEstado2);
                                }
                                automato.addTransicao(nomeEstado1, simbol, nomeEstado2);
                                //estado2.Clear();
                            }
                        }
                    }
                }
                
            }
            return automato;
        }
        //Utiliza o Hash de Estados para gerar o novo nome do estado.
        //Por exemplo a primeira posição da raiz da Arvore no algoritmo Aho, sendo o conjunto {1,2,3}
        //Esse conjunto será o primeiro estado do automato, gera a string "123" como o nome do estado.
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

        //Metodo para Debug, apenas mostra a tabela Posicao_SEguinte na saida.
        private void showPosSeguinte()
        {
            //Console.WriteLine("enter");
            foreach (DictionaryEntry element in arvore.posicao_seguinte)
            {
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
        //Chama o metodo pra Criar a Arvore Expandida da Expressão para o metodo Aho
        public void createTree()
        {
            string regex_fixed = addParenthesis(regex);
            arvore.parseRegex(arvore.initialNodo(regex_fixed));
        }
        //Adiciona parentesis na expressao regular para funcionar com o metodo Aho.
        public string addParenthesis(string regex)
        {
            //coloca parentesis antes do trecho final, (regex).#
            //O primeiro nodo não pode ser '|', os parentesis faz com que o primeiro nodo seja '.'
            regex = regex.Replace(".#","");
            regex = "(" + regex + ")" + ".#";
            return regex;
        }
        //Chama metodo que percorre a arvore fazendo marcações necessárias para o algoritmo de conversão.
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
            //Identifica se Nodo é Folha, ou seja indicador.
            public bool isLeaf(Nodo nodo)
            {
                return (nodo.nodoEsquerda == null && nodo.nodoDireita == null);
            }
            //Cria novo Nodo na Arvore
            public Nodo createLeaf(Nodo nodo)
            {
                Nodo n = new Nodo();
                n.nodoPai = nodo;
                if (raiz == null)
                    raiz = nodo;
                return n;
            }
            //Recebe em que posicao da regex fazer o split e para cada novo termo chama o parse novamente
            //Ex: (a|b).c, pos=5, separa em dois termos: (a|b) e c, e para cada chama o parse
            //Na segunda chamada o (a|b) será dividido novamente a patir do simbolo |
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
            //Identifica simbolo de maior relevancia, e separa tudo à esquerda e à direita para ser os filhos.
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
            //Utiliza esse metodo para saber qual será o primeiro Novo na Arvore
            //Ex: (a.b.c)|(a|b)* é interpretado como ( )|( )*
            //Assim sabemos que o '|' será o primeiro Nodo desse termo e os filhos serão ( ) e ( )*
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
            //Após a divisão do metodo acima, ele remove os parentesis externos para continuar o parse.
            //Ex: Continuando o exemplo, o filho esquerdo é (a.b.c), transforma em a.b.c
            public String removeExternalParenthesis(String text)
            {
                if (text.First() == '(' && text.Last() == ')')
                    return text.Substring(1, text.Length - 2);
                return text;
            }
            //Metodo percorre a Arvore Sintatica toda, fazendo as seguintes funções:
            //1-Identifica os indicadores(nodos folhas)
            //2-Seta se os indicadores são anulaveis ou não
            //3-Identifica a primeira_posicao e ultima_posicao para os indicadores
            //4-Identifica quais os simbolos para o Automato
            //5-Insere Nodos não folha em uma pilha.
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
            //Chama o primeiro Nodo da Arvore, e percorre toda ela
            public String listTree()
            {
                result = "";
                indicador = 1;
                readNodo(raiz);
                return result;
            }
            //Inclui os Nodos Internos em uma pilha para serem percorridos na forma depth-first.
            public void copyStack()
            {
                NodosPosicaoSeguinte = new Stack<Nodo>(NodosInternos.Reverse());
            }
            //O Primeiro Novo será e expressão inteira
            public Nodo initialNodo(String regex)
            {
                Nodo nodo = new Nodo();
                nodo.valor = regex;
                return nodo;
            }
            //Metodo que chama as funções para preencher as tabelas de Anulavel, Primeira Posicao e Ultima Posicao
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
            //Calcula se um Nodo Interno é Anulavel ou não. (Os indicadores são calculados em ReadNodo() )
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
            //Calcula o valor da Primeira Posicao para um Nodo Interno. (Os indicadores são calculados em ReadNodo() )
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
            //Calcula o valor da Ultima Posicao para um Nodo Interno. (Os indicadores são calculados em ReadNodo() )
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
            //Retira um Nodo da Pilha para montar a tabela Posição Seguinte
            //Só para nó-cat e nó-rep
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
            //Lê nodo e identifica se é nó-cat ou nó-rep e já interpreta algoritmo Aho
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
            //Inclui as posições nos Indicadores da Tabela de Posição Seguinte de acordo com Algoritmo Aho.
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
