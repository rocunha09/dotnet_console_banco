using dotnet_console_banco.Interfaces;
namespace dotnet_console_banco.Classes
{
    public abstract class Conta : Banco, IConta
    {
        public double saldo { get; protected set;}
        public string numeroAgencia { get; private set;}
        public string NumeroConta { get; protected set;}
        public static int numeroDaContaSequencial {get; private set;}

        private List<Extrato> movimentacoes;
        public Conta()
        {
            this.numeroAgencia = "0001";
            Conta.numeroDaContaSequencial++;
            this.movimentacoes = new List<Extrato>();
        }


        public void Depositar(double valor)
        {
            if(valor >= 0){
            this.saldo += valor;
            DateTime dataAtual = DateTime.Now;
            this.movimentacoes.Add(new Extrato(dataAtual, "Depósito", valor));
            }
        }
        public bool Sacar(double valor)
        {
            if(valor <= ConsultarSaldo()){
                this.saldo -= valor;
                DateTime dataAtual = DateTime.Now;
                this.movimentacoes.Add(new Extrato(dataAtual, "Saque", -valor));
                return true;
            } else {
                return false;
            }

        }
        public double ConsultarSaldo()
        {
            return this.saldo;
        }
        public string GetCodigoDoBanco()
        {
            return this.CodigoBanco;
        }
        public string GetNumeroAgencia()
        {   
            return this.numeroAgencia;
        }
        public string GetNumeroConta()
        {
            return this.NumeroConta;
        }

        public List<Extrato> Extrato()
        {
            return this.movimentacoes;
        }
    }
}