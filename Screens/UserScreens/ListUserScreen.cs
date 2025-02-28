using System;
using Blog.Repositories;
using Blog.Models;

namespace Blog.Screens.UserScreens
{
    public static class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de usuários");
            Console.WriteLine("---------");
            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<User>(Database.Connection);
            var users = repository.Get();
            foreach (var item in users)
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Email} ({item.Slug})");
            }
        }
    }
}