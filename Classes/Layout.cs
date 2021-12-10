namespace dotnet_console_banco.Classes
{
    public class Layout
    {
        private static int opcao = 0;
        public static void TelaPrincipal()
        {
            //Console.BackgroundColor = ConsoleColor.Blue;

            Console.Clear();

            Console.WriteLine("                                                         ");
            Console.WriteLine("                 Digite a opção desejada:                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 1 - Criar Conta                         ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 2 - Entrar com CPF e Senha              ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");

            while(opcao == 0)
            {
                opcao = int.Parse(Console.ReadLine());

            }    

            opEscolhida(opcao);

        }       

        private static void opEscolhida(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    //exibe a tela de criar conta:
                    TelaCriarConta();
                    break;
                case 2:
                    //Exibe a tela de Login
                    TelaEntrar();
                    break;
                default:
                    Console.WriteLine("Opt invalida");
                    break;
            }
        }

        private static void TelaCriarConta()
        {
            Console.Clear();

            Console.WriteLine(" _Entre com seus dados para criar uma nova Conta:        ");
            Console.WriteLine("                 Digite seu Nome:                        ");
            string nome = Console.ReadLine();
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 Digite seu CPF:                         ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 Digite sua Senha:                       ");
            string senha = Console.ReadLine();
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");


            //chama o método que vai criar conta do usuário...
            Console.WriteLine($"\nnome: {nome}, cpf: {cpf}, senha: {senha}");
        }

        private static void TelaEntrar()
        {
            Console.Clear();

            Console.WriteLine(" _Entre com seus dados para acessar sua conta:           ");
            Console.WriteLine("                 Digite o número da conta:               ");
            string conta = Console.ReadLine();
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 Digite a Senha:                         ");
            string senha = Console.ReadLine();
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");

            //chama o método que vai realizar o login...
            Console.WriteLine($"\nnome: {conta}, cpf: {senha}");
        }
    }
 
}