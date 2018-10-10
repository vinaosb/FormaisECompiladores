using System;
using Gtk;

namespace Trabalho1 {
	public partial class ConverterERAFD : Gtk.Dialog {
		MainWindow janela;

		public ConverterERAFD (MainWindow main) {
			this.Title = "Converter ER em AFD";
			this.janela = main;
			this.Build ();
		}


		protected void OnButtonCancelClicked (object sender, EventArgs e) {
			this.Hide();
		}

		protected void OnButtonOkClicked (object sender, EventArgs e) {
			janela.converterER (Int32.Parse(entry1.Text));
			this.Hide();
		}
	}
}

