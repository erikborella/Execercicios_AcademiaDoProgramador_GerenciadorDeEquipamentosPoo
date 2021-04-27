using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeEquipamentosOO.ids
{
    /// <summary>
    /// Gera id's unicos para os <see cref="Chamado"/>
    /// </summary>
    class GeradorDeIdsChamado
    {
        private static int idAtual = 0;

        /// <summary>
        /// Cria um id unico
        /// </summary>
        /// <returns>id unico</returns>
        public static int PegarId()
        {
            return ++idAtual;
        }
    }
}
