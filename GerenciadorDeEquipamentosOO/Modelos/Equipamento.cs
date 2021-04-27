using System;
using System.Collections.Generic;

using GerenciadorDeEquipamentosOO.ids;

namespace GerenciadorDeEquipamentosOO.Modelos
{
    /// <summary>
    /// Um equipamento
    /// </summary>
    class Equipamento
    {
        private int id;
        private double precoAquisicao;
        private string nome;
        private string fabricante;
        private DateTime dataDeFabricacao;
        private List<Chamado> chamados = new List<Chamado>();


        public int Id 
        { 
            get => id; 
        }

        public double PrecoAquisicao
        { 
            get => precoAquisicao;
        }

        public string Nome
        { 
            get => nome; 
        }

        public string Fabricante 
        { 
            get => fabricante;
        }

        public DateTime DataDeFabricacao 
        { 
            get => dataDeFabricacao; 
        }

        /// <summary>
        /// Cria um novo equipamento com um id unico
        /// </summary>
        /// <param name="nome">Nome do equipamento</param>
        /// <param name="precoAquisicao">Preço de aquisição do equipamento</param>
        /// <param name="dataDeFabricacao">Data de fabricação do equipamento</param>
        /// <param name="fabricante">Fabricante do equipamento</param>
        public Equipamento(string nome, double precoAquisicao, DateTime dataDeFabricacao, string fabricante)
        {
            this.id = GeradorDeIdsEquipamento.PegarId();
            this.nome = nome;
            this.dataDeFabricacao = dataDeFabricacao;
            this.precoAquisicao = precoAquisicao;
            this.fabricante = fabricante;
        }

        /// <summary>
        /// Edita o equipametno
        /// </summary>
        /// <param name="nome">novo Nome do equipamento</param>
        /// <param name="precoAquisicao">novo Preço de aquisição do equipamento</param>
        /// <param name="dataDeFabricacao">nova Data de fabricação do equipamento</param>
        /// <param name="fabricante">nova Fabricante do equipamento</param>
        public void Editar(string nome, double precoAquisicao, DateTime dataDeFabricacao, string fabricante)
        {
            this.nome = nome;
            this.dataDeFabricacao = dataDeFabricacao;
            this.precoAquisicao = precoAquisicao;
            this.fabricante = fabricante;
        }

        /// <summary>
        /// Abre um <see cref="Chamado"/> neste equipamento
        /// </summary>
        /// <param name="tituloChamado">Titulo do chamado</param>
        /// <param name="descricaoChamado">Descrição do chamado</param>
        public void AbrirChamado(string tituloChamado, string descricaoChamado)
        {
            Chamado novoChamado = new Chamado(tituloChamado, descricaoChamado);
            chamados.Add(novoChamado);
        }

        /// <summary>
        /// Exclui um dos chamados vinculados a esse equipamento
        /// </summary>
        /// <param name="idChamado">Id do chamado a ser excluido</param>
        /// <returns>foi possivel excluir o chamado</returns>
        public bool ExcluirChamado(int idChamado)
        {
            for (int i = 0; i < chamados.Count; i++)
            {
                if (chamados[i].Id == idChamado)
                {
                    chamados.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Retorna uma lista de todos os <see cref="Chamado"/> vinculados a esse equipamento
        /// </summary>
        /// <returns>Chamados vinculados a esse equipamento</returns>
        public Chamado[] ListarChamados()
        {
            return chamados.ToArray();
        }

        /// <summary>
        /// Retorna um chamado vinculado a esse equipametno baseado em seu id
        /// </summary>
        /// <param name="idChamado">id do chamado selecionado</param>
        /// <returns>Null se não foi encontrado o chamado, ou o chamado caso tenha sido encontrado</returns>
        public Chamado ConsultarChamado(int idChamado)
        {
            for (int i = 0; i < chamados.Count; i++)
            {
                if (chamados[i].Id == idChamado)
                {
                    return chamados[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Retorna uma representação de todos os dados uteis a este equipamento
        /// </summary>
        /// <returns>Representação dos dados deste equipamento</returns>
        public override string ToString()
        {
            return $"id: {id}\n" +
                $"nome: {nome}\n" +
                $"Preço de Aquicição: {precoAquisicao}\n" +
                $"Data de Fabricaçãp: {dataDeFabricacao}\n" +
                $"Fabricante: {fabricante}\n" +
                $"N. Chamados Abertos: {chamados.Count}";
        }
    }
}
