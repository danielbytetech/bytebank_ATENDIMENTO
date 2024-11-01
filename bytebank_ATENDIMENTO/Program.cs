using bytebank_ATENDIMENTO.bytebank.Atendimento;
using System;

/*Documentações a serem Vistas
- https://learn.microsoft.com/pt-br/dotnet/csharp/linq/get-started/introduction-to-linq-queries
- https://learn.microsoft.com/pt-br/dotnet/api/system.guid?view=net-6.0
 */

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Exemplos Arrays em C# 
//TesteArrayInt();

//TesteArrayPalavra();

void TesteArrayInt()
{
    int[] idades = new int[7];

    idades[0] = 11;
    idades[1] = 12;
    idades[2] = 13;
    idades[3] = 14;
    idades[4] = 15;
    idades[5] = 16;
    idades[6] = 17;

    var acumular = 0;

    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        acumular += idade;
    }

    var media = acumular / idades.Length;

    Console.WriteLine($"A média é de {media}");
}

void TesteArrayPalavra()
{
    string[] palavras = new string[5];

    for (int i = 0; i < palavras.Length; i++)
    {
        Console.Write($"Digite {i + 1}° a palavra: ");
        palavras[i] = Console.ReadLine()!;
    }

    Console.WriteLine("Digite a palavra que deseja encontrar: ");
    var busca = Console.ReadLine()!;

    foreach (var nome in palavras)
    {
        if (nome.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada: {nome}");
            break;
        }
    }

}


// Ou Array amostra = new double[5];
Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

//[5,9] [1,8] [7,1] [10] [6,9]

//TestaMediana(amostra);

void TestaMediana(Array array)
{
    if ((array == null) || (array.Length == 0))
    {
        Console.WriteLine("Array para calculo da mediana está vazio oui nulo.");
    }

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);
    // [1,8] [5,9] [6,9] [7,1] [10]

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] :
                                    (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;
    Console.WriteLine($"Com base na amostra a mediana = {mediana}");
}

void TesteArrayDeContasCorrentes()
{
    //Array de Objeto
    //ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();

    //listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    //listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
    //listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    //listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    //listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    //listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    //var contaDoAndre = new ContaCorrente(963, "123456-x");
    //listaDeContas.Adicionar(contaDoAndre);
    ////listaDeContas.ExibirLista();
    ////Console.WriteLine("==============");
    ////listaDeContas.Remover(contaDoAndre);
    ////listaDeContas.ExibirLista();

    //for (int i = 0; i < listaDeContas.Tamanho; i++)
    //{
    //    ContaCorrente conta = listaDeContas[i];
    //    Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Nome_Agencia}");
    //}
}

//TesteArrayDeContasCorrentes();
#endregion

#region Exemplos de uso do List
//List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
//{
//    new ContaCorrente(874, "5679787-A"),
//    new ContaCorrente(874, "4456668-B"),
//    new ContaCorrente(874, "7781438-C")
//};

//List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>()
//{
//    new ContaCorrente(951, "5679787-E"),
//    new ContaCorrente(321, "4456668-F"),
//    new ContaCorrente(719, "7781438-G")
//};

//_listaDeContas2.AddRange(_listaDeContas3);
//_listaDeContas2.Reverse();

//for (int i = 0; i < _listaDeContas2.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas2[i].Conta}]");
//}

//Console.WriteLine("\n\n");

//var range = _listaDeContas3.GetRange(0, 1);
//for (int i = 0; i < range.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
//}

//Console.WriteLine("\n\n");

//_listaDeContas3.Clear();
//for (int i = 0; i < _listaDeContas3.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
//}
#endregion


new ByteBankAtendimento().AtendimentoAoCliente();



/* // Criei uma classe generica que quando instanciada posso usar qualquer tipo de objeto definindo apenas uma unica vez
Generico<int> teste1 = new Generico<int>();
teste1.Exibir(10);

Generico<string> teste2 = new Generico<string>();
teste2.Exibir("Ola Mundo!");
public class Generico<T>
{
    public void Exibir(T t)
    {
        Console.WriteLine($"Exibindo: {t}");
    }
}*/

#region Exercio 1 extra
/*int[] temperaturas = new int[7];

temperaturas[0] = 25;
temperaturas[1] = 28;
temperaturas[2] = 30;
temperaturas[3] = 22;
temperaturas[4] = 27;
temperaturas[5] = 32;
temperaturas[6] = 29;

int CalculaTemperaturaMedia(int[] temperatura)
{
    int acumular = 0;

    for (int i = 0; i < temperatura.Length; i++)
    {
        acumular += temperatura[i];
    }

    var media = acumular / temperatura.Length;

    return media;
}

var mediaDaTemperatura = CalculaTemperaturaMedia(temperaturas);

Console.WriteLine($"A média da temperatura é de {mediaDaTemperatura}");
*/
#endregion

#region Exercicio 2 
/*double[] array1 = { 10, 5, 16, 24, 7, 18 };

double CalculaMedia(double[] array)
{   
    double acumulador = 0;

    if ((array == null) || (array.Length == 0))
    {
        Console.WriteLine("Amostra de dados nula ou vazia.");
        return 0;
    }
    else
    {
        for (int i = 0; i < array.Length; i++)
        {          
            acumulador = acumulador + array[i];
        }

        double media = acumulador / array.Length;

    return media;
    }
}

CalculaMedia(array1);
*/
#endregion