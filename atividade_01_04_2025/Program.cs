internal class Program{
    private static void Main(string[] args){
        Console.WriteLine("Exercicio 1 programa que identifica genero do usuario");
        e1();

        Console.WriteLine("\nExercicio 2 programa que calcula media simples"); 
        e2();

        Console.WriteLine("\nExercicio 3 programa que exibe todos as partes da divisão entre números inteiros");
        e3();

        Console.WriteLine("\nExercicio 4 programa que converte dias de vida em anos");
        e4();

        Console.WriteLine("\nExercicio 5 programa que retorna a tabuada do número inserido pelo usuario");
        e5();

        Console.WriteLine("\nExercicio 6 programa que mostra quantos números são pares entre 10 números inseridos pelo usuario");
        e6();

        Console.WriteLine("\nExercicio 7 programa que mostra se a letra inserida pelo usuario é uma vogal ou consoante");
        e7();
        
        Console.WriteLine("\nExercicio 8 programa que retorna dia da semana a partir de um número entre 1 e 7 inserido pelo usuario");
        e8();

        Console.WriteLine("\nExercicio 9 programa que calcula o volume de esferas");
        e9();

        Console.WriteLine("\nExercicio 10 programa que retorna menor quantidade de notas possiveis para quantia inserida pelo usuario");
        e10();
    }

    // seguir a seguinte estrutura
    public static void e1(){
        /* Escreva um programa que identifique se uma pessoa é do sexo masculino ou feminino.
        Para isso, utilize 1 para Masculino e 2 para feminino*/
        int sexo=0;

        do{
            Console.WriteLine("\nIdentifique seu genero\n1 para masculino\n2 para feminino");
            sexo=Convert.ToInt32(Console.ReadLine());

            if(sexo==1){
                Console.WriteLine("\nVocê é um homem");
            }else if(sexo==2){
                Console.WriteLine("\nVocê é uma mulher");
            }else{
                Console.WriteLine("\nOpção não reconhecida");
            }
        }while(sexo<1 || sexo>2);
    }

    public static void e2(){
        /*Escreva um programa que receba três notas do tipo inteira, N1, N2 e N3. Com base
nessas três notas calcule a média simples e identifique que o aluno atingiu a nota mínima para
passar ou reprovou. A nota mínima para passar é 6.*/

        int[] notas=new int[3];
        double nota_final=0;

        for(int i=0;i<3;i++){
            Console.WriteLine($"\ndigite sua {i+1}° nota");
            notas[i]=Convert.ToInt32(Console.ReadLine());
        }

        for(int i=0;i<3;i++){
            nota_final+=notas[i];
        }
        nota_final/=3;

        Console.WriteLine("\nSuas notas foram:");
        for(int i=0;i<3;i++){
            Console.WriteLine(notas[i]);
        }
        Console.WriteLine($"\nSua media final foi: {Math.Truncate(100*nota_final)/100}");
        if(nota_final>=6){
            Console.WriteLine($"\nVocê atingiu a media 6\nVocê foi aprovado");
        }else{Console.WriteLine($"\nVocê não atingiu a media 6\n Você foi reprovado");}
    }

    public static void e3(){
        /*Ler dois números inteiros e exibir o quociente e o resto da divisão inteira entre eles.*/

        int num1,num2;

        Console.WriteLine("\nDigite um número para ser o dividendo da nossa divisão");
        num1=Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nDigite um número para ser o divisor da nossa divisão");
        num2=Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"\nNossa divisão foi: {num1}/{num2}\nNosso quociente foi: {num1/num2}\nNosso resto foi: {num1%num2}");
    }

    public static void e4(){
        /*Solicitar quantos dias de vida uma pessoa tem e informar na tela a idade em anos,
meses e dias*/

        int dias_vividos;

        Console.WriteLine("\nDigite quantos dias de vida você tem");
        dias_vividos=Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"\nVocê tem {dias_vividos/365} anos");
    }

    public static void e5(){
        /*Escreva um programa que faça a leitura de um valor inteiro (aceitar somente valores
entre 1 e 10) e escrever a tabuada de multiplicação de 1 a 10 do valor lido.*/

        int numero=-1;

        do{
            Console.WriteLine("\nDigite um número entre 1 e 10 para ver sua tabuada");
            numero=Convert.ToInt32(Console.ReadLine());
        }while(numero<=0 || numero>10);

        Console.WriteLine($"\nTabuada de {numero}");
        for(int i=1;i<=10;i++){
            Console.WriteLine(numero*i);
        }
    }

    public static void e6(){
        /*Faça um programa que faça a leitura de 10 números e imprimir quantos são pares e
quantos são ímpares.*/

        double[] numeros=new double[10],pares=new double[10];
        int quantidade_pares=0;

        for(int i=0;i<10;i++){
            Console.WriteLine($"\nDigite o {i+1}° número");
            numeros[i]=Convert.ToDouble(Console.ReadLine());

            if(numeros[i]%2==0){
                pares[quantidade_pares]=numeros[i];
                quantidade_pares+=1;
            }else{;}
        }

        Console.WriteLine("\nDos números digitados:");
        for(int i=0;i<10;i++){
            Console.WriteLine(numeros[i]);
        }

        Console.WriteLine($"\n{quantidade_pares} são pares, sendo eles:");
        for(int i=0;i<quantidade_pares;i++){
            Console.WriteLine(pares[i]);
        }
    }

    public static void e7(){
        /*Escreva um programa que leia uma letra e mostre se ela é vogal ou consoante.*/

        string letra;

        Console.WriteLine("\nDigite uma letra");
        letra=Console.ReadLine();
        
        switch(letra.ToLower()){
            case "a":
                Console.WriteLine($"\nA letra inserida {letra} é uma vogal");
                break;
            
            case "e":
                Console.WriteLine($"\nA letra inserida {letra} é uma vogal");
                break;

            case "i":
                Console.WriteLine($"\nA letra inserida {letra} é uma vogal");
                break;

            case "o":
                Console.WriteLine($"\nA letra inserida {letra} é uma vogal");
                break;

            case "u":
                Console.WriteLine($"\nA letra inserida {letra} é uma vogal");
                break;

            default:
                Console.WriteLine($"\nA letra inserida {letra} é uma consoante");
                break;
        }
    }

    public static void e8(){
        /*Escreva um programa que leia um número correspondente ao dia da semana e mostre o
dia da semana. Sendo domingo 1 e sábado 7.*/

        int dia=-1;

        do{
            Console.WriteLine("\nInforme que dia da semana é hoje sendo:\n1 DOMINGO\n2 SEGUNDA\n3 TERÇA\n4 QUARTA\n5 QUINTA\n6 SEXTA\n7 SÁBADO");
            dia=Convert.ToInt32(Console.ReadLine());
            
            if(dia<1||dia>7){
                Console.WriteLine("\nEntrada invalida por favor informe o dia correto\n");
            }else{;}
        }while(dia<1||dia>7);

        switch(dia){
            case 1:
                Console.WriteLine("\nHoje é domingo");
                break;
            
            case 2:
                Console.WriteLine("\nHoje é segunda");
                break;

            case 3:
                Console.WriteLine("\nHoje é terça");
                break;

            case 4:
                Console.WriteLine("\nHoje é quarta");
                break;

            case 5:
                Console.WriteLine("\nHoje é quinta");
                break;

            case 6:
                Console.WriteLine("\nHoje é sexta");
                break;

            case 7:
                Console.WriteLine("\nHoje é sábado");
                break;

            default:
                break;
        }
    }

    public static void e9(){
        /*Escreva um programa que, dado o valor do raio via teclado, calcule e imprima o
volume da esfera correspondente. Sabe-se que o volume da esfera é dado por 4/3*πr³, onde r
representa o raio da esfera. Note que a linguagem C não disponibiliza um operador de
exponenciação (potenciação). Utilize o valor de π sendo 3.141592*/

    double raio;

    Console.WriteLine("\nDigite o raio em cm da circunferencia que quer saber o volume");
    raio=Convert.ToDouble(Console.ReadLine());

    Console.WriteLine($"\nO volume de uma esfera com raio {raio}cm é {(4*3.141592*(raio*raio*raio))/3}cm³ ou {(4*(raio*raio*raio)/3)}πcm³");
    }

    public static void e10(){
        /*Considerando a existência de notas (cédulas) nos valores R$ 100, R$ 50, R$ 20, R$
10, R$ 5, R$ 2 e R$ 1, escreva um programa que capture um valor inteiro em reais (R$) e determine
o menor número de notas para se obter o montante fornecido. O programa deve exibir o número de
notas para cada um dos valores de nota existentes.*/

        int nota100=0,nota50=0,nota20=0,nota10=0,nota5=0,nota2=0,nota1=0,valor,temp;

        Console.WriteLine("\nDigite um valor inteiro para encontrar a menor quantidade possivel de notas de possiveis para essa quantia em notas de 100, 50, 20, 10, 5, 2 e 1 real");
        valor=Convert.ToInt32(Console.ReadLine());

        nota100=valor/100;
        temp=valor%100;

        if(temp!=0){
            nota50=temp/50;
            temp%=50;
        }

        if(temp!=0){
            nota20=temp/20;
            temp%=20;
        }

        if(temp!=0){
            nota10=temp/10;
            temp%=10;
        }

        if(temp!=0){
            nota5=temp/5;
            temp%=5;
        }

        if(temp!=0){
            nota2=temp/2;
            temp%=2;
        }

        if(temp!=0){
            nota1=temp/1;
            temp%=1;
        }

        Console.WriteLine($"\nPara o valor de {valor}R$ são necessarias:\n{nota100} notas de 100R$\n{nota50} notas de 50R$\n{nota20} notas de 20R$\n{nota10} notas de 10R$\n{nota5} notas de 5R$\n{nota2} notas de 2R$\n{nota1} notas de 1R$\nDando um total de {nota100+nota50+nota20+nota10+nota5+nota2+nota1} notas");
    }
}