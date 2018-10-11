using System;
using Gtk;

namespace Trabalho1 {
	public partial class AdicionarGramatica : Gtk.Dialog {
		MainWindow janela;

		public AdicionarGramatica (MainWindow main) {
			janela = main;
			this.Title = "Nova Gramática";
			this.Build ();
		}

		protected void OnButtonCancelClicked (object sender, EventArgs e) {
			this.Hide ();
		}

		protected void OnButtonOkClicked (object sender, EventArgs e) {
			janela.atualizarGramatica (textview1.Buffer.Text);
			this.Hide ();
		}
	}
}

