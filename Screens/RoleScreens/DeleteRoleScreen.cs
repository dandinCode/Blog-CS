using System;
using Blog.Repositories;
using Blog.Models;

namespace Blog.Screens.RoleScreens
{
    public static class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um perfil");
            Console.WriteLine("---------");
            Console.WriteLine("Qual o Id do perfil que deseja excluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Perfil deletado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("N�o foi poss�vel deletar o perfil");
                Console.WriteLine(ex.Message);
            }
        }
    }
}