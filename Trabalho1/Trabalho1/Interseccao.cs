/*
 * Universidade Federal de Santa Catarina
 * Departamento de Informática e Estatística
 * Trabalho de Linguagens Formais e Compiladores
 * Marcelo José Dias
 * Thiago Martendal Salvador
 * Vinicius Schwinden Berkenbrock
*/
using System;
using Gtk;

namespace Trabalho1 {
	/* Classe para fazer a intersecção de autômatos */
	public partial class Interseccao : Gtk.Dialog {
		MainWindow janela;
		public Interseccao (MainWindow main) {
			/* instancias */
			this.Title = "Intersecção de Autômatos";
			janela = main;
			this.Build ();
		}

		protected void OnButtonCancelClicked (object sender, EventArgs e) {
			this.Hide (); //Cancela
		}

		protected void OnButtonOkClicked (object sender, EventArgs e) {
			if (entry1.Text == entry2.Text) {
				/* Mensagem de erro caso as ids sejam iguais */
				MessageDialog msg = new MessageDialog (this, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Close, "Digite indices diferentes");
				msg.Run ();
				msg.Destroy ();
			} else {
				janela.interseccao (Int32.Parse(entry1.Text), Int32.Parse(entry2.Text)); //Envia ids para intersecção
				this.Hide (); //Fecha
			}
		}
	}
}

