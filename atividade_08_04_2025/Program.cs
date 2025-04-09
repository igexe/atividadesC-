public class Program{
    private static void Main(string[] args){
        var pessoa1= new Classes.Pessoa();
        pessoa1.Nome="julio";
        pessoa1.setIdade(21);
        pessoa1.Email="teste_julio";

        Console.WriteLine($"Nome: {pessoa1.Nome}\nIdade: {pessoa1.getIdade()}\nEmail: {pessoa1.Email}");
        
        var pessoa2= new Classes.Pessoa("ig",20,"teste","casa10");

        var funcionario=new Classes.Funcionario("ig",20,"teste","casa10","estoquista",1500);
        
        pessoa2.Apresentar();

        funcionario.Apresentar();
    }
}