/*
 * Universidade Federal de Santa Catarina
 * Departamento de Informática e Estatística
 * Trabalho de Linguagens Formais e Compiladores
 * Marcelo José Dias
 * Thiago Martendal Salvador
 * Vinicius Schwinden Berkenbrock
*/
using System;
using Gtk;
using Trabalho1;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window {
	public Table tabela; //Tabela para exibir os autômatos
	public List<ElementosAutomato> entradas; //entradas dos autômatos a serem exibidos
	public List<Automato> automatos; //Lista de autômatos
	public List<Gramatica> gramaticas; //Lista de Gramáticas
	public List<ExpressaoRegular> expressoes; //Lista de Expressões Regulares
	public bool temTabela = false; //Variável para controle de exibição da tabela

	/* Struct de Dados do Autômato */
	public struct ElementosAutomato {
		public string estado1;
		public Entry estado2;
		public string simbolo;
	}

	public MainWindow () : base (Gtk.WindowType.Toplevel) {
		/* Instancias */
		Build ();
		entradas = new List<ElementosAutomato>();
		automatos = new List<Automato> ();
		gramaticas = new List<Gramatica> ();
		expressoes = new List<ExpressaoRegular> ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a) {
		Application.Quit ();
		a.RetVal = true;
	}

	protected void inserirAutomato (object sender, EventArgs e) {
		/* Ação para abrir a janela de criação do autômato */
		NovoAutomato novo = new NovoAutomato (this);
	}

	/* Metodo para exibir a criação do autômato em forma de tabela */
	public void atualizarAutomato(string[] vetorEstados, string[] vetorSimbolos) {
		if (temTabela) {
			tabela.Destroy (); //Se existe tabela, ela é destruida
		}
		tabela = new Table((uint)vetorEstados.Length, (uint)vetorSimbolos.Length, false); //Criação de uma nova tabela
		tabela.BorderWidth = 0;
		scrolledwindow1.Add(tabela);
		/* Laço de repetição para montar a visão dos simbolos de transição na tabela */
		uint inc1 = 2;
		for (int i = 0; i < vetorSimbolos.Length; i++) {
			Label lbl2 = new Label(vetorSimbolos[i]);
			if (vetorSimbolos.Length == 1) {
				tabela.Attach(lbl2, 1, 3, 0, 1); //Adicionado o primeiro símbolo
			} else {
				tabela.Attach(lbl2, (uint)i, inc1+1, 0, 1); //Adicionado os demais
			}
			lbl2.Show();
			inc1++;
		}
		/* Laço de repetição para montar a visão dos estados na tabela */
		uint inc2 = 2;
		for (int i = 0; i < vetorEstados.Length; i++) {
			Label lbl3 = new Label(vetorEstados[i]);
			if (vetorEstados.Length == 1) {
				tabela.Attach (lbl3, 0, 2, 1, 3); //Adicionado o primeiro estado
			} else {
				tabela.Attach (lbl3, 0, 1, (uint)i, inc2 + 1); //Adicionado os demais
			}
			lbl3.Show();
			inc2++;
		}
		/* Estes dois laços formam o corpo do autômato com caixas de texto para digitar os estados */
		for (int i = 0; i < vetorSimbolos.Length; i++) {
			for (int j = 0; j < vetorEstados.Length; j++) {
				Entry txt = new Entry();
				txt.WidthChars = 5;
				if (vetorSimbolos.Length == 1 && vetorEstados.Length == 1) {
					tabela.Attach(txt, 1, (uint)i+3, 1, (uint)j+3, AttachOptions.Expand, AttachOptions.Fill, 0, 0); //Adicionado uma caixa de texto
				} else if (vetorSimbolos.Length == 1) {
					tabela.Attach(txt, 1, (uint)i+3, (uint)j, (uint)j+3, AttachOptions.Expand, AttachOptions.Fill, 0, 0); //Adicionado uma caixa de texto
				} else if (vetorEstados.Length == 1) {
					tabela.Attach(txt, (uint)i, (uint)i+3, 1, (uint)j+3, AttachOptions.Expand, AttachOptions.Fill, 0, 0); //Adicionado uma caixa de texto
				} else {
					tabela.Attach(txt, (uint)i, (uint)i+3, (uint)j, (uint)j+3, AttachOptions.Expand, AttachOptions.Fill, 0, 0); //Adicionado uma caixa de texto
				}
				txt.Show();
				/* Abaixo cria-se o corpo de dados do autômato */
				ElementosAutomato elementos = new ElementosAutomato ();
				elementos.estado1 = vetorEstados [j];
				elementos.estado2 = txt;
				elementos.simbolo = vetorSimbolos [i];
				entradas.Add (elementos); //Adicionado nas entradas
			}
		}
		tabela.Show();
		temTabela = true;
	}

	/* Este método é igual ao método atualizarAutomato mas como se trata de exibição recebe a lista de transições para se inserir nas caixas de texto */
	public void abrirAutomato(List<string> vetorEstados1, List<string> vetorSimbolos, List<string[]> transicoes) {
		if (temTabela) {
			tabela.Destroy ();
		}
		tabela = new Table((uint)vetorEstados1.Count, (uint)vetorSimbolos.Count, false);
		tabela.BorderWidth = 0;
		scrolledwindow1.Add(tabela);
		uint inc1 = 2;
		for (int i = 0; i < vetorSimbolos.Count; i++) {
			Label lbl2 = new Label(vetorSimbolos[i]);
			if (vetorSimbolos.Count == 1) {
				tabela.Attach(lbl2, 1, 3, 0, 1);
			} else {
				tabela.Attach(lbl2, (uint)i, inc1+1, 0, 1);
			}
			lbl2.Show();
			inc1++;
		}
		uint inc2 = 2;
		for (int i = 0; i < vetorEstados1.Count; i++) {
			Label lbl3 = new Label(vetorEstados1[i]);
			if (vetorEstados1.Count == 1) {
				tabela.Attach (lbl3, 0, 2, 1, 3);
			} else {
				tabela.Attach (lbl3, 0, 1, (uint)i, inc2 + 1);
			}
			lbl3.Show();
			inc2++;
		}
		for (int i = 0; i < vetorSimbolos.Count; i++) {
			for (int j = 0; j < vetorEstados1.Count; j++) {
				Entry txt = new Entry();
				for (int k = 0; k < transicoes.Count; k++) {
					if (vetorEstados1[j] == transicoes[k][0] && vetorSimbolos[i] == transicoes[k][1]) {
						txt.Text = transicoes[k][2];
					}
				}
				txt.WidthChars = 5;
				if (vetorSimbolos.Count == 1 && vetorEstados1.Count == 1) {
					tabela.Attach(txt, 1, (uint)i+3, 1, (uint)j+3, AttachOptions.Expand, AttachOptions.Fill, 0, 0);
				} else if (vetorSimbolos.Count == 1) {
					tabela.Attach(txt, 1, (uint)i+3, (uint)j, (uint)j+3, AttachOptions.Expand, AttachOptions.Fill, 0, 0);
				} else if (vetorEstados1.Count == 1) {
					tabela.Attach(txt, (uint)i, (uint)i+3, 1, (uint)j+3, AttachOptions.Expand, AttachOptions.Fill, 0, 0);
				} else {
					tabela.Attach(txt, (uint)i, (uint)i+3, (uint)j, (uint)j+3, AttachOptions.Expand, AttachOptions.Fill, 0, 0);
				}
				txt.Show();
				ElementosAutomato elementos = new ElementosAutomato ();
				elementos.estado1 = vetorEstados1 [j];
				elementos.estado2 = txt;
				elementos.simbolo = vetorSimbolos [i];
				entradas.Add (elementos);
			}
		}
		tabela.Show();
		temTabela = true;
		vetorEstados1.Clear ();
		vetorSimbolos.Clear ();
		transicoes.Clear ();
	}

	/* Metodo para atualizar a gramática sendo exibida*/
	public void atualizarGramatica(string gramatica) {
		textview2.Buffer.Text = gramatica; //Adiciona a gramática na caixa de texto
	}

	/* Metodo para atualizar a lista de autômatos */
	private void atualizarListaAutomatos() {
		for (int i = 0; i < automatos.Count; i++) {
			if (!combobox1.Data.Contains ("Autômato " + (i).ToString ())) {
				combobox1.AppendText ("Autômato " + (i).ToString ()); //Adiciona o autômato na lista com seu indice no nome
				combobox1.Data.Add ("Autômato " + (i).ToString (), "Autômato " + (i).ToString ()); //Adiciona o autômato nos dados da combobox
			}
		}
	}

	/* Ação para salvar o autômato */
	protected void OnAutomatoAction1Activated (object sender, EventArgs e) {
        Crud crud = new Crud("Automato");
		crud.Store<List<Automato>>(automatos); //Salva a lista de autômatos
	}

	/* Ação para abrir a lista de autômatos */
	protected void OnAutomatoActionActivated (object sender, EventArgs e) {
		Crud crud = new Crud("Automato");
		crud.Load<List<Automato>>(automatos); //Abre a lista
		atualizarListaAutomatos (); //Atualiza a lista
	}

	protected void OnDeterminizarAutmatoActionActivated (object sender, EventArgs e) {
		
	}

	/* Metodo para limpeza da lista de entradas */
	public void limparEntradas() {
		entradas.Clear ();
	}

	/* Ação para criação ou edição do autômato */
	protected void OnButton6Clicked (object sender, EventArgs e) {
		if (entradas.Count == 0) {
			/* Se nenhum autômato está selecionado não se pode guardar a edição feita */
			MessageDialog msg = new MessageDialog (this, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Close, "Selecione um autômato para editá-lo");
			msg.Run ();
			msg.Destroy ();
		} else {
			Automato temp = new Automato (automatos.Count + 1); //Criado um novo autômato
			for (int i = 0; i < entradas.Count; i++) {
				temp.addEstado (entradas [i].estado1); //Adicionado os estados
				temp.addSimbolo (entradas [i].simbolo); //Adicionado os simbolos de transição
				if (entradas [i].estado2.Text.Contains (",")) {
					/* Caso aja transições não deterministicas */
					string[] quebra = entradas [i].estado2.Text.Split (','); //Quebra-se pela virgula
					for (int j = 0; j < quebra.Length; j++) {
						temp.addEstado (quebra [j]); //Adicionados cada um dos estados na transição
						temp.addTransicao (entradas [i].estado1, entradas [i].simbolo, quebra [j]); //Adicionada a transição não determinística
					}
				} else {
					/* Se não houverem transições não-deterministicas */
					temp.addEstado (entradas [i].estado2.Text); //Adiciona-se o segundo estado
					temp.addTransicao (entradas [i].estado1, entradas [i].simbolo, entradas [i].estado2.Text); //Adiciona-se a transição
				}
			}
			limparEntradas (); //As entradas são limpas para não interferir na exibição
			automatos.Add (temp); //Adicionado o novo autômato na lista
			atualizarListaAutomatos (); //Atualizada a lista de autômatos
		}
	}

	/* Ação para exibir um autômato na lista */
	protected void OnCombobox1Changed (object sender, EventArgs e) {
		string[] indice = combobox1.ActiveText.Split (' '); //Retira o indice do autômato no nome
		Automato temp = automatos[Int32.Parse(indice[1])]; //Busca o autômato na lista com o indice
		List<string> estados1 = new List<string>(); //Lista de estados
		List<string> simbolos = new List<string>(); //Lista de símbolos de transição
		List<string[]> transicao = new List<string[]> (); //Lista de transições
		HashSet<string> tempEstados1 = new HashSet<string> ();
		HashSet<string> tempSimbolos = new HashSet<string> ();
		foreach (var t in temp.transicoes) {
			string estado = "";
			foreach (string s in temp.estadosFinais) {
				if (t.Value.estado1 == temp.estadoInicial && t.Value.estado1 == s) {
					estado = "+*" + t.Value.estado1; //Estado inicial e final
				} else if (t.Value.estado1 == temp.estadoInicial) {
					estado = "+" + t.Value.estado1; //Estado inicial
				} else if (t.Value.estado1 == s) {
					estado = "*" + t.Value.estado1; //Estado final
				} else {
					estado = t.Value.estado1; //Estado comum
				}
			}
			tempEstados1.Add (estado); //Adiciona o estado
			tempSimbolos.Add (t.Value.simbolo); //Adiciona o símbolo
			foreach (string h in t.Value.estado2) {
				string estado2 = "";
				foreach (string s in temp.estadosFinais) {
					if (h == temp.estadoInicial && h == s) {
						estado2 = "+*" + h;
					} else if (h == temp.estadoInicial) {
						estado2 = "+" + h;
					} else if (h == s) {
						estado2 = "*" + h;
					} else {
						estado2 = h;
					}
				}
				string[] chave = {estado, t.Value.simbolo, estado2}; //Cria uma transição
				transicao.Add (chave); //Adiciona a transição
			}
		}
		/* Os dois foreach tranferem os dados das listas temporarias para as defintivas */
		foreach (string x in tempEstados1) {
			estados1.Add (x);
		}
		foreach (string x in tempSimbolos) {
			simbolos.Add (x);
		}
		/* O algoritmo abaixo faz a exibição de estados não-determinísticos */
		List<string[]> tempTransicoesNDertermnisticas = new List<string[]> ();
		for (int i = 0; i < transicao.Count; i++) {
			string[] novaChave = new string[3]; //Nova chave com as transições
			string[] chave = transicao [i]; //Chave com transições antigas
			for (int j = 0; j < transicao.Count; j++) {
				string[] chave2 = transicao [j]; //Outra chave com transições antigas
				if (chave[0] == chave2[0] && chave[1] == chave2[1]) { //Compara dados das chaves
					if (chave[2] != chave2[2] && chave[2] != "" && chave2[2] != "") { //Compara se não existem estados nulos
						novaChave [0] = chave [0]; //Copia o primeiro estado
						novaChave [1] = chave [1]; //Copia o símbolo
						novaChave [2] = chave [2] + "," + chave2 [2]; //Copia o segundo estado
					}
				}
			}
			tempTransicoesNDertermnisticas.Add (novaChave); //Adiciona a nova transição na lista
		}
		for (int i = 0; i < tempTransicoesNDertermnisticas.Count; i++) {
			transicao.Add(tempTransicoesNDertermnisticas[i]); //Copia a lista
		}
		abrirAutomato (estados1, simbolos, transicao); //Atualiza a exibição do autômato
	}

	/* Metodo para atualizar a lista de gramáticas */
	public void atualizarListaGramaticas() {
		for (int i = 0; i < gramaticas.Count; i++) {
			if (!combobox2.Data.Contains ("Gramática " + (i).ToString ())) {
				combobox2.AppendText ("Gramática " + (i).ToString ()); //Adiciona a gramática com indice no nome
				combobox2.Data.Add ("Gramática " + (i).ToString (), "Gramática " + (i).ToString ()); //Adiciona a gramática nos dados da combobox
			}
		}
	}

	/* Ação para adicionar gramáticas */
	protected void OnButton230Clicked (object sender, EventArgs e) {
		string[] temp = textview2.Buffer.Text.Split(new [] { '\r', '\n' }); //Quebra a gramática em linhas
		Gramatica gramatica = new Gramatica ((gramaticas.Count+1).ToString()); //Cria uma nova gramática
		for (int i = 0; i < temp.Length; i++) {
			Gramatica.Regular regular = new Gramatica.Regular (); //Cria um pedaço da gramática
			string[] temp2 = temp [i].Split(new string[] { "->" }, StringSplitOptions.None); //Quebra o caractere de atribuição
			if (temp2 [0] != "") {
				string a = temp2 [0];
				regular.Atual = a[0]; //Define a cabeça de produção
				List<string> proximos = new List<string> (); //Lista com os simbolos do corpo da produção
				for (int j = 1; j < temp2.Length; j++) {
					if (!temp2 [j].Contains ("|")) { //Verifica se a produção tem mais de um caminho
						if (!proximos.Contains (temp2 [j])) { //Se não tem a produção
							if (temp2 [j] != "") {
								proximos.Add (temp2 [j]); //Adiciona
							}
						}
					} else {
						//Mesmos passos do código acima
						string[] temp3 = temp2 [j].Split ('|');
						for (int k = 0; k < temp3.Length; k++) {
							if (!proximos.Contains (temp3 [k])) {
								if (temp3 [k] != "") {
									proximos.Add (temp3 [k]);
								}
							}
						}
					}
				}
				regular.Proximos = proximos; //Define o corpo da produção
				gramatica.AddProducao (regular); //Adiciona na lista
			}
		}
		gramaticas.Add (gramatica); //Adiciona a gramática na lista
		atualizarListaGramaticas (); //Atualiza a lista de gramáticas
	}

	/* Ação para exibir a gramática selecionada na lista */
	protected void OnCombobox2Changed (object sender, EventArgs e) {
		string[] indice = combobox2.ActiveText.Split (' '); //Recebe o identificador da gramática
		Gramatica temp = gramaticas[Int32.Parse(indice[1])]; //Busca na lista
		string texto = "";
		foreach (var t in temp.Producoes) {
			Gramatica.Regular producao = t.Value; //Pega pedaços da gramática
			string parte = "";
			for (int j = 0; j < producao.Proximos.Count; j++) {
				if (producao.Proximos.Count > 1) {
					if (j == producao.Proximos.Count-1) {
						parte += producao.Proximos[j]; //Monta o corpo da produção
					} else {
						parte += producao.Proximos[j]+"|"; //Monta o corpo da produção com mais de um caminho
					}
				} else {
					parte += producao.Proximos[j]; ////Monta o corpo da produção única
				}
			}
			texto += producao.Atual+"->"+parte+"\r\n"; //Define a cabeça e o corpo
		}
		textview2.Buffer.Text = texto; //Exibe na caixa de texto
	}

	/* Ação para salvar a grmática */
	protected void OnGramticaActionActivated (object sender, EventArgs e) {
		Crud crud = new Crud("Gramatica");
		crud.Store<List<Gramatica>>(gramaticas); //Salva a lista de gramáticas
	}

	/* Abre a Lista de gramáticas */
	protected void OnGramaticaActionActivated (object sender, EventArgs e) {
		Crud crud = new Crud("Gramatica");
		crud.Load<List<Gramatica>>(gramaticas); //Abre aqui
		atualizarListaGramaticas (); //Atualiza a lista
	}

	/* Ação para abrir a janela de união de autômatos */
	protected void OnUnirAutmatosActionActivated (object sender, EventArgs e) {
		UnirAutomato uniao = new UnirAutomato (this);
	}

	/* Metodo que faz a união de dois autômatos */
	public void uniao(int indice1, int indice2) {
		Automato automato1 = automatos[indice1]; //Inicia o autômato 1
		Automato automato2 = automatos[indice2]; //Inicia o autômato 2
		Automato temp = automato1.Uniao (automato2); //Faz a união dos autômatos
		//O bloco de código abaixo é identico ao método OnCombobox1Changed
		List<string> estados1 = new List<string>();
		List<string> simbolos = new List<string>();
		List<string[]> transicao = new List<string[]> ();
		HashSet<string> tempEstados1 = new HashSet<string> ();
		HashSet<string> tempSimbolos = new HashSet<string> ();
		foreach (var t in temp.transicoes) {
			string estado = "";
			foreach (string s in temp.estadosFinais) {
				if (t.Value.estado1 == temp.estadoInicial && t.Value.estado1 == s) {
					estado = "+*" + t.Value.estado1;
				} else if (t.Value.estado1 == temp.estadoInicial) {
					estado = "+" + t.Value.estado1;
				} else if (t.Value.estado1 == s) {
					estado = "*" + t.Value.estado1;
				} else {
					estado = t.Value.estado1;
				}
			}
			tempEstados1.Add (estado);
			tempSimbolos.Add (t.Value.simbolo);
			foreach (string h in t.Value.estado2) {
				Console.WriteLine (t.Value.estado1+" "+t.Value.simbolo+" "+h);
				string estado2 = "";
				foreach (string s in temp.estadosFinais) {
					if (h == temp.estadoInicial && h == s) {
						estado2 = "+*" + h;
					} else if (h == temp.estadoInicial) {
						estado2 = "+" + h;
					} else if (h == s) {
						estado2 = "*" + h;
					} else {
						estado2 = h;
					}
				}
				string[] chave = { estado, t.Value.simbolo, estado2 };
				transicao.Add (chave);
			}
		}
		foreach (string x in tempEstados1) {
			estados1.Add (x);
		}
		foreach (string x in tempSimbolos) {
			simbolos.Add (x);
		}
		string[] novaChave = new string[3];
		for (int i = 0; i < transicao.Count; i++) {
			string[] chave = transicao [i];
			for (int j = 0; j < transicao.Count; j++) {
				string[] chave2 = transicao [j];
				if (chave[0] == chave2[0] && chave[1] == chave2[1]) {
					if (chave[2] != chave2[2] && chave[2] != "" && chave2[2] != "") {
						novaChave [0] = chave [0];
						novaChave [1] = chave [1];
						novaChave [2] = chave [2] + "," + chave2 [2];
					}
				}
			}
		}
		transicao.Add(novaChave);
		abrirAutomato(estados1, simbolos, transicao);
	}

	/* Metodo para fazer a intersecção de autômatos */
	public void interseccao(int indice1, int indice2) {
		//Codigo identico do metodo acima
		Automato automato1 = automatos [indice1];
		Automato automato2 = automatos [indice2];
		Automato temp = automato2.Interseccao (automato1);
		List<string> estados1 = new List<string>();
		List<string> simbolos = new List<string>();
		List<string[]> transicao = new List<string[]> ();
		HashSet<string> tempEstados1 = new HashSet<string> ();
		HashSet<string> tempSimbolos = new HashSet<string> ();
		foreach (var t in temp.transicoes) {
			string estado = "";
			foreach (string s in temp.estadosFinais) {
				if (t.Value.estado1 == temp.estadoInicial && t.Value.estado1 == s) {
					estado = "+*" + t.Value.estado1;
				} else if (t.Value.estado1 == temp.estadoInicial) {
					estado = "+" + t.Value.estado1;
				} else if (t.Value.estado1 == s) {
					estado = "*" + t.Value.estado1;
				} else {
					estado = t.Value.estado1;
				}
			}
			tempEstados1.Add (estado);
			tempSimbolos.Add (t.Value.simbolo);
			foreach (string h in t.Value.estado2) {
				string estado2 = "";
				foreach (string s in temp.estadosFinais) {
					if (h == temp.estadoInicial && h == s) {
						estado2 = "+*" + h;
					} else if (h == temp.estadoInicial) {
						estado2 = "+" + h;
					} else if (h == s) {
						estado2 = "*" + h;
					} else {
						estado2 = h;
					}
				}
				string[] chave = { estado, t.Value.simbolo, estado2 };
				transicao.Add (chave);
			}
		}
		foreach (string x in tempEstados1) {
			estados1.Add (x);
		}
		foreach (string x in tempSimbolos) {
			simbolos.Add (x);
		}
		abrirAutomato(estados1, simbolos, transicao);
	}

	/* Ação para abrir a janela de intersecção */
	protected void OnInterseccionarAutmatosActionActivated (object sender, EventArgs e) {
		Interseccao interseccao = new Interseccao (this);
	}

	/* Ação para abrir a janela de minimização */
	protected void OnMinimizarAutmatoActionActivated (object sender, EventArgs e) {
		MinimizarAutomato mini = new MinimizarAutomato (this);
	}

	/* Metodo para minimizar autômatos */
	public void minimizacao(int indice) {
		Automato automato = automatos [indice]; //Seleciona o autômato com a id
		Automato temp = automato.Minimizacao (automato, automato.ID); //Recebe o autômato minimizado
		List<string> estados1 = new List<string>(); //Lista de estados
		List<string> simbolos = new List<string>(); //Lista de simbolos
		List<string[]> transicao = new List<string[]> (); //Lista de transições
		/* Listas temporárias */
		HashSet<string> tempEstados1 = new HashSet<string> ();
		HashSet<string> tempSimbolos = new HashSet<string> ();
		//O bloco de código abaixo ja foi comentado no método OnCombobox1Changed
		foreach (var t in temp.transicoes) {
			string estado = "";
			foreach (string s in temp.estadosFinais) {
				Console.WriteLine (s);
				if (t.Value.estado1 == temp.estadoInicial && t.Value.estado1 == s) {
					estado = "+*" + t.Value.estado1;
				} else if (t.Value.estado1 == temp.estadoInicial) {
					estado = "+" + t.Value.estado1;
				} else if (t.Value.estado1 == s) {
					estado = "*" + t.Value.estado1;
				} else {
					estado = t.Value.estado1;
				}
			}
			tempEstados1.Add (estado);
			tempSimbolos.Add (t.Value.simbolo);
			foreach (string h in t.Value.estado2) {
				string estado2 = "";
				foreach (string s in temp.estadosFinais) {
					if (h == temp.estadoInicial && h == s) {
						estado2 = "+*" + h;
					} else if (h == temp.estadoInicial) {
						estado2 = "+" + h;
					} else if (h == s) {
						estado2 = "*" + h;
					} else {
						estado2 = h;
					}
				}
				string[] chave = { estado, t.Value.simbolo, estado2 };
				transicao.Add (chave);
			}
		}
		/* Os dados são copiados para as listas finais*/
		foreach (string x in tempEstados1) {
			estados1.Add (x);
		}
		foreach (string x in tempSimbolos) {
			simbolos.Add (x);
		}
		abrirAutomato(estados1, simbolos, transicao); //Atualiza a exibição do autômato
	}

	/* Ação para cria uma nova expressão regular */
	protected void OnButton1952Clicked (object sender, EventArgs e) {
		string expressao = textview3.Buffer.Text; //Copia a expressão da caixa de texto
		ExpressaoRegular ER = new ExpressaoRegular (expressao); //Cria-se a nova expressão
		expressoes.Add (ER); //Adiciona a expressão na lista
		atualizarListaER (); //Atualiza a lista de expressões
	}

	/* Metodo para atualizar a lista de expressões regulares */
	public void atualizarListaER() {
		for (int i = 0; i < expressoes.Count; i++) {
			if (!combobox3.Data.Contains ("Expressão " + (i).ToString ())) {
				combobox3.AppendText ("Expressão " + (i).ToString ()); //Adiciona a expressão com indice no nome a lista
				combobox3.Data.Add ("Expressão " + (i).ToString (), "Expressão " + (i).ToString ()); //Adiciona a expressão na lista de dados da combobox
			}
		}
	}

	/* Ação para converter expressão em AFD */
	protected void OnConverterEREmAFDActionActivated (object sender, EventArgs e) {
		ConverterERAFD converter = new ConverterERAFD (this);
	}

	/* Método da conversão de ER em AFD */
	public void converterER(int indice) {
		ExpressaoRegular ER = expressoes[indice]; //Inicia a expressão da lista
		Automato temp = ER.transformaERemAFD (); //Converte a ER para AFD
		/* O código abaixo já foi comentado e serve para fazer a exibição do autômato */
		List<string> estados1 = new List<string>();
		List<string> simbolos = new List<string>();
		List<string[]> transicao = new List<string[]> ();
		HashSet<string> tempEstados1 = new HashSet<string> ();
		HashSet<string> tempSimbolos = new HashSet<string> ();
		foreach (var t in temp.transicoes) {
			string estado = "";
			foreach (string s in temp.estadosFinais) {
				if (t.Value.estado1 == temp.estadoInicial && t.Value.estado1 == s) {
					estado = "+*" + t.Value.estado1;
				} else if (t.Value.estado1 == temp.estadoInicial) {
					estado = "+" + t.Value.estado1;
				} else if (t.Value.estado1 == s) {
					estado = "*" + t.Value.estado1;
				} else {
					estado = t.Value.estado1;
				}
			}
			tempEstados1.Add (estado);
			tempSimbolos.Add (t.Value.simbolo);
			foreach (string h in t.Value.estado2) {
				string estado2 = "";
				foreach (string s in temp.estadosFinais) {
					if (h == temp.estadoInicial && h == s) {
						estado2 = "+*" + h;
					} else if (h == temp.estadoInicial) {
						estado2 = "+" + h;
					} else if (h == s) {
						estado2 = "*" + h;
					} else {
						estado2 = h;
					}
				}
				string[] chave = { estado, t.Value.simbolo, estado2 };
				transicao.Add (chave);
			}
		}
		foreach (string x in tempEstados1) {
			estados1.Add (x);
		}
		foreach (string x in tempSimbolos) {
			simbolos.Add (x);
		}
		abrirAutomato(estados1, simbolos, transicao);
	}

	/* Ação para exibir uma ER da lista */
	protected void OnCombobox3Changed (object sender, EventArgs e) {
		string[] indice = combobox3.ActiveText.Split (' '); //Recebe o indice da ER
		ExpressaoRegular temp = expressoes[Int32.Parse(indice[1])]; //Retira a ER da lista
		string texto = temp.regex; //Recebe a string da ER
		textview3.Buffer.Text = texto; //Adiciona na caixa de texto
	}

	/* Ação para converter Gramática para AFND */
	protected void OnConverterGramticaParaAFNDActionActivated (object sender, EventArgs e) {
		ConverterGRAFND converter = new ConverterGRAFND (this);
	}

	/* Metodo que faz a conversão de GR em AFND */
	public void converterGRAFND(int indice) {
		Gramatica GR = gramaticas [indice]; //Retira a gramática da lista
		Automato temp = GR.GetAutomato (); //Converte a gramática em autômato
		temp.showAutomato(temp);
		/* Código abaixo já comentado anteriormente */
		List<string> estados1 = new List<string>();
		List<string> simbolos = new List<string>();
		List<string[]> transicao = new List<string[]> ();
		HashSet<string> tempEstados1 = new HashSet<string> ();
		HashSet<string> tempSimbolos = new HashSet<string> ();
		foreach (var t in temp.transicoes) {
			string estado = "";
			foreach (string s in temp.estadosFinais) {
				if (t.Value.estado1 == temp.estadoInicial && t.Value.estado1 == s) {
					estado = "+*" + t.Value.estado1;
				} else if (t.Value.estado1 == temp.estadoInicial) {
					estado = "+" + t.Value.estado1;
				} else if (t.Value.estado1 == s) {
					estado = "*" + t.Value.estado1;
				} else {
					estado = t.Value.estado1;
				}
			}
			tempEstados1.Add (estado);
			tempSimbolos.Add (t.Value.simbolo);
			foreach (string h in t.Value.estado2) {
				string estado2 = "";
				foreach (string s in temp.estadosFinais) {
					if (h == temp.estadoInicial && h == s) {
						estado2 = "+*" + h;
					} else if (h == temp.estadoInicial) {
						estado2 = "+" + h;
					} else if (h == s) {
						estado2 = "*" + h;
					} else {
						estado2 = h;
					}
				}
				string[] chave = { estado, t.Value.simbolo, estado2 };
				transicao.Add (chave);
				tempEstados1.Add (estado2);
			}
		}
		foreach (string x in tempEstados1) {
			estados1.Add (x);
		}
		foreach (string x in tempSimbolos) {
			simbolos.Add (x);
		}
		abrirAutomato(estados1, simbolos, transicao);
	}

	/* Ação para converter AFD em Gramática */
	protected void OnConverterAFDEmGramticaActionActivated (object sender, EventArgs e) {
		ConverterAFDGR converter = new ConverterAFDGR (this);
	}

	/* Método que converte AFD em GR */
	public void coverterAFDGR(int indice) {
		Automato temp = automatos [indice]; //Retira o autômato da lista
		Gramatica GR = new Gramatica (temp); //Cria a gramática com o autômato
		/* Código abaixo já comentado e serve para exibir a gramática na caixa de texto */
		string texto = "";
		foreach (var t in GR.Producoes) {
			Gramatica.Regular producao = t.Value;
			string parte = "";
			for (int j = 0; j < producao.Proximos.Count; j++) {
				if (producao.Proximos.Count > 1) {
					if (j == producao.Proximos.Count-1) {
						parte += producao.Proximos[j];
					} else {
						parte += producao.Proximos[j]+"|";
					}
				} else {
					parte += producao.Proximos[j];
				}
			}
			texto += producao.Atual+"->"+parte+"\r\n";
		}
		textview2.Buffer.Text = texto;
	}

	/* Metodo para salvar a lista de expressões */
	protected void OnExpressoActionActivated (object sender, EventArgs e) {
		Crud crud = new Crud("Expressao");
		crud.Store<List<ExpressaoRegular>>(expressoes); //Salva aqui
	}

	/* Metodo para abrir a lista de expressões */
	protected void OnExpressoAction1Activated (object sender, EventArgs e) {
		Crud crud = new Crud("Expressao");
		crud.Load<List<ExpressaoRegular>>(expressoes); //Abre aqui
		atualizarListaER (); //Atualiza a lista
	}

}