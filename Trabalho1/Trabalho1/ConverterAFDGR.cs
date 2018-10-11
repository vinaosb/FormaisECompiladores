using System;
using Gtk;

namespace Trabalho1 {
	public partial class ConverterAFDGR : Gtk.Dialog {
		MainWindow janela;

		public ConverterAFDGR (MainWindow main) {
			this.Title = "Converter AFD em Gramática";
			this.janela = main;
			this.Build ();
		}

		protected void OnButtonCancelClicked (object sender, EventArgs e) {
			this.Hide();
		}

		protected void OnButtonOkClicked (object sender, EventArgs e) {
			janela.coverterAFDGR (Int32.Parse(entry2.Text));
			this.Hide();
		}
	}
}