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
	/* Classe para converter ER em AFD */
	public partial class ConverterERAFD : Gtk.Dialog {
		MainWindow janela;

		public ConverterERAFD (MainWindow main) {
			/* Dados da classe */
			this.Title = "Converter ER em AFD";
			this.janela = main;
			this.Build ();
		}


		protected void OnButtonCancelClicked (object sender, EventArgs e) {
			this.Hide(); //Cancela a operação
		}

		protected void OnButtonOkClicked (object sender, EventArgs e) {
			janela.limparEntradas (); //Limpa as entradas
			janela.converterER (Int32.Parse(entry1.Text)); //Passa o indice da ER na caixa de texto
			this.Hide(); //Fecha a janela
		}
	}
}

