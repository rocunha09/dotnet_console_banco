using dotnet_console_banco.Enum;
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
        protected TipoConta tipoConta { get; set; }
        protected double credito { get; set;}
        public Conta()
        {
            this.numeroAgencia = "0001";
            Conta.numeroDaContaSequencial++;
            this.movimentacoes = new List<Extrato>();
        }
        public void Depositar(double valor)
        {
            if(valor > 0){
            this.saldo += valor;
            DateTime dataAtual = DateTime.Now;
            this.movimentacoes.Add(new Extrato(dataAtual, "Depósito", valor));
            } 
        }
        public bool Sacar(double valor)
        {
            double saldoDisponivelComCredito = this.saldo + this.credito;
            double saldoDisponivel = this.saldo;

            if(valor > saldoDisponivelComCredito){
                return false;
                
            } else if(valor > saldoDisponivel){
                double limiteRestante = valor - saldoDisponivel;
                this.saldo = Math.Round(0 - limiteRestante, 2);
                limiteRestante = Math.Round(this.credito - limiteRestante, 2);
                
                DateTime dataAtual = DateTime.Now;
                this.movimentacoes.Add(new Extrato(dataAtual, "Saque", -valor));

                return true;

            } else {
                this.saldo -= valor;

                DateTime dataAtual = DateTime.Now;
                this.movimentacoes.Add(new Extrato(dataAtual, "Saque", -valor));

                return true;

            }

        }
        public List<Extrato> Extrato()
        {
            return this.movimentacoes;
        }
        public double ConsultarSaldo()
        {
            return this.saldo;
        }
        public void selecionarTipoConta(TipoConta tipoConta)
        {
            this.tipoConta = tipoConta;
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
        public double GetCredito()
        {
            return this.credito;
        }
        public TipoConta GetTipoConta()
        {
            return this.tipoConta;
        }
        public void DefinirLimiteDeCredito(double credito)
        {
            this.credito = credito;
        }
    }
}