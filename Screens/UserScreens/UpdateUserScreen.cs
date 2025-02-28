using System;
using Blog.Repositories;
using Blog.Models;

namespace Blog.Screens.UserScreens
{
    public static class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando um usu�rio");
            Console.WriteLine("---------");
            Console.WriteLine("Id: ");
            var id = Console.ReadLine();

            Console.WriteLine("Nome: ");
            var name = Console.ReadLine();

            Console.WriteLine("E-mail: ");
            var email = Console.ReadLine();

            Console.WriteLine("Senha: ");
            var password = Console.ReadLine();

            Console.WriteLine("Bio: ");
            var bio = Console.ReadLine();

            Console.WriteLine("URL da imagem: ");
            var image = Console.ReadLine();

            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();

            Update(new User
            {
                Id = int.Parse(id),
                Name = name,
                Email = email,
                PasswordHash = password,
                Bio = bio,
                Image = image,
                Slug = slug
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Update(User user)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                repository.Update(user);
                Console.WriteLine("Usu�rio atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("N�o foi poss�vel atualizar o usu�rio");
                Console.WriteLine(ex.Message);
            }
        }
    }
}