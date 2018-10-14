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
using System.Collections.Generic;

namespace Trabalho1 {
	/* Classe para unir autômatos */
	public partial class UnirAutomato : Gtk.Dialog {
		MainWindow janela;
		public UnirAutomato (MainWindow main) {
			/* Instancias */
			this.Title = "Unir Autômatos";
			janela = main;
			this.Build ();
		}

		protected void OnButtonOkClicked (object sender, EventArgs e) {
			janela.limparEntradas (); //Limpa entradas do autômato
			if (entry1.Text == entry2.Text) {
				/* Mensagem de erro se as entradas forem iguais */
				MessageDialog msg = new MessageDialog (this, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Close, "Digite indices diferentes");
				msg.Run ();
				msg.Destroy ();
			} else {
				janela.limparEntradas ();
				janela.uniao (Int32.Parse(entry1.Text), Int32.Parse(entry2.Text)); //Passa os ids para fazer a união
				this.Hide (); //Fecha
			}
		}

		protected void OnButtonCancelClicked (object sender, EventArgs e) {
			this.Hide (); //Cancela
		}
	}
}