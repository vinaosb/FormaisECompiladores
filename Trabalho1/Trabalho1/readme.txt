Universidade Federal de Santa Catarina
Departamento de Informática e Estatística
Marcelo José Dias, Thiago Martendal Salvador, Vinícius Schwinden Berkenbrock

Pré requisitos do programa

O programa foi feito em C# usando Mono para compilar
Deve rodar em qualquer sistema operacional (TESTADO EM LINUX), caso não funcione, favor instale o runtime do Mono

O programa possui uma interface gráfica que deixa gerar Autômatos Finitos, Gramáticas Regulares e Expressões Regulares

Nelas ele deixa realizar:
• Edição, leitura e gravação de AF, GR e ER
• Conversão de AFND para AFD
• Conversão de AFD para GR e de GR para AFND
• Conversão de ER para AFD (usando o algoritmo baseado em árvore sintática - Livro Aho - seção 3.9)
• Minimização de AFD
• União de AFD

Notações Usadas para gerar:
GR:
	S -> A | aA | bB| a

AF:
	Gera diretamente a tabela de transições e adiciona as transiçoes necessárias automaticamente

ER:
	Expressões sempre utilizando sinal de concatenação '.' e terminando com '#'.
	Exemplo: (a|b)*.b.(a|b).#
	+ e ? não são permitidos.

