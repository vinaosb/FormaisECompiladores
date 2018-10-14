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
	/* Classe para converter AFD em GR */
	public partial class ConverterAFDGR : Gtk.Dialog {
		MainWindow janela;

		public ConverterAFDGR (MainWindow main) {
			/* Instancias */
			this.Title = "Converter AFD em Gramática";
			this.janela = main;
			this.Build ();
		}

		protected void OnButtonCancelClicked (object sender, EventArgs e) {
			this.Hide(); //Cancela
		}

		protected void OnButtonOkClicked (object sender, EventArgs e) {
			janela.coverterAFDGR (Int32.Parse(entry2.Text)); //Passa id do autômato para conversão
			this.Hide(); //Fecha
		}
	}
}