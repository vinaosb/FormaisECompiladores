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
	/* Classe para criar um novo autômato */
	public partial class NovoAutomato : Gtk.Dialog {
		MainWindow janela;

		public NovoAutomato (MainWindow main) {
			/* instancias */
			janela = main;
			this.Title = "Novo Autômato";
			this.Build ();
		}

		protected void OnButtonOkClicked (object sender, EventArgs e) {
			string[] vetorEstados = entry2.Text.Split(' '); //Obtem os estados da caixa de texto
			string[] vetorSimbolos = entry3.Text.Split (' '); //Obtem os simbolos de transição da caixa de texto
			janela.limparEntradas (); //Limpa entradas do autômato
			janela.atualizarAutomato (vetorEstados, vetorSimbolos); //Atualiza a tabela com autômato
			this.Hide (); //Fecha
		}

		protected void OnButtonCancelClicked (object sender, EventArgs e) {
			this.Hide (); //Cancela
		}
	}
}
