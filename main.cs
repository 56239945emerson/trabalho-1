public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello World");
       
        ContaCorrente conta = new ContaCorrente();
        conta.AdicionarSaldo(1000m);        
       
        Console.WriteLine("Saldo da conta corrente: "+ conta.Saldo);
       
        conta.Transferir(123, 100m);
        Console.WriteLine("Saldo da conta corrente: "+ conta.Saldo);
       
        conta.Transferir("joseromualdo@outlook.com", 100m);
        Console.WriteLine("Saldo da conta corrente: "+ conta.Saldo);
       
    }
}

public class ContaCorrente
{
    public decimal Saldo { get; private set; }    
    public decimal ValorChequeEspecial {get; private set;}
    public string Numero {get;set;}
   
    public ContaCorrente()
    {
     Numero = Guid.NewGuid().ToString();
    }
  public void AdicionarSaldo(decimal valor)
    {
        Saldo += valor;
    }
   
    public void DebitarValor(decimal valor)
    {
        Saldo -= valor;
    }
   
    public void DebitarValor(decimal valor, bool possuiChequeEspecial)
    {
        if((Saldo + ValorChequeEspecial) >= valor)
            Saldo -= valor;
    }
   
    //Realiza a transferencia utilizandoa chave PIX e-mail
    public bool Transferir(string email, decimal valor)
    {
        ContaCorrente conta = BuscarPorEmail(email);
        return Transferir(conta, valor);
    }
   
    public bool Transferir(int numeroConta, decimal valor)
    {
        ContaCorrente conta = BuscarPorNumero(numeroConta);
        return Transferir(conta, valor);        
    }
   public bool Transferir(ContaCorrente conta, decimal valor)
    {
        if(Saldo < valor)
        {
            Console.WriteLine("Saldo insuficiente");
            return false;
        }
       
        conta.DebitarValor(valor);
        conta.AdicionarSaldo(valor);
        Console.WriteLine("Transferencia de "+ valor +" realizada para a conta:" + conta.Numero);
       
        return true;        
    }
   
    private ContaCorrente BuscarPorNumero(int numero)
    {
        return new ContaCorrente();    
    }
  private ContaCorrente BuscarPorEmail(string email)
    {
        return new ContaCorrente();    
    }
   
    private ContaCorrente BuscarPorCPF(string cpf)
    {
        return new ContaCorrente();    
    }
}
