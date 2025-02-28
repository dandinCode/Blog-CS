using System;
using Blog.Screens.UserScreens;

namespace Blog.Screens.UserScreens
{
    public static class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gest�o de usu�rios");
            Console.WriteLine("------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar usu�rios");
            Console.WriteLine("2 - Cadastrar usu�rio");
            Console.WriteLine("3 - Atualizar usu�rio");
            Console.WriteLine("4 - Excluir usu�rio");
            Console.WriteLine("0 ou 'Enter' - Voltar ao menu principal");
            Console.WriteLine();

            var input = Console.ReadLine();
            var option = string.IsNullOrWhiteSpace(input) ? 0 : short.Parse(input);

            switch (option)
            {
                case 0:
                    Program.Load();
                    break;
                case 1:
                    ListUserScreen.Load();
                    break;
                case 2:
                    CreateUserScreen.Load();
                    break;
                case 3:
                    UpdateUserScreen.Load();
                    break;
                case 4:
                    DeleteUserScreen.Load();
                    break;
                default:
                    Console.WriteLine("Por favor insira um valor v�lido!");
                    Load();
                    break;
            }
        }
    }
}