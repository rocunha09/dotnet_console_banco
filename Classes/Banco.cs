namespace dotnet_console_banco.Classes
{
    public abstract class Banco
    {
        public Banco()
        {
            this.NomeBanco = "BancoPoo";
            this.CodigoBanco = "021";
        }

        public string NomeBanco {get; private set;}
        public string CodigoBanco { get; private set;}
    }
}