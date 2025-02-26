using System;
using Blog.Repositories;
using Blog.Models;

namespace Blog.Screens.CategoryScreens
{
    public static class UpdateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando uma categoria");
            Console.WriteLine("---------");
            Console.WriteLine("Id: ");
            var id = Console.ReadLine();

            Console.WriteLine("Nome: ");
            var name = Console.ReadLine();

            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();

            Update(new Category
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Update(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Update(category);
                Console.WriteLine("Categoria atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("N�o foi poss�vel atualizar a categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}