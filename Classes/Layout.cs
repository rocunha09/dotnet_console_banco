using dotnet_console_banco.Classes;
namespace dotnet_console_banco.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int opcao = 0;

        public static void TelaPrincipal()
        {
            //reseta menu
            opcao = 0;

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
            Pessoa pessoa = criarConta(nome, cpf, senha);

            //adiciona na lista de pessoas cadastradas...
            pessoas.Add(pessoa);

            Console.Clear();
            Console.WriteLine("                 Conta cadastrada com sucesso!           ");
            Console.WriteLine("                 =================================       ");

            //aguarda 1.5 segundos
            Thread.Sleep(1500);
            //redireciona para area do cliente
            areaDoCliente(pessoa);
        }

        private static Pessoa criarConta(string nome, string cpf, string senha)
        {
            Pessoa pessoa = new Pessoa();
            ContaCorrente contaCorrente = new ContaCorrente();

            pessoa.setNome(nome);
            pessoa.setCpf(cpf);
            pessoa.setSenha(senha);
            pessoa.Conta = contaCorrente;

            return pessoa;
        }

        private static void TelaEntrar()
        {
            Console.Clear();

            Console.WriteLine(" _Entre com seus dados para acessar sua conta:           ");
            Console.WriteLine("                 Digite o número do CPF:                 ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 Digite a Senha:                         ");
            string senha = Console.ReadLine();
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");

            //chama o método que vai realizar o login...
            Pessoa pessoa = buscarConta(cpf, senha);

            if (pessoa != null){
                //redireciona para área do cliente
               areaDoCliente(pessoa);

            } else {
                Console.Clear();
                Console.WriteLine("                 Pessoa não cadastrada!                  ");
                Console.WriteLine("                 =================================       ");
                Console.WriteLine();
                Console.WriteLine();

                //aguarda 1.5 segundos
                Thread.Sleep(1500);
                //redireciona para o inicio
                TelaPrincipal();
            }
        }

        private static Pessoa buscarConta(string cpf, string senha)
        {
            Pessoa pessoa = pessoas.FirstOrDefault( x =>
                x.cpf == cpf &&
                x.senha == senha
            );

            return pessoa;
        }

        private static void telaBoasVindas(Pessoa pessoa)
        {
            Console.WriteLine("                                                         ");
            Console.WriteLine($"                Seja Bem Vindo, {pessoa.nome}           ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine($"                Seus Dados: [Banco: {pessoa.Conta.GetCodigoDoBanco()}]");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine($"                Seus Dados: [Agência: {pessoa.Conta.GetNumeroAgencia()}]");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine($"                Seus Dados: [Conta: {pessoa.Conta.GetNumeroConta()}]");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
        }

        private static void areaDoCliente(Pessoa pessoa)
        {
            //reseta menu
            opcao = 0;

            Console.Clear();

            telaBoasVindas(pessoa);

            Console.WriteLine("                                                         ");
            Console.WriteLine("                 Digite a opção desejada:                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 1 - Realizar um Depósito                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 2 - Realizar um Saque                   ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 3 - Consultar Saldo                     ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 4 - Extrato                             ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 5 - Sair                                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");

            while(opcao == 0)
            {
                opcao = int.Parse(Console.ReadLine());

            }    

            opEscolhidaAreaCliente(opcao);

        }       

        private static void opEscolhidaAreaCliente(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    //realizar Depósito:
                    
                    break;
                case 2:
                    //realizar Saque:
                    
                    break;
                case 3:
                    //Consultar Saldo:
                    
                    break;
                case 4:
                    //Extrato:
                    
                    break;
                case 5:
                    //Sair
                    TelaPrincipal();
                    break;
                default:
                    Console.WriteLine("Opt invalida");
                    break;
            }
        }
    }
 
}