using System;
using Blog.Repositories;
using Blog.Models;

namespace Blog.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {

            Console.Clear();
            Console.WriteLine("Novo usu�rio");
            Console.WriteLine("---------");
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

            Create(new User
            {
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

        public static void Create(User user)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                repository.Create(user);
                Console.WriteLine("Usu�rio cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("N�o foi poss�vel salvar a usu�rio");
                Console.WriteLine(ex.Message);
            }
        }
    }
}