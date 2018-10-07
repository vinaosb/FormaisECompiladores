using System;
using Gtk;
using Trabalho1;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window {
	private NovoAutomato novo;
	private Table tabela;
	private List<ElementosAutomato> entradas;
	private List<Automato> automatos;
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
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a) {
		Application.Quit ();
		a.RetVal = true;
	}

	protected void inserirAutomato (object sender, EventArgs e) {
		novo = new NovoAutomato (this);
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

	private void atualizarListaAutomatos() {
		combobox1.AppendText ("Autômato "+(automatos.Count-1).ToString());
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
		HashSet<string> e2 = new HashSet<string> ();
		for (int i = 0; i < entradas.Count; i++) {
			temp.addEstado (entradas [i].estado1);
			temp.addSimbolo (entradas [i].simbolo);
			e2.Add (entradas [i].estado2.Text);
			foreach (string x in e2) {
				//Console.WriteLine (entradas [i].estado1+" "+entradas [i].simbolo+" "+x);
			}
			temp.addTransicao (entradas [i].estado1, entradas [i].simbolo, e2);
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
			tempEstados1.Add (t.Value.estado1);
			tempSimbolos.Add (t.Value.simbolo);
			foreach (string h in t.Value.estado2) {
				string[] chave = {t.Value.estado1, t.Value.simbolo, h};
				Console.WriteLine (t.Value.estado1+" "+t.Value.simbolo+" "+h);
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

}