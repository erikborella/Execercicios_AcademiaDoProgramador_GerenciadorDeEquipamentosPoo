using System;

namespace GerenciadorDeEquipamentosOO.Menus
{
    /// <summary>
    /// Menu principal, serve como ponto inicial para o fluxo de todos os menus
    /// </summary>
    class Menu
    {
        private ListaEquipamentos listaEquipamentos = new ListaEquipamentos();

        /// <summary>
        /// Inicia o fluxo de menus
        /// </summary>
        public void Iniciar()
        {
            MenusEquipamento menusEquipamento = new MenusEquipamento(listaEquipamentos);

            bool noMenu = true;
            while (noMenu)
            {
                Console.Clear();
                Console.WriteLine("Bem vindo!\n");

                int opcao = Ajudadores.ListarEPegarSelecao(
                    "1. Consultar Equipamento\n" +
                    "2. Criar Equipamento\n" +
                    "3. Excluir Equipamento\n" +
                    "4. Sair\n" +
                    "Digite o que deseja fazer: ",
                    "Você digitou uma opcao invalida, tente novamente",
                    1, 4);

                switch (opcao)
                {
                    case 1:
                        menusEquipamento.SelecaoEquipamento();
                        break;
                    case 2:
                        menusEquipamento.CriarEquipamento();
                        break;
                    case 3:
                        menusEquipamento.ExcluirEquipamento();
                        break;
                    case 4:
                        noMenu = false;
                        break;
                }
            }

        }
    }
}
