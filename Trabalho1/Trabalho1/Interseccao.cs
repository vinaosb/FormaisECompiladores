using System;
using Gtk;

namespace Trabalho1 {
	public partial class Interseccao : Gtk.Dialog {
		MainWindow janela;
		public Interseccao (MainWindow main) {
			this.Title = "Intersecção de Autômatos";
			janela = main;
			this.Build ();
		}

		protected void OnButtonCancelClicked (object sender, EventArgs e) {
			this.Hide ();
		}

		protected void OnButtonOkClicked (object sender, EventArgs e) {
			if (entry1.Text == entry2.Text) {
				MessageDialog msg = new MessageDialog (this, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Close, "Digite indices diferentes");
				msg.Run ();
				msg.Destroy ();
			} else {
				janela.interseccao (Int32.Parse(entry1.Text), Int32.Parse(entry2.Text));
				this.Hide ();
			}
		}
	}
}

