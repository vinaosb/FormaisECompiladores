using System;
using Gtk;

namespace Trabalho1 {
	public partial class MinimizarAutomato : Gtk.Dialog {
		MainWindow janela;

		public MinimizarAutomato (MainWindow main) {
			janela = main;
			this.Title = "Minimizar Autômato";
			this.Build ();
		}

		protected void OnButtonCancelClicked (object sender, EventArgs e) {
			this.Hide();
		}

		protected void OnButtonOkClicked (object sender, EventArgs e) {
			janela.minimizacao (Int32.Parse(entry1.Text));
			this.Hide();
		}
	}
}