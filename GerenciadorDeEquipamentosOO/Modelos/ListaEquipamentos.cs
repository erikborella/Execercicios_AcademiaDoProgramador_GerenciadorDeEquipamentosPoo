using System;
using System.Collections.Generic;

using GerenciadorDeEquipamentosOO.Modelos;

namespace GerenciadorDeEquipamentosOO
{
    /// <summary>
    /// Classe para manter uma lista de varios <see cref="Equipamento"/> e fornecer opcções para manipula-los
    /// </summary>
    class ListaEquipamentos
    {
        private List<Equipamento> equipamentos = new List<Equipamento>();

        /// <summary>
        /// Cria um novo <see cref="Equipamento"/>
        /// </summary>
        /// <param name="nome">Nome do equipamento</param>
        /// <param name="precoAquisicao">preço de aquisição do equipamento</param>
        /// <param name="dataDeFabricacao">Data de Fabricação do equipamento</param>
        /// <param name="fabricante">Fabricante do equipamento</param>
        public void RegistrarEquipamento(string nome, double precoAquisicao, DateTime dataDeFabricacao, string fabricante)
        {
            Equipamento novoEquipamento = new Equipamento(nome, precoAquisicao, dataDeFabricacao, fabricante);
            equipamentos.Add(novoEquipamento);
        }

        /// <summary>
        /// Exclui um <see cref="Equipamento"/> baseado em seu <see cref="Equipamento.id"/>
        /// </summary>
        /// <param name="idEquipamento">id do equipamento</param>
        /// <returns>Se foi possivel excluir o equiapamento</returns>
        public bool ExcluirEquipamento(int idEquipamento)
        {
            for (int i = 0; i < equipamentos.Count; i++)
            {
                if (equipamentos[i].Id == idEquipamento)
                {
                    equipamentos.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Cria uma lista de todos os <see cref="Equipamento"/> registrados nesta lista de equipamentos
        /// </summary>
        /// <returns>Lista de todos os equipamentos registrados</returns>
        public Equipamento[] ListarEquipamentos()
        {
            return equipamentos.ToArray();
        }

        /// <summary>
        /// Permite ver um <see cref="Equipamento"/> em especifico baseado em seu <see cref="Equipamento.id"/>
        /// </summary>
        /// <param name="idEquipamento">Id do equipamento</param>
        /// <returns>Null se não foi possivel encontra-lo, ou o proprio Equipamento se foi</returns>
        public Equipamento ConsultarEquipamento(int idEquipamento)
        {
            for (int i = 0; i < equipamentos.Count; i++)
            {
                if (equipamentos[i].Id == idEquipamento)
                {
                    return equipamentos[i];
                }
            }
            return null;
        }
    }
}
