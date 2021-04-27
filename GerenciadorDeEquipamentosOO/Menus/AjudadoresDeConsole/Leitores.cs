using System;

using static GerenciadorDeEquipamentosOO.Menus.Ajudadores;

namespace GerenciadorDeEquipamentosOO.Menus
{
    /// <summary>
    /// Classe de leitores de varios tipos de dados, já fazendo as suas validações
    /// </summary>
    class Leitores
    {
        /// <summary>
        /// Le uma <see cref="string"/> digita pelo usuario
        /// </summary>
        /// <returns><see cref="string"/> digitada pelo usuario</returns>
        public static string LerString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Le uma <see cref="string"/> digitada pelo usuario com um tamanho minimo
        /// </summary>
        /// <param name="tamanhoMinimo">Tamanho minimo que a <see cref="string"/> tem que ter</param>
        /// <returns><see cref="string"/> digitada pelo usuario o tamanho estabelecido</returns>
        public static string LerString(int tamanhoMinimo)
        {
            while (true)
            {
                string nome = Console.ReadLine();

                if (nome.Length < tamanhoMinimo)
                {
                    ImprimirErro($"Você precisa digitar no minimo {tamanhoMinimo} caracteres");
                    continue;
                }

                return nome;
            }
        }

        /// <summary>
        /// Lê um <see cref="double"/> digitado pelo usuario já fazendo a sua validação
        /// </summary>
        /// <returns><see cref="double"/> digitado pelo usuario</returns>
        public static double LerDouble()
        {
            while (true)
            {
                try
                {
                    double n = Convert.ToDouble(Console.ReadLine());

                    return n;
                }
                catch (Exception)
                {
                    ImprimirErro("Digite um numero!");
                    continue;
                }
            }
        }

        /// <summary>
        /// Lê um <see cref="int"/> digitado pelo usuario já fazendo a sua validação
        /// </summary>
        /// <returns><see cref="int"/> digitado pelo usuario</returns>
        public static int LerInt()
        {
            while (true)
            {
                try
                {
                    int n = Convert.ToInt32(Console.ReadLine());
                    return n;
                }
                catch (Exception)
                {
                    ImprimirErro("Digite um numero!");
                    continue;
                }
            }
        }

        /// <summary>
        /// Lê um <see cref="DateTime"/> digitado pelo usuario já fazendo a sua validação
        /// </summary>
        /// <returns><see cref="DateTime"/> digitado pelo usuario</returns>
        public static DateTime LerData()
        {
            while (true)
            {
                try
                {
                    string dataStr = Console.ReadLine();
                    DateTime data = DateTime.Parse(dataStr);

                    return data;
                }
                catch (Exception)
                {
                    ImprimirErro("Digite uma data no formato dd/mm/aaaa");
                    continue;
                }
            }
        }
    }
}
