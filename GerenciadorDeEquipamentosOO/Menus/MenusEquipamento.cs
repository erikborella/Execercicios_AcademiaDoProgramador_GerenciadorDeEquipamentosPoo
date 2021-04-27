using System;

using GerenciadorDeEquipamentosOO.Modelos;

namespace GerenciadorDeEquipamentosOO.Menus
{
    /// <summary>
    /// Menus para o fluxo especifico de menus voltadas aos <see cref="Equipamento"/>
    /// </summary>
    class MenusEquipamento
    {
        private ListaEquipamentos listaEquipamentos;

        /// <summary>
        /// Cria um novo fluxo de menus para <see cref="Equipamento"/> com um contexto de uma <see cref="ListaEquipamentos"/>
        /// </summary>
        /// <param name="listaEquipamentos">Contexto de trabalho do fluxo</param>
        public MenusEquipamento(ListaEquipamentos listaEquipamentos)
        {
            this.listaEquipamentos = listaEquipamentos;
        }

        /// <summary>
        /// Pede pro usuario digitar informações para criar um <see cref="Equipamento"/>, 
        /// e depois o adiciona a <see cref="listaEquipamentos"/>
        /// </summary>
        public void CriarEquipamento()
        {
            Console.Clear();

            Console.Write("Digite o nome do equipamento: ");
            string nome = Leitores.LerString(6);

            Console.Write("Digite o preco de aquicição: ");
            double precoAquisicao = Leitores.LerDouble();

            Console.Write("Digite a data de fabricação: ");
            DateTime dataDeFabricacao = Leitores.LerData();

            Console.Write("Digite a fabricante: ");
            string fabricante = Leitores.LerString();

            listaEquipamentos.RegistrarEquipamento(nome, precoAquisicao, dataDeFabricacao, fabricante);
        }

        /// <summary>
        /// Mostra uma lista de todos os <see cref="Equipamento"/> da <see cref="listaEquipamentos"/>
        /// e pede pro usuario deletar aquele que ele quiser
        /// </summary>
        public void ExcluirEquipamento()
        {
            while (true)
            {
                Console.Clear();

                Equipamento[] equipamentos = listaEquipamentos.ListarEquipamentos();
                Console.WriteLine(GeradoresDeListaDeObjetos.GerarLista(equipamentos));

                Console.Write("Digite qual equipamento deseja exluir ou digite 0 para voltar: ");
                int equipamentoId = Leitores.LerInt();

                if (equipamentoId == 0)
                    break;

                if (listaEquipamentos.ExcluirEquipamento(equipamentoId))
                {
                    Console.WriteLine("Equipamento Excluido com sucesso");
                    Ajudadores.PausarConsole();
                }
                else
                {
                    Ajudadores.ImprimirErro("Voce selecionou um equipamento invalido");
                    Ajudadores.PausarConsole();
                }
            }
        }

        /// <summary>
        /// Mostra uma lista com todos os <see cref="Equipamento"/> cadastrados e pede pro usuario escolher um,
        /// depois o leva para o Menu principal dos Equipamentos
        /// <seealso cref="PrincipalEquipamento(Equipamento)"/>
        /// </summary>
        public void SelecaoEquipamento()
        {
            while (true)
            {
                Console.Clear();

                Equipamento[] equipamentos = listaEquipamentos.ListarEquipamentos();
                Console.WriteLine(GeradoresDeListaDeObjetos.GerarLista(equipamentos));

                Console.Write("Digite qual equipamento você deseja selecionar, ou digite 0 para voltar: ");
                int equipamentoId = Leitores.LerInt();

                if (equipamentoId == 0)
                    break;

                Equipamento equipamentoSelecionado = listaEquipamentos.ConsultarEquipamento(equipamentoId);

                if (equipamentoSelecionado != null)
                {
                    PrincipalEquipamento(equipamentoSelecionado);
                }
                else
                {
                    Ajudadores.ImprimirErro("Você selecionou um equipamento invalido");
                    Ajudadores.PausarConsole();
                }
            }
        }

        /// <summary>
        /// Menu princial de um <see cref="Equipamento"/>, permitindo manipular os seus <see cref="Chamado"/>
        /// e tambem em edita-lo
        /// </summary>
        /// <param name="equipamento">Equipamento em contexto</param>
        private void PrincipalEquipamento(Equipamento equipamento)
        {
            MenusChamado menusChamado = new MenusChamado(equipamento);
            bool noMenu = true;
            while (noMenu)
            {
                Console.Clear();

                Console.WriteLine(equipamento);
                Console.WriteLine();

                int opcao = Ajudadores.ListarEPegarSelecao(
                    "1. Editar Equipamento\n" +
                    "2. Consultar Chamado\n" +
                    "3. Abrir Chamado\n" +
                    "4. Excluir Chamado\n" +
                    "5. Voltar\n" +
                    "Digite o que deseja fazer: ",
                    "Você digitou uma opção incorreta, tente novamente",
                    1, 5);

                switch (opcao)
                {
                    case 1:
                        EditarEquipamento(equipamento);
                        break;
                    case 2:
                        menusChamado.SelecaoChamado();
                        break;
                    case 3:
                        menusChamado.AbrirChamado();
                        break;
                    case 4:
                        menusChamado.ExcluirChamado();
                        break;
                    case 5:
                        noMenu = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Pede pro usuario digitar novas informações sobre um <see cref="Equipamento"/> e
        /// depois altera as suas informações
        /// </summary>
        /// <param name="equipamento">Equipamento em contexto</param>
        private void EditarEquipamento(Equipamento equipamento)
        {
            Console.Clear();

            Console.Write("Digite o nome do equiapamento: ");
            string nome = Leitores.LerString(6);

            Console.Write("Digite o preco de aquicição: ");
            double precoAquisicao = Leitores.LerDouble();

            Console.Write("Digite a data de fabricação: ");
            DateTime dataDeFabricacao = Leitores.LerData();

            Console.Write("Digite a fabricante: ");
            string fabricante = Leitores.LerString();

            equipamento.Editar(nome, precoAquisicao, dataDeFabricacao, fabricante);
        }
    }
}
