using System;
using Blog.Repositories;
using Blog.Models;

namespace Blog.Screens.PostScreens
{
    public static class UpdatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando uma post");
            Console.WriteLine("---------");
            Console.WriteLine("Id: ");
            var id = Console.ReadLine();

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


            Update(new Post
            {
                Id = int.Parse(id),
                CategoryId = int.Parse(category),
                AuthorId = int.Parse(author),
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                LastUpdateDate = DateTime.Now
            
            });
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Update(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Update(post);
                Console.WriteLine("Post atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("N�o foi poss�vel atualizar a post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}