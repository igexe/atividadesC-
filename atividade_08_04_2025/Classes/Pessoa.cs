namespace Classes;

public class Pessoa:IApresentavel
{
    public string Nome{get;set;}
    int Idade;
    public string Email{get;set;}

    public int getIdade(){
        return this.Idade;
    }
    public void setIdade(int idade){
        this.Idade = idade;
    }

    public Pessoa(){}

    public Endereco Endereco{get;set;}

    public Pessoa(string nome, int idade, string email,string endereco){
        this.Nome = nome;
        this.Idade = idade;
        this.Email=email;

        this.Endereco=new Endereco();
        this.Endereco.Local= endereco;
    }

    public void Apresentar(){
        Console.WriteLine($"Olá eu sou {Nome} e tenho {Idade} anos");
    }

    public void Moradia(){
        Console.WriteLine($"eu moro no endereço {this.Endereco.Local}");
    }
}
