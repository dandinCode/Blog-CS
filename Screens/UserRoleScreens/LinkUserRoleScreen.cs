using System;
using Blog.Repositories;
using Blog.Models;

namespace Blog.Screens.UserRoleScreens
{
    public static class LinkUserRoleScreen
    {
        public static void Load()
        {

            Console.Clear();
            Console.WriteLine("Vinculando tag ao post");
            Console.WriteLine("---------");
            Console.WriteLine("Id do usuário: ");
            var userId = Console.ReadLine();
            
            Console.WriteLine("Id do perfil: ");
            var roleId = Console.ReadLine();

            Create(new UserRole
            {
                UserId = int.Parse(userId),
                RoleId = int.Parse(roleId)
            });
            Console.ReadKey();
            Program.Load();
        }

        public static void Create(UserRole userRole)
        {
            try
            {
                var repository = new Repository<UserRole>(Database.Connection);
                repository.Create(userRole);
                Console.WriteLine("Pefil vinculado ao usuário com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível vincular o perfil ao usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}