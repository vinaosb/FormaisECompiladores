using System;
using System.Collections.Generic;

namespace Trabalho1 {
	public class Automato {
		private string estadoInicial;
		private HashSet<string> estadosFinais;
		private HashSet<Transicao> transicoes;

		private struct Transicao {
			public string estado1;
			public string simbolo;
			public string estado2;
		}

		public Automato () {
			
		}

		public void setEstadoInicial(string estadoInicial) {
			this.estadoInicial = estadoInicial;
			procuraEstadosFinais ();
		}

		private void procuraEstadosFinais() {
			if (estadoInicial.Contains("*")) {
				this.estadosFinais.Add (estadoInicial);
			}
			for (int i = 0; i < transicoes.Count; i++) {
				Transicao T = transicoes [i];
				if (T.estado1.Contains("*")) {
					this.estadosFinais.Add (T.estado1);
				}
				if (T.estado2.Contains("*")) {
					this.estadosFinais.Add (T.estado2);
				}
			}
		}

		public void setTransicao(string estado1, string simbolo, string estado2) {
			Transicao T = new Transicao ();
			T.estado1 = estado1;
			T.simbolo = simbolo;
			T.estado2 = estado2;
		}

		public string getEstadoInicial() {
			return estadoInicial;
		}
	
		public HashSet<string> getEstadosFinais() {
			return estadosFinais;
		}

		public HashSet<Transicao> getTransicoes() {
			return transicoes;
		}
	}
}