using System;
using Blog.Repositories;
using Blog.Models;

namespace Blog.Screens.PostScreens
{
    public static class CreatePostScreen
    {
        public static void Load()
        {

            Console.Clear();
            Console.WriteLine("Novo post");
            Console.WriteLine("---------");
            
            Console.WriteLine("Id da categoria: ");
            var category = Console.ReadLine();
            
            Console.WriteLine("Id do autor: ");
            var author = Console.ReadLine();
            
            Console.WriteLine("Titulo: ");
            var title = Console.ReadLine();
            
            
            Console.WriteLine("Sumario: ");
            var summary = Console.ReadLine();
            
            Console.WriteLine("Texto: ");
            var body = Console.ReadLine();
            
            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();

            Create(new Post
            {
                CategoryId = int.Parse(category),
                AuthorId = int.Parse(author),
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug
            });
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Create(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Create(post);
                Console.WriteLine("Post cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar o post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}