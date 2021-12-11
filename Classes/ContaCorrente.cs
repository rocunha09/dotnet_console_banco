namespace dotnet_console_banco.Classes
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente()
        {
            this.NumeroConta = "00" + Conta.numeroDaContaSequencial;
        }
    }
}