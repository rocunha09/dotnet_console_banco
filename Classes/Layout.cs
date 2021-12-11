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

            //aguarda 0.5 segundos
            Thread.Sleep(500);
            //redireciona para area do cliente ou tela inicial
            opcaoVoltar(pessoa);
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
            Console.WriteLine($"                 Seja Bem Vindo, {pessoa.nome}          ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine($"            | Banco: {pessoa.Conta.GetCodigoDoBanco()} | Agência: {pessoa.Conta.GetNumeroAgencia()} | Conta: {pessoa.Conta.GetNumeroConta()} |");
            Console.WriteLine("                 =================================       ");
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

            opEscolhidaAreaCliente(opcao, pessoa);

        }       

        private static void opEscolhidaAreaCliente(int opcao, Pessoa pessoa)
        {
            switch (opcao)
            {
                case 1:
                    //realizar Depósito:
                    telaDeposito(pessoa);
                    break;
                case 2:
                    //realizar Saque:
                    telaSaque(pessoa);
                    break;
                case 3:
                    //Consultar Saldo:
                    telaCconsultaSaldo(pessoa);
                    break;
                case 4:
                    //Extrato:
                    telaExtrato(pessoa);
                    break;
                case 5:
                    //Sair
                    TelaPrincipal();
                    break;
                default:
                    Console.WriteLine("Opt invalida");
                    Thread.Sleep(1500);
                    TelaPrincipal();
                    break;
            }
        }

        private static void telaDeposito(Pessoa pessoa)
        {
            Console.Clear();
            telaBoasVindas(pessoa);

            Console.WriteLine("                 Digite o valor do Depósito:             ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("                 =================================       ");

            pessoa.Conta.Depositar(valor);
            
            Console.Clear();
            telaBoasVindas(pessoa);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                 Depósito Realizado com Sucesso!         ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(1500);

            opcaoVoltarAreaCliente(pessoa);

        }

        private static void telaSaque(Pessoa pessoa)
        {
            Console.Clear();
            telaBoasVindas(pessoa);

            Console.WriteLine("                 Digite o valor do Saque:                ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("                 =================================       ");

            bool result = pessoa.Conta.Sacar(valor);
            
            Console.Clear();
            telaBoasVindas(pessoa);

            Console.WriteLine();
            Console.WriteLine();
            if(result){
                Console.WriteLine("                 Saque Realizado com Sucesso!            ");
                Console.WriteLine("                 =================================       ");

            } else {
                Console.WriteLine("                 Saldo insuficiente!                     ");
                Console.WriteLine("                 =================================       ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(1500);

            Console.Clear();
            opcaoVoltarAreaCliente(pessoa);

        }

        private static void telaCconsultaSaldo(Pessoa pessoa)
        {
            Console.Clear();
            telaBoasVindas(pessoa);

            Console.WriteLine("                 Seu Saldo é:                            ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine($"                R$ {pessoa.Conta.ConsultarSaldo()}");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine();
            Console.WriteLine();

            opcaoVoltarAreaCliente(pessoa);

        }
       
        private static void telaExtrato(Pessoa pessoa)
        {
            Console.Clear();
            telaBoasVindas(pessoa);
            
            //monta extrato a partir de um histórico de movimentações...
            if(pessoa.Conta.Extrato().Any()){
                Console.WriteLine("                  Extrato:                                                                  ");
                Console.WriteLine("                 ===================================================================        ");
                foreach (Extrato extrato in pessoa.Conta.Extrato())
                {
                    Console.WriteLine($"                 Data: {extrato.data.ToString("dd/MM/yyyy HH:mm:ss")}    Movimentação: {extrato.descricao}   Valor: {extrato.valor}      ");
                    Console.WriteLine("                 ---------------------------------------------------------------        ");
                }
                
                double saldoAtual = pessoa.Conta.Extrato().Sum(x => x.valor);
                
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                  Saldo Atual:                                  ");
                Console.WriteLine("                 ===================================================================       ");
                 Console.WriteLine($"                                       {saldoAtual}                                      ");
                Console.WriteLine("                 ===================================================================       ");
                Console.WriteLine();
                Console.WriteLine();
            } else {
                Console.WriteLine("                 Não há Movimentações:                   ");
                Console.WriteLine("                 =================================       ");
                Console.WriteLine();
                Console.WriteLine();
            }

            Thread.Sleep(1500);

            opcaoVoltarAreaCliente(pessoa);
        }
        
        private static void opcaoVoltarAreaCliente(Pessoa pessoa)
        {
            //reseta menu
            opcao = 0;

            Console.WriteLine("                                                         ");
            Console.WriteLine("                 Digite a opção desejada:                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 1 - Voltar para minha conta             ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 2 - Sair                                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");

            while(opcao == 0)
            {
                opcao = int.Parse(Console.ReadLine());

            }    

            if(opcao == 1){
                areaDoCliente(pessoa);

            } else {
                TelaPrincipal();
            }

        }

        private static void opcaoVoltar(Pessoa pessoa)
        {
            //reseta menu
            opcao = 0;


            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 1 - Acessar Conta                       ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 2 - Sair                                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");

            while(opcao == 0)
            {
                opcao = int.Parse(Console.ReadLine());

            }    

            if(opcao == 1){
                areaDoCliente(pessoa);

            } else {
                TelaPrincipal();
            }

        }
    }
 
}