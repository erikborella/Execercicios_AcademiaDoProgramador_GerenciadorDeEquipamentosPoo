using System;

using GerenciadorDeEquipamentosOO.ids;

namespace GerenciadorDeEquipamentosOO.Modelos
{
    /// <summary>
    /// Um chamado
    /// </summary>
    class Chamado
    {
        private int id;
        private string titulo;
        private string descricao;
        private DateTime dataDeAbertura;

        public int Id
        {
            get => id;
        }

        public string Titulo
        {
            get => titulo;
        }

        public string Descricao
        {
            get => descricao;
        }

        public DateTime DataDeAbertura
        {
            get => dataDeAbertura;
        }

        /// <summary>
        /// Cria um chamado com a <see cref="dataDeAbertura"/> atual
        /// </summary>
        /// <param name="titulo">nome do chamado</param>
        /// <param name="descricao">descrição do chamado</param>
        public Chamado(string titulo, string descricao)
        {
            this.id = GeradorDeIdsChamado.PegarId();
            this.titulo = titulo;
            this.descricao = descricao;
            this.dataDeAbertura = DateTime.Now;
        }

        /// <summary>
        /// Edita o chamado
        /// </summary>
        /// <param name="titulo">novo titulo do chamado</param>
        /// <param name="descricao">nova descrição do chamado</param>
        public void Editar(string titulo, string descricao)
        {
            this.titulo = titulo;
            this.descricao = descricao;
        }

        /// <summary>
        /// Retornar quantos dias estão abertos desde a <see cref="dataDeAbertura"/> até hoje
        /// </summary>
        /// <returns>Dias abertos</returns>
        public int PegarDiasAbertos()
        {
            DateTime dataHoje = DateTime.Now;
            TimeSpan diferenca = dataHoje - dataDeAbertura;

            return Convert.ToInt32(diferenca.TotalDays);
        }

        /// <summary>
        /// Gera uma representação de dados uteis do chamado
        /// </summary>
        /// <returns>representação dos dados do chamado</returns>
        public override string ToString()
        {
            return $"id: {id}\n" +
                $"Titulo: {titulo}\n" +
                $"Descrição: {descricao}\n" +
                $"Data De Abertura: {dataDeAbertura}\n" +
                $"Dias Abertos: {PegarDiasAbertos()}";
        }
    }
}
