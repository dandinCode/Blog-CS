using System;
using Blog.Repositories;
using Blog.Models;

namespace Blog.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um usu�rio");
            Console.WriteLine("---------");
            Console.WriteLine("Qual o Id do usu�rio que deseja excluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Usu�rio deletado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("N�o foi poss�vel deletar o usu�rio");
                Console.WriteLine(ex.Message);
            }
        }
    }
}