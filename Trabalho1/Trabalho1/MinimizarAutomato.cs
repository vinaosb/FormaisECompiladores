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
	/* Classe para minimizar autômatos */
	public partial class MinimizarAutomato : Gtk.Dialog {
		MainWindow janela;

		public MinimizarAutomato (MainWindow main) {
			//Instancias
			janela = main;
			this.Title = "Minimizar Autômato";
			this.Build ();
		}

		protected void OnButtonCancelClicked (object sender, EventArgs e) {
			this.Hide(); //Cancela
		}

		protected void OnButtonOkClicked (object sender, EventArgs e) {
			janela.limparEntradas (); //Limpa entradas do autômatos
			janela.minimizacao (Int32.Parse(entry1.Text)); //Envia o id para a minimização
			this.Hide(); //Fecha
		}
	}
}