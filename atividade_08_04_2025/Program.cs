public class Program{
    private static void Main(string[] args){
        var pessoa1= new Classes.Pessoa();
        pessoa1.Nome="julio";
        pessoa1.setIdade(21);
        pessoa1.Email="teste_julio";
        
        var pessoa2= new Classes.Pessoa("ig",20,"teste","casa10");

        Console.WriteLine($"Nome: {pessoa1.Nome}\nIdade: {pessoa1.getIdade()}\nEmail: {pessoa1.Email}");
        pessoa2.Apresentar();
    }
}