using System;
using Gtk;
using Trabalho1;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window {
	private Table tabela;
	private List<ElementosAutomato> entradas;
	public List<Automato> automatos;
	public List<Gramatica> gramaticas;
	private bool temTabela = false;

	struct ElementosAutomato {
		public string estado1;
		public Entry estado2;
		public string simbolo;
	}

	public MainWindow () : base (Gtk.WindowType.Toplevel) {
		Build ();
		entradas = new List<ElementosAutomato>();
		automatos = new List<Automato> ();
		gramaticas = new List<Gramatica> ();
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
				/*ElementosAutomato elementos = new ElementosAutomato ();
				elementos.estado1 = vetorEstados [j];
				elementos.estado2 = txt;
				elementos.simbolo = vetorSimbolos [i];
				entradas.Add (elementos);*/
			}
		}
		tabela.Show();
		temTabela = true;
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
			combobox1.AppendText("Autômato " + (i).ToString ());
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
		Automato temp = new Automato (automatos.Count);
		for (int i = 0; i < entradas.Count; i++) {
			temp.addEstado (entradas [i].estado1);
			temp.addEstado (entradas [i].estado2.Text);
			temp.addSimbolo (entradas [i].simbolo);
			temp.addTransicao(entradas [i].estado1, entradas [i].simbolo, entradas [i].estado2.Text);
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
		abrirAutomato (estados1, simbolos, transicao);
	}
		
	protected void OnGramticaRegularActionActivated (object sender, EventArgs e) {
		AdicionarGramatica adGramatica = new AdicionarGramatica (this);
	}

	public void atualizarListaGramaticas() {
		for (int i = 0; i < gramaticas.Count; i++) {
			combobox2.AppendText ("Gramática " + (i).ToString ());
		}
	}

	protected void OnButton230Clicked (object sender, EventArgs e) {
		string[] temp = textview2.Buffer.Text.Split(new [] { '\r', '\n' });
		Gramatica gramatica = new Gramatica ();
		for (int i = 0; i < temp.Length; i++) {
			Gramatica.Regular regular = new Gramatica.Regular ();
			string[] temp2 = temp [i].Split(new string[] { "->" }, StringSplitOptions.None);
			regular.Atual = temp2 [0];
			List<string> proximos = new List<string> ();
			for (int j = 0; j < temp2.Length; j++) {
				if (!temp2 [j].Contains ("|")) {
					if (!proximos.Contains (temp2 [1])) {
						proximos.Add (temp2 [1]);
					}
				}
			}
			regular.Proximos = proximos;
			gramatica.AddProducao (regular);
		}
		gramaticas.Add (gramatica);
		atualizarListaGramaticas ();
	}

	protected void OnCombobox2Changed (object sender, EventArgs e) {
		string[] indice = combobox2.ActiveText.Split (' ');
		Gramatica temp = gramaticas[Int32.Parse(indice[1])];
		string texto = "";
		for (int j = 0; j < temp.Producoes.Count; j++) {
			for (int k = 0; k < temp.Producoes[j].Proximos.Count; k++) {
				texto += temp.Producoes [j].Atual + "->" + temp.Producoes [j].Proximos [k]+"\n";
			}
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

}