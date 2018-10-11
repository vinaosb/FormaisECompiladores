using System;
using Gtk;
using Trabalho1;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window {
	public Table tabela;
	public List<ElementosAutomato> entradas;
	public List<Automato> automatos;
	public List<Gramatica> gramaticas;
	public List<ExpressaoRegular> expressoes;
	public bool temTabela = false;
	public bool temBox1 = false;

	public struct ElementosAutomato {
		public string estado1;
		public Entry estado2;
		public string simbolo;
	}

	public MainWindow () : base (Gtk.WindowType.Toplevel) {
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
		NovoAutomato novo = new NovoAutomato (this);
	}

	public void atualizarAutomato(string[] vetorEstados, string[] vetorSimbolos) {
		if (temTabela) {
			tabela.Destroy ();
		}
		tabela = new Table((uint)vetorEstados.Length, (uint)vetorSimbolos.Length, false);
		tabela.BorderWidth = 0;
		scrolledwindow1.Add(tabela);
		uint inc1 = 2;
		for (int i = 0; i < vetorSimbolos.Length; i++) {
			Label lbl2 = new Label(vetorSimbolos[i]);
			if (vetorSimbolos.Length == 1) {
				tabela.Attach(lbl2, 1, 3, 0, 1);
			} else {
				tabela.Attach(lbl2, (uint)i, inc1+1, 0, 1);
			}
			lbl2.Show();
			inc1++;
		}
		uint inc2 = 2;
		for (int i = 0; i < vetorEstados.Length; i++) {
			Label lbl3 = new Label(vetorEstados[i]);
			if (vetorEstados.Length == 1) {
				tabela.Attach (lbl3, 0, 2, 1, 3);
			} else {
				tabela.Attach (lbl3, 0, 1, (uint)i, inc2 + 1);
			}
			lbl3.Show();
			inc2++;
		}
		for (int i = 0; i < vetorSimbolos.Length; i++) {
			for (int j = 0; j < vetorEstados.Length; j++) {
				Entry txt = new Entry();
				txt.WidthChars = 5;
				if (vetorSimbolos.Length == 1 && vetorEstados.Length == 1) {
					tabela.Attach(txt, 1, (uint)i+3, 1, (uint)j+3, AttachOptions.Expand, AttachOptions.Fill, 0, 0);
				} else if (vetorSimbolos.Length == 1) {
					tabela.Attach(txt, 1, (uint)i+3, (uint)j, (uint)j+3, AttachOptions.Expand, AttachOptions.Fill, 0, 0);
				} else if (vetorEstados.Length == 1) {
					tabela.Attach(txt, (uint)i, (uint)i+3, 1, (uint)j+3, AttachOptions.Expand, AttachOptions.Fill, 0, 0);
				} else {
					tabela.Attach(txt, (uint)i, (uint)i+3, (uint)j, (uint)j+3, AttachOptions.Expand, AttachOptions.Fill, 0, 0);
				}
				txt.Show();
				ElementosAutomato elementos = new ElementosAutomato ();
				elementos.estado1 = vetorEstados [j];
				elementos.estado2 = txt;
				elementos.simbolo = vetorSimbolos [i];
				entradas.Add (elementos);
			}
		}
		tabela.Show();
		temTabela = true;
	}

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

	public void atualizarGramatica(string gramatica) {
		textview2.Buffer.Text = gramatica;
		/*string[] temp = gramatica.Split (new string[] { "->" }, StringSplitOptions.None);
		for (int i = 0; i < temp.Length; i++) {
			if (temp[i].Contains("|")) {
				string[] proximos = temp [i].Split ('|');
				for (int j = 0; j < proximos.Length; j++) {
					Console.WriteLine (proximos[i]);
				}
			}
		}*/
	}

	private void atualizarListaAutomatos() {
		for (int i = 0; i < automatos.Count; i++) {
			if (!combobox1.Data.Contains ("Autômato " + (i).ToString ())) {
				combobox1.AppendText ("Autômato " + (i).ToString ());
				combobox1.Data.Add ("Autômato " + (i).ToString (), "Autômato " + (i).ToString ());
			}
		}
	}

	protected void OnAutomatoAction1Activated (object sender, EventArgs e) {
        Crud crud = new Crud("Automato");
		crud.Store<List<Automato>>(automatos);
	}

	protected void OnAutomatoActionActivated (object sender, EventArgs e) {
		Crud crud = new Crud("Automato");
		crud.Load<List<Automato>>(automatos);
		atualizarListaAutomatos ();
	}

	protected void OnDeterminizarAutmatoActionActivated (object sender, EventArgs e) {
		
	}

	protected void OnButton6Clicked (object sender, EventArgs e) {
		Automato temp = new Automato (automatos.Count+1);
		for (int i = 0; i < entradas.Count; i++) {
			temp.addEstado (entradas [i].estado1);
			temp.addSimbolo (entradas [i].simbolo);
			if (entradas [i].estado2.Text.Contains(",")) {
				string[] quebra = entradas [i].estado2.Text.Split(',');
				for (int j = 0; j < quebra.Length; j++) {
					temp.addEstado (quebra[j]);
					temp.addTransicao(entradas [i].estado1, entradas [i].simbolo, quebra[j]);
				}
			} else {
				temp.addEstado (entradas [i].estado2.Text);
				temp.addTransicao(entradas [i].estado1, entradas [i].simbolo, entradas [i].estado2.Text);
			}
		}
		automatos.Add (temp);
		atualizarListaAutomatos ();
	}

	protected void OnCombobox1Changed (object sender, EventArgs e) {
		string[] indice = combobox1.ActiveText.Split (' ');
		Automato temp = automatos[Int32.Parse(indice[1])];
		List<string> estados1 = new List<string>();
		List<string> simbolos = new List<string>();
		List<string[]> transicao = new List<string[]> ();
		HashSet<string> tempEstados1 = new HashSet<string> ();
		HashSet<string> tempSimbolos = new HashSet<string> ();
		foreach (var t in temp.transicoes) {
			string estado = "";
			foreach (string s in temp.estadosFinais) {
				if (t.Value.estado1 == temp.estadoInicial) {
					estado = "+" + t.Value.estado1;
				} else if (t.Value.estado1 == s) {
					estado = "*" + t.Value.estado1;
				} else if (t.Value.estado1 == temp.estadoInicial && t.Value.estado1 == s) {
					estado = "+*" + t.Value.estado1;
				} else {
					estado = t.Value.estado1;
				}
			}
			tempEstados1.Add (estado);
			tempSimbolos.Add (t.Value.simbolo);
			foreach (string h in t.Value.estado2) {
				string estado2 = "";
				foreach (string s in temp.estadosFinais) {
					if (h == temp.estadoInicial) {
						estado2 = "+" + h;
					} else if (h == s) {
						estado2 = "*" + h;
					} else if (h == temp.estadoInicial && h == s) {
						estado2 = "+*" + h;
					} else {
						estado2 = h;
					}
				}
				string[] chave = {estado, t.Value.simbolo, estado2};
				transicao.Add (chave);
			}
		}
		foreach (string x in tempEstados1) {
			estados1.Add (x);
		}
		foreach (string x in tempSimbolos) {
			simbolos.Add (x);
		}
		List<string[]> tempTransicoesNDertermnisticas = new List<string[]> ();
		for (int i = 0; i < transicao.Count; i++) {
			string[] novaChave = new string[3];
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
			tempTransicoesNDertermnisticas.Add (novaChave);
		}
		for (int i = 0; i < tempTransicoesNDertermnisticas.Count; i++) {
			transicao.Add(tempTransicoesNDertermnisticas[i]);
		}
		tempEstados1.Clear ();
		tempSimbolos.Clear ();
		foreach (string x in estados1) {
			Console.WriteLine ("Estados 1: "+x);
		}
		foreach (string x in simbolos) {
			Console.WriteLine ("Símbolos: "+x);
		}
		/*estados1.Clear ();
		simbolos.Clear ();
		transicao.Clear ();*/
		abrirAutomato (estados1, simbolos, transicao);
	}

	public void atualizarListaGramaticas() {
		for (int i = 0; i < gramaticas.Count; i++) {
			if (!combobox2.Data.Contains ("Gramática " + (i).ToString ())) {
				combobox2.AppendText ("Gramática " + (i).ToString ());
				combobox2.Data.Add ("Gramática " + (i).ToString (), "Gramática " + (i).ToString ());
			}
		}
	}

	protected void OnButton230Clicked (object sender, EventArgs e) {
		string[] temp = textview2.Buffer.Text.Split(new [] { '\r', '\n' });
		Gramatica gramatica = new Gramatica ();
		for (int i = 0; i < temp.Length; i++) {
			Gramatica.Regular regular = new Gramatica.Regular ();
			string[] temp2 = temp [i].Split(new string[] { "->" }, StringSplitOptions.None);
			if (temp2 [0] != "") {
				string a = temp2 [0];
				regular.Atual = a[0];
				List<string> proximos = new List<string> ();
				for (int j = 1; j < temp2.Length; j++) {
					if (!temp2 [j].Contains ("|")) {
						if (!proximos.Contains (temp2 [j])) {
							if (temp2 [j] != "") {
								proximos.Add (temp2 [j]);
							}
						}
					} else {
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
				regular.Proximos = proximos;
				gramatica.AddProducao (regular);
			}
		}
		gramaticas.Add (gramatica);
		atualizarListaGramaticas ();
	}

	protected void OnCombobox2Changed (object sender, EventArgs e) {
		string[] indice = combobox2.ActiveText.Split (' ');
		Gramatica temp = gramaticas[Int32.Parse(indice[1])];
		string texto = "";
		foreach (var t in temp.Producoes) {
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
			//if ((producao.Atual != "" && parte != "") && (producao.Atual != "" || parte != "")) {
				texto += producao.Atual+"->"+parte+"\r\n";
			//}
		}
		textview2.Buffer.Text = texto;
	}

	protected void OnGramticaActionActivated (object sender, EventArgs e) {
		Crud crud = new Crud("Gramatica");
		crud.Store<List<Gramatica>>(gramaticas);
	}

	protected void OnGramaticaActionActivated (object sender, EventArgs e) {
		Crud crud = new Crud("Gramatica");
		crud.Load<List<Gramatica>>(gramaticas);
		atualizarListaGramaticas ();
	}

	protected void OnUnirAutmatosActionActivated (object sender, EventArgs e) {
		UnirAutomato uniao = new UnirAutomato (this);
	}

	public void uniao(int indice1, int indice2) {
		Automato automato1 = automatos[indice1];
		Automato automato2 = automatos[indice2];
		Automato temp = automato2.Uniao (automato1);
		List<string> estados1 = new List<string>();
		List<string> simbolos = new List<string>();
		List<string[]> transicao = new List<string[]> ();
		HashSet<string> tempEstados1 = new HashSet<string> ();
		HashSet<string> tempSimbolos = new HashSet<string> ();
		foreach (var t in temp.transicoes) {
			string estado = "";
			foreach (string s in temp.estadosFinais) {
				if (t.Value.estado1 == temp.estadoInicial) {
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
					if (h == temp.estadoInicial) {
						estado2 = "+" + h;
					} else if (h == s) {
						estado2 = "*" + h;
					} else if (h == temp.estadoInicial && h == s) {
						estado2 = "+*" + h;
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

	public void interseccao(int indice1, int indice2) {
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
				if (t.Value.estado1 == temp.estadoInicial) {
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
					if (h == temp.estadoInicial) {
						estado2 = "+" + h;
					} else if (h == s) {
						estado2 = "*" + h;
					} else if (h == temp.estadoInicial && h == s) {
						estado2 = "+*" + h;
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

	protected void OnInterseccionarAutmatosActionActivated (object sender, EventArgs e) {
		Interseccao interseccao = new Interseccao (this);
	}

	protected void OnMinimizarAutmatoActionActivated (object sender, EventArgs e) {
		MinimizarAutomato mini = new MinimizarAutomato (this);
	}

	public void minimizacao(int indice) {
		Automato automato = automatos [indice];
		Automato minimizado = automato.Minimizacao (automato, automato.ID);
		foreach (var t in minimizado.transicoes) {
			foreach (string s in t.Value.estado2) {
				Console.WriteLine (t.Value.estado1+" "+t.Value.simbolo+" "+s);
			}
		}
	}

	protected void OnButton1952Clicked (object sender, EventArgs e) {
		string expressao = textview3.Buffer.Text;
		ExpressaoRegular ER = new ExpressaoRegular (expressao);
		expressoes.Add (ER);
		atualizarListaER ();
	}

	public void atualizarListaER() {
		for (int i = 0; i < expressoes.Count; i++) {
			if (!combobox3.Data.Contains ("Expressão " + (i).ToString ())) {
				combobox3.AppendText ("Expressão " + (i).ToString ());
				combobox3.Data.Add ("Expressão " + (i).ToString (), "Expressão " + (i).ToString ());
			}
		}
	}

	protected void OnConverterEREmAFDActionActivated (object sender, EventArgs e) {
		ConverterERAFD converter = new ConverterERAFD (this);
	}

	public void converterER(int indice) {
		ExpressaoRegular ER = expressoes[indice];
		Automato temp = ER.transformaERemAFD ();
		List<string> estados1 = new List<string>();
		List<string> simbolos = new List<string>();
		List<string[]> transicao = new List<string[]> ();
		HashSet<string> tempEstados1 = new HashSet<string> ();
		HashSet<string> tempSimbolos = new HashSet<string> ();
		foreach (var t in temp.transicoes) {
			string estado = "";
			foreach (string s in temp.estadosFinais) {
				if (t.Value.estado1 == temp.estadoInicial) {
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
					if (h == temp.estadoInicial) {
						estado2 = "+" + h;
					} else if (h == s) {
						estado2 = "*" + h;
					} else if (h == temp.estadoInicial && h == s) {
						estado2 = "+*" + h;
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

	protected void OnCombobox3Changed (object sender, EventArgs e) {
		string[] indice = combobox3.ActiveText.Split (' ');
		ExpressaoRegular temp = expressoes[Int32.Parse(indice[1])];
		string texto = temp.regex;
		textview3.Buffer.Text = texto;
	}

	protected void OnConverterGramticaParaAFNDActionActivated (object sender, EventArgs e) {
		ConverterGRAFND converter = new ConverterGRAFND (this);
	}

	public void converterGRAFND(int indice) {
		Gramatica GR = gramaticas [indice];
		Automato temp = GR.GetAutomato ();
		List<string> estados1 = new List<string>();
		List<string> simbolos = new List<string>();
		List<string[]> transicao = new List<string[]> ();
		HashSet<string> tempEstados1 = new HashSet<string> ();
		HashSet<string> tempSimbolos = new HashSet<string> ();
		foreach (var t in temp.transicoes) {
			Console.WriteLine (t.Value.estado1+" "+t.Value.simbolo);
			string estado = "";
			foreach (string s in temp.estadosFinais) {
				if (t.Value.estado1 == temp.estadoInicial) {
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
					if (h == temp.estadoInicial) {
						estado2 = "+" + h;
					} else if (h == s) {
						estado2 = "*" + h;
					} else if (h == temp.estadoInicial && h == s) {
						estado2 = "+*" + h;
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

	protected void OnConverterAFDEmGramticaActionActivated (object sender, EventArgs e) {
		ConverterAFDGR converter = new ConverterAFDGR (this);
	}

	public void coverterAFDGR(int indice) {
		Automato temp = automatos [indice];
		Gramatica GR = new Gramatica (temp);
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
			//if ((producao.Atual != "" && parte != "") && (producao.Atual != "" || parte != "")) {
			texto += producao.Atual+"->"+parte+"\r\n";
			//}
		}
		textview2.Buffer.Text = texto;
	}
}