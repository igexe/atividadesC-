namespace Classes;

public class Funcionario:Pessoa{
    public string Cargo{get;set;}
    public double Salario{get;set;}

    public Funcionario(string nome,int idade,string email,string cargo,double salario):base(nome,idade,email){
        this.Cargo=cargo;
        this.Salario=salario;
    }

    public void Apresentar(){
        Console.WriteLine($"Olá eu sou {this.Nome} e tenho {this.getIdade()} anos\nSobre meu emprego eu sou {this.Cargo} e ganho {this.Salario}R$");
    }
}