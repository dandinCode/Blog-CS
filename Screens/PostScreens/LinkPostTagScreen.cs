using System;
using Blog.Repositories;
using Blog.Models;

namespace Blog.Screens.PostScreens
{
    public static class LinkPostTagScreen
    {
        public static void Load()
        {

            Console.Clear();
            Console.WriteLine("Vinculando tag ao post");
            Console.WriteLine("---------");
            Console.WriteLine("Id do post: ");
            var postId = Console.ReadLine();
            
            Console.WriteLine("Id da tag: ");
            var tagId = Console.ReadLine();

            Create(new PostTag
            {
                PostId = int.Parse(postId),
                TagId = int.Parse(tagId)
            });
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Create(PostTag postTag)
        {
            try
            {
                var repository = new Repository<PostTag>(Database.Connection);
                repository.Create(postTag);
                Console.WriteLine("Tag vinculada ao Post com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível vincular a tag ao post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}