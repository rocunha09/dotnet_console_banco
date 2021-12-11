namespace dotnet_console_banco.Interfaces;

public interface IConta
{
    void Depositar(double valor);
    void Sacar(double valor);
    double ConsultarSaldo();
    string GetCodigoDoBanco();
    string GetNumeroAgencia();
    string GetNumeroConta();
}