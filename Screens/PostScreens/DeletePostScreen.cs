using System;
using Blog.Repositories;
using Blog.Models;

namespace Blog.Screens.PostScreens
{
    public static class DeletePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma post");
            Console.WriteLine("---------");
            Console.WriteLine("Qual o Id da post que deseja excluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Post deletada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível deletar a post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}