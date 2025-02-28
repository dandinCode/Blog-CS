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
            Console.WriteLine("Excluir um usuário");
            Console.WriteLine("---------");
            Console.WriteLine("Qual o Id do usuário que deseja excluir? ");
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
                Console.WriteLine("Usuário deletado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível deletar o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}