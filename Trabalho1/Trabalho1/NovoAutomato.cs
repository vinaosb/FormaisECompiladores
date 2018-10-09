using System;
using Gtk;
using System.Collections.Generic;

namespace Trabalho1 {
	public partial class NovoAutomato : Gtk.Dialog {
		MainWindow janela;

		public NovoAutomato (MainWindow main) {
			janela = main;
			this.Title = "Novo Autômato";
			this.Build ();
		}

		protected void OnButtonOkClicked (object sender, EventArgs e) {
			string[] vetorEstados = entry2.Text.Split(' ');
			string[] vetorSimbolos = entry3.Text.Split (' ');
			janela.atualizarAutomato (vetorEstados, vetorSimbolos);
			this.Hide ();
		}

		protected void OnButtonCancelClicked (object sender, EventArgs e) {
			this.Hide ();
		}
	}
}
