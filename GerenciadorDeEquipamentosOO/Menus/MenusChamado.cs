using System;

using GerenciadorDeEquipamentosOO.Modelos;

namespace GerenciadorDeEquipamentosOO.Menus
{
    /// <summary>
    /// Menus para o fluxo expecifico para tarefas voltadas aos <see cref="Chamado"/>
    /// </summary>
    class MenusChamado
    {
        Equipamento equipamento;

        /// <summary>
        /// Cria um novo fluxo com um <see cref="Equipamento"/> como contexto de trabalho
        /// </summary>
        /// <param name="equipamento">Contexto de trabalho</param>
        public MenusChamado(Equipamento equipamento)
        {
            this.equipamento = equipamento;
        }

        /// <summary>
        /// Pede pro usuario digitar informações acerca de um <see cref="Chamado"/> 
        /// e depois o adicionao ao <see cref="equipamento"/>
        /// </summary>
        public void AbrirChamado()
        {
            Console.Clear();

            Console.Write("Digite o titulo do chamado: ");
            string titulo = Leitores.LerString();

            Console.Write("Digite a descricao do chamado: ");
            string descricao = Leitores.LerString();

            equipamento.AbrirChamado(titulo, descricao);
        }

        /// <summary>
        /// Mostra uma lista de todos os <see cref="Chamado"/> abertos em <see cref="equipamento"/> e
        /// depois pede pro usuario escolher um pra excluir
        /// </summary>
        public void ExcluirChamado()
        {
            while (true)
            {
                Console.Clear();

                Chamado[] chamados = equipamento.ListarChamados();
                Console.WriteLine(GeradoresDeListaDeObjetos.GerarLista(chamados));

                Console.Write("Digite qual chamado você deseja excluir ou digite 0 para sair: ");
                int idChamado = Leitores.LerInt();

                if (idChamado == 0)
                    break;

                if (equipamento.ExcluirChamado(idChamado))
                {
                    Console.WriteLine("Chamado excluido com sucesso");
                    Ajudadores.PausarConsole();
                }
                else
                {
                    Ajudadores.ImprimirErro("Você selecionou um chamado invalido");
                    Ajudadores.PausarConsole();
                }
            }
        }

        /// <summary>
        /// Mostra uma lista de todos os <see cref="Chamado"/> no <see cref="equipamento"/> e depois pede pro usuario escolher um
        /// e o manda para o <see cref="PrincipalChamado(Chamado)"/>
        /// </summary>
        public void SelecaoChamado()
        {
            while (true)
            {
                Console.Clear();

                Chamado[] chamados = equipamento.ListarChamados();
                Console.WriteLine(GeradoresDeListaDeObjetos.GerarLista(chamados));

                Console.Write("Digite qual equipamento você dejseja consultar ou 0 para voltar: ");
                int idChamado = Leitores.LerInt();

                if (idChamado == 0)
                    break;

                Chamado chamado = equipamento.ConsultarChamado(idChamado);

                if (chamado != null)
                {
                    PrincipalChamado(chamado);
                }
                else
                {
                    Ajudadores.ImprimirErro("Você selecionou um chamado invalido");
                    Ajudadores.PausarConsole();
                }
            }
        }

        /// <summary>
        /// Menu principal acerta de um <see cref="Chamado"/>,
        /// permite edita-lo
        /// </summary>
        /// <param name="chamado">Contexto de trabalho</param>
        private void PrincipalChamado(Chamado chamado)
        {
            bool noMenu = true;
            while (noMenu)
            {
                Console.Clear();

                Console.WriteLine(chamado);
                Console.WriteLine();

                int opcao = Ajudadores.ListarEPegarSelecao(
                    "1. Editar Chamado\n" +
                    "2. Voltar\n" +
                    "Digite o que deseja fazer: ",
                    "Você digitou uma opcao invalida",
                    1, 2);

                switch (opcao)
                {
                    case 1:
                        EditarChamado(chamado);
                        break;
                    case 2:
                        noMenu = false;
                        break;
                }

            }
        }

        /// <summary>
        /// Pede pro usuario digitar informações acerca de um <see cref="Chamado"/> e depois modifico os valores
        /// do <see cref="Chamado"/> escolhido
        /// </summary>
        /// <param name="chamado">Chamado para ser editado</param>
        private void EditarChamado(Chamado chamado)
        {
            Console.Clear();

            Console.Write("Digite o titulo do chamado: ");
            string titulo = Leitores.LerString();

            Console.Write("Digite a descricao do chamado: ");
            string descricao = Leitores.LerString();

            chamado.Editar(titulo, descricao);
        }

    }
}
