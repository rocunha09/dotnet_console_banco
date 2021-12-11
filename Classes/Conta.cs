using dotnet_console_banco.Interfaces;
namespace dotnet_console_banco.Classes
{
    public abstract class Conta : Banco, IConta
    {
        public double saldo { get; protected set;}
        public string numeroAgencia { get; private set;}
        public string NumeroConta { get; protected set;}
        public static int numeroDaContaSequencial {get; private set;}
        public Conta()
        {
            this.numeroAgencia = "0001";
            Conta.numeroDaContaSequencial++;
        }


        public void Depositar(double valor)
        {
            this.saldo += valor;
        }
        public void Sacar(double valor)
        {
            this.saldo -= valor;
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
    }
}