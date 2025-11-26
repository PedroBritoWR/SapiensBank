using System.Text.Json.Serialization;

public class Conta
{
    public int Numero { get; set; }
    public string Cliente { get; set; }
    public string Cpf { get; set; }
    public string Senha { get; set; }
    public decimal Saldo { get; set; }
    public decimal Limite { get; set; }

    [JsonIgnore]
    public decimal SaldoDisponível => Saldo + Limite;

    public Conta(int numero, string cliente, string cpf, string senha, decimal limite = 0)
    {
        Numero = numero;
        Cliente = cliente;
        Cpf = cpf;
        Senha = senha;
        Limite = limite;
    }

    public void Depositar(decimal valor)
    {
        if (valor > 0)
        {
            Saldo += valor;
            Console.WriteLine($"Depósito de {valor:C} realizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Valor inválido para depósito!");
        }
    }
    public void Sacar(decimal valor)
    {
        if (valor > 0)
        {
            if (valor <= SaldoDisponível)
            {
                Saldo -= valor;
                Console.WriteLine($"Saque de {valor:C} realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");
            }
        }
        else
        {
            Console.WriteLine("Valor inválido para saque!");
        }
    }
    public void AumentarLimite(decimal valor)
    {
        if (valor > 0)
        {
            Limite += valor;
            Console.WriteLine($"Limite aumentado em {valor:C}!");
        }
        else
        {
            Console.WriteLine("Valor inválido!");
        }
    }
    public void DiminuirLimite(decimal valor)
    {
        if (valor > 0)
        {
            if (Limite - valor >= 0)
            {
                Limite -= valor;
                Console.WriteLine($"Limite reduzido em {valor:C}!");
            }
            else
            {
                Console.WriteLine("Não é possível reduzir o limite abaixo de zero!");
            }
        }
        else
        {
            Console.WriteLine("Valor inválido!");
        }
    }

}
