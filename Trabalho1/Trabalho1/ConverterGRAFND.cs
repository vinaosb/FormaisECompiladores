using System;
using Gtk;

namespace Trabalho1 {
	public partial class ConverterGRAFND : Gtk.Dialog {
		MainWindow janela;

		public ConverterGRAFND (MainWindow main) {
			this.Title = "Converter Gramática em AFND";
			janela = main;
			this.Build ();
		}


		protected void OnButtonCancelClicked (object sender, EventArgs e) {
			this.Hide ();
		}

		protected void OnButtonOkClicked (object sender, EventArgs e) {
			janela.limparEntradas ();
			janela.converterGRAFND (Int32.Parse(entry1.Text));
			this.Hide ();
		}
	}
}

