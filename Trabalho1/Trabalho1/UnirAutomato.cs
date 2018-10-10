using System;
using Gtk;
using System.Collections.Generic;

namespace Trabalho1 {
	public partial class UnirAutomato : Gtk.Dialog {
		MainWindow janela;
		public UnirAutomato (MainWindow main) {
			this.Title = "Unir Autômatos";
			janela = main;
			this.Build ();
		}

		protected void OnButtonOkClicked (object sender, EventArgs e) {
			if (entry1.Text == entry2.Text) {
				MessageDialog msg = new MessageDialog (this, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Close, "Digite indices diferentes");
				msg.Run ();
				msg.Destroy ();
			} else {
				janela.uniao (Int32.Parse(entry1.Text), Int32.Parse(entry2.Text));
				this.Hide ();
			}
		}
	}
}