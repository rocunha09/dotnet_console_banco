namespace dotnet_console_banco.Classes
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente()
        {
            this.NumeroConta = "00" + Conta.numeroDaContaSequencial;
            this.DefinirLimiteDeCredito(0);
        }

        public ContaCorrente(double credito)
        {
            this.NumeroConta = "00" + Conta.numeroDaContaSequencial;
            this.DefinirLimiteDeCredito(credito);
        }

        // public Array Transferir(double valor, Object contaDestino)
        // {
        //     string[] result = new string[2];

        //     if(this.Sacar(valor)){

        //         if(contaDestino.Depositar(valor)){          //aqui devo passar a instância de conta...
        //             result[0] = "true";
        //             result[1] = "Transferência realizada com sucesso";
        //             return result;

        //         } else {
        //             this.Extornar(valor);
        //             result[0] = "Erro Conta Destino";
        //             result[1] = "Erro[Conta Destino] ao tentar realizar transferência";
        //             return result;
        //         }

        //     } else {
        //         result[0] = "Erro Conta Origem";
        //         result[1] = "Saldo Insuficiente";
        //         return result;
        //     }
        // }
        private void Extornar(double valor)
        {
            this.Depositar(valor);
        }
    }
}