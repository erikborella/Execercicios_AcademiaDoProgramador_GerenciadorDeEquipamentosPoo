using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeEquipamentosOO.Menus
{
    /// <summary>
    /// Ajudadores de diversos tipos para funções de terminal
    /// </summary>
    class Ajudadores
    {
        /// <summary>
        /// Imprime uma mensagem com o fundo vermelho
        /// </summary>
        /// <param name="mensagem">Mensagem a ser impressa</param>
        public static void ImprimirErro(string mensagem)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        /// <summary>
        /// Pede pro usuario digitar qualquer coisa para continuar
        /// </summary>
        public static void PausarConsole()
        {
            Console.Write("Digite qualquer coisa para Continuar: ");
            Console.ReadLine();
        }

        /// <summary>
        /// Verifica se uma opção é valida baseada em uma faixa de valores, ex: apenas as opções de 1-5 são validas
        /// </summary>
        /// <param name="opMin">Numero da opção de menor valor</param>
        /// <param name="opMax">Numero da opção de maior valor</param>
        /// <param name="op">Numero da opção escolhida</param>
        /// <returns>Se op está na faixa de valores de opções</returns>
        public static bool OpcaoEstaCorreta(int opMin, int opMax, int op)
        {
            return (op >= opMin && op <= opMax);
        }

        /// <summary>
        /// Lista as opções de um menu e pede pro usuario digitar aquele que ele quer, e
        /// verifica se ele digitou uma opção certa
        /// </summary>
        /// <param name="msg">Mensagem a ser impressa como menu</param>
        /// <param name="erroMsg">Mensagem a ser impressa quando o usuario digita algo invalido</param>
        /// <param name="opMin">Numero da opção minima</param>
        /// <param name="opMax">Numero da opção maxima</param>
        /// <returns>Opção escolhida pelo usuario</returns>
        public static int ListarEPegarSelecao(string msg, string erroMsg, int opMin, int opMax)
        {
            int opcao = opMin - 1;

            while (opcao <= opMin - 1)
            {
                Console.Write(msg);
                opcao = Leitores.LerInt();

                if (!OpcaoEstaCorreta(opMin, opMax, opcao))
                {
                    ImprimirErro(erroMsg);
                    opcao = opMin - 1;
                }
            }

            return opcao;
        }
    }
}
