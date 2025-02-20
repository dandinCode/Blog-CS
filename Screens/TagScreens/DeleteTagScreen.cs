using System;
using Blog.Repositories;
using Blog.Models;

namespace Blog.Screens.TagScreens
{
    public static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma tag");
            Console.WriteLine("---------");
            Console.WriteLine("Qual o Id da tag que deseja excluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuTagScreen.Load();
        }

         public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Tag deletada com suceso!");
            } catch (Exception ex)
            {
                Console.WriteLine("Não foi possível deletar a tag");
                Console.WriteLine(ex.Message);
            }
        } 
    }
}