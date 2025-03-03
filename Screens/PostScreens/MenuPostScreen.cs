using Blog.Screens.PostScreens;

namespace Blog.Screens.PostScreens
{
    public static class MenuPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gest�o de posts");
            Console.WriteLine("------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar posts");
            Console.WriteLine("2 - Cadastrar post");
            Console.WriteLine("3 - Atualizar post");
            Console.WriteLine("4 - Excluir post");
            Console.WriteLine("5 - Vincular tag ao post");
            Console.WriteLine("0 ou 'Enter' - Voltar ao menu principal");
            Console.WriteLine();
            
            var input = Console.ReadLine();
            var option = string.IsNullOrWhiteSpace(input) ? 0 : short.Parse(input);

            switch (option)
            {
                case 0:
                    Program.Load();
                    break;
                case 1:
                    ListPostScreen.Load();
                    break;
                case 2:
                    CreatePostScreen.Load();
                    break;
                case 3:
                    UpdatePostScreen.Load();
                    break;
                case 4:
                    DeletePostScreen.Load();
                    break;
                case 5:
                    LinkPostTagScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}