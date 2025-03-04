using Blog.Screens.TagScreens;

namespace Blog.Screens.TagScreens
{
    public static class MenuTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de tags");
            Console.WriteLine("------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar tags");
            Console.WriteLine("2 - Cadastrar tag");
            Console.WriteLine("3 - Atualizar tag");
            Console.WriteLine("4 - Excluir tag");
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
                    ListTagScreen.Load();
                    break;
                case 2:
                    CreateTagScreen.Load();
                    break;
                case 3:
                    UpdateTagScreen.Load();
                    break;
                case 4:
                    DeleteTagScreen.Load();
                    break;
                default: 
                    Console.WriteLine("Por favor insira um valor válido!");
                    Load();
                    break;
            }
        }
    }
}