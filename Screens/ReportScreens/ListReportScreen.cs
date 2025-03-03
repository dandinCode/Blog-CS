using System;
using Blog.Repositories;
using Blog.Models;

namespace Blog.Screens.ReportScreens
{
    public static class ListReportScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de usu�rios");
            Console.WriteLine("---------");
            List();
            Console.ReadKey();
         
            Program.Load();
        }

        private static void List()
        {
            var repository = new UserRepository(Database.Connection);
            var users = repository.GetWithRoles();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id} - {user.Name} - {user.Email} ({user.Slug})");
                 if (user.Roles != null && user.Roles.Count > 0){
                    Console.WriteLine($"Perfis vinculados a este usuário ({user.Roles.Count}):\n");
                }
                Console.WriteLine("======================================");
                 foreach (var role in user.Roles)
                    Console.WriteLine($"{role.Id} - {role.Name} ({role.Slug})");
                
                 Console.WriteLine("======================================\n");
            }
        }
    }
}