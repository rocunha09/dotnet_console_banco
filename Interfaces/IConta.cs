
using dotnet_console_banco.Classes;
namespace dotnet_console_banco.Interfaces;

public interface IConta
{
    void Depositar(double valor);
    bool Sacar(double valor);
    double ConsultarSaldo();
    string GetCodigoDoBanco();
    string GetNumeroAgencia();
    string GetNumeroConta();
    public List<Extrato> Extrato();
}