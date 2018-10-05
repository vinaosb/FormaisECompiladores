using System;
using Gtk;
using Trabalho1;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window {
	private NovoAutomato novo;

	public MainWindow () : base (Gtk.WindowType.Toplevel) {
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a) {
		Application.Quit ();
		a.RetVal = true;
	}

	protected void inserirAutomato (object sender, EventArgs e) {
		novo = new NovoAutomato (this);
	}

	public void atualizarAutomato(string[] vetorEstados, string[] vetorSimbolos) {
		Table tabela = new Table((uint)vetorEstados.Length, (uint)vetorSimbolos.Length, false);
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
			}
		}
		tabela.Show();
	}

	protected void OnAutomatoAction1Activated (object sender, EventArgs e) {
        Crud crud = new Crud("Automato");
	}

	protected void OnAutomatoActionActivated (object sender, EventArgs e) {
		Crud crud = new Crud("Automato");
	}

	protected void OnDeterminizarAutmatoActionActivated (object sender, EventArgs e) {
		
	}
}
