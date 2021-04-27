using System;
using System.Collections.Generic;
using System.Text;

using GerenciadorDeEquipamentosOO.Modelos;

namespace GerenciadorDeEquipamentosOO.Menus
{
    /// <summary>
    /// Gera listas baseadas nos objetos e em seus id's
    /// </summary>
    class GeradoresDeListaDeObjetos
    {
        /// <summary>
        /// Gera uma lista baseada em <see cref="Equipamento"/>
        /// </summary>
        /// <param name="equipamentos">Lista de equipamentos</param>
        /// <returns><see cref="string"/> listando todos os equipametos e seus id's</returns>
        public static string GerarLista(Equipamento[] equipamentos)
        {
            StringBuilder saida = new StringBuilder();

            if (equipamentos.Length == 0)
                saida.Append("Nenhum Equipamento cadastrado");

            foreach (Equipamento equipamento in equipamentos)
            {
                saida.Append($"{equipamento.Id}. {equipamento.Nome}");
                saida.AppendLine();
            }

            return saida.ToString();
        }

        /// <summary>
        /// Gera uma lista baseada em <see cref="Chamado"/>
        /// </summary>
        /// <param name="chamados">Lista de chamados</param>
        /// <returns><see cref="string"/> listando todos os chamado e seus id's</returns>
        public static string GerarLista(Chamado[] chamados)
        {
            StringBuilder saida = new StringBuilder();

            if (chamados.Length == 0)
                saida.Append("Nenhum Equipamento cadastrado");

            foreach (Chamado chamado in chamados)
            {
                saida.Append($"{chamado.Id}. {chamado.Titulo}");
                saida.AppendLine();
            }

            return saida.ToString();
        }
    }
}
